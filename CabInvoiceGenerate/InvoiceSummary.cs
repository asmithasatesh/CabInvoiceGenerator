using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerate
{
    public class InvoiceSummary
    {

        public int numOfRides;
        public double totalFare;
        public double avgFare;

        //Calculate Average Fare 
        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.avgFare = totalFare/numOfRides;
        }
    
    }
}
