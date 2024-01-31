using sweet.Models;
using sweet.Models.DAL;
using sweet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sweet.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        List<Country> GetCountries();
        bool AddCustomer(string name, int countryId);
    }
    public class CustomerService: ICustomerService
    {
        private IRepository _repository;
        public CustomerService(IRepository repository) {
            this._repository = repository;
        }

        public List<Customer> GetCustomers() => _repository.GetCustomers();
        public List<Country> GetCountries() => _repository.GetCountries();

        public bool AddCustomer(string name, int countryId) => _repository.AddCustomer(name, countryId);
	}
}