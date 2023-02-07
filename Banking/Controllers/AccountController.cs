
using Banking.services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Authentication;

namespace Banking.Controllers
{
	[Route("Account")]
	public class AccountController : Controller
	{
		private readonly BankContext context;

		public AccountController()
		{
			this.context = new BankContext();
		}
        
            [Route("Index")]
		public async Task<IActionResult> Index()
		{
			//var acc= context.Accounts.ToList();

			return View();
			//return View(acc);
			//IEnumerable<Account> Accounts = null;


			//using (var client = new HttpClient())
			//{
			//	try
			//	{

			//		var responseTask = await client.GetAsync("http://localhost:7118/api/Account/Get");

			//		var result = responseTask;
			//		if (result.IsSuccessStatusCode)
			//		{
			//			var readTask = await result.Content.ReadAsAsync<IList<Account>>();

			//			Accounts = readTask;
			//		}
			//		else
			//		{
			//			//log response status here..

			//			Accounts = Enumerable.Empty<Account>();

			//			ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
			//		}
			//	}
			//	catch(Exception ex) 
			//	{
				
			//	}

			//}
			//return View(Accounts);

		}

		[HttpGet]
		[Route("Create")]
		public IActionResult Create()
		{
			return View();
		}
        [HttpPost]
        [Route("create")]
        public IActionResult Create([Bind("AccountName", "Balance")] Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();




			return RedirectToAction("Index");
        }

	

		[HttpGet]
		[Route("Edit/{accountNumber}")]
		public IActionResult Edit(int accountNumber)
		{

			var model = context.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault(); 


			return View(model);
		}
		[HttpPost]
		[Route("Edit/{accountNumber}")]
		public IActionResult Edit([Bind] Account account, int accountNumber)
		{
			context.Accounts.Update(account);
			context.SaveChanges();




			return RedirectToAction("Index");
		}
		[HttpGet]
		[Route("Delete/{accountNumber}")]
		public IActionResult Delete(int accountNumber)
		{
			var del= context.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
			return View(del);
		}

		[HttpPost]
		[Route("Delete/{accountNumber}")]
		public IActionResult Delete([Bind] Account account,int accountNumber)
		{
		var del= context.Accounts.Where(a=> a.AccountNumber == accountNumber).FirstOrDefault();
			context.Accounts.Remove(del);
			context.SaveChanges();
			return RedirectToAction("Index");
		}


	}
}
