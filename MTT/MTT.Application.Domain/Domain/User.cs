using System.Collections.Generic;
using MTT.Application.Domain.Utilities;

namespace MTT.Application.Domain.Domain
{    
    public class User
    {        
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Email { get; set; }        
        public string Password { get; set; }
        public List<Activity> Activities { get; set; }
        public void Add(string name, string email, string password) 
        {
            Name = name;
            Email = email;
            Password = password.Encrypt();
        }
        public bool VerifyPassword(string passwordModelEncrypt, string passwordContractDecrypt)
        {
            string passwordDecrypt = passwordModelEncrypt.Decrypt();
            
            return passwordDecrypt == passwordContractDecrypt ? true : false;
        }
    }
}
