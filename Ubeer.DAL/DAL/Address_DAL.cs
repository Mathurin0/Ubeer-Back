namespace Ubeer.DAL.DAL
{
    public class Address_DAL
    {
        public int ID { get; set; }

        public int IdUser { get; set; }

        public string Libelle { get; set; }

        public string Address { get; set; }

        public string AddressComplement { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public Address_DAL(int id, int idUser, string libelle, string address, string addressComplement, string city, string region, string country, string postalCode, string phoneNumber) => (ID, IdUser, Libelle, Address, AddressComplement, City, Region, PostalCode, Country, PhoneNumber) = (id, idUser, libelle, address, addressComplement, city, region, postalCode, country, phoneNumber);

        public Address_DAL(int idUser, string libelle, string address, string addressComplement, string city, string region, string country, string postalCode, string phoneNumber) => (IdUser, Libelle, Address, AddressComplement, City, Region, PostalCode, Country, PhoneNumber) = (idUser, libelle, address, addressComplement, city, region, postalCode, country, phoneNumber);

    }
}
