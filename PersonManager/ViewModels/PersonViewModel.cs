using PersonManager.Dal;
using PersonManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.ViewModels
{
    public class PersonViewModel
    {
        public ObservableCollection<Person> People { get; set; }
        public PersonViewModel()
        {
            People = new ObservableCollection<Person>(RepoFactory.GetRepository().GetPeople());
            People.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepoFactory.GetRepository().AddPerson(People[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepoFactory.GetRepository().DeletePerson(e.OldItems!.OfType<Person>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepoFactory.GetRepository().UpdatePerson(e.NewItems!.OfType<Person>().ToList()[0]);
                    break;
            }
        }
        public void UpdatePerson(Person person) => People[People.IndexOf(person)] = person;
    }
}
