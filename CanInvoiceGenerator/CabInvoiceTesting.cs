using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerate;

namespace CanInvoiceGeneratorTesting
{
    [TestClass]
    public class CabInvoiceTesting
    {

        // UC 1- TC 1.1 Calculate fare for Normal Rides
        [TestMethod]
        [TestCategory("CalculatingNormalFare")]
        public void Return_TotalFare_ForNormalRide()
        {
            CabInvoiceCalculate cabInvoiceCalculate = new CabInvoiceCalculate(CabInvoiceCalculate.RideType.Normal);
            double distance = 6.3;
            int time = 15;
            double fare = cabInvoiceCalculate.CalculateFare(distance, time);
            double expected = 78.0;
            Assert.AreEqual(expected, fare);

        }
        // UC 1- TC 1.2 Through exception if given Invalid Values
        [TestMethod]
        [TestCategory("CalculatingNormalFare")]
        public void Return_TotalFare_ForRide_InvalidDistance()
        {
            string expected = "Distance should be Greater than zero";
            try
            {
                CabInvoiceCalculate cabInvoiceCalculate = new CabInvoiceCalculate(CabInvoiceCalculate.RideType.Normal);
                double distance = -1;
                int time = 10;
                double fare = cabInvoiceCalculate.CalculateFare(distance, time);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.message);
            }
        }

        // UC 5- TC 5.1 Calculate fare for Premium Rides
        [TestMethod]
        [TestCategory("CalculatingPremiumFare")]
        public void Return_TotalFare_ForPremiumRide()
        {

            CabInvoiceCalculate cabInvoiceCalculate = new CabInvoiceCalculate(CabInvoiceCalculate.RideType.Premium);
            double distance = 15.0;
            int time = 12;
            double fare = cabInvoiceCalculate.CalculateFare(distance, time);
            double expected = 237.0;
            Assert.AreEqual(expected, fare);

        }

        // UC 5- TC 5.2 Through exception if given Invalid Values
        [TestMethod]
        [TestCategory("CalculatingPremiumFare")]
        public void Return_TotalFare_ForRide_InvalidTime()
        {
            string expected = "Time should be Greater than zero";
            try
            {
                CabInvoiceCalculate cabInvoiceCalculate = new CabInvoiceCalculate(CabInvoiceCalculate.RideType.Premium);
                double distance = 10;
                int time = -3;
                double fare = cabInvoiceCalculate.CalculateFare(distance, time);

            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.message);
            }
        }
        //UC 2- Total Fare for multiple Rides
        [TestMethod]
        [TestCategory("CalculatingTotalFareForMultipleRides")]
        public void Given_MultipleRides_Return_TotalFare()
        {
            CabInvoiceCalculate cabInvoiceCalculate = new CabInvoiceCalculate(CabInvoiceCalculate.RideType.Premium);
            Rides[] rides = { new Rides(2.0, 5), new Rides(0.1, 1) };
            InvoiceSummary summary = new InvoiceSummary(2, 55.0);
            InvoiceSummary expected = cabInvoiceCalculate.CalculateFare(rides);
            Assert.AreEqual(summary.totalFare, expected.totalFare);
        }
        //UC 3 TC 3.1- Return total Total rides
        [TestMethod]
        [TestCategory("Enhanced Invoice")]
        public void Given_MultipleRides_Return_TotalRides()
        {
            CabInvoiceCalculate cabInvoiceCalculate = new CabInvoiceCalculate(CabInvoiceCalculate.RideType.Premium);
            Rides[] rides = { new Rides(2.0, 5), new Rides(0.1, 1) };
            InvoiceSummary summary = new InvoiceSummary(2, 55.0);
            InvoiceSummary expected = cabInvoiceCalculate.CalculateFare(rides);
            Assert.AreEqual(summary.numOfRides, expected.numOfRides);
        }
        //UC 3 TC 3.2- Return total Average Ride
        [TestMethod]
        [TestCategory("Enhanced Invoice")]
        public void Given_MultipleRides_Return_AverageFare()
        {
            CabInvoiceCalculate cabInvoiceCalculate = new CabInvoiceCalculate(CabInvoiceCalculate.RideType.Premium);
            Rides[] rides = { new Rides(2.0, 5), new Rides(0.1, 1) };
            InvoiceSummary summary = new InvoiceSummary(2, 55.0);
            InvoiceSummary expected = cabInvoiceCalculate.CalculateFare(rides);
            Assert.AreEqual(summary.avgFare, expected.avgFare);
        }
        //UC 4- Return InVoice when queried by UserId
        [TestMethod]
        [TestCategory("User ID Invoice Summary")]
        public void Given_UserId_Return_Invoice()
        {
            //Create two users
            int userIdOne = 1, userIdTwo = 2;
            RideRepository rideRepository = new RideRepository();
            //Add value for User id One
            Rides[] userOne = { new Rides(2.0, 5), new Rides(0.1, 1) };
            rideRepository.UserRides(userIdOne, userOne, CabInvoiceCalculate.RideType.Premium);
            //Add Ride value for User id One
            Rides[] userTwo = { new Rides(2.0, 5), new Rides(0.1, 1) };
            rideRepository.UserRides(userIdTwo, userTwo, CabInvoiceCalculate.RideType.Normal);

            InvoiceSummary expected = new InvoiceSummary(2, 30.0);
            InvoiceSummary actual = rideRepository.ReturnInvoicefromRepository(userIdTwo);
            Assert.AreEqual(actual.avgFare, expected.avgFare);
        }
    }
}


