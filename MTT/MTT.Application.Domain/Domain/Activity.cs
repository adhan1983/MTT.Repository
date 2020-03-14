namespace MTT.Application.Domain.Domain
{
    // tarefa
    public class Activity
    {
        public int Id { get; set; }
        public int Name { get; set; }        
        public bool WasConcluded { get; set; }
        public int MusterId { get; set; }
        public Muster Muster { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
