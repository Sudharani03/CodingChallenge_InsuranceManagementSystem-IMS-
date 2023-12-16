using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Model
{
    internal class Policies
    {
        public  int PolicyId { get; set; }
        public string PolicyNumber { get; set; }

        public string PolicyType { get; set; }
        public double CoverageAmount { get; set; }
        public double PremiumAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Policies()
        {
            
        }

        public Policies(int policyId , string policyNumber , string policyType , double coverageAmount ,double premiumAmount ,DateTime startDate , DateTime endDate)
        {
            PolicyId = policyId;
            PolicyNumber=policyNumber;
            PolicyType = policyType;
            CoverageAmount = coverageAmount;
            PremiumAmount = premiumAmount;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
        {
            return $"PolicyId : {PolicyId}\t  PolicyNumber : {PolicyNumber}\t  PolicyType : {PolicyType}\t  CoverageAmount : {CoverageAmount}\t PremiumAmount :{PremiumAmount}\t,StartDate :{StartDate}\t EndDate : {EndDate}";
        }
    }
}
