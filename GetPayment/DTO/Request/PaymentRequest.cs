using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetPayment.DTO.Request
{
	public class PaymentRequest
	{
        private string ref1;
        private string ref2;

        public string Ref1
        {
            get { return ref1; }
            set
            {
                if (value.Length <= 12)
                    ref1 = value;
                else
                    throw new ArgumentException("Ref1 must be 12 characters or less.");
            }
        }

        public string Ref2
        {
            get { return ref2; }
            set
            {
                if (value.Length <= 12)
                    ref2 = value;
                else
                    throw new ArgumentException("Ref2 must be 12 characters or less.");
            }
        }
    }
}