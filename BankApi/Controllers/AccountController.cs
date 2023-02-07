using Banking.services;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase
	{
		private readonly BankContext _bankContext;
		public AccountController()
		{
			this._bankContext = new BankContext();
		}
		[HttpGet]
		[Route("Get")]
		public IActionResult Get()
		{
			var bank= _bankContext.Accounts.ToList();

			return Ok(bank);
		}
	}
}
