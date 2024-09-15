namespace Application.DTOs
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
