using System;

using Foundation;
using AppKit;
using CoreGraphics;

namespace RocketSplit_Mac
{
	public partial class MainWindow : NSWindow
	{
		public MainWindow (IntPtr handle) : base (handle)
		{
		}

		[Export ("initWithCoder:")]
		public MainWindow (NSCoder coder) : base (coder)
		{
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			txtEmail.BecomeFirstResponder ();


			//NSButtonCell cell = btnLogin.Cell;
			//cell.BackgroundColor = NSColor.DarkGray; //FromCalibratedRgba (66f, 148f, 182f, 0.5f);
			//btnLogin.Cell = new NSButtonCell{ BackgroundColor = NSColor.FromSrgb(66f, 148f, 182f, 0.5f) }; 
			//btnLogin.Cell = cell;


			//this.ContentView.AddSubview (labelTest);
		}
	}
}
