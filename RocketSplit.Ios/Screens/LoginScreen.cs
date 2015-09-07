using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UIKit;
using Foundation;
using CoreGraphics;

namespace RocketSplit.Ios
{
	public class LoginScreen: UIViewController 
	{
		private CGRect dimensions;

		private UITextField textFieldUsername;
		private UITextField textFieldPassword;
		private UIButton buttonSingIn;

		public LoginScreen ()
		{
			this.dimensions = UIScreen.MainScreen.Bounds;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.View.BackgroundColor = UIColor.FromRGB (241, 241, 242);

			//Hide navigation bar
			this.NavigationController.SetNavigationBarHidden (true, false);
			this.NavigationController.NavigationBar.TintColor = UIColor.White;
			this.NavigationController.NavigationBar.BarTintColor = UIColor.Black;

			var navigationBar = NavigationController.NavigationBar;

			navigationBar.TitleTextAttributes = new UIStringAttributes () {
				StrokeColor = UIColor.White
			};


			// This view contains logo 
			UIView topView = new UIView ();
			topView.Frame = new CGRect (dimensions.X, dimensions.Top, dimensions.Width, 75f);
			topView.BackgroundColor = UIColor.FromRGB (241, 101, 44);
			topView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			UIImageView topLogo = new UIImageView (UIImage.FromBundle("Images/transparent.png"));
			topLogo.Frame = new CGRect (5f, 30f, topView.Frame.Width * 0.5f, 40f);

			UIImageView topButton = new UIImageView (UIImage.FromBundle("Images/transparent.png"));
			topButton.Frame = new CGRect (topView.Frame.Width - 45f, 30f, 40f, 40f);
			topButton.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin;

			UIImageView centerLogo = new UIImageView (UIImage.FromBundle("Images/transparent.png"));
			centerLogo.Frame = new CGRect ((dimensions.Width - 170f)/2f, 120f, 170f, 175f);


			UILabel loginLabel = new UILabel ();
			loginLabel.Frame = new CGRect (dimensions.X, centerLogo.Frame.Bottom + 20f, dimensions.Width, 20f);
			loginLabel.Text = "LOGIN";
			loginLabel.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			loginLabel.TextAlignment = UITextAlignment.Center;


			//textfields
			var placeHolderAttributes = new UIStringAttributes {
				ForegroundColor = UIColor.FromRGB(241, 241, 242),
				StrokeColor = UIColor.FromRGB(241, 241, 242),
				Font = UIFont.FromName("CenturyGothic", 15f)
			};

			// padding text in textfield 
			UIView paddingViewUsername = new UIView ();
			paddingViewUsername.Frame = new CGRect (0, 0, 10, 20);
			paddingViewUsername.BackgroundColor = UIColor.Clear;

			UIView paddingViewPassword = new UIView ();
			paddingViewPassword.Frame = new CGRect (0, 0, 10, 20);
			paddingViewPassword.BackgroundColor = UIColor.Clear;

			UITextField textFieldUsername = new UITextField ();
			textFieldUsername.TextColor = UIColor.LightGray;
			textFieldUsername.LeftView = paddingViewUsername;
			textFieldUsername.LeftViewMode = UITextFieldViewMode.Always;
			textFieldUsername.Frame = new CGRect (dimensions.X + 9, dimensions.Y + 360, dimensions.Width - 18, 38);
			textFieldUsername.AttributedPlaceholder = new NSAttributedString("Email:", placeHolderAttributes);
			textFieldUsername.Layer.BorderColor = UIColor.LightGray.CGColor;
			textFieldUsername.BackgroundColor = UIColor.White;
			textFieldUsername.Layer.BorderWidth =  1;
			textFieldUsername.Layer.CornerRadius = 5;

			UITextField textFieldPassword = new UITextField ();
			textFieldPassword.TextColor = UIColor.LightGray;
			textFieldPassword.SecureTextEntry = true;
			textFieldPassword.LeftView = paddingViewPassword;
			textFieldPassword.LeftViewMode = UITextFieldViewMode.Always;
			textFieldPassword.Frame = new CGRect (dimensions.X + 9, dimensions.Y + 406, dimensions.Width - 18, 38);
			textFieldPassword.AttributedPlaceholder = new NSAttributedString("Password", placeHolderAttributes);
			textFieldPassword.Layer.BorderColor = UIColor.LightGray.CGColor;
			textFieldPassword.BackgroundColor = UIColor.White;
			textFieldPassword.Layer.BorderWidth =  1;
			textFieldPassword.Layer.CornerRadius = 5;

			// Buttons
			UIButton buttonSingIn = new UIButton ();
			buttonSingIn = UIButton.FromType (UIButtonType.System);
			buttonSingIn.Frame = new CGRect(dimensions.X + 9, dimensions.Y + 513, dimensions.Width - 18, 42);
			buttonSingIn.SetTitle ("LOGIN", UIControlState.Normal);
			buttonSingIn.SetTitleColor (UIColor.White, UIControlState.Normal);
			buttonSingIn.BackgroundColor = UIColor.FromRGB(66, 148, 182);
			buttonSingIn.Layer.CornerRadius = 5;
			buttonSingIn.ClipsToBounds = true;

			// Define action when user click button
			buttonSingIn.TouchUpInside +=  delegate {

//				if(textFieldUsername.Text == "" || textFieldPassword.Text == "")
//				{
//					new UIAlertView("RocketSplit", "Please enter a username and password", null, "Ok", null).Show();
//					return;
//				}

				buttonSingIn.Enabled = false;

				// Force Keyboard to hide
				this.View.EndEditing(true);
				this.ExecuteLogin(textFieldUsername.Text, textFieldPassword.Text);
			};

			//Remove this block after add final images
			topLogo.BackgroundColor = UIColor.LightGray;
			topButton.BackgroundColor = UIColor.LightGray;
			centerLogo.BackgroundColor = UIColor.LightGray;



			// Add controls to view
			topView.AddSubview (topLogo);
			this.View.AddSubview (topView);

			this.View.Add (textFieldUsername);
			this.View.Add (textFieldPassword);
			this.View.Add (buttonSingIn);
			this.View.AddSubview (centerLogo);
			this.View.AddSubview (loginLabel);
		}

		private void ExecuteLogin(String username, String Password){
			//validate login

			// Continue to menu screen
			HomeScreen homeScreen = new HomeScreen();

			UIView.BeginAnimations ("hideLogin");

			UIView.SetAnimationDuration (0.75);
			UIView.SetAnimationCurve (UIViewAnimationCurve.EaseInOut);
			UIView.SetAnimationTransition (UIViewAnimationTransition.FlipFromRight, this.NavigationController.View, false);

			UIView.CommitAnimations ();

			UIView.BeginAnimations ("showHome");
			UIView.SetAnimationDelay (0.375);
			this.NavigationController.SetViewControllers (new UIViewController[]{ homeScreen }, false);
			UIView.CommitAnimations ();
		}
	}
}

