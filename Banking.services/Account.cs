using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Banking.services
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
