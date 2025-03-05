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
        [Route("api/payment-message")]
        public IHttpActionResult PaymentMessage()
        {
            return Ok(PaymentHelp.PaymentMessage());
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
