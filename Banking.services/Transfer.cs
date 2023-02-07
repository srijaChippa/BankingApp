using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.services
{
	
		[Table("Transfer")]

		public class Transfer
		{
			[Key]
			public int TransferId { get; set; }
			public int FromAccountNumber { get; set; }
			public int ToAccountNumber { get; set; }
			public int AmountDebited { get; set; }
			public DateTime TransactionTime { get; set; }
			public decimal ToAccountBalance { get; set; }
			public decimal FromAccountBalance { get; set; }
		}
	}

