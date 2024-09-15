using MediatR;

namespace Application.Commands
{
    public class DeleteEventCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
