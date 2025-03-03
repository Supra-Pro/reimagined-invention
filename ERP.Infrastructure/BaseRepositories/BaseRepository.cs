using System.Linq.Expressions;
using ERP.Application.Abstractions.IServices;
using ERP.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.BaseRepositories;

public class BaseRepository<T>: IBaseReporitory<T> where T: class
{

    private readonly ERPDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(ERPDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> Create(T entity)
    {
        var result = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<T> Update(T entity)
    {
        var result = _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> Delete(Expression<Func<T, bool>> expression)
    {
        var result = await _dbSet.FirstOrDefaultAsync(expression);

        if (result == null)
        {
            return false;
        }

        _dbSet.Remove(result);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(expression);
            return result;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }
}