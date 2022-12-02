
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
using Infrastructure.Services;

[ApiController]
[Route("controller")]

public class BookController
{
    private BookService _bookService;
    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet("Get book by join")]
    public async Task<List<GetBooks>> GetBooks()
    {
        return await _bookService.GetBooks();
    }

    [HttpGet("Get book by join (by id)")]
    public async Task<GetBooks> GetBooksById(int id)
    {
        return await _bookService.GetBooksById(id);
    }

    [HttpPost("Insert into Book(join)")]
    public async Task<int> InsertBook(Book book)
    {
        return await _bookService.InsertBook(book);
    }

    [HttpPut("Update Book")]
    public async Task<int> UpdateBook(Book book)
    {
        return await _bookService.UpdateBook(book);
    }

    [HttpDelete("Delete Book")]
    public async Task<int> DeleteBook(int id)
    {
        return await _bookService.DeleteBook(id);
    }
}
