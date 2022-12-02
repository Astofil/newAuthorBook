
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
using Infrastructure.Services;

[ApiController]
[Route("controller")]

public class AuthorController
{
    private AuthorService _authorService;
    public AuthorController(AuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet("Get all(author)")]
    public async Task<List<Author>> GetAuthors()
    {
        return await _authorService.GetAuthors();
    }

    [HttpPost("Insert into Author")]
    public async Task<int> InsertAuthor(Author author)
    {
        return await _authorService.InsertAuthor(author);
    }

    [HttpPut("Update Author")]
    public async Task<int> UpdateAuthor(Author author)
    {
        return await _authorService.UpdateAuthor(author);
    }

    [HttpDelete("Delete Author")]
    public async Task<int> DeleteAuthor(int id)
    {
        return await _authorService.DeleteAuthor(id);
    }
}
