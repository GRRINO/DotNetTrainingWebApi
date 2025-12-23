using EncDecExampleLoginApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EncDecExampleLoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly EncDecService _encDecService;

        public BlogController(EncDecService encDecService)
        {
            _encDecService = encDecService;
        }

        [HttpPost("Login")]
        public IActionResult Login(BlogLoginRequest req)
        {
            try
            {
                var result = UserData.Users
                    .FirstOrDefault(u => u.UserName == req.Username && u.Password == req.Password);
                if (result is null)
                {
                    return Unauthorized();
                }

                var user = new BlogLoginModel
                {
                    Username = req.Username,
                    SessionId = Guid.NewGuid().ToString(),
                    SessionExpired = DateTime.UtcNow.AddMinutes(1)
                };

                var json = JsonConvert.SerializeObject(user);

               var token = _encDecService.Encrypt(json);

                var model = new BlogLoginResponse
                {
                    AccessToken = token
                };
                return Ok(model);

            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("UserList")]
        public IActionResult UserList(UserListRequest req)
        {
            try
            {
                var json = _encDecService.Decrypt(req.AccessToken);
                var user = JsonConvert.DeserializeObject<BlogLoginModel>(json);
                if (user!.SessionExpired < DateTime.Now)
                {
                    return Unauthorized("Session is expired.");
                }
                return Ok(
                    UserData.Users
                );
            } catch(Exception ex)
            {
                return StatusCode(500, ex.ToString);
            }
        }
        public static class UserData
        {
            public static List<UserDto> Users = new List<UserDto>
            {
                new UserDto { UserName = "admin", Password = "admin123" },
                new UserDto { UserName = "user1", Password = "password1" },
                new UserDto { UserName = "user2", Password = "password2" }
            };

        }

        public class UserListRequest
        {
            public string AccessToken { get; set; }
        }

        public class BlogLoginModel
        {
            public string Username { get; set; }
            public string SessionId { get; set; }
            public DateTime SessionExpired { get; set; }
        }

        public class BlogLoginResponse
        {
            public string AccessToken { get; set; }
        }

        public class BlogLoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class UserDto
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
