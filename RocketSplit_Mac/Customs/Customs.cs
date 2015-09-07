using System;

using Foundation;
using AppKit;
using CoreGraphics;

namespace RocketSplit_Mac
{
	public class myTextfield : NSTextField
	{
		private NSColor backgroundColor;
		public myTextfield ()
		{
		}


	}

	public class mySecureTextfield : NSSecureTextField
	{
		public mySecureTextfield ()
		{
		}
	}

	public class myButton : NSButton
	{
		public myButton ()
		{
			
		}

		public override void DrawRect (CGRect dirtyRect)
		{
			base.DrawRect (dirtyRect);
		}
	}

}

