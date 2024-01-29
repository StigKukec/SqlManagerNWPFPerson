using PersonManager.Models;
using PersonManager.ViewModels;


namespace PersonManager
{
    /// <summary>
    /// Interaction logic for ListPeoplePage.xaml
    /// </summary>
    public partial class ListPeoplePage : FramedPage
    {
        public ListPeoplePage(PersonViewModel personViewModel) : base(personViewModel)
        {
            InitializeComponent();
            lvPeople.ItemsSource = personViewModel.People;
        }

        private void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Frame?.Navigate(new EditPersonPage(PersonViewModel)
            {
                Frame = Frame
            });
        }

        private void BtnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lvPeople.SelectedItem != null)
            {
                Frame?.Navigate(new EditPersonPage(PersonViewModel, lvPeople.SelectedItems as Person)
                {
                    Frame = Frame
                });
            }
        }

        private void BtnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lvPeople.SelectedItems != null)
            {
                PersonViewModel.People.Remove((lvPeople.SelectedItem as Person)!);
            }
        }
    }
}
