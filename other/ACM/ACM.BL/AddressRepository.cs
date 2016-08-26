namespace ACM.BL
{
    class AddressRepository
    {
        public Address Retrieve(int addressId)
        {
            Address address = new Address(addressId);

            if (addressId == 1)
            {
                address.StreetLine1 = "123 Main Street";
                address.StreetLine2 = "Suite 007";
                address.City = "Dallas";
                address.State = "TX";
                address.PostalCode = "12345";
                address.Country = "USA";
                address.AddressType = 1;
            }

            return address;
        }

        public bool Save(Address address)
        {
            // Code that saves the defined address.
            return true;
        }
    }
}
