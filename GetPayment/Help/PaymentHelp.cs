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

                if (PaymentResult == null || PaymentResult.Status == "Not found")
                {
                    res.Ref1 = request.Ref1;
                    res.NotificationNo = request.Ref2;
                    res.InvoiceNo = null;
                    res.DebtId = null;
                    res.ReceiptId = null;
                    res.PayDate = null;
                    res.UpdateStatus.Response = "ไม่พบข้อมูล";
                    res.UpdateStatus.Status = "Not found";
                    res.UpdateStatus.Message = "ไม่พบข้อมูลในระบบ";
                }
                else if (PaymentResult.Status == "Paid")
                {
                    res.Ref1 = PaymentResult.Ref1;
                    res.NotificationNo = PaymentResult.NotificationNo;
                    res.InvoiceNo = PaymentResult.InvoiceNo;
                    res.DebtId = PaymentResult.DebtId;
                    res.ReceiptId = PaymentResult.ReceiptId;
                    res.PayDate = PaymentResult.CreatedDate;
                    res.UpdateStatus.Response = "ชำระเงินเรียบร้อยแล้ว";
                    res.UpdateStatus.Status = "Paid";
                    res.UpdateStatus.Message = "พบข้อมูลการชำระเงิน";
                }
                else if (PaymentResult.Status == "Cancel")
                {
                    res.Ref1 = PaymentResult.Ref1;
                    res.NotificationNo = PaymentResult.NotificationNo;
                    res.InvoiceNo = PaymentResult.InvoiceNo;
                    res.DebtId = PaymentResult.DebtId;
                    res.ReceiptId = PaymentResult.ReceiptId;
                    res.PayDate = PaymentResult.CreatedDate;
                    res.UpdateStatus.Response = "คำร้องยังไม่ได้ชำระเงิน";
                    res.UpdateStatus.Status = "Cancel";
                    res.UpdateStatus.Message = "มีการยกเลิกการรับชำระเงิน";
                }

                return res;
            }
            catch (Exception ex)
            {
                res.Ref1 = null;
                res.NotificationNo = null;
                res.InvoiceNo = null;
                res.DebtId = null;
                res.ReceiptId = null;
                res.PayDate = null;
                res.UpdateStatus.Response = null;
                res.UpdateStatus.Status = "Error";
                res.UpdateStatus.Message = "Error : " + ex.Message;
                throw new Exception("เกิดข้อผิดพลาด ", ex);
            }
        }
    }
}