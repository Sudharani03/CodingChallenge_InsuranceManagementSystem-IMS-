using InsuranceManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.ServiceProvider
{
    internal interface IPolicyRepository
    {
        public int CreatePolicy(Policies policy);

        public List<Policies> GetPolicy(int policyId);

        public List<Policies> GetAllPolicies();

        public void DeletePolicy(int policyId);

        public int UpdatePolicy(Policies policy);



    }
}
