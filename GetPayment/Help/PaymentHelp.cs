using System;
using System.Linq;
using GetPayment.DAL;
using GetPayment.Models;
using System.Collections.Generic;
using GetPayment.DTO.Request;
using GetPayment.DTO.Response;
using GetPayment.DTO.Result;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GetPayment.Help
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class PaymentHelp
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        internal static string PaymentMessage()
        {
            return "Hello, ASP.NET Web API!";
        }

        internal static async Task<PaymentResponce> PostPaymentSp(DB_BPM_CENTER_ADT_DB dbadt, PaymentRequest request)
        {
            var res = new PaymentResponce
            {
                UpdateStatus = new UpdateStatus()
            };
            try
            {
                var PaymentResult = await dbadt.GetPaymentFromStoredProc(request);

                if (PaymentResult.ReceiptId != null)
                {
                    res.Ref1 = PaymentResult.Ref1;
                    res.NotificationNo = PaymentResult.NotificationNo;
                    res.InvoiceNo = PaymentResult.InvoiceNo;
                    res.DebtId = PaymentResult.DebtId;
                    res.ReceiptId = PaymentResult.ReceiptId;
                    res.CreatedDate = PaymentResult.CreatedDate;
                }
                else
                {
                    res.Ref1 = request.Ref1;
                    res.NotificationNo = request.Ref2;
                    res.InvoiceNo = null;
                    res.DebtId = null;
                    res.ReceiptId = null;
                    res.CreatedDate = DateTime.Now;
                    res.UpdateStatus.Response = "คำร้องยังไม่ได้ชำระเงิน";
                    res.UpdateStatus.Success = false;
                    res.UpdateStatus.Message = "ไม่พบข้อมูลการชำระเงิน";
                }

                return res;
            }
            catch (Exception ex)
            {
                res.Ref1 = request.Ref1;
                res.NotificationNo = request.Ref2;
                res.InvoiceNo = null;
                res.DebtId = null;
                res.ReceiptId = null;
                res.CreatedDate = DateTime.Now;
                res.UpdateStatus.Response = null;
                res.UpdateStatus.Success = false;
                res.UpdateStatus.Message = "Error : " + ex.Message;
                throw new Exception("เกิดข้อผิดพลาด ", ex);
            }
        }
    }
}