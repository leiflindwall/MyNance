using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
namespace Monthly_Goal_Activity
{
    public class User
    {
        public string username;
        public string password;
        public float total_funds;
        public float monthly_goal_total;
        public float monthly_goal_current;
        public float[] recurring_charges = new float[100];
        public float misc_charge;
        public int recurring_date;

        public float toString(string temp)
        {
            return float.Parse(temp);
        }
    }
}