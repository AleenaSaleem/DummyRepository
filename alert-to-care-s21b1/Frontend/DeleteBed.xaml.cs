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
    /// Interaction logic for DeleteBed.xaml
    /// </summary>
    public partial class DeleteBed : UserControl
    {
        ObservableCollection<string> _icuList = new ObservableCollection<string>();
        ObservableCollection<string> _bedList = new ObservableCollection<string>();

        public DeleteBed()
        {
            InitializeComponent();
            _icuList = RetrieveIcus();
            this.DataContext = this;

        }
        public ObservableCollection<string> RetrieveIcus()
        {
            var icus = new IcuApiCalls().GetAllIcus();
            foreach (var icu in icus)
            {
                this.IcuList.Add(icu.IcuId);
            }
            return this.IcuList;
        }

        public ObservableCollection<string> RetrieveBeds()
        {
            this.BedList.Clear();
            
            var beds = new BedApiCalls().GetAllBedsFromAnIcu(this.icuList.SelectedItem.ToString());
            foreach(var bed in beds)
            {
                this.BedList.Add(bed.BedId);
            }
            return this.BedList;

        }

        public ObservableCollection<string> IcuList
        {
            get { return this._icuList; }
            set { this._icuList = value; }
        }

        public ObservableCollection<string> BedList
        {
            get { return this._bedList; }
            set { this._bedList = value; }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var icuId = this.icuList.SelectedItem.ToString();
            var bedId = this.bedList.SelectedItem.ToString();
            new BedApiCalls().RemoveBed(icuId,bedId);
            Application.Current.MainWindow.Content = new MainPage();
        }

        
        private void icuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RetrieveBeds();
        }
    }
}
