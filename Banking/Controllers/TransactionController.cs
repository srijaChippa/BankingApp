using Banking.DbEntity;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Controllers
{
    [Route("Transaction")]
    public class TransactionController : Controller
    {
        private readonly BankContext context;

        public TransactionController()
        {
            this.context = new BankContext();
        }
        [HttpGet]
        [Route("Index")]
           public IActionResult Index()
        {
            var trans=context.Transfers.ToList();

            return View("Transfer",trans);
        }
    }
}
