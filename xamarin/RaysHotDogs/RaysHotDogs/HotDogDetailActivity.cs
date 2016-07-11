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
    [Activity(Label = "Hot dog detail", MainLauncher = true)]
    public class HotDogDetailActivity : Activity
    {

        private ImageView mImageViewHotDog;
        private TextView mTextViewHotDogName;
        private TextView mTextViewShortDescription;
        private TextView mTextViewDescription;
        private TextView mTextViewPrice;
        private EditText mEditTextAmount;
        private Button mButtonCancel;
        private Button mButtonOrder;

        private HotDog mSelectedHotDog;
        private HotDogDataService mDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HotDogDetailView);

            mDataService = new HotDogDataService();
            mSelectedHotDog = mDataService.GetHotDogById(1);

            FindViews();
            BindData();

        }

        private void FindViews()
        {
            mImageViewHotDog = FindViewById<ImageView>(Resource.Id.image_view_hot_dog);
            mTextViewHotDogName = FindViewById<TextView>(Resource.Id.text_view_hot_dog_name);
            mTextViewShortDescription = FindViewById<TextView>(Resource.Id.text_view_short_description);
            mTextViewDescription = FindViewById<TextView>(Resource.Id.text_view_description);
            mTextViewPrice = FindViewById<TextView>(Resource.Id.text_view_price);
            mEditTextAmount = FindViewById<EditText>(Resource.Id.edit_text_amount);
            mButtonCancel = FindViewById<Button>(Resource.Id.button_cancel);
            mButtonOrder = FindViewById<Button>(Resource.Id.button_order);
        }

        private void BindData()
        {
            mTextViewHotDogName.Text = mSelectedHotDog.Name;
            mTextViewShortDescription.Text = mSelectedHotDog.ShortDescription;
            mTextViewDescription.Text = mSelectedHotDog.Description;
            mTextViewPrice.Text = "Price: " + mSelectedHotDog.Price;
        }
    }
}