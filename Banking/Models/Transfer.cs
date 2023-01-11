using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.Models
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
