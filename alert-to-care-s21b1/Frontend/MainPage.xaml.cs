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
        ListObservable bedListObserver = new ListObservable();

        public MainPage()
        {
            InitializeComponent();
            this.DataContext = bedListObserver;

            CreateAndPlaceBeds();


        }

        private void CreateAndPlaceBeds()
        {
            
            for(int i=0; i < 5; i++)
            {
                Button newBed = new Button
                {
                    Content = i.ToString(),
                    Width = 50,
                    Height = 50
                };

                V1StackPanel.Children.Add(newBed);
            }

            for (int i = 0; i < 5; i++)
            {
                Button newBed = new Button
                {
                    Content = i.ToString(),
                    Width = 50,
                    Height = 50
                };
                HStackPanel.Children.Add(newBed);
            }

            for (int i = 0; i < 5; i++)
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
    }
}
