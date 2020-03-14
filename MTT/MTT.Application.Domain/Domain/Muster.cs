using System.Collections.Generic;

namespace MTT.Application.Domain.Domain
{
    //lista
    public class Muster
    {
        public int Id { get; set; }
        public int Name { get; set; }        
        public bool WasConcluded { get; set; }
        public int CategoryId { get; set; }        
        public Category Category { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
