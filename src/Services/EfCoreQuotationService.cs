using BeginnerTasks.Data;
using BeginnerTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace BeginnerTasks.Services;

public class EfCoreQuotationService : IQuotationService
{
    private readonly DataContext _dbContext;

    public EfCoreQuotationService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task<List<Quote>> GetAllAsync()
    {
        var list = await _dbContext.Quotations.ToListAsync();
        return list;
    }

    public async Task<Quote?> GetByIdAsync(int id)
    {
        var quote = await _dbContext.Quotations.AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
        return quote;
    }


    public async Task<bool> AddAsync(Quote quotation)
    {
        try
        {
            await _dbContext.Quotations.AddAsync(quotation);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
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

}