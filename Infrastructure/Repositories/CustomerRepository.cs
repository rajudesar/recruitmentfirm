using Domain.Customers;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private readonly ApplicationContext _context;
        public CustomerRepository(ApplicationContext applicationContext)
        {
            this._context = applicationContext;
        }

        public async Task Update(Company company)
        {
            var companyRepo = _context.Companies;
            
            if (company.Id > 0)
                _context.Entry(company).State = EntityState.Modified;
            else
                await companyRepo.AddAsync(company);
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
