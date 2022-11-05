using Microsoft.AspNetCore.Mvc;
using Graph.src;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using MongoDB.Driver;
using models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Linq;

namespace api.Controllers;

[ApiController]
[Route("api")]
public class BooksController : ControllerBase
{

    private readonly IMongoCollection<Book> _booksCollection;


    public BooksController(IOptions<BookDatabaseSettings> bookDatabaseSettings)
    {
        var mongoClient = new MongoClient(
           bookDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<Book>(
            bookDatabaseSettings.Value.BooksCollectionName);
    }

    [HttpGet("getAllBooks")]
    public async Task<IEnumerable<Book>> Get()
    {
        return await _booksCollection.Find(_ => true).ToListAsync();
    }

    [HttpGet("getBook/{bookName}")]
    public async Task<Book> GetSpecificBook(string bookName)
    {
        return await _booksCollection.Find(b => b.Name.Contains(bookName)).FirstOrDefaultAsync();
    }
    [HttpGet("getBooks/{order:bool?}")]
    public async Task<IEnumerable<Book>> GetBooks([FromBody] List<string> books,[FromRoute] bool order = false)
    {
        
        var booksQueried = await _booksCollection.Find(b => books.Contains(b.Name)).ToListAsync();
        if(order)
        {
            booksQueried = booksQueried.OrderBy(b => b.Name).ToList();
        }
        return booksQueried;
    }

}