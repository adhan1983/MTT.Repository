namespace MTT.Application.Domain.Domain
{
    // tarefa
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool WasConcluded { get; set; }
        public int MusterId { get; set; }
        public Muster Muster { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public void Add(string name, int musterId, int userId) 
        {
            this.Name = name;
            this.MusterId = musterId;
            this.UserId = userId;
            this.WasConcluded = false;
        }
        public void Update(string name, int musterId, int userId) 
        {
            this.Name = name;
            this.MusterId = musterId;
            this.UserId = userId;
        }
        public void Concluded(bool wasConcluded)
        {
            this.WasConcluded = wasConcluded;
        }

    }
}
