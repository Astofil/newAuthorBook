
namespace Infrastructure.Services;
using Npgsql;
using Dapper;
using Domain.Dtos;

public class AuthorService
{
    private readonly DapperContext _context;
    public AuthorService(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAuthors()
    {
        using( var conn = _context.CreateConnection())
        {
            var sql = $"select Id,   first_name as FirstName, last_name as LastName from authors";
            var result = conn.Query<Author>(sql).ToList();
            return result;
        }
    }
     public async Task<int> InsertAuthor(Author author)
     {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"insert into authors(first_name, last_name) Values('{author.FirstName}','{author.LastName}') ";
            var result = conn.Execute(sql);
            return result;
        }
     }
      public async Task<int> UpdateAuthor(Author author)
      {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"update authors set first_name = '{author.FirstName}', last_name = '{author.LastName}' where id = {author.Id}";
            var result = conn.Execute(sql);
            return result;
        }
      }
      public async Task<int> DeleteAuthor(int id)
      {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"delete from authors where id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
      }
}
