

using Banking.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Banking.Controllers
{
    [Route("TransferFunds")]
    public class TransferFundsController : Controller
    {
        private readonly BankContext context;

        public TransferFundsController()
        { 
            this.context = new BankContext();
        }


        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        
        {
            var accountDetails = context.Accounts.Select(a => new SelectListItem
            {
                Value = a.AccountNumber.ToString(),
                Text = $"{a.AccountName}"
            }).ToList();
            ViewBag.AccountDetails = accountDetails;
            return View("TransferFunds");
        }


        [HttpPost]
        [Route("Index")]
        public IActionResult Index([Bind] Transfer transfer)
        {
            if (ModelState.IsValid)
            {
                if (transfer.FromAccountNumber == transfer.ToAccountNumber)
                { 
                    ModelState.AddModelError("AccountNumber", "Both FromAccount and ToAccount should not be same!!");
                    return Index();
                }
                if (!(transfer.AmountDebited > 1 && transfer.AmountDebited < 10000))
                { 
                    ModelState.AddModelError("AmountDebited", "Amount to transfer should be in between $1 and $10000!!");
                    return Index();
                }
                var fromAccount = context.Accounts.Where(_ => _.AccountNumber == transfer.FromAccountNumber).FirstOrDefault();
           

                if (fromAccount != null && fromAccount.Balance > transfer.AmountDebited)
                {
                    var toAccount = context.Accounts.Where(_ => _.AccountNumber == transfer.ToAccountNumber).FirstOrDefault();
                    // insert into transfer table 
                    context.Transfers.Add(new Transfer()
                    {
                        AmountDebited = transfer.AmountDebited,
                        FromAccountBalance = fromAccount.Balance,
                        ToAccountBalance = toAccount.Balance,
                        FromAccountNumber = fromAccount.AccountNumber,
                        ToAccountNumber = toAccount.AccountNumber,
                        TransactionTime = DateTime.Now
                    });
                    context.SaveChanges();

                    // decrease fromAccount balance
                    fromAccount.Balance = fromAccount.Balance - transfer.AmountDebited;
                    toAccount.Balance = toAccount.Balance + transfer.AmountDebited;
                    context.SaveChanges();


                }
                else
                {
                    ModelState.AddModelError("AmountDebited", "Sufficient Balance is not available in the FromAccount ");
                }
            }
            else
            {
                if(transfer.AmountDebited == 0)
                    ModelState.AddModelError("AmountDebited", "Please Enter Amount to Transfer");
                else
                    ModelState.AddModelError("AmountDebited", "Something Wrong");
            }
            return Index();
        }
    }
}
