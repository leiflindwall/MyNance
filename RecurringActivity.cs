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
using LoginSystem;
using MyNance;

namespace AndroidApp
{
    [Activity(Label = "Recurring Expenses/Deposits")]
    public class RecurringActivity : Activity
    {
        string expense_Name = "";
        string expense_Cost = "";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Recurring);

            EditText ExpenseCost = FindViewById<EditText>(Resource.Id.expenseCost);
            ExpenseCost.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                expense_Cost = e.Text.ToString();
            };

            EditText ExpenseName = FindViewById<EditText>(Resource.Id.expenseName);
            ExpenseName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                expense_Name = e.Text.ToString();
            };
           Button Submit_Expense = FindViewById<Button>(Resource.Id.submitExpense);

            Submit_Expense.Click += delegate
            {
                if (expense_Cost != "" && expense_Name != "")
                {
                    StartActivity(typeof(HomeActivity));
                }
            };


        }

       
    }

}