using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace fittrack.DataAccess
{
    public class TextFileConnector : IDataconnection
    {
        private const string UserFiles = "UserModel.txt";
        private const string GoalFiles = "GoalModel.txt";

        public static List<User> UserDb = new List<User>();

        public static List<GoalModel> GoalsDb = new List<GoalModel>();



        public User CreatenewUser(User model)
        {

            UserDb.Add(model);
            //List<User> newuser = UserFiles.FullFilePath().loadfile().ConvertTouserModels();

            ////int currentId = 1;
            ////if (newuser.Count > 0)
            ////{

            ////    currentId = newuser.OrderByDescending(x => x.id).First().id + 1;
            ////}

            //newuser.Add(model);
            //newuser.SaveuserFiles(UserFiles);
            return model;
        }
        public GoalModel CreateGoal(GoalModel model)
        {
            //List<GoalModel> NewGoals = GoalFiles.FullFilePath().loadfile().ConvertTogoalModels();

            ////int currentId = 1;
            ////if (NewGoals.Count > 0)
            ////{
            ////    currentId = NewGoals.OrderByDescending(x => x.id).First().id + 1;
            ////}

            //NewGoals.Add(model);
            //NewGoals.SaveGoalsFiles(GoalFiles);

            GoalsDb.Add(model);
            return model;
        }
        public List<User> FindAllUsers()
        {
            //string filePath = ConnectionProcessor.FullFilePath("Users.txt");
            //var lines = filePath.loadfile();
            //return lines.ConvertTouserModels();

            return UserDb;
        }

        List<GoalModel> IDataconnection.FindAll()
        {
            return GoalsDb;
        }

    }
}


