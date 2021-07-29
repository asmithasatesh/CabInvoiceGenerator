using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerate
{
    public class Rides
    {

        public double distance;
        public int time;

        //Initialize distance and time for each ride
        public Rides(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
        
    }
}
