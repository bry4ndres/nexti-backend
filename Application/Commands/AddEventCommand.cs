using MediatR;

namespace Application.Commands
{
    public class AddEventCommand: IRequest<int>
    {
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
