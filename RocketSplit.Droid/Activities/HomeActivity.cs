
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

namespace RocketSplit.Droid
{
	[Activity (Label = "HomeActivity")]			
	public class HomeActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//Remove title bar
			this.RequestWindowFeature(WindowFeatures.NoTitle);

			//Remove notification bar
			this.Window.SetFlags (WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Home);

		}
	}
}

