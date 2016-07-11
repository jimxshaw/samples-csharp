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

namespace RaysHotDogs.Adapters
{
    public class HotDogListAdapter : BaseAdapter<HotDog>
    {
        List<HotDog> mItems;
        Activity mContext;

        public HotDogListAdapter(Activity context, List<HotDog> items) : base()
        {
            mContext = context;
            mItems = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = mItems[position];

            // We're receiving the convertView parameter. List view rows that are not seen will be placed in limbo to be reused later.
            // When Android eventually calls upon a list view row, that row will be passed in to our convertView parameter, if not then 
            // we'll have to instantiate a new row.

            if (convertView == null)
            {
                convertView = mContext.LayoutInflater.Inflate(Android.Resource.Layout.SimpleExpandableListItem1, null);
            }

            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;

            return convertView;
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override HotDog this[int position]
        {
            get
            {
                return mItems[position];
            }
        }
    }
}