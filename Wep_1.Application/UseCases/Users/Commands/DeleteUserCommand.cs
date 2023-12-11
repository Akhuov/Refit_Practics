using MediatR;

namespace Wep_1.Application.UseCases.Users.Commands
{
    public class DeleteUserCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
