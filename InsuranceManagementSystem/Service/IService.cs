using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Repository
{
    internal interface IService
    {
        void CreatePolicy();
        void GetPolicy();
        void GetAllPolicies();
        int UpdatePolicy();
        void DeletePolicy();



        string ExitConsole();
    }
}
