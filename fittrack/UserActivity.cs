using System;
using System.Collections.Generic;

namespace fittrack
{
    public class UserActivity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ActivityName { get; set; }
        public string Metric { get; set; }
        public List<string> MetricList { get; set; } = new List<string>(); // Initialize metricList

        private int Calories;

        // Method to calculate calories based on the activity and input metrics
        public int GetCurrentCalories(string actName, Dictionary<string, int> metrics)
        {
            this.Calories = 0;

            switch (actName.ToLower())
            {
                case "walking":
                    if (metrics.ContainsKey("distance") && metrics.ContainsKey("time") && metrics.ContainsKey("steps"))
                    {
                        this.Calories = Walking_calorie(metrics["distance"], metrics["time"], metrics["steps"]);
                    }
                    break;

                case "swimming":
                    if (metrics.ContainsKey("ahr") && metrics.ContainsKey("time") && metrics.ContainsKey("laps"))
                    {
                        this.Calories = Swimming_calorie(metrics["ahr"], metrics["time"], metrics["laps"]);
                    }
                    break;

                case "running":
                    if (metrics.ContainsKey("distance") && metrics.ContainsKey("time"))
                    {
                        this.Calories = Running_calorie(metrics["distance"], metrics["time"]);
                    }
                    break;

                case "cycling":
                    if (metrics.ContainsKey("distance") && metrics.ContainsKey("time"))
                    {
                        this.Calories = Cycling_calorie(metrics["distance"], metrics["time"]);
                    }
                    break;

                case "jumping":
                    if (metrics.ContainsKey("jumps"))
                    {
                        this.Calories = Jumping_calorie(metrics["jumps"]);
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid activity name.");
            }

            return this.Calories;
        }

        // Adds a metric to the metric list
        public void AddMetric(string metric)
        {
            MetricList.Add(metric);
        }

        // Gets a list of activity details for display
        public List<string> GetActivityDetails()
        {
            List<string> details = new List<string>
            {
                $"Activity: {ActivityName}",
                $"Calories Burned: {Calories}"
            };
            details.AddRange(MetricList);
            return details;
        }

        // Method to get total calories for a specific activity, this can be expanded based on your needs
        public static int GetTotalCaloriesForActivity(string name, List<UserActivity> activities)
        {
            int totalCalories = 0;
            foreach (var activity in activities)
            {
                if (activity.ActivityName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    totalCalories += activity.Calories;
                }
            }
            return totalCalories;
        }

        // Walking calorie calculation
        public int Walking_calorie(int distance, int time, int steps)
        {
            int calorie = (steps * distance) / time;
            return calorie;
        }

        // Swimming calorie calculation
        public int Swimming_calorie(int ahr, int time, int laps)
        {
            int calorie = (laps * ahr) / time;
            return calorie;
        }

        // Running calorie calculation
        public int Running_calorie(int distance, int time)
        {
            int calorie = distance / time;
            return calorie;
        }

        // Cycling calorie calculation
        public int Cycling_calorie(int distance, int time)
        {
            int calorie = distance / time;
            return calorie;
        }

        // Jumping calorie calculation
        public int Jumping_calorie(int jumps)
        {
            int calorie = jumps * 1; // Adjusted calculation for integer
            return calorie;
        }
    }
}
