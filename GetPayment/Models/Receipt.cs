using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetPayment.Models
{
    [Table("Receipt", Schema = "ta")]
    public class Receipt
    {
        // 1
        [Key]
        public string ReceiptId { get; set; }

        // 2
        public string PaymentId { get; set; }
    }

}
