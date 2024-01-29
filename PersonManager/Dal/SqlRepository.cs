using PersonManager.Models;
using PersonManager.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;


namespace PersonManager.Dal
{
    class SqlRepository : IRepository
    {
        private readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString; 
        public void AddPerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
            new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
            {
                Value = person.Picture
            });
            var id = new SqlParameter(nameof(person.IDPerson), System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            cmd.Parameters.Add(id);

            cmd.ExecuteNonQuery();
            person.IDPerson = (int)id.Value;
        }

        public void DeletePerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
            cmd.ExecuteNonQuery();
        }

        public IList<Person> GetPeople()
        {
            IList<Person> list = new List<Person>();
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(ReadPerson(reader));
            }


            return list;
        }

        public Person GetPerson(int id)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), id);
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ReadPerson(reader);
            }

            throw new ArgumentException("Wrong id");
        }

        private Person ReadPerson(SqlDataReader reader)
        {
            return new Person
            {
                IDPerson = /*(int)reader["ID"]*/(int)reader[nameof(Person.IDPerson)],
                FirstName = reader[nameof(Person.FirstName)].ToString(),
                LastName = reader[nameof(Person.LastName)].ToString(),
                Age = (int)reader[nameof(Person.Age)],
                Email = reader[nameof(Person.Email)].ToString(),
                Picture = ImageUtils.ByteArrayFromReader(reader, nameof(Person.Picture))
            };
        }

        public void UpdatePerson(Person person)
        {
            using SqlConnection con = new(cs);
            con.Open();
            using SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = MethodBase.GetCurrentMethod()?.Name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
            cmd.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
            cmd.Parameters.AddWithValue(nameof(Person.Age), person.Age);
            cmd.Parameters.AddWithValue(nameof(Person.Email), person.Email);
            cmd.Parameters.Add(
            new SqlParameter(nameof(Person.Picture), System.Data.SqlDbType.Binary, person.Picture!.Length)
            {
                Value = person.Picture
            });
            cmd.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
            cmd.ExecuteNonQuery();
        }
    }
}
