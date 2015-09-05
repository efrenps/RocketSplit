using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RocketSplit.Droid
{
	[Activity (Label = "RocketSplit", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//Remove title bar
			this.RequestWindowFeature(WindowFeatures.NoTitle);

			//Remove notification bar
			this.Window.SetFlags (WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.buttonSingIn);
			
			button.Click += delegate {
				Console.WriteLine("click");
			};
		}
	}
}


