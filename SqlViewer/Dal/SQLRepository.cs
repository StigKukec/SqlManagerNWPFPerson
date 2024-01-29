using SqlViewer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlViewer.Dal
{
    class SQLRepository : IRepository
    {
        #region constants
        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string SelectDatabases = "SELECT name As Name FROM sys.databases";
        private const string SelectEntities = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.{1}S";
        private const string SelectProcedures = "SELECT SPECIFIC_NAME as Name, ROUTINE_DEFINITION as Definition FROM {0}.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'";
        private const string SelectColumns = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}'";
        private const string SelectProcedureParameters = "SELECT PARAMETER_NAME as Name, PARAMETER_MODE as Mode, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='{1}'";
        private const string SelectQuery = "SELECT * FROM {0}.{1}.{2}";
        #endregion

        private static bool loginValid = false;

        private string? cs;

        public IEnumerable<Database> GetDatabases()
        {
            using (SqlConnection con = new(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = SelectDatabases;
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return new Database
                            {
                                Name = dataReader[nameof(Database.Name)].ToString()
                            };
                        }
                    }
                }
            }
        }
        public IEnumerable<Procedure> GetProcedures(Database database)
        {
            using (SqlConnection con = new(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectProcedures, database.Name);
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return new Procedure
                            {
                                Name = dataReader[nameof(Procedure.Name)].ToString(),
                                Definition = dataReader[nameof(Procedure.Definition)].ToString(),
                                Database = database
                            };
                        }
                    }
                }
            }
        }
        public IEnumerable<Parameter> GetParameters(Procedure procedure)
        {
            using (SqlConnection con = new(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectProcedureParameters, procedure.Database?.Name, procedure.Name);
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return new Parameter
                            {
                                Mode = dataReader[nameof(Parameter.Mode)].ToString(),
                                DataType = dataReader[nameof(Parameter.DataType)].ToString(),
                                Name = dataReader[nameof(Parameter.Name)].ToString()
                            };
                        }
                    }
                }
            }
        }
        public IEnumerable<Column> GetColumns(DBEntity entity)
        {
            using (SqlConnection con = new(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectColumns, entity.Database?.Name, entity.Name);
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return new Column
                            {
                                Name = dataReader[nameof(Column.Name)].ToString(),
                                DataType = dataReader[nameof(Column.DataType)].ToString(),
                            };
                        }
                    }
                }
            }
        }
        public IEnumerable<DBEntity> GetDBEntities(Database database, DBEntityType entityType)
        {
            using (SqlConnection con = new(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = string.Format(SelectEntities, database.Name, entityType.ToString());
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return new DBEntity
                            {
                                Name = dataReader[nameof(DBEntity.Name)].ToString(),
                                Schema = dataReader[nameof(DBEntity.Schema)].ToString(),
                                Database = database
                            };
                        }
                    }
                }
            }
        }
        DataSet ds = new();
        SQLResult sr = new(string.Empty);
        public SQLResult SendSQLCommand(string command, Database database)
        {
            try
            {
                command = $"use {database.Name} {command}";
                using SqlConnection con = new(cs);
                con.Open();
                using SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = command;
                SqlDataAdapter sqlDataAdapter = new(command, con);
                sqlDataAdapter.Fill(ds);
                sr.Message = "Succesfull command.";
                sr.MessageColor = Color.Green;
                if (ds.Tables[0] != null)
                {
                    string message = $"({ds.Tables[0].Rows.Count} rows affected)";
                    sr.Result = ds.Tables[0];
                }
                return sr;
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    return new SQLResult(ex.Message) { MessageColor = Color.Red };
                }
                return new SQLResult("Succesful command.\nCommand doesn't retreve the table.") { MessageColor = Color.Green };
                // throw new Exception("Error in fetching the data from SQL database");
            }
        }
        public void Login(string server, string username, string password)
        {

            using (SqlConnection connection = new(string.Format(ConnectionString, server, username, password)))
            {
                connection.Open();
                cs = string.Format(ConnectionString, server, username, password);
                loginValid = true;
            }
        }
        public static bool LoginSuccess() => loginValid;

        public DataSet CreateDataset(DBEntity dbEntity)
        {
            using SqlConnection con = new(cs);
            SqlDataAdapter da = new(string.Format(SelectQuery, dbEntity.Database?.Name, dbEntity.Schema, dbEntity.Name), con);
            DataSet ds = new();
            da.Fill(ds);
            ds.Tables[0].TableName = dbEntity.Name;
            return ds;

        }
    }
}
