using System;

namespace fittrack
{
    public class GoalModel
    {
        public string? goalname { get; set; }
        public int Steps { get; set; }
        public int Distance { get; set; }
        public int Time { get; set; }

        public int Laps { get; set; }
        public int AHR { get; set; }

        /// <summary>
        /// This calculates the calories burnt for walking exercises.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        public int Walking_calorie(int distance, int time, int steps)
        {
            Steps = steps;
            Distance = distance;
            Time = time;

            int calorie = (steps * distance) / time;
            return calorie;
        }

        /// <summary>
        /// This calculates the calories burnt for swimming exercises.
        /// </summary>
        /// <param name="ahr"></param>
        /// <param name="time"></param>
        /// <param name="laps"></param>
        /// <returns></returns>
        public int Swimming_calorie(int ahr, int time, int laps)
        {
            AHR = ahr;
            Laps = laps;
            Time = time;

            int calorie = (laps * ahr) / time;
            return calorie;
        }

        /// <summary>
        /// This calculates the calories burnt for jumping rope exercises.
        /// </summary>
        /// <param name="jumps"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int JumpingRopeCalories(int jumps, int time)
        {
            int calories = (jumps * 1) / time; // Example formula
            return calories;
        }

        /// <summary>
        /// This calculates the calories burnt for cycling exercises.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int CyclingCalories(int distance, int time)
        {
            int calories = (distance * 1) / time; // Example formula
            return calories;
        }

        /// <summary>
        /// This calculates the calories burnt for running exercises.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int RunningCalories(int distance, int time)
        {
            int calories = (distance * 1) / time; // Example formula
            return calories;
        }
    }
}
