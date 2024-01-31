using System.ComponentModel.DataAnnotations;

namespace sweet.Models
{
	public class newCustomerModel
	{
		[Required]
		public string name { get; set; }
		public int countryId { get; set; }
	}
}
