using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fittrack.DataAccess
{
    public interface IDataconnection
    {
        GoalModel CreateGoal(GoalModel model);
        User CreatenewUser(User user);
        List<GoalModel> FindAll();
        List<User> FindAllUsers();
    }
}
