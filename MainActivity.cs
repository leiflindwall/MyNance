using Android.App;
using Android.Widget;
using Android.OS;
namespace Monthly_Goal_Activity
{
    [Activity(Label = "MyNance", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button new_goal = FindViewById<Button>(Resource.Id.new_goal_button);
            Button done_button = FindViewById<Button>(Resource.Id.done);
            Button cancel_button = FindViewById<Button>(Resource.Id.cancel);
            EditText goal_change = FindViewById<EditText>(Resource.Id.setGoal);
            TextView user = FindViewById<TextView>(Resource.Id.goal_status);
            User guy = new User();
            guy.monthly_goal_current = 0;
            guy.monthly_goal_total = 0;
            string temp_val = "";
            user.Text = guy.monthly_goal_current + "/" + guy.monthly_goal_total;
            new_goal.Click += delegate
            {
                new_toggle(new_goal, goal_change, done_button, cancel_button);
                goal_change.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
                {
                    temp_val = e.Text.ToString();
                };
                cancel_button.Click += delegate
                {
                    cancel_toggle(goal_change, done_button, cancel_button, new_goal);
                };
                done_button.Click += delegate
                {
                    done_toggle(guy, temp_val, user, goal_change, done_button, cancel_button, new_goal);
                };
                /*goal.Visibility = Android.Views.ViewStates.Gone;
                done.Visibility = Android.Views.ViewStates.Gone;
                cancel.Visibility = Android.Views.ViewStates.Gone;
                new_goal.Visibility = Android.Views.ViewStates.Visible;*/
            };
        }
        public void new_toggle(Button new_item, EditText goal, Button done, Button cancel)
        {
            new_item.Visibility = Android.Views.ViewStates.Gone;
            goal.Visibility = Android.Views.ViewStates.Visible;
            done.Visibility = Android.Views.ViewStates.Visible;
            cancel.Visibility = Android.Views.ViewStates.Visible;
        }
        public void cancel_toggle(EditText goal, Button cancel, Button done, Button new_item)
        {
            goal.Visibility = Android.Views.ViewStates.Gone;
            done.Visibility = Android.Views.ViewStates.Gone;
            cancel.Visibility = Android.Views.ViewStates.Gone;
            new_item.Visibility = Android.Views.ViewStates.Visible;
        }
        public void done_toggle(User item, string temp, TextView total, EditText goal, Button done, Button cancel, Button new_item)
        {
            item.monthly_goal_total = item.toString(temp);
            item.monthly_goal_current = item.monthly_goal_total - 25;
            total.Text = item.monthly_goal_current + "/" + item.monthly_goal_total;
            goal.Visibility = Android.Views.ViewStates.Gone;
            done.Visibility = Android.Views.ViewStates.Gone;
            cancel.Visibility = Android.Views.ViewStates.Gone;
            new_item.Visibility = Android.Views.ViewStates.Visible;
        }
    }
}

