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

        public string Code { set; get; }  

        public string PhoneCode { set; get; }

        public clsCountry() 
        {
            this.ID = -1;
            this.Name = "";
            this.Code = "";
            this.PhoneCode = "";
            Mode = enMode.AddNew;
        }
        private clsCountry(int ID , string Name,string Code,string PhoneCode)
        {
            this.ID=ID;
            this.Name=Name;
            this.Code=Code;
            this.PhoneCode=PhoneCode;
            Mode = enMode.Update;
        }

        public static clsCountry Find(int ID)
        {

            string Name = "";
            string Code = "";
            string PhoneCode = "";
            
            if (clsCountryDataAcess.GetCountryByID(ID,ref Name,ref Code , ref PhoneCode))

                return new clsCountry(ID,Name,Code,PhoneCode);
            else
                return null;

        }
        public static clsCountry FindByName(string Name)
        {
            int ID = -1;
            string Code = "";
            string PhoneCode = "";
            if (clsCountryDataAcess.GetCountryByName(Name, ref ID,ref Code, ref PhoneCode))
                return new clsCountry(ID, Name,Code,PhoneCode);
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

            this.ID = clsCountryDataAcess.AddNewCountry(this.Name , this.Code, this.PhoneCode);
            return (this.ID != -1);
        }

        private bool _UpdateCountry()
        {
            //call DataAccess Layer 

            return clsCountryDataAcess.UpdateCountry(this.ID,this.Name,this.Code , this.PhoneCode);
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
