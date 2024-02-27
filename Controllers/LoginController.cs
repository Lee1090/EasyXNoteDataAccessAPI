using EasyXNoteDataAccessAPI.Models;
using EasyXNoteDataAccessAPI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace EasyXNoteDataAccessAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly LoginService _loginService;
        public LoginController()
        {
            _loginService = new LoginService();
        }

        [HttpGet]
        [Route("api/login")]
        public IHttpActionResult Login()
        {
            // 获取请求的标头 Get the headers of the request
            var headers = Request.Headers;

            // 检查是否包含 Authorization 标头 Check if the Authorization header is included
            if (headers.Contains("Authorization"))
            {
                // 获取 Authorization 标头的值 Get the value of the Authorization header
                string authHeaderValue = headers.GetValues("Authorization").FirstOrDefault();

                // 解码 Authorization 标头值 Decode the value of the Authorization header
                string encodedUsernamePassword = authHeaderValue.Substring("Basic ".Length).Trim();
                string decodedUsernamePassword = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                string[] usernamePasswordArray = decodedUsernamePassword.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];

                if (_loginService.IsValidUser(username, password))
                {
                    return Ok("Login successful");
                }
            }

            // 用户名密码验证失败或未提供，返回未授权 401 Username/password authentication failed or not provided, returning 401 Unauthorized
            return Unauthorized();
        }


    }
}

/*

// 从请求标头中获取授权标头值
string authHeader = HttpContext.Current.Request.Headers["Authorization"];

// 检查授权标头是否存在并且以 "Basic " 开头
if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Basic "))
{
    // 提取 Base64 编码的用户名和密码
    string encodedCredentials = authHeader.Substring(6);
    
    // 解码 Base64 编码的字符串
    string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));

    // 分离用户名和密码
    string[] parts = credentials.Split(':');
    string username = parts[0];
    string password = parts[1];

    // 进一步处理用户名和密码，例如进行身份验证
}
*/