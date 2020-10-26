using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using Frontend.ApiCalls;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for DeleteIcu.xaml
    /// </summary>
    public partial class DeleteIcu : UserControl
    {
        ObservableCollection<string> _icuList = new ObservableCollection<string>();
        public DeleteIcu()
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
        public ObservableCollection<string> IcuList
        {
            get { return this._icuList; }
            set { this._icuList = value; }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var icuId = this.icuList.SelectedItem.ToString();
            var result = new IcuApiCalls().RemoveIcu(icuId);
            MessageBox.Show(result);
            if(result == "ICU deleted successfully")
            {
                if(_icuList.Count == 1)
                {
                    Application.Current.MainWindow.Content = new Configuration();
                }
                else
                {
                    Application.Current.MainWindow.Content = new MainPage();
                }
            }
            
            
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainPage();
        }
    }
}
