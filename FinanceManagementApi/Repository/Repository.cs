using System.Linq.Expressions;
using FinanceManagementApi.Context;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagementApi.Repository;

/// <summary>
/// Repositório genérico para manipulação de entidades no Entity Framework.
/// Fornece operações CRUD e métodos auxiliares reutilizáveis para qualquer tipo de entidade.
/// </summary>
/// <typeparam name="T">Tipo da entidade</typeparam>
public class Repository(AppDbContext _context) : IRepository
{
    #region IRepository Methods
    public async Task CreateAsync<T>(T entity) where T : class
    { await _context.Set<T>().AddAsync(entity); await _context.SaveChangesAsync(); }

    public async Task DeleteAsync<T>(int id) where T : class
    {
        var entityToDelete = await GetByIdAsync<T>(id);

        _context.Set<T>().Remove(entityToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync<T>(int id) where T : class
        => await _context.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException();

    public async Task<T> GetByAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        => await _context.Set<T>().FirstOrDefaultAsync(predicate) ?? throw new KeyNotFoundException();
    
    public async Task<bool> ExistsAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        => await _context.Set<T>().FirstOrDefaultAsync(predicate) is not null; 

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        => await _context.Set<T>().ToListAsync();

    public async Task<List<TCollection>> GetCollectionFromEntityAsync<TEntity, TCollection>(
    int entityId,
    Expression<Func<TEntity, IEnumerable<TCollection>>> includeExpression)

    where TEntity : class
    where TCollection : class

    {
        var entity = await _context.Set<TEntity>()
            .Include(includeExpression)
            .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == entityId)
            ?? throw new Exception($"{typeof(TEntity).Name} com ID {entityId} não encontrado.");

        var collection = includeExpression.Compile().Invoke(entity);

        return collection.ToList();
    }
    #endregion
}
