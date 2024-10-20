using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using fittrack; // Namespace of your class library
namespace UI
{
    public partial class Dashboard : Window
    {
        private User user;
        private double totalCaloriesBurned = 0; // Variable to track total calories burned
        private double expectedCaloriesToBurn = 0; // Variable to track user-set goal for calories to burn
        public Dashboard()
        {
            InitializeComponent();
        }
        public static List<UserActivity> ActivityDb = new List<UserActivity>();
        public Dashboard(User user) : this()
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }
            this.user = user;
            UsernameTextBlock.Text = user.Username;
            CaloriesBurnedTextBlock.Text = user.CB.ToString();
            CaloriesBurnedTextBlock.Text = totalCaloriesBurned.ToString(); // Display total burned calories
            ExpectedCaloriesTextBlock.Text = expectedCaloriesToBurn.ToString(); // Display the expected calorie goal
        }
        public static double Walking_calorie(double distance, double time, double steps)
        {
            return (steps * distance * 10) / time;
        }
        public static double Swimming_calorie(double ahr, double time, double laps)
        {
            return (laps * ahr * 10) / time;
        }
        public static double Running_calorie(double distance, double time)
        {
            return (distance / time) * 10;
        }
        public static double Cycling_calorie(double distance, double time)
        {
            return ((distance) / time) * 10; // Example formula
        }
        public static double Jumping_calorie(double jumps, double time)
        {
            return (jumps * 10) / time; // Example formula
        }
        // Calculate Total Calories and check if goal is reached
        private void CheckAndUpdateTotalCalories(double caloriesBurned)
        {
            // Update total calories burned
            totalCaloriesBurned += caloriesBurned;
            CaloriesBurnedTextBlock.Text = totalCaloriesBurned.ToString(); // Update the display of total calories burned
            // Check if the total calories burned have reached the user's expected goal
            if (totalCaloriesBurned >= expectedCaloriesToBurn)
            {
                MessageBox.Show("Congratulations! You've reached your calorie goal!");
            }
        }
        private void SetCalorieGoal_Click(object sender, RoutedEventArgs e)
        {

            if (double.TryParse(ExpectedCaloriesTextBlock.Text, out double expectedCalories))
            {
                expectedCaloriesToBurn = expectedCalories;
                ExpectedCaloriesTextBlock.Text = expectedCalories.ToString();
                MessageBox.Show($"Your calorie goal has been set to {expectedCaloriesToBurn} calories.");
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the expected calories to burn.");
            }
        }



        private void CalcCal_Click(object sender, RoutedEventArgs e)
        {
            var selectedGoalItem = (ListBoxItem)GoalListBox.SelectedItem;
            if (selectedGoalItem != null)
            {
                string selectedActivity = selectedGoalItem.Content.ToString();
                double caloriesBurned = 0;
                switch (selectedActivity)
                {
                    case "Walk":
                        if (double.TryParse(DistanceInput.Text, out double walkDistance) &&
                            double.TryParse(TimeInput.Text, out double walkTime) &&
                            double.TryParse(StepsInput.Text, out double walkSteps))
                        {
                            caloriesBurned = Walking_calorie(walkDistance, walkTime, walkSteps);
                            MessageBox.Show($"Calories burnt walking: {caloriesBurned}");
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid numeric values for walking inputs.");
                        }
                        break;
                    case "Swim":
                        if (double.TryParse(AHRInput.Text, out double swimAHR) &&
                            double.TryParse(SwimDistanceInput.Text, out double swimDistance) &&
                            double.TryParse(LapsInput.Text, out double swimLaps))
                        {
                            caloriesBurned = Swimming_calorie(swimAHR, swimDistance, swimLaps);
                            MessageBox.Show($"Calories burnt swimming: {caloriesBurned}");
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid numeric values for swimming inputs.");
                        }
                        break;
                    case "Jumping":
                        if (double.TryParse(JumpsInput.Text, out double jumps) &&
                            double.TryParse(JumpTimeInput.Text, out double jumpTime))
                        {
                            caloriesBurned = Jumping_calorie(jumps, jumpTime);
                            MessageBox.Show($"Calories burnt jumping: {caloriesBurned}");
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid numeric values for jumps.");
                        }
                        break;
                    case "Cycling":
                        if (double.TryParse(distanceinput.Text, out double cycleDistance) &&
                            double.TryParse(timeinput.Text, out double cycleTime))
                        {
                            caloriesBurned = Cycling_calorie(cycleDistance, cycleTime);
                            MessageBox.Show($"Calories burnt cycling: {caloriesBurned}");
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid numeric values for cycling inputs.");
                        }
                        break;
                    case "Running":
                        if (double.TryParse(running_distanceinput.Text, out double runDistance) &&
                            double.TryParse(running_input.Text, out double runTime))
                        {
                            caloriesBurned = Running_calorie(runDistance, runTime);
                            MessageBox.Show($"Calories burnt running: {caloriesBurned}");
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid numeric values for running inputs.");
                        }
                        break;
                    default:
                        MessageBox.Show("Please select a valid activity from the list.");
                        return;
                }

                CheckAndUpdateTotalCalories(caloriesBurned);
                GoalProgressListBox.Items.Add($"{selectedActivity}: {caloriesBurned} calories burned");
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a goal from the list.");
            }
        }
        private void ClearInputFields()
        {
            // Clear input fields
            DistanceInput.Clear();
            TimeInput.Clear();
            StepsInput.Clear();
            AHRInput.Clear();
            SwimDistanceInput.Clear();
            LapsInput.Clear();
            running_distanceinput.Clear();
            running_input.Clear();
            distanceinput.Clear();
            timeinput.Clear();
            JumpsInput.Clear();
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            // Refresh logic, if any
            MessageBox.Show("Refresh button clicked!");
        }
        private void GoalListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected activity from the ListBox
            var selectedItem = (ListBoxItem)GoalListBox.SelectedItem;
            // Hide all activity parameter panels by default
            WalkParameters.Visibility = Visibility.Collapsed;
            SwimParameters.Visibility = Visibility.Collapsed;
            JumpParameters.Visibility = Visibility.Collapsed;
            CycleParameters.Visibility = Visibility.Collapsed;
            RunningParameters.Visibility = Visibility.Collapsed;
            // Display the relevant parameter panel based on the selected activity
            if (selectedItem != null)
            {
                string activity = selectedItem.Content.ToString();
                switch (activity)
                {
                    case "Walk":
                        WalkParameters.Visibility = Visibility.Visible;
                        break;
                    case "Swim":
                        SwimParameters.Visibility = Visibility.Visible;
                        break;
                    case "Jumping":
                        JumpParameters.Visibility = Visibility.Visible;
                        break;
                    case "Cycling":
                        CycleParameters.Visibility = Visibility.Visible;
                        break;
                    case "Running":
                        RunningParameters.Visibility = Visibility.Visible;
                        break;
                }
            }
        }
    }
}