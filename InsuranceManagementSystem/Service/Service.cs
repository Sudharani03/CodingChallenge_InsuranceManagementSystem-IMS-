using InsuranceManagementSystem.Exceptions;
using InsuranceManagementSystem.Model;
using InsuranceManagementSystem.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Repository
{
    internal class Service : IService
    {
        IPolicyRepository policyService = new PolicyRepository();

        public void CreatePolicy()
        {
            
            Console.WriteLine("Enter the PolicyNumber:: ");
            string PolicyNumber = Console.ReadLine();
            Console.WriteLine("Enter the Policy Type");
            string PolicyType = Console.ReadLine();
            Console.WriteLine("Enter the CoverageAmount:: ");
            double CoverageAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the PremiumAmount:: ");
            double PremiumAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Provide the start date of policy in (yyyy-MM-dd) format:: ");
            DateTime StartDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Provide end date of policy in (yyyy-MM-dd) format:: ");
            DateTime EndDate = DateTime.Parse(Console.ReadLine());

            policyService.CreatePolicy(new Policies() { PolicyNumber = PolicyNumber, PolicyType = PolicyType, CoverageAmount = CoverageAmount, PremiumAmount = PremiumAmount,StartDate=StartDate, EndDate=EndDate});
        }

        public void GetPolicy()
        {
            try
            {
                Console.WriteLine("Enter the Policy ID:: ");
                int policyID = int.Parse(Console.ReadLine());
                var policies = policyService.GetPolicy(policyID);
                foreach (var policy in policies)
                {
                    Console.WriteLine(policy);
                }
            }
            catch (PolicyNumberNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllPolicies()
        {
            var policies = policyService.GetAllPolicies();
            foreach (var policy in policies)
            {
                Console.WriteLine(policy);
            }
        }

        public void DeletePolicy()
        {
            try
            {
                Console.WriteLine("\nEnter the Id of the Policy to be Deleted:: ");
                int PolicyId = int.Parse(Console.ReadLine());
                policyService.DeletePolicy(PolicyId);
            }
            catch (PolicyNumberNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int UpdatePolicy()
        {
            try
            {
                Console.WriteLine("Enter the Policy ID to update: ");
                int policyID = int.Parse(Console.ReadLine());

                var policyToUpdate = policyService.GetPolicy(policyID);

                if (policyToUpdate == null)
                {
                    Console.WriteLine($"Policy with ID {policyID} not found.");
                    return 0;
                }
                Console.WriteLine("Enter the new Policy Number: ");
                string newPolicyNumber = Console.ReadLine();

                Console.WriteLine("Enter the new Policy Type: ");
                string newPolicyType = Console.ReadLine();

                Console.WriteLine("Enter the new Coverage Amount: ");
                double newCoverageAmount=double.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new Premium Amount: ");
                double newPremiumAmount= double.Parse(Console.ReadLine()); ;

                Console.WriteLine("Enter the new Start Date (YYYY-MM-DD): ");
                DateTime newStartDate= DateTime.Parse(Console.ReadLine()); ;

                Console.WriteLine("Enter the new End Date (YYYY-MM-DD): ");
                DateTime newEndDate= DateTime.Parse(Console.ReadLine()); ;

                Policies updatedPolicy = new Policies
                {
                    PolicyNumber = newPolicyNumber,
                    PolicyType = newPolicyType,
                    CoverageAmount = newCoverageAmount,
                    PremiumAmount = newPremiumAmount,
                    StartDate = newStartDate,
                    EndDate = newEndDate
                };

                int updatePolicyStatus = policyService.UpdatePolicy(updatedPolicy);

                if (updatePolicyStatus > 0)
                {
                    Console.WriteLine($"Policy with ID {policyID} updated successfully!");
                }
                else
                {
                    Console.WriteLine($"Error updating policy with ID {policyID}.");
                }

                return updatePolicyStatus;
            }
            catch (PolicyNumberNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public string ExitConsole()
        {
            Console.WriteLine("Do you really want to exit : Yes/No ");
            string res = Console.ReadLine();
            return res;
        }

    
    }
}
