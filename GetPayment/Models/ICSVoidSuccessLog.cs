using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetPayment.Models
{
    [Table("ICSVoidSuccessLog", Schema = "ta")]
    public class ICSVoidSuccessLog
    {
        [Key]
        public string ReceiptId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
