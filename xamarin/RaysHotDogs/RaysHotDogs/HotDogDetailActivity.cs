using System;
using Android.App;
using Android.OS;
using Android.Widget;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Utilities;

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
        private HotDogDataService mHotDogDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HotDogDetailView);

            mHotDogDataService = new HotDogDataService();
            mSelectedHotDog = mHotDogDataService.GetHotDogById(1);

            FindViews();
            BindData();
            HandleEvents();

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

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + mSelectedHotDog.ImagePath + ".jpg");
            mImageViewHotDog.SetImageBitmap(imageBitmap);
        }

        private void HandleEvents()
        {
            mButtonOrder.Click += OrderButtonClick;
            mButtonCancel.Click += CancelButtonClick;
        }

        private void OrderButtonClick(object sender, EventArgs e)
        {
            var amount = Int32.Parse(mEditTextAmount.Text);

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Confirmation");
            dialog.SetMessage("Your hot dog has been added to your cart!");
            dialog.Show();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            // TODO
        }
    }
}