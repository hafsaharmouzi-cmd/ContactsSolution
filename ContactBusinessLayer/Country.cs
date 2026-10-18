using System;
using System.Data;
using ContactsDataAccessLayer;



namespace ContactBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }

        public clsCountry() 
        {
            this.ID = -1;
            this.Name = "";
            Mode = enMode.AddNew;
        }
        private clsCountry(int ID , string Name)
        {
            this.ID=ID;
            this.Name=Name;
            Mode = enMode.Update;
        }

        public static clsCountry Find(int ID)
        {

            string Name = "";
            
            if (clsCountryDataAcess.GetCountryByID(ID,ref Name))

                return new clsCountry(ID,Name);
            else
                return null;

        }
        public static clsCountry FindByName(string Name)
        {
            int ID = -1;
            if (clsCountryDataAcess.GetCountryByName(Name, ref ID))
                return new clsCountry(ID, Name);
            else
                return null;
        }

        public static bool isCountryExist(int ID)
        {
            return clsCountryDataAcess.IsCountryExist(ID);
        }

        public static bool isCountryExistSearchByName(string Name)
        {
            return clsCountryDataAcess.IsCountryExistSearchByName(Name);
        }

        private bool _AddNewCountry()
        {
            //call DataAccess Layer 

            this.ID = clsCountryDataAcess.AddNewCountry(this.Name);
            return (this.ID != -1);
        }

        private bool _UpdateCountry()
        {
            //call DataAccess Layer 

            return clsCountryDataAcess.UpdateCountry(this.ID,this.Name);
        }
        public static bool DeleteCountry(int ID)
        {
            return clsCountryDataAcess.DeleteCountry(ID);
        }
        public static DataTable GetAllCountry()
        {
            return clsCountryDataAcess.GetAllCountries();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCountry();

            }

            return false;
        }
    }
}
