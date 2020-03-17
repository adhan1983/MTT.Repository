using System.Collections.Generic;

namespace MTT.Application.Domain.Domain
{
    //As informacoes do usuario virao do Identity Server
    public class User
    {        
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Email { get; set; }        
        public string Password { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
