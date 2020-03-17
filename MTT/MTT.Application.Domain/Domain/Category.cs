using System.Collections.Generic;

namespace MTT.Application.Domain.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Muster> Musters { get; set; }

    }
}
