using LayeredDbConsole.Data.Repositories;
using LayeredDbConsole.Models;
using LayeredDbConsole.Services;
using Moq;

namespace ServiceTests
{
    [TestClass]
    public class VehicleRentalServiceTests
    {
        private Customer _testCustomer;
        private Vehicle _testVehicle;
        private Mock<IRepository<Customer, Guid>> _customerRepo;
        private Mock<IRepository<Vehicle, Guid>> _vehicleRepo;
        private VehicleRentalService _vehicleRentalService;

        public VehicleRentalServiceTests()
        {
            // set up Mocks
            _testCustomer = new Customer() { FirstName = "Test", LastName = "Person", RegistrationDate = DateTime.Now, RegistrationNumber = Guid.NewGuid() };
            _testVehicle = new Vehicle() { Colour = Colour.Blue, Model = "Test Car", LicenceNumber = "A1A1A1", RegistrationNumber = Guid.NewGuid() };
            _customerRepo = new Mock<IRepository<Customer, Guid>>();
            _vehicleRepo = new Mock<IRepository<Vehicle, Guid>>();
            _vehicleRentalService = new VehicleRentalService(_customerRepo.Object, _vehicleRepo.Object);

        }

        [TestMethod]
        public void GetCustomer_ValidCustomerId_ReturnsCustomer()
        {

            _customerRepo.Setup(c => c.Get(_testCustomer.RegistrationNumber)).Returns(_testCustomer);

            Assert.AreEqual(_testCustomer, _vehicleRentalService.GetCustomerbyId(_testCustomer.RegistrationNumber));
        }

        [TestMethod]
        public void GetVehicleByLicence_ValidVehicleLicence_ReturnsVehicle()
        {
            _vehicleRepo.Setup(v => v.GetByCondition(It.IsAny<Func<Vehicle, bool>>())).Returns(new HashSet<Vehicle>() { _testVehicle });

            Assert.AreEqual(_testVehicle, _vehicleRentalService.GetVehicleByLicence(_testVehicle.LicenceNumber));
        }

        [TestMethod]
        public void AddLease_VehicleAlreadyHasLease_ThrowsInvalidOperation()
        {
            _vehicleRepo.Setup(v => v.Get(_testVehicle.RegistrationNumber)).Returns(_testVehicle);

            _testVehicle.Lease = new Lease();

            Assert.ThrowsException<InvalidOperationException>(() => _vehicleRentalService.AddLease(_testCustomer.RegistrationNumber, _testVehicle.RegistrationNumber, 1));
        }
    }
}