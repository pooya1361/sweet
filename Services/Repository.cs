using MySql.Data.MySqlClient;
using sweet.Models;
using sweet.Models.DAL;
using System.Diagnostics.Metrics;

namespace sweet.Services
{
    public class Repository: IRepository
    {
        public Repository() { }
        private MySqlConnection Connection
        {
            get
            {
                return
                       new MySqlConnection("server=localhost;port=3306;database=sweet;user=user;password=Sweetsystems");
            }
        }

        public List<Customer> GetCustomers()
        {
            string query = "SELECT * FROM sweet.customers";

            List<Customer> customers = new List<Customer>();


            using (MySqlConnection connection = Connection)
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.id = (int)reader["id"];
                            customer.name = (string)reader["name"];
                            customer.countryId = (int)reader["country"];
                            customers.Add(customer);
                        }
                    }
                }
            }
            return customers;
        }
        public List<Country> GetCountries()
        {
            string query = "SELECT * FROM sweet.countries";

            List<Country> countries = new List<Country>();


            using (MySqlConnection connection = Connection)
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Country country = new Country();
                            country.id = (int)reader["id"];
                            country.name = (string)reader["name"];
                            countries.Add(country);
                        }
                    }
                }
            }
            return countries;
        }

        public bool AddCustomer(string name, int countryId)
        {
			string query = "INSERT INTO sweet.customers (`name`,`country`) VALUES (@name, @country)";

            try
            {
				using (MySqlConnection connection = Connection)
				{
					connection.Open();
					using (MySqlCommand command = new MySqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@name", name);
						command.Parameters.AddWithValue("@country", countryId);
						command.ExecuteNonQuery();
					}
				}

			}
			catch (Exception ex)
            {
                return false;
            }
            return true;
		}
	}
}
