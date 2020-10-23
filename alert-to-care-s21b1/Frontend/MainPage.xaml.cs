using Backend.Models;
using Frontend.ViewModel;
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

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        
        public MainPage()
        {
            InitializeComponent();

            List<Backend.Models.BedModel> bedList = new List<BedModel>();
            CreateAndPlaceBeds(bedList);

        }

        private void CreateAndPlaceBeds(List<BedModel> BedList)
        {

            var index = UBedLayout(BedList);
            for(int i=0; i < index[0]; i++)
            {
                Button newBed = new Button
                {
                    Content = i.ToString(),
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
                    Content = i.ToString(),
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
                    Content = i.ToString(),
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

        private List<int> LBedLayout(List<BedModel> BedList)
        {
            var index = new List<int>();
            int noOfBeds = BedList.Count;
            index.Add(noOfBeds/2);
            index.Add(noOfBeds / 2 + noOfBeds % 2);
            index.Add(0);
            return index;
        }
        private List<int> UBedLayout(List<BedModel> BedList)
        {
            var index = new List<int>();
            int noOfBeds = BedList.Count;
            noOfBeds = 16;
            index.Add(noOfBeds / 3);
            index.Add(noOfBeds / 3 + noOfBeds % 3);
            index.Add(noOfBeds/3);
            return index;
        }
        private List<int> HBedLayout(List<BedModel> BedList)
        {

            var index = new List<int>();
            int noOfBeds = BedList.Count;
            index.Add(noOfBeds / 2 + noOfBeds % 2);
            index.Add(0);
            index.Add(noOfBeds / 2);
            return index;
        }

    }
}
