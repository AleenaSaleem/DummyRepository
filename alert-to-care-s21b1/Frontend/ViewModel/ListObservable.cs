using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Frontend.ViewModel
{
    class ListObservable
    {
        static Backend.Models.BedModel bed1 = new Backend.Models.BedModel()
        {
            IcuId = "IC1",
            BedId = "IC1B1",
            BedOccupancyStatus = "Free",
            Location = "First"
        };

        static Backend.Models.BedModel bed2 = new Backend.Models.BedModel()
        {
            IcuId = "IC1",
            BedId = "IC1B2",
            BedOccupancyStatus = "Occupied",
            Location = "Second"
        };



        public ObservableCollection<Backend.Models.BedModel> Bedlist = new ObservableCollection<Backend.Models.BedModel>()
        {
            bed1,
            bed2
        };
        

        public ObservableCollection<Backend.Models.BedModel> BedList
        {
            get { return this.Bedlist; }
            set { this.Bedlist = value; }
        }

    }
}
