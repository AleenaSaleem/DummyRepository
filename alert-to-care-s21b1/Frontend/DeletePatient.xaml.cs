using Frontend.ApiCalls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
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
    /// Interaction logic for DeletePatient.xaml
    /// </summary>
    public partial class DeletePatient : UserControl
    {
        ObservableCollection<string> _patientIdList;
        public DeletePatient()
        {
            InitializeComponent();
            this._patientIdList = new ObservableCollection<string>();
            this.DataContext = this;
            RetrievePatients();
        }

        public ObservableCollection<string> PatientIdList
        {
            get { return this._patientIdList; }
            set { this._patientIdList = value; }
        }

        public void RetrievePatients()
        {
            var patients = new PatientApiCalls().GetAllPatients();
            foreach(var patient in patients)
            {
                this.PatientIdList.Add(patient.PatientId);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = new PatientApiCalls().RemovePatient(this.patientIdList.SelectedItem.ToString());
            MessageBox.Show(result);
            Application.Current.MainWindow.Content = new MainPage();
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        { 
            Application.Current.MainWindow.Content = new MainPage();
        }
    }
}
