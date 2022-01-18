using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Persons.DataModel;
using Persons.Lib;

namespace Persons.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var db = new DB();
            ListOfPersons.ItemsSource = db.GetAllPersons();
        }

        private void ListOfPersons_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var person = (sender as ListBox)?.SelectedItem as Person;
            Input_Id.Text = person?.Id.ToString();
            Input_FirstName.Text = person?.FirstName;
            Input_LastName.Text = person?.LastName;
            Input_Age.Text = person?.Age.ToString();
            Input_IsDelete.IsChecked = person?.IsDelete;
        }

        private void Button_Save_OnClick(object sender, RoutedEventArgs e)
        {
            var person = new Person
            {
                Id = int.Parse(Input_Id.Text),
                FirstName = Input_FirstName.Text,
                LastName = Input_LastName.Text,
                Age = int.Parse(Input_Age.Text),
                IsDelete = (bool)Input_IsDelete.IsChecked
            };

            var db = new DB();
            var res = db.UpdatePerson(person);

            MessageBox.Show(res.ToString());

            ListOfPersons.ItemsSource = db.GetAllPersons();
        }
    }
}