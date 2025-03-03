using ERP.Application.Abstractions.IServices.IServices;
using ERP.Domain;
using ERP.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public UserController(IUserService userService, IStudentService studentService, ITeacherService teacherService)
        {
            _userService = userService;
            _studentService = studentService;
            _teacherService = teacherService;
        }
        
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.Authenticate(request.Email, request.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");
            
            var token = await _userService.GenerateJwtToken(user);
            
            return Ok(new { 
                user.Id, 
                user.Email, 
                user.Role, 
                Token = token 
            });
        }
        
        
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == "Role")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || string.IsNullOrEmpty(roleClaim))
                return Unauthorized("Invalid token");

            if (!int.TryParse(userIdClaim, out var userId))
                return Unauthorized("Invalid user ID format");

            switch (roleClaim)
            {
                case "SuperAdmin":
                    var user = await _userService.GetById(userId);
                    return user != null ? Ok(user) : NotFound("User not found");

                default:
                    return Unauthorized("Invalid role");
            }
        }

        // [Authorize(Roles = "SuperAdmin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var newUser = new User
            {
                Email = request.Email,
                Password = request.Password, 
                Role = request.Role,
                Name = request.Name
            };

            var createdUser = await _userService.CreateUser(newUser);
    
            if (request.Role == "Student")
            {
                var studentDto = new StudentDTO
                {
                    Name = request.Name,
                };
                await _studentService.CreateStudent(studentDto);
            }
            else if (request.Role == "Teacher")
            {
                var teacherDto = new TeacherDTO
                {
                    Name = request.Name,
                    Email = request.Email,
                };
                await _teacherService.CreateTeacher(teacherDto);
            }

            var token = await _userService.GenerateJwtToken(createdUser);

            return Ok(new { user = createdUser, token });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            var result = await _userService.UpdateUser(id, user);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
    }
}