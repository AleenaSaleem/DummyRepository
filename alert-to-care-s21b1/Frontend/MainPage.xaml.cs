using Backend.Models;
using Frontend.ApiCalls;
using Frontend.ViewModel;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        readonly Dictionary<string, Func<int, List<int>>> BedLayoutFunctionCall;
        public Icudetails _icuDetails;
        
        public MainPage()
        {
            InitializeComponent();
            _icuDetails = new Icudetails();
            this.DataContext = _icuDetails;
           
            BedLayoutFunctionCall = new Dictionary<string, Func<int, List<int>>>
            {
                { "L" , LBedLayout},
                { "U", UBedLayout },
                { "H", HBedLayout }
            };
            SetUp("IC1");
        }

        public void SetUp(string icuId)
        {
            var beds = new BedApiCalls().GetAllBedsFromAnIcu(icuId);
            CreateAndPlaceBeds(beds);
            RetrieveIcu(icuId);
        }

        public void RetrieveIcu(string icuId)
        {
            var icu = new IcuApiCalls().GetIcu(icuId);
            _icuDetails.UpdateIcuDetails(icu);
        }
        private void CreateAndPlaceBeds(ObservableCollection<BedModel> BedList)
        {
            var index = BedLayoutFunctionCall["U"].Invoke(BedList.Count);

            //var index = UBedLayout(BedList);
            for(int i=0; i < index[0]; i++)
            {
                Button newBed = new Button
                {
                    Content = BedList[i].BedId,
                    Width = 50,
                    Height = 50
                };

                V1StackPanel.Children.Add(newBed);
            }

            index[1] = index[1] + index[0];
            for (int i = index[0]; i < index[1]; i++)
            {
                Button newBed = new Button
                {
                    Content = BedList[i].BedId,
                    Width = 50,
                    Height = 50
                };
                HStackPanel.Children.Add(newBed);
            }

            index[2] = index[2] + index[1];
            for (int i = index[1] ; i < index[2]; i++)
            {
                Button newBed = new Button
                {
                    Content = BedList[i].BedId,
                    Width = 50,
                    Height = 50
                };
                V2StackPanel.Children.Add(newBed);
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if(MenuOptions.Visibility == Visibility.Collapsed)
                MenuOptions.Visibility = Visibility.Visible;
            else if (MenuOptions.Visibility == Visibility.Visible)
                MenuOptions.Visibility = Visibility.Collapsed;

        }

        private void ViewAll_Click(object sender, RoutedEventArgs e)
        {
           if (ViewAllOptions.Visibility == Visibility.Collapsed)
                ViewAllOptions.Visibility = Visibility.Visible;
            else if (ViewAllOptions.Visibility == Visibility.Visible)
                ViewAllOptions.Visibility = Visibility.Collapsed;
        }

        private List<int> LBedLayout(int noOfBeds)
        {
            var index = new List<int>();
            index.Add(noOfBeds/2);
            index.Add(noOfBeds / 2 + noOfBeds % 2);
            index.Add(0);
            return index;
        }
        private List<int> UBedLayout(int noOfBeds)
        {
            var index = new List<int>();
            //noOfBeds = 16;
            index.Add(noOfBeds / 3);
            index.Add(noOfBeds / 3 + noOfBeds % 3);
            index.Add(noOfBeds/3);
            return index;
        }
        private List<int> HBedLayout(int noOfBeds)
        {

            var index = new List<int>();
            index.Add(noOfBeds / 2 + noOfBeds % 2);
            index.Add(0);
            index.Add(noOfBeds / 2);
            return index;
        }

        /*public void update_Click(object sender, RoutedEventArgs e)
        {
            var beds = new BedApiCalls().GetAllBedsFromAnIcu("IC1");
            CreateAndPlaceBeds(beds);
            RetrieveIcu();
        }*/
    }
}
