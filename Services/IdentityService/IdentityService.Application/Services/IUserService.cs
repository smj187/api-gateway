﻿using IdentityService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services
{
    public interface IUserService
    {
        Task<Token> RegisterAsync(User user, string password);
        Task<Token> AuthenticateAsync(Token token);
    }
}