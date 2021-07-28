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
    }
}

