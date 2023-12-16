using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Model
{
    internal class Payments
    {
        public int PaymentId { get; set; }
        public int ClientId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }

        //default constructor

        public Payments() { }

        public Payments(int paymentId, int clientId, DateTime paymentDate, double paymentamount)
        {
            PaymentId = paymentId;
            ClientId = clientId;
            PaymentDate = paymentDate;
            PaymentAmount = paymentamount;
        }

        public override string ToString()
        {
            return $"PaymentId : {PaymentId}\t  ClientId : {ClientId}\t  PaymentDate : {PaymentDate}\t  PaymentAmount : {PaymentAmount}";
        }
    }
}
