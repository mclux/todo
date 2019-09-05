using Api.Models;
using Api.Providers;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace Api.Controllers
{
    public class AuthController : ApiController
    {
        UserRepository userRepo;
        public AuthController()
        {
            userRepo = new UserRepository();
        }

        [Route("api/auth")]
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] LoginRequest request)
        {
            var response = new Response();

            var user = userRepo.Get(request.Username);
            if (user != null)
            {
                MD5 md5Hash = MD5.Create();
                string hash = PasswordManager.GetMd5Hash(md5Hash, request.Password);
                if (PasswordManager.VerifyMd5Hash(md5Hash, request.Password, hash))
                {
                    var token = TokenProvider.GenerateToken(request.Username);
                    return Ok(new Response
                    {
                        Data = token,
                        Message = "Login successful",
                        Status = true
                    });
                }
            }

            return Ok(new Response {
                Data=null,
                Message="Invalid credentials",
                Status=false
            });
        }
    }
}
