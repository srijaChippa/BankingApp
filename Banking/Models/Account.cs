using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Models
{
	[Table("Account")]
	public class Account
	{
		[Key]
		public int AccountNumber { get; set; }
		public string AccountName { get; set; }
		public decimal Balance { get; set; }

	}
}
