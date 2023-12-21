using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredDbConsole.Data;
using LayeredDbConsole.Data.Repositories;
using LayeredDbConsole.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace LayeredDbConsole.Services
{
    public class VehicleRentalService
    {
        private IRepository<Customer, Guid> _customerRepository;
        private IRepository<Vehicle, Guid> _vehicleRepository;
        public VehicleRentalService(IRepository<Customer, Guid> CustomerRepo, IRepository<Vehicle, Guid> VehicleRepo) {

            _customerRepository = CustomerRepo;
            _vehicleRepository = VehicleRepo;
        }

        public bool NameMatches(Customer customer, string firstName, string lastName)
        {
            return (customer.FirstName == firstName && customer.LastName == lastName);
        }

        public Customer? GetCustomerByName(string firstName, string lastName)
        {
            Customer? customer = _customerRepository.GetByCondition(c => (c.FirstName == firstName && c.LastName == lastName)).FirstOrDefault();
            return customer;
        }

        public Customer? GetCustomerbyId(Guid id)
        {
            Customer? customer = _customerRepository.Get(id);
            return customer;
        }

        public Vehicle? GetVehicleByLicence(string licence)
        {
            Vehicle? vehicle = _vehicleRepository.GetByCondition(v => v.LicenceNumber == licence).FirstOrDefault();

            return vehicle;
        }

        public void CreateCustomer(Customer customer)
        {
            Customer foundCustomer = GetCustomerByName(customer.FirstName, customer.LastName);

            if (foundCustomer == null)
            {
                _customerRepository.Create(customer);
                _customerRepository.SaveChanges();                
            } else
            {
                throw new InvalidOperationException("Error: Customer with given names already exists");
            }

        }

        public void CreateVehicle(Vehicle vehicle)
        {
            _vehicleRepository.Create(vehicle);
            _vehicleRepository.SaveChanges();
        }

        public void AddLease(Guid customerGuid, Guid vehicleGuid, int leaseDurationDays)
        {
            Vehicle vehicle = _vehicleRepository.Get(vehicleGuid);
            
            if(vehicle == null) {
                throw new InvalidOperationException("Vehicle not found");
            } else if (vehicle.Lease != null)
            {
                throw new InvalidOperationException("Vehicle already has Lease");
            }

            Customer customer = _customerRepository.Get(customerGuid);

            if(customer == null)
            {
                throw new InvalidOperationException("Customer not found");
            }
            
            Lease newLease = new Lease { Customer = customer, StartDate = DateTime.Now, Vehicle = vehicle, EndDate = DateTime.Now.AddDays(leaseDurationDays) };

            vehicle.Lease = newLease;
            _vehicleRepository.SaveChanges();
        }
    }
}
