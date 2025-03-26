using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetPayment.DTO.Response
{
	public class PaymentResponce
	{
        public string Ref1 { get; set; }
        public string NotificationNo { get; set; }
        public string InvoiceNo { get; set; }
        public string DebtId { get; set; }
        public string ReceiptId { get; set; }
        public UpdateStatus UpdateStatus { get; set; }
        public DateTime? PayDate { get; set; }
    }

    public class UpdateStatus
    {
        public string Response { get; set; } = "คำร้องชำระเงินแล้ว";
        public string Status { get; set; }
        public string Message { get; set; } = "OK REQUEST";
    }
}