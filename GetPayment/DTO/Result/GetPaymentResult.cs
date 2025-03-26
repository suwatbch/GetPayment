using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetPayment.DTO.Result
{
	public class GetPaymentResult
	{
		// ตารางแรก
		public string Status { get; set; }

		// ตารางที่สอง
		public string Ref1 { get; set; }
		public string NotificationNo { get; set; }
		public string InvoiceNo { get; set; }
		public string ReceiptId { get; set; }
		public string DebtId { get; set; }
		public string UpdateStatus { get; set; }
		public DateTime? CreatedDate { get; set; }
	}
}