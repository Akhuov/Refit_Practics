using MediatR;
using Wep_1.Domain;

namespace Wep_1.Application.UseCases.Users.Queries
{
    public class GetAllUsersCommand : IRequest<List<User>>
    {
    }
}
