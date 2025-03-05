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
	public class PaymentHelp
	{
        internal static string PaymentMessage()
        {
            return "Hello, ASP.NET Web API!";
        }

        internal static async Task<List<PaymentType>> GetPaymentType(DB_BPM_CENTER_APP_DB dbapp)
        {
            try
            {
                return await dbapp.PaymentTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("เกิดข้อผิดพลาด ", ex);
            }
        }

        internal static async Task<ICSVoidSuccessLog> GetPaymentSuccessLogs(DB_BPM_CENTER_ADT_DB dbadt)
        {
            try 
            {
                var result = await dbadt.ICSVoidSuccessLogs
                    .OrderByDescending(x => x.CreatedDate)
                    .FirstOrDefaultAsync();
                    
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("เกิดข้อผิดพลาด ", ex);
            }
        }

        internal static async Task<List<ICSUpdatePaymentLog>> GetPaymentLogs(DB_BPM_CENTER_ADT_DB dbadt)
        {
            try 
            {
                return await dbadt.ICSUpdatePaymentLogs
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(2)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("เกิดข้อผิดพลาด ", ex);
            }
        }

        internal static async Task<PaymentResponce> GetPaymentByRef(DB_BPM_CENTER_ADT_DB dbadt, PaymentRequest request)
        {
            var res = new PaymentResponce
            {
                UpdateStatus = new UpdateStatus()
            };

            try
            {
                
                var paymentLogs = await dbadt.ICSUpdatePaymentLogs
                                .Where(x => x.Ref1 == request.Ref1 && x.NotificationNo == request.Ref2)
                                .OrderByDescending(x => x.CreatedDate)
                                .SingleOrDefaultAsync();

                if (paymentLogs != null)
                {
                    var successLogs = await dbadt.ICSVoidSuccessLogs
                                    .Where(x => x.ReceiptId == paymentLogs.ReceiptId)
                                    .OrderByDescending(x => x.CreatedDate)
                                    .SingleOrDefaultAsync();

                    if (successLogs != null)
                    {
                        var data = paymentLogs;
                        res.Ref1 = data.Ref1;
                        res.NotificationNo = data.NotificationNo;
                        res.InvoiceNo = data.InvoiceNo;
                        res.DebtId = data.DebtId;
                        res.ReceiptId = data.ReceiptId;
                        res.CreatedDate = data.CreatedDate;

                        return res;
                    }
                }

                res.Ref1 = request.Ref1;
                res.NotificationNo = request.Ref2;
                res.InvoiceNo = null;
                res.DebtId = null;
                res.ReceiptId = null;
                res.CreatedDate = DateTime.Now;
                res.UpdateStatus.Response = "คำร้องยังไม่ได้ชำระเงิน";
                res.UpdateStatus.Success = false;
                res.UpdateStatus.Message = "ไม่พบข้อมูลการชำระเงิน";

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

                return res;
            }
        }

        internal static async Task<GetPaymentResult> GetPaymentSp(DB_BPM_CENTER_ADT_DB dbadt, PaymentRequest request)
        {
            try
            {
                return await dbadt.GetPaymentFromStoredProc(request);
            }
            catch (Exception ex)
            {
                throw new Exception("เกิดข้อผิดพลาด ", ex);
            }
        }
    }
}