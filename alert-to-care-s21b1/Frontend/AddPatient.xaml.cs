using Backend.Models;
using Frontend.ApiCalls;
using Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : UserControl
    {
        PatientDetails _patient;
        
        public AddPatient()
        {
            InitializeComponent();
            _patient = new PatientDetails();
            this.DataContext = _patient;
            this._patient.IcuIdList = new AddBed().IcuList;
        }
        public void RetrieveBeds()
        {
            this._patient.BedIdList.Clear();
            var bedsInIcu = new BedApiCalls().GetAllBedsFromAnIcu(this.icuIdList.SelectedItem.ToString()).ToList();
            foreach(var bed in bedsInIcu)
            {
                if(bed.BedOccupancyStatus == "Free")
                {
                    this._patient.BedIdList.Add(bed.BedId);
                }
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainPage();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            PatientModel patient = new PatientModel()
            {
                PatientId = this.bedIdList.SelectedItem.ToString()+this.name.Text.ToString(),
                IcuId = this.icuIdList.SelectedItem.ToString(),
                BedId = this.bedIdList.SelectedItem.ToString(),
                Name = this.name.Text.ToString(),
                Age = Int32.Parse(this.age.Text),
                Address = this.address.Text.ToString()
            };
            var result = new PatientApiCalls().AddPatient(patient);
            MessageBox.Show(result);
            Application.Current.MainWindow.Content = new MainPage();
        }

        private void icuIdList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RetrieveBeds();
        }
    }
}
