using BeginnerTasks.Models;

namespace BeginnerTasks.Services;

public interface IOldQuotationservice
{
    bool CreateQuoteInDatabase(Quote quote);
    List<Quote> GetQuotesFromDatabase(string? filterType, string? filterValue, string? filterLenght);
    bool UpdateQuoteFromDatabase(Quote quote);
    bool DeleteQuoteFromDatabase(int id);
}

public interface IQuotationService
{
    Task<List<Quote>> GetAllAsync();
    Task<Quote?> GetByIdAsync(int id);
    Task <bool> AddAsync(Quote quotation);
    Task <bool> UpdateAsync(Quote quotation);
    Task <bool> DeleteAsync(int id);
}