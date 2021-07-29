using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerate
{
    public class RideRepository
    {
        //Create dictionary to store UserId and Invoice Summary
        Dictionary<int, InvoiceSummary> userRides = new Dictionary<int, InvoiceSummary>();

        //Store invoice of all Rides of a particular User
        public void UserRides(int userId, Rides[] rides, CabInvoiceCalculate.RideType rideType)
        {
            CabInvoiceCalculate cabInvoiceCalculate = new CabInvoiceCalculate(rideType);
            InvoiceSummary invoiceSummary = cabInvoiceCalculate.CalculateFare(rides);
            userRides.Add(userId, invoiceSummary);
        }
        public InvoiceSummary ReturnInvoicefromRepository(int userid)
        {
            //Return Invoice
            return (userRides[userid]);
        }
    }
}
