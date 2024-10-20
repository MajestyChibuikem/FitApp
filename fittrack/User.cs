using fittrack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fittrack
{
    public class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }


        /// <summary>
        /// CB = calorieburnt
        /// </summary>
        public double CB { get; set; } = 0;



        /// <summary>
        /// refresh my cb boy!!!
        /// </summary>
        /// <returns></returns>
        //public double RefreshCB()
        //{
        //    CB = 0;
        //    foreach (var activity in Activities)
        //    {

        //        CB += activity.CalculateCB();
        //    }
        //    return CB;
        //}
    }





}
