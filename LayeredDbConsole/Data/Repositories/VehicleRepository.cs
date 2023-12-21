using LayeredDbConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredDbConsole.Data.Repositories
{
    internal class VehicleRepository : IRepository<Vehicle, Guid>
    {
        private AppDbContext _appDbContext;
        private void _ExplicitLoadLeases(Vehicle vehicle)
        {
            _appDbContext.Entry(vehicle)
                .Reference(vehicle => vehicle.Lease)
                .Load();
        }
        public void Create(Vehicle entity)
        {
            _appDbContext.Vehicles.Add(entity);
        }

        public void Delete(Vehicle entity)
        {
            _appDbContext.Vehicles.Remove(entity);
        }

        public Vehicle Get(Guid id)
        {
            Vehicle vehicle = _appDbContext.Vehicles.Find(id);
            _ExplicitLoadLeases(vehicle);
            return vehicle;
        }

        public ICollection<Vehicle> GetAll()
        {
            HashSet<Vehicle> vehicles = _appDbContext.Vehicles.ToHashSet();

            foreach(Vehicle v in vehicles)
            {
                _ExplicitLoadLeases(v);
            }

            return vehicles;
        }

        public ICollection<Vehicle> GetByCondition(Func<Vehicle, bool> predicate)
        {
            HashSet<Vehicle> vehicles = _appDbContext.Vehicles.Where(predicate).ToHashSet();

            foreach(Vehicle v in vehicles)
            {
                _ExplicitLoadLeases(v);
            }

            return vehicles;
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public VehicleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
