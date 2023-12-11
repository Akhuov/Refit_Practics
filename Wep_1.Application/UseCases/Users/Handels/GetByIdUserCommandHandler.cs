﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wep_1.Application.Absreactions;
using Wep_1.Application.UseCases.Users.Queries;
using Wep_1.Domain;

namespace Wep_1.Application.UseCases.Users.Handels
{
    public class GetByIdUserCommandHandler : IRequestHandler<GetByIdUserCommand, User>
    {
        private readonly IApplicationContext _context;
        public GetByIdUserCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetByIdUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x=>x.Id == request.Id);
                if (user != null)
                {

                    return user;
                }
                throw new Exception("Users not Found!!");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
