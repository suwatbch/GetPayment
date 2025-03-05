using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetPayment.Models
{
    [Table("PaymentType", Schema = "mt")]
	public class PaymentType
    {
        [Key]
        public string PtId { get; set; }
        public string PtName { get; set; }
        public string PaymentSeq { get; set; }
        public string SyncFlag { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public string ModifiedBy { get; set; }
        public string Active { get; set; }

    }
}