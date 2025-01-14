﻿

using MyNewCiniesOction.Models;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Extensions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MyNewCiniesOction.Models;
using System.Linq.Expressions;

namespace MyNewCiniesOction.Middleware

{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMiddleware> _logger;

        private static IConfiguration _config;
        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger, IConfiguration config)
        {
            _next = next;
            _logger = logger;
            _config = config;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
                var handler = new JwtSecurityTokenHandler();
                var b = context.Request.Headers["Authorization"].ToString();
                var tokenSecure = handler.ReadToken(context.Request.Headers["Authorization"]) as SecurityToken;
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var claims = handler.ValidateToken(context.Request.Headers["Authorization"], validations, out tokenSecure);
                var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
                //if (prinicpal is ClaimsPrincipal claim)

                User user = new User();

                int a;
                int.TryParse(claims.Claims.FirstOrDefault(x => x.Type == "userId")?.Value ?? "", out a);
                user.UserId = a;
                context.Items["User"] = user;
                await _next(context);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the middleware.");

            }
        }
    }
}