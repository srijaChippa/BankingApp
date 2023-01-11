using Banking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Banking.DbEntity
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

	
	

