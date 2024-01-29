using Microsoft.Win32;
using PersonManager.Models;
using PersonManager.Utils;
using PersonManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonManager
{
    /// <summary>
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Person? person;
        public EditPersonPage(PersonViewModel personViewModel, Person? person = null) : base(personViewModel)
        {
            InitializeComponent();
            this.person = person ?? new Person();
            DataContext = person;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }
        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FromValid())
            {
                person!.FirstName = tbFirstName.Text.Trim();
                person!.LastName = tbLastName.Text.Trim();
                person!.Age = int.Parse(tbAge.Text.Trim());
                person!.Email = tbEmail.Text.Trim();
                person!.Picture = ImageUtils.BitmapImageToByteArray((picture.Source as BitmapImage)!);
                if (person.IDPerson == 0)
                {
                    PersonViewModel.People.Add(person);
                }
                else
                {
                    PersonViewModel.UpdatePerson(person);
                }
                Frame?.NavigationService.GoBack();
            }
        }

        private bool FromValid()
        {
            bool ok = true;
            grid.Children.OfType<TextBox>().ToList().ForEach(x =>
            {
                x.Background = Brushes.White;
                if (string.IsNullOrEmpty(x.Text.Trim()) || "Int".Equals(x.Tag) && !int.TryParse(x.Text, out int i) || "Email".Equals(x.Tag) && !ValidationUtils.IsValidEmail(x.Text))
                {
                    ok = false;
                    x.Background = Brushes.LightCoral;
                }
            });

            pictureBorder.BorderBrush = Brushes.White;
            if (picture.Source == null)
            {
                ok = false;
                pictureBorder.BorderBrush = Brushes.Red;
            }
            return ok;
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { FileName = Filter };
            if (dialog.ShowDialog() == true)
            {
                picture.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }
    }
}
