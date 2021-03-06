﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> vendors;

        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        public IEnumerable<Vendor> RetrieveAll()
        {
            var vendors = new List<Vendor>()
            {
                new Vendor()
                {
                    VendorId = 11, CompanyName = "Disney", Email = "publicrelations@disney.com"
                },
                new Vendor()
                {
                    VendorId = 37, CompanyName = "Google", Email = "google@gmail.com"
                },
                new Vendor()
                {
                    VendorId = 82, CompanyName = "Uber", Email = "uber@uber.net"
                },
                new Vendor()
                {
                    VendorId = 99, CompanyName = "Facebook", Email = "facebook@fb.com"
                },
                new Vendor()
                {
                    VendorId = 10, CompanyName = "Amazon", Email = "amazon@amazon.net"
                },
                new Vendor()
                {
                    VendorId = 69, CompanyName = "ESPN", Email = "espn@espn.net"
                }
            };

            return vendors;
        }

        public Vendor[] RetrieveArray()
        {
            var vendors = new Vendor[2]
            {
                new Vendor()
                {
                    VendorId = 11, CompanyName = "Disney", Email = "publicrelations@disney.com"
                },
                new Vendor()
                {
                    VendorId = 39, CompanyName = "Google", Email = "google@gmail.com"
                }
            };

            return vendors;
        }

        public List<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();

                vendors.Add(new Vendor() { CompanyName = "IBM", Email = "news@ibm.com", VendorId = 12345 });
                vendors.Add(new Vendor() { CompanyName = "GE", Email = "investorservices@ge.com", VendorId = 54321 });
            }

            foreach (var vendor in vendors)
            {
                Console.WriteLine(vendor);
            }

            return vendors;
        }

        public Dictionary<string, Vendor> RetrieveWithKeys()
        {
            var vendors = new Dictionary<string, Vendor>()
            {
                { "JP Morgan", new Vendor() { CompanyName = "JP Morgan", VendorId = 8, Email = "publicrelations@jpmorgan.com"} },
                { "Lockheed Martin", new Vendor() { CompanyName = "Lockheed Martin", VendorId = 10, Email = "investorservices@lockheed.com"} }
            };

            foreach (var element in vendors)
            {
                Console.WriteLine($"Key: {element.Key}, Value: {element.Value}");
            }

            //foreach (var companyName in vendors.Keys)
            //{
            //    Console.WriteLine(vendors[companyName]);
            //}

            //Console.WriteLine(vendors["JP Morgan"]);

            //Vendor vendor;

            //if (vendors.TryGetValue("Morgan", out vendor))
            //{
            //    Console.WriteLine(vendor);
            //}

            return vendors;
        }

        // Instead of having multiple method returning different types of collections, 
        // we could simple write one method that returns ICollection<T>. Arrays, Lists 
        // and Dictionaries all implement ICollection<T>.
        public ICollection<Vendor> RetrieveCollection()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();

                vendors.Add(new Vendor() { CompanyName = "IBM", Email = "news@ibm.com", VendorId = 12345 });
                vendors.Add(new Vendor() { CompanyName = "GE", Email = "investorservices@ge.com", VendorId = 54321 });
            }

            foreach (var vendor in vendors)
            {
                Console.WriteLine(vendor);
            }

            return vendors;
        }

        // The below method returns a generic type T. That type <T> is defined on 
        // the method itself as opposed to directly on the class is because no other 
        // class members are generic. Defining <T> only on the method that uses T 
        // simplifies things. The where T : struct clause is a generic constraint. 
        // In this case, RetrieveValue's T is limited to value types since all 
        // structs are value types.
        public T RetrieveValue<T>(string sql, T defaultValue) where T : struct
        {
            // Call the database to retrieve the value
            // If no value is returned, return the default value
            T value = defaultValue;

            return value;
        }

        // Since the above method constrained T to only value types and strings 
        // are reference types, the below overloaded method must be written to 
        // account for strings. 
        public string RetrieveValue(string sql, string defaultValue)
        {
            string value = defaultValue;

            return value;
        }

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }

        public IEnumerable<Vendor> RetrieveWithIterator()
        {
            // Get the data from a repository.
            Retrieve();

            // Yield returns each element in the collection one-at-a-time.
            foreach (var vendor in vendors)
            {
                Console.WriteLine($"Vendor Id: {vendor.VendorId}");

                // When the yield statement executes, the current location in this 
                // code is remembered. The single vendor is returned to the calling 
                // code and processing continues from there. Executing is re-started 
                // from this location the next time the interator method is called. 
                // The iterator is consuming from the calling code using a foreach 
                // statement or with a LINQ expression. 
                yield return vendor;
            }
        } 
    }
}
