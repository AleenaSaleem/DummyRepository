using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Frontend.ViewModel
{
    public class LayoutModel
    {
        public ObservableCollection<string> Layoutlist = new ObservableCollection<string>()
        {
            "L-Layout",
            "U-Layout",
            "H-Layout"
        };

        public ObservableCollection<string> LayoutList
        {
            get { return this.Layoutlist; }
            set { this.Layoutlist = value; }
        }
       

             

    }
}
