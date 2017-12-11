using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<Person> mItems;
        private ListView mListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mListView = FindViewById<ListView>(Resource.Id.myListView);

            mItems = new List<Person>();
            mItems.Add(new Person { FirstName = "Ramesh", LastName = "Kumar", Age = "22", Gender = "Male" });
            mItems.Add(new Person { FirstName = "Suresh", LastName = "Dixit", Age = "35", Gender = "Male" });
            mItems.Add(new Person { FirstName = "Priya", LastName = "Kumari", Age = "30", Gender = "Female" });

            //From Tutorial 2
            //ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);

            //From Tutorial 3 onwards till
            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            mListView.Adapter = adapter;
            mListView.ItemClick += MListView_ItemClick;
            mListView.ItemLongClick += MListView_ItemLongClick;
        }

        private void MListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].LastName);
        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Console.WriteLine(mItems[e.Position].FirstName);
        }
    }
}

