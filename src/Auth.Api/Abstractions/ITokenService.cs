﻿using Auth.Api.Model;

namespace Auth.Api.Abstractions;

public interface ITokenService
{
    string CreateToken(UserIdentity userIdentity);  
}
