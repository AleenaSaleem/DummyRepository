using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Frontend.ApiCalls;

namespace Frontend.ViewModel
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
            new IcuApiCalls().RemoveIcu(icuId);
            Application.Current.MainWindow.Content = new MainPage();
        }
    }
}
