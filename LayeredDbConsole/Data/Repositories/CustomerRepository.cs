using LayeredDbConsole.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredDbConsole.Data.Repositories
{
    internal class CustomerRepository : IRepository<Customer, Guid>
    {
        private AppDbContext _appDbContext;
        private void _ExplicitLoadLeases(Customer customer)
        {
            _appDbContext.Entry(customer)
                .Collection(c => c.Leases)
                .Load();
        }
        public void Create(Customer entity)
        {
            _appDbContext.Customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _appDbContext.Customers.Remove(entity);
        }

        public Customer Get(Guid id)
        {
            Customer customer = _appDbContext.Customers.Find(id);

            _ExplicitLoadLeases(customer);

            return customer;
        }

        public ICollection<Customer> GetAll()
        {
            HashSet<Customer> customers = _appDbContext.Customers.ToHashSet();
            foreach(Customer c in customers)
            {
                _ExplicitLoadLeases(c);    
            }
            return customers;
        }

        public ICollection<Customer> GetByCondition(Func<Customer, bool> predicate)
        {
            HashSet<Customer> customers = _appDbContext.Customers.Where(predicate).ToHashSet();

            foreach(Customer c in customers)
            {
                _ExplicitLoadLeases(c);
            }

            return customers;
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

    }
}
