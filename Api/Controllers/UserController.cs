using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                return BadRequest("Passwords do not match.");
            }

            var user = new ApplicationUser
            {
                Name = dto.Name ?? "",
                UserName = dto.Email,
                Email = dto.Email,
                Photo = dto.Photo ?? ""
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                return Ok(new { Message = "User created successfully", UserId = user.Id });
            }

            return BadRequest(result.Errors);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetUserss(
            int page = 1,
            int pageSize = 10,
            string? name = null,
            string? email = null,
            string? username = null
        )
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => (s.Name ?? "").Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(s => (s.Email ?? "").Contains(email));
            }

            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(s => (s.UserName ?? "").Contains(username));
            }

            var totalUsers = await query.CountAsync();

            // Retrieve users and their roles asynchronously
            var users = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var userDtos = new List<object>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userDtos.Add(new
                {
                    Id = user.Id,
                    Name = user.Name,
                    Photo = user.Photo,
                    Username = user.UserName,
                    Email = user.Email,
                    Roles = roles
                });
            }

            var result = new
            {
                TotalCount = totalUsers,
                PageSize = pageSize,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalUsers / (double)pageSize),
                Data = userDtos
            };

            return Ok(result);
        }
    }
}
