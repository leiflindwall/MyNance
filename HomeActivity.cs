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
using Newtonsoft.Json;

namespace MyNance_v1
{
    [Activity(Label = "MyNance")]
    public class HomeActivity : Activity
    {
        string check_flag = "";
        public User guy;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);

            //If statement to check which activity we are coming from when going to the homepage.
            if (Intent != null)
            {
                //These checks are to see which activity the home page is being called from
                //Will be used to implement toast notifications based on what happened
                check_flag = Intent.GetStringExtra("Flag");
                if (check_flag == "Login")
                {
                    guy = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));
                }
                if (check_flag == "Transaction")
                {
                    guy = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));
                }
                if (check_flag == "Goal")
                {
                    guy = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));
                }
                if (check_flag == "EditSuccess")
                {
                    guy = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));
                }
                if (check_flag == "EditCancel")
                {
                    guy = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));
                }
                if (check_flag == "History")
                {
                    guy = JsonConvert.DeserializeObject<User>(Intent.GetStringExtra("User"));
                }
            }

            // ** testing notification code 

            // Set up an intent so that tapping the notifications returns to this app:
            Intent notif_intent = new Intent(this, typeof(Transaction));
            notif_intent.PutExtra("User", JsonConvert.SerializeObject(guy));

            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            PendingIntent pendingIntent =
                PendingIntent.GetActivity(this, pendingIntentId, notif_intent, PendingIntentFlags.OneShot);

            // Instantiate the builder and set notification elements:
            // ignore warning about .setDefaults - changed for android 8.0 / API 26
#pragma warning disable CS0618 // Type or member is obsolete
            Notification.Builder builder = new Notification.Builder(this)
                .SetContentIntent(pendingIntent)
                .SetContentTitle("Account Inactivity")
                .SetContentText("You haven't updated your balance in a while, would you like to add a transaction?")
                 .SetDefaults(NotificationDefaults.Vibrate)
#pragma warning restore CS0618 // Type or member is obsolete
                .SetSmallIcon(Resource.Drawable.icon);

            // Instantiate the Big Text style:
            Notification.BigTextStyle textStyle = new Notification.BigTextStyle();

            // Fill it with text:
            string longTextMessage = "You haven't updated your balance in a while, would you like to add a transaction?";
            textStyle.BigText(longTextMessage);

            // Set the summary text:
            textStyle.SetSummaryText("Update Balance");

            // Plug this style into the builder:
            builder.SetStyle(textStyle);
            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager =
                GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
            // ** end notification code

            //Dispalying and setting Current Total Funds view
            TextView total = FindViewById<TextView>(Resource.Id.total_string);
            total.Text = "$" + string.Format("{0:N2}", guy.getFunds());

            //Button toggle for creating a transaction
            Button transaction_button = FindViewById<Button>(Resource.Id.createTransaction);
            transaction_button.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Transaction));
                intent.PutExtra("User", JsonConvert.SerializeObject(guy));
                this.StartActivity(intent);
                this.Finish();
            };
            // Get our button from the layout resource,
            // and attach an event to it
            Button goal_button = FindViewById<Button>(Resource.Id.goalButton);
            goal_button.Click += delegate
            {
                //here we will jump to the monthly goal page
                Intent intent = new Intent(this, typeof(GoalActivity));
                intent.PutExtra("User", JsonConvert.SerializeObject(guy));
                this.StartActivity(intent);
                this.Finish();
            };

            Button recurring_button = FindViewById<Button>(Resource.Id.recurringButton);
            recurring_button.Click += delegate
            { 
                //here we will jump to the page to create a recurring expense
                StartActivity(typeof(RecurringActivity));
            };

            Button history_button = FindViewById<Button>(Resource.Id.historyButton);
            history_button.Click += delegate
            {
                //here we will jump to the monthly transaction history page
                Intent intent = new Intent(this, typeof(HistoryActivity));
                intent.PutExtra("User", JsonConvert.SerializeObject(guy));
                this.StartActivity(intent);
                this.Finish();
            };

            //Button toggle for editing account information
            Button edit_account = FindViewById<Button>(Resource.Id.editAccount);
            edit_account.Click += delegate
            {
                Intent intent = new Intent(this, typeof(EditAccount));
                intent.PutExtra("User", JsonConvert.SerializeObject(guy));
                this.StartActivity(intent);
                this.Finish();
            };

            Button emailButton = FindViewById<Button>(Resource.Id.HelpButton);
            emailButton.Click += (sender, e) =>
            {
                //Xamarin.Forms.Device.OpenUri(new Uri("mailto:mikelindwall@gmail.com"));
                Intent email = new Intent(Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, new string[] { "team@MyNance.com" });
                email.PutExtra(Intent.ExtraSubject, "MyNance Help / Contact:");
                email.PutExtra(Intent.ExtraText, "");
                email.SetType("message/rfc822");
                StartActivity(Intent.CreateChooser(email, "Send Email Via"));
            };

            Button logout_button = FindViewById<Button>(Resource.Id.logoutButton);
            logout_button.Click += delegate
            {
                //here we will logout and go back to the login screen
                Intent intent = new Intent(this, typeof(MainActivity));
                intent.PutExtra("username", guy.getUsername());
                intent.PutExtra("password", guy.getPassword());
                intent.PutExtra("total", guy.getFunds().ToString());
                intent.PutExtra("Flag", "Home");
                this.StartActivity(intent);
                this.Finish();
            };

        }

    }
}