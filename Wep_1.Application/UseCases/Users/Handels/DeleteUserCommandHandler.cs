using MediatR;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Users.Commands;

namespace Wep_1.Application.UseCases.Users.Handels
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IApplicationContext _context;
        public DeleteProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = _context.Users.FirstOrDefault(x => x.Id == request.Id);
                if (res != null)
                {
                    _context.Users.Remove(res);
                    var res2 = await _context.SaveChangesAsync(cancellationToken);
                    return $"{res2} User Deleted! Name = {res.Name}";
                }
                throw new Exception("User NotFound!!");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
