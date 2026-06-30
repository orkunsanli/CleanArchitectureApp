using CleanArchitectureApp.Application.Interfaces;
using CleanArchitectureApp.Domain.Common;
using CleanArchitectureApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureApp.Infrastructure.Repositories;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> DbSet;

    public GenericRepository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) => await DbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await DbSet.ToListAsync();

    public async Task AddAsync(T entity) => await DbSet.AddAsync(entity);

    public void Update(T entity) => DbSet.Update(entity);

    public void Remove(T entity) => DbSet.Remove(entity);

    public async Task<bool> SaveChangesAsync() => await Context.SaveChangesAsync() >= 0;
}
