using BeginnerTasks.Data;
using BeginnerTasks.Models;
using Microsoft.EntityFrameworkCore;
using Type = BeginnerTasks.Models.Type;

namespace BeginnerTasks.Services;

public class EfCoreQuotationService : IQuotationService
{
    private readonly DataContext _dbContext;

    public EfCoreQuotationService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<QuoteResponse>> GetAllAsync()
    {
        var list = await _dbContext.QuoteTexts
            .Include(x => x.Author)
            .Include(x => x.QuoteType)
            .ToListAsync();
        return new List<QuoteResponse>(list.Select(x =>
            new QuoteResponse(x.QuoteTextId, x.Text, x.Author.FirstName, x.Author.LastName, x.QuoteType.TypeText)));
    }

    public async Task<Quote?> GetByIdAsync(int id)
    {
        var quote = await _dbContext.Quotations.AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
        return quote;
    }


    public async Task<bool> AddAsync(QuoteRequest quoteRequest)
    {
        var authorEntity = new Author { FirstName = quoteRequest.FirstName, LastName = quoteRequest.LastName };
        var typeEntity = new Type { TypeText = quoteRequest.Type };

        var authorFromDatabase = await GetAuthor(quoteRequest.FirstName, quoteRequest.LastName);
        if (authorFromDatabase is not null)
            authorEntity = authorFromDatabase;

        var typeFromDatabase = await GetType(quoteRequest.Type);

        if (typeFromDatabase is not null)
            typeEntity = typeFromDatabase;

        var quoteEntity = new QuoteText
            { Text = quoteRequest.QuoteText, Author = authorEntity, QuoteType = typeEntity };

        await _dbContext.QuoteTexts.AddAsync(quoteEntity);
        var affectedRows = await _dbContext.SaveChangesAsync();
        return affectedRows > 0;
    }

    public async Task<bool> UpdateAsync(Quote quotation)
    {
        try
        {
            _dbContext.Quotations.Update(quotation);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var quotation = await _dbContext.Quotations.FindAsync(id);
            if (quotation == null)
            {
                return false;
            }

            _dbContext.Quotations.Remove(quotation);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task<Author?> GetAuthor(string firstName, string lastName)
    {
        var author =
            await _dbContext.Authors.FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
        return author;
    }

    private async Task<Type?> GetType(string type)
    {
        var typeEntity = await _dbContext.Types.FirstOrDefaultAsync(x => x.TypeText == type);
        return typeEntity;
    }
}