
using LayeredDbConsole.Data;
using LayeredDbConsole.Data.Repositories;
using LayeredDbConsole.Models;
using LayeredDbConsole.Services;
using Microsoft.EntityFrameworkCore;

Vehicle newVehicle = new Vehicle() { Colour = Colour.Grey, LicenceNumber = "AAA333", Model = "Toyota Car" };
Customer newCustomer = new Customer() { FirstName = "Jane", LastName = "Doe", RegistrationDate = DateTime.Now};

// note that this exposes the db context for direct access - will be remedied with future Dependency Injection course
using(AppDbContext db = new AppDbContext())
{

    DataSeed.Initialize(db);

    VehicleRentalService rentalService = new VehicleRentalService(
            new CustomerRepository(db), new VehicleRepository(db)
        );

    try
    {
        rentalService.CreateVehicle(newVehicle);    
        rentalService.CreateCustomer(newCustomer);

        Vehicle queryVehicle = rentalService.GetVehicleByLicence(newVehicle.LicenceNumber);
        Customer queryCustomer = rentalService.GetCustomerByName(newCustomer.FirstName, newCustomer.LastName);

        rentalService.AddLease(queryCustomer.RegistrationNumber, queryVehicle.RegistrationNumber, 365);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}