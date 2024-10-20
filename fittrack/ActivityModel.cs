using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fittrack
{
    public class ActivityModel
    {
        public string Name { get; set; }
        public double Metric1 { get; set; }
        public double Metric2 { get; set; }
        public double Metric3 { get; set; }

        public ActivityModel(string name, double metric1, double metric2, double metric3)
        {
            this.Name = name;
            this.Metric1 = metric1;
            this.Metric2 = metric2;
            this.Metric3 = metric3;
        }

        public virtual double CalculateCB()
        {
            return 0;
        }
    }
    public class Walking : ActivityModel
    {
        public Walking(double steps, double distance, double timeTaken) : base("Walking", steps, distance, timeTaken)
        {

        }

        public override double CalculateCB()
        {
            // Example formula for walking
            //im using the  MEt (metabolic equivalent of task) values for each parameter
            //metric1 = steps
            //metric2 = distance
            //metric3 = time taken(hours)
            return (Metric1 * 0.045) + ((Metric2 * 100) / 1609.34) + (Metric3 * 240);

        }
    }

    public class Swimming : ActivityModel
    {
        public Swimming(double laps, double timetaken, double ahr) : base("Swimming", laps, timetaken, ahr)
        {

        }

        public override double CalculateCB()
        {
            //metric1 = laps
            //metric2 = timetaken
            //metric3 = average heart rate
            return 0.01 * Metric1 * Metric2 * Metric3;
        }
    }

}
