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
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;

namespace RaysHotDogs
{
    // Do we want this activity to start when our app start? If yes then set the annotation of 
    // MainLauncher to true.
    [Activity(Label = "HotDogMenuActivity", MainLauncher = true)]
    public class HotDogMenuActivity : Activity
    {
        private ListView mListViewHotDog;
        private List<HotDog> mAllHotDogs;
        private HotDogDataService mHotDogDataService; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HotDogMenuView);

            mListViewHotDog = FindViewById<ListView>(Resource.Id.list_view_hot_dog);

            mHotDogDataService = new HotDogDataService();

            mAllHotDogs = mHotDogDataService.GetAllHotDogs();

        }
    }
}