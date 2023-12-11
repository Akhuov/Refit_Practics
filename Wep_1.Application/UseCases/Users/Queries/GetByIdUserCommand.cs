using MediatR;
using Wep_1.Domain;

namespace Wep_1.Application.UseCases.Users.Queries
{
    public class GetByIdUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
