using BackEnd.BackPack.Domain.Repositories;
using BackEnd.BackPack.Infraestruture.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackEnd.BackPack.Infraestruture.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private IDbContextTransaction _transaction;
    private bool disposed;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed && disposing)
        {
            //dispose managed resources
            _dbContext.Dispose();
        }
        //dispose unmanaged resources
        disposed = true;
    }

    public async Task<IDbContextTransaction> BeginTransaction()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
        return _transaction;
    }
}