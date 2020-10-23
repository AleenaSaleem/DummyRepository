﻿using Frontend.ApiCalls;
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
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class Configuration : UserControl
    {
        LayoutModel layoutModel = new LayoutModel();

        public Configuration()
        {
            InitializeComponent();
            this.DataContext = layoutModel;
        }
        
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Application.Current.MainWindow;
            if (parentWindow.GetType() == typeof(MainWindow))
            {
                (parentWindow as MainWindow).Configuration.Visibility = Visibility.Collapsed;
                (parentWindow as MainWindow).MainPage.Visibility = Visibility.Visible;
            }
           this.AddIcu();
        }
        private void AddIcu()
        {
            var icuApiObj = new IcuApiCalls();
            var numIcus = icuApiObj._icus.Count;
            var icu = new Backend.Models.IcuModel()
            {
               IcuId = "IC"+(numIcus+1).ToString(),
               NoOfBeds =0,
               Layout = this.LayoutList.SelectedItem.ToString().Substring(0,1),
               MaxBeds = Int32.Parse(this.maxBeds.Text)
            };
            bool msg =icuApiObj.AddIcu(icu);
        }
    }
}