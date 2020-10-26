using Backend.Models;
using Frontend.ApiCalls;
using Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

            RetrieveAllIcusIds();
            this.icuComboBox.SelectedIndex = 0;
            SetUp(_icuDetails.IcuIdList[0]);
        }

        public void SetUp(string icuId)
        {
            var icu = RetrieveIcu(icuId);
            var beds = new BedApiCalls().GetAllBedsFromAnIcu(icuId);
            CreateAndPlaceBeds(beds,icu);
        }

        public IcuModel RetrieveIcu(string icuId)
        {
            var icu = new IcuApiCalls().GetIcu(icuId);
            _icuDetails.UpdateIcuDetails(icu);
            return icu;
        }

        public void RetrieveAllIcusIds()
        {
            this._icuDetails.IcuIdList.Clear();
            var allIcus = new IcuApiCalls().GetAllIcus();
            foreach(var icu in allIcus)
            {
                this._icuDetails.IcuIdList.Add(icu.IcuId);
            }          
        }


        private void CreateAndPlaceBeds(ObservableCollection<BedModel> BedList,IcuModel icu)
        {
            var index = BedLayoutFunctionCall[icu.Layout].Invoke(icu.MaxBeds);
            var noOfBeds = icu.NoOfBeds;
            V1StackPanel.Children.Clear();
            HStackPanel.Children.Clear();
            V2StackPanel.Children.Clear();

            //var index = UBedLayout(BedList);
            for(int i=0; i < index[0] && i < noOfBeds ; i++)
            {
                Button newBed = new Button
                {
                    Content = BedList[i].BedId,
                    Width = 50,
                    Height = 50
                };
                newBed.MouseEnter += new MouseEventHandler(MouseOverBed);
                V1StackPanel.Children.Add(newBed);
            }

            index[1] = index[1] + index[0];
            for (int i = index[0]; i < index[1] && i < noOfBeds; i++)
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
            for (int i = index[1] ; i < index[2] && i < noOfBeds; i++)
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

       private void MouseOverBed(object sender, RoutedEventArgs e)
       {
            var btn = sender as Button;
            var bedId = btn.Content.ToString();
            Button optionButton = new Button()
            {
                Content = "add/remove patient",
                Width =70,
                Height=30
            };
            MessageBox.Show(bedId);
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

        private List<int> LBedLayout(int maxBeds)
        {
            var index = new List<int>();
            index.Add(maxBeds/2);
            index.Add(maxBeds / 2 + maxBeds % 2);
            index.Add(0);
            return index;
        }
        private List<int> UBedLayout(int maxBeds)
        {
            var index = new List<int>();
            //noOfBeds = 16;
            int temp = maxBeds / 3;
            index.Add(temp);
            index.Add(temp + maxBeds % 3);
            index.Add(temp);
            return index;
        }
        private List<int> HBedLayout(int maxBeds)
        {

            var index = new List<int>();
            index.Add(maxBeds / 2 + maxBeds % 2);
            index.Add(0);
            index.Add(maxBeds / 2);
            return index;
        }

        private void Icu_Changed(object sender, SelectionChangedEventArgs e)
        {
            SetUp(this.icuComboBox.SelectedItem.ToString());
        }

        /*public void update_Click(object sender, RoutedEventArgs e)
        {
            var beds = new BedApiCalls().GetAllBedsFromAnIcu("IC1");
            CreateAndPlaceBeds(beds);
            RetrieveIcu();
        }*/
    }
}
