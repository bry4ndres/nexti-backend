namespace Domain.Entities
{
    public class EventEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
