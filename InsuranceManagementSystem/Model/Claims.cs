using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Model
{
    internal class Claims
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }

        public Claims()
        {
              
        }

        public Claims(int userId , string userName,string password , string role)
        {
            UserId = userId;
            UserName = userName;
            PassWord = password;
            Role = role;
        }

        public override string ToString()
        {
            return $"UserID : {UserId}\t UserName : {UserName}\t Password : {PassWord}\t Role : {Role}";
        }
    }
}
