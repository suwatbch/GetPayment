using System;
using GetPayment.DAL;
using System.Web.Http;
using GetPayment.Help;
using GetPayment.DTO.Request;
using GetPayment.DTO.Response;
using GetPayment.DTO.Result;
using System.Threading.Tasks;
namespace GetPayment.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly DB_BPM_CENTER_APP_DB _dbapp;
        private readonly DB_BPM_CENTER_ADT_DB _dbadt;

        public PaymentController()
        {
            _dbapp = new DB_BPM_CENTER_APP_DB();
            _dbadt = new DB_BPM_CENTER_ADT_DB();
        }

        [HttpGet]
        [Route("api/test-dbapp-connection")]
        public IHttpActionResult TestDBAppConnection()
        {
            try
            {
                bool isConnected = _dbapp.Database.Exists();
                if (isConnected)
                {
                    return Ok(new { status = "success", message = "Database connection is working properly" });
                }
                return BadRequest("Database connection failed");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/payment-message")]
        public IHttpActionResult PaymentMessage()
        {
            return Ok(PaymentHelp.PaymentMessage());
        }

        [HttpGet]
        [Route("api/payment-type")]
        public async Task<IHttpActionResult> PaymentType()
        {
            try
            {
                var result = await PaymentHelp.GetPaymentType(_dbapp);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/payment-success-logs")]
        public async Task<IHttpActionResult> PaymentSuccessLogs()
        {
            var result = await PaymentHelp.GetPaymentSuccessLogs(_dbadt);
            return Ok(result);
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

        [HttpPost]
        [Route("api/post-payment-sp")]
        public async Task<IHttpActionResult> PostPaymentSp(PaymentRequest request)
        {
            try
            {
                var result = await PaymentHelp.PostPaymentSp(_dbadt, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/get-payment-sp")]
        public async Task<IHttpActionResult> GetPaymentSp(string ref1, string ref2)
        {
            try
            {
                var request = new PaymentRequest();
                request.Ref1 = ref1;
                request.Ref2 = ref2;
                var result = await PaymentHelp.PostPaymentSp(_dbadt, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
