// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RocketSplit_Mac
{
	[Register ("MainWindow")]
	partial class MainWindow
	{
		[Outlet]
		AppKit.NSButton btnLogin { get; set; }

		[Outlet]
		AppKit.NSButton termsCheckBox { get; set; }

		[Outlet]
		AppKit.NSImageView topLogoView { get; set; }

		[Outlet]
		AppKit.NSView topView { get; set; }

		[Outlet]
		AppKit.NSTextField txtEmail { get; set; }

		[Outlet]
		AppKit.NSSecureTextField txtPassword { get; set; }

		[Action ("clickBtnLogin:")]
		partial void clickBtnLogin (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnLogin != null) {
				btnLogin.Dispose ();
				btnLogin = null;
			}

			if (topLogoView != null) {
				topLogoView.Dispose ();
				topLogoView = null;
			}

			if (topView != null) {
				topView.Dispose ();
				topView = null;
			}

			if (txtEmail != null) {
				txtEmail.Dispose ();
				txtEmail = null;
			}

			if (txtPassword != null) {
				txtPassword.Dispose ();
				txtPassword = null;
			}

			if (termsCheckBox != null) {
				termsCheckBox.Dispose ();
				termsCheckBox = null;
			}
		}
	}
}
