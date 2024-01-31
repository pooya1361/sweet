namespace sweet.Models.DAL
{
    public interface IRepository
    {
        List<Customer> GetCustomers();
        List<Country> GetCountries();
		bool AddCustomer(string name, int countryId);
	}
}
