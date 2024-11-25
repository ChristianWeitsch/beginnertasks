using BeginnerTasks.Models;

namespace BeginnerTasks.Services;

public interface IQuotationservice
{
    bool CreateQuoteInDatabase(Quote quote);
    List<Quote> GetQuotesFromDatabase();
    bool UpdateQuoteFromDatabase(Quote quote);
    bool DeleteQuoteFromDatabase(int id);
}