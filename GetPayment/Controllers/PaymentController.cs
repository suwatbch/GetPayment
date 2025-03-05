using System;
using GetPayment.DAL;
using System.Web.Http;
using GetPayment.Help;
using GetPayment.DTO.Request;
using GetPayment.DTO.Response;
using System.Threading.Tasks;
namespace GetPayment.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly DB_BPM_CENTER_ADT_DB _dbadt;
        private readonly DB_BPM_CENTER_APP_DB _dbapp;

        public PaymentController()
        {
            _dbadt = new DB_BPM_CENTER_ADT_DB();
            _dbapp = new DB_BPM_CENTER_APP_DB();
        }

        [HttpGet]
        [Route("api/payment-message")]
        public IHttpActionResult PaymentMessage()
        {
            return Ok(PaymentHelp.PaymentMessage());
        }

        [HttpGet]
        [Route("api/payment-success-logs")]
        public IHttpActionResult PaymentSuccessLogs()
        {
            var logs = PaymentHelp.GetPaymentSuccessLogs(_dbadt);
            return Ok(new { Message = PaymentHelp.PaymentMessage(), Logs = logs });
        }

        [HttpGet]
        [Route("api/payment-logs")]
        public async Task<IHttpActionResult> PaymentLogs()
        {
            var result = await PaymentHelp.GetPaymentLogs(_dbadt);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/get-payment-by-ref")]
        public async Task<IHttpActionResult> GetPaymentByRef(PaymentRequest request)
        {
            var result = await PaymentHelp.GetPaymentByRef(_dbadt, request);
            return Ok(result);
        }
    }
}
