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
using RaysHotDogs.Utilities;

namespace RaysHotDogs.Adapters
{
    public class HotDogListAdapter : BaseAdapter<HotDog>
    {
        List<HotDog> mHotDogs;
        Activity mContext;

        public HotDogListAdapter(Activity context, List<HotDog> items) : base()
        {
            mContext = context;
            mHotDogs = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            HotDog hotDog = mHotDogs[position];

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + hotDog.ImagePath + ".jpg");

            // We're receiving the convertView parameter. List view rows that are not seen will be placed in limbo to be reused later.
            // When Android eventually calls upon a list view row, that row will be passed in to our convertView parameter, if not then 
            // we'll have to instantiate a new row.

            if (convertView == null)
            {
                // Instead of inflating an Android resource layout, we'll be using our own custom row view layout.
                convertView = mContext.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.text_view_hot_dog_name).Text = hotDog.Name;
            convertView.FindViewById<ImageView>(Resource.Id.image_view_hot_dog).SetImageBitmap(imageBitmap);
            convertView.FindViewById<TextView>(Resource.Id.text_view_short_description).Text = hotDog.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.text_view_price).Text = "$" + hotDog.Price;

            return convertView;
        }

        public override int Count
        {
            get
            {
                return mHotDogs.Count;
            }
        }

        public override HotDog this[int position]
        {
            get
            {
                return mHotDogs[position];
            }
        }
    }
}