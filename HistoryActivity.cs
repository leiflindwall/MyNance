using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace MyNance_v1
{
    [Activity(Label = "Transaction History")]
    public class HistoryActivity : Activity
    {//, View.IOnClickListener {

        List<TableItem> tableItems = new List<TableItem>();
        ListView listView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.History);
            listView = FindViewById<ListView>(Resource.Id.List);

            tableItems.Add(new TableItem() { Heading = "Vegetables", SubHeading = "$15.00" });
            tableItems.Add(new TableItem() { Heading = "Books", SubHeading = "$180.00"});
            tableItems.Add(new TableItem() { Heading = "Hulu", SubHeading = "$8.00" });
            tableItems.Add(new TableItem() { Heading = "Legumes", SubHeading = "$6.00"});
            tableItems.Add(new TableItem() { Heading = "Pizza Hut", SubHeading = "$18.00"});

            listView.Adapter = new HomeScreenAdapter(this, tableItems);

            listView.ItemClick += OnListItemClick;
        }

        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = tableItems[e.Position];
            Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t.Heading);
        }
    }
}