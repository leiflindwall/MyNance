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
        public float monthly_goal_total;
        public float monthly_goal_current;
        public float[] recurring_charges = new float[100];
        public float misc_charge;
        public int recurring_date;
        private float total_funds;
        private string password;

        public float toString(string temp)
        {
            return float.Parse(temp);
        }
        public void setUsername(string temp_user)
        {
            username = temp_user;
        }
        public void setPassword(string temp_pass)
        {
            password = temp_pass;
        }
        public void setFunds(float temp_total)
        {
            total_funds = temp_total;
        }
        public void setMonthTotal(float temp_month_total)
        {
            monthly_goal_total = temp_month_total;
        }
        public string getUsername()
        {
            return username;
        }
        public string getPassword()
        {
            return password;
        }
        public float getFunds()
        {
            return total_funds;
        }
        public float getMonthTotal()
        {
            return monthly_goal_total;
        }

    }
}