using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagementSystem.Model
{
    internal class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Users()
        {
            
        }

        public Users(int userId , string userName,string password,string role)
        {
            UserId = userId; 
            UserName = userName;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            return $"UserId : {UserId}\t  UserName : {UserName}\t  Password : {Password}\t  Role : {Role}";
        }
    }
    
}
