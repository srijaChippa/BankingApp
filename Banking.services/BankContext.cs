using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.services
{
	public class BankContext : DbContext
	{


		public DbSet<Account> Accounts { get; set; }
		public DbSet<Transfer> Transfers { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LAPTOP-FJI9I0SL;Initial Catalog=BankingApp;Integrated Security=true;Trust Server Certificate=true");
		}


	}
}

	