using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("API/[Controller]")] // /api/users

public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.User.ToListAsync();
        return users;
    }

    [HttpGet("{id}")] // /api/usres/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.User.FindAsync(id);
    }
}

