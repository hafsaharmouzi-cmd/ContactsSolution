
using System;
using System.Data;
using ContactBusinessLayer;
using ContactsBusinessLayer;

namespace ContactsConsolApp
{
    internal class Program
    {
        static void testFindContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Console.WriteLine(Contact1.FirstName+ " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else 
            {
                Console.WriteLine("Contact [" + ID + "] Not found!");   
            }
        }
        static void testAddNewContact()


        {
            clsContact Contact1 = new clsContact();
            Contact1.FirstName = "Fadi";
            Contact1.LastName = "Maher";
            Contact1.Email = "A@a.com";
            Contact1.Phone = "010010";
            Contact1.Address = "address1";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";
          
           if (Contact1.Save())
            {

                Console.WriteLine("Contact Added Successfully with id=" + Contact1.ID);
            }

        }
        static void testUpdateContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                //update whatever info you want
                Contact1.FirstName = "Fadi";
                Contact1.LastName = "Maher";
                Contact1.Email = "A2@a.com";
                Contact1.Phone = "2222";
                Contact1.Address = "222";
                Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
                Contact1.CountryID = 1;
                Contact1.ImagePath = "";

                if (Contact1.Save())
                {

                    Console.WriteLine("Contact updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }
        static void testDeleteContact(int ID)
        {
            if(clsContact.isContactExist(ID))
            {
                if (clsContact.DeleteContact(ID))
                {
                    Console.WriteLine("contact delete succefully");
                }
                else
                {
                    Console.WriteLine("Failed to delete Contact ");
                }
            }
            else
            {
                Console.WriteLine("Contact is not found");
            }
            
        }
        static void ListContacts()
        {

            DataTable dataTable = clsContact.GetAllContacts();
           
            Console.WriteLine("Contacts Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]},  {row["FirstName"]} {row["LastName"]}");
            }

        }
        static void testIsContactExist(int ID)
        {
            if (clsContact.isContactExist(ID))
            {
                Console.WriteLine("Yes, contact is here");
            }
            else
            { Console.WriteLine("no Contact is not here"); }


        }

        // TEST function for Country
        static void testFindCountryByID(int ID)
        {

            clsCountry Country = clsCountry.Find(ID);
            
            if (Country != null)
            {
                Console.WriteLine("Country Name : " + Country.Name);
                Console.WriteLine("Country Code : " + Country.Code);
                Console.WriteLine("Country PhoneCode " + Country.PhoneCode);
                
            }
            else
            {
                Console.WriteLine("Country [" + ID + "] Not found!");
            }
        }
        static void testFindCountryByName(string Name)
        {
            clsCountry Country = clsCountry.FindByName(Name);

            if (Country != null)
            {
                Console.WriteLine("Country ID : " + Country.ID);
                Console.WriteLine("Country Code : " + Country.Code);
                Console.WriteLine("Country PhoneCode " + Country.PhoneCode);
            }
            else
            {
                Console.WriteLine("Country [" + Name + "] Not found!");
            }
        }
        static void testAddNewCountry()
        {
            clsCountry Country = new clsCountry();

            Country.Name = "France";
            Country.Code = "FR";
            Country.PhoneCode = "33";

            if (Country.Save())
            {

                Console.WriteLine("Country Added Successfully with id=" + Country.ID);
            }
            else
            {
                Console.WriteLine("failed");
            }
        }
        static void testDeleteCountry(int ID)
        {
            if (clsCountry.isCountryExist(ID))
            {
                if (clsCountry.DeleteCountry(ID))
                {
                    Console.WriteLine("Country delete succefully");
                }
                else
                {
                    Console.WriteLine("Failed to delete Country ");
                }
            }
            else
            {
                Console.WriteLine("Country is not found");
            }
        }
        static void testUpdateCountry(int ID)
        {
            clsCountry Country = clsCountry.Find(ID);

            if (Country != null)
            {
                //update whatever info you want
                Country.Name = "Egypt";
                Country.Code = "EGP";
                Country.PhoneCode = "234";

                if (Country.Save())
                {

                    Console.WriteLine("Country updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void ListCountry()
        {
            DataTable dataTable = clsCountry.GetAllCountry();

            Console.WriteLine("Country Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]},  {row["CountryName"]} , {row["Code"]} , {row["PhoneCode"]}");
            }
        }

        static void testIsCountryExistByID(int ID)
        {
            if (clsCountry.isCountryExist(ID))
            {
                Console.WriteLine("Yes, country is exist");
            }
            else
            { Console.WriteLine("no Country is not exist"); }


        }
        static void testIsCountryExistByName(string Name)
        {
            if (clsCountry.isCountryExistSearchByName(Name))
            {
                Console.WriteLine("Yes, country is exist");
            }
            else
            { Console.WriteLine("no Country is not exist"); }

        }
        static void Main(string[] args)
        {


            // testDeleteCountry(12);

            // ListCountry();
            // testIsCountryExistByID(1);
            //testIsCountryExistByName("Morocco");

            //testUpdateCountry(8);

            //testAddNewCountry();

            // testDeleteCountry(1008);
            testFindCountryByID(1007);
            testFindCountryByName("France");

            Console.ReadKey();

        }
    }
}
