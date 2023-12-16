using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Exceptions
{
    internal class PolicyNumberNotFoundException:ApplicationException
    {
        public PolicyNumberNotFoundException() { }
        public PolicyNumberNotFoundException(string message) : base(message) { }
    }
}
