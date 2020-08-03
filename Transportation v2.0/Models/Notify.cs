using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Transportation_v2._0.Models
{
    public class Notify: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name = " ")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
