using System.Collections.Generic;

namespace MTT.Application.Domain.Domain
{
    //lista
    public class Muster
    {
        public void Add(string name, int categoryId) 
        {
            this.Name = name;
            this.CategoryId = categoryId;
        }
        public void Update(string name) 
        {
            this.Name = name;            
        }
        public void Concluded(bool wasConcluded) 
        {
            this.WasConcluded = wasConcluded;
        }
        public int Id { get; set; }
        public string Name { get; set; }        
        public bool WasConcluded { get; set; }
        public int CategoryId { get; set; }        
        public Category Category { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
