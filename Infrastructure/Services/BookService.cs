
namespace Infrastructure.Services;
using Npgsql;
using Dapper;
using Domain.Dtos;

public class BookService
{
    private readonly DapperContext _context;
    public BookService(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<GetBooks>> GetBooks()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select books.id, books.book_name as BookName, books.author_id as AuthorId, authors.first_name as FirstName, authors.last_name as LastName from books full outer join authors on books.id=authors.id";
            var result = conn.Query<GetBooks>(sql).ToList();
            return result;
        }
    }
    public async Task<GetBooks> GetBooksById(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select books.id, books.book_name as BookName, books.author_id as AuthorId, authors.first_name as FirstName, authors.last_name as LastName from books full outer join authors on books.id=authors.id where id = {id}";
            var result = conn.QuerySingleOrDefault<GetBooks>(sql);
            return result;
        }
    }
    public async Task<int> InsertBook(Book book)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"insert into books(book_name, author_id) values ('{book.BookName}', {book.AuthorId})";
            var result = conn.Execute(sql);
            return result;
        }
    }
    public async Task<int> UpdateBook(Book book)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"update books set book_name = '{book.BookName}', author_id = '{book.AuthorId}' where id = {book.Id}";
            var result = conn.Execute(sql);
            return result;
        }
    }

    public async Task<int> DeleteBook(int id)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"delete from books where id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
}
