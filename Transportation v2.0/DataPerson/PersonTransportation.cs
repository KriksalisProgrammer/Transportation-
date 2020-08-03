using System;
using System.Collections.Generic;
using System.Text;
using Transportation_v2._0.Models;

namespace Transportation_v2._0.DataPerson
{
   public class PersonTransportation:Notify
    {
        
        private uint _ID;
        private string _Name;
        private string _Surname;
        private string _City;
        private string _CityBef;
        private long _NumberT;
        public uint Id { 
            get { return _ID; } 
            set { if (Id == value)
                    return;
                _ID = value;
                OnPropertyChanged(); } }
        public string Name
        {
            get { return _Name; }
            set {
                if (Name == value)
                    return;
               _Name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        { get { return _Surname; } 
            set
            {
                if (Surname == value)
                    return;
                _Surname = value;
                OnPropertyChanged();
            } }
        public DateTime Date
        {
            get;set;
        } = DateTime.Now;
        public string City
        {
            get { return _City; }
            set
            {
                if (City == value)
                    return;
                _City = value;
                OnPropertyChanged();
            }
        }
        public string City_before { 
            get { return _CityBef; }
            set
            {
                if (City_before == value)
                    return;
                _CityBef = value;
                OnPropertyChanged();
            } }
        public long Number_Telephone
        { get { return _NumberT; }
            set
            {
                if (Number_Telephone == value)
                    return;
                _NumberT = value;
                OnPropertyChanged();
            } }

    }
}
