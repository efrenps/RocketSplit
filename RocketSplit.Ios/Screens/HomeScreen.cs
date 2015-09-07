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
	public class HomeScreen : UIViewController
	{
		private CGRect dimensions;

		private UIScrollView mainScrollView;
		private nfloat scrollViewHeight = 0f;

		private nint myAccounts;
		private nint availableAccounts;

		private UIButton buttonCloud;
		private UIButton buttonFolder;
		private UIButton buttonFile;
		//private UIButton buttonCloud;
		//private UIButton buttonCloud;

		private UIView borderBottom1;
		private UIView borderBottom2;
		private UIView borderBottom3;

		private UIView bodyView;


		private List<object> tree;

		public enum Tabs
		{
			ACCOUNTS,
			FOLDERS,
			FILES
		}

		public HomeScreen ()
		{
			this.dimensions = UIScreen.MainScreen.Bounds;

			//Sync accounts
			this.myAccounts = 3;
			this.availableAccounts = 6;

			List<string> files1 = loadFiles ("file", "txt", 10);
			List<string> files2 = loadFiles ("music", "mp3", 10);
			List<string> files3 = loadFiles ("video", "avi", 10);
			List<string> files4 = loadFiles ("file", "xml", 10);
			List<string> files5 = loadFiles ("pic", "jpg", 10);
			List<string> files6 = loadFiles ("file", "psd", 10);
			List<string> files7 = loadFiles ("music", "wav", 10);
			List<string> files8 = loadFiles ("video", "mp4", 10);
			List<string> files9 = loadFiles ("file", "docx", 10);
			List<string> files10 = loadFiles ("file", "ppt", 10);

			List<object> folder1 = new List<object> (){ files1, files2 };
			List<object> folder2 = new List<object> (){ files3, files4 };
			List<object> folder3 = new List<object> (){ files4, files5 };
			List<object> folder4 = new List<object> (){ files6, files7 };
			List<object> folder5 = new List<object> (){ files1, files9 };
			List<object> folder6 = new List<object> (){ files2, files5 };
			List<object> folder7 = new List<object> (){ files3, files10 };
			List<object> folder8 = new List<object> (){ files4, files9 };
			List<object> folder9 = new List<object> (){ files5, files8 };
			List<object> folder10 = new List<object> (){ files6, files7 };

			List<object> folder11 = new List<object> (){ folder1, folder10 };
			List<object> folder12 = new List<object> (){ folder2, folder9 };
			List<object> folder13 = new List<object> (){ folder3, folder8 };
			List<object> folder14 = new List<object> (){ folder4, folder7 };
			List<object> folder15 = new List<object> (){ folder5, folder6 };
			List<object> folder16 = new List<object> (){ folder6, folder5 };
			List<object> folder17 = new List<object> (){ folder7, folder4 };
			List<object> folder18 = new List<object> (){ folder8, folder3 };
			List<object> folder19 = new List<object> (){ folder9, folder2};
			List<object> folder20 = new List<object> (){ folder10, folder1 };


			List<object> folder21 = new List<object> (){ folder11, folder20 };
			List<object> folder22 = new List<object> (){ folder12, folder19 };
			List<object> folder23 = new List<object> (){ folder13, folder18 };
			List<object> folder24 = new List<object> (){ folder14, folder17 };
			List<object> folder25 = new List<object> (){ folder15, folder16 };
			List<object> folder26 = new List<object> (){ folder16, folder15 };
			List<object> folder27 = new List<object> (){ folder17, folder14 };
			List<object> folder28 = new List<object> (){ folder18, folder13 };
			List<object> folder29 = new List<object> (){ folder19, folder12 };
			List<object> folder30 = new List<object> (){ folder20, folder11 };

			List<object> folder31 = new List<object> (){ folder21, folder30 };
			List<object> folder32 = new List<object> (){ folder22, folder29 };
			List<object> folder33 = new List<object> (){ folder23, folder28 };
			List<object> folder34 = new List<object> (){ folder24, folder27 };
			List<object> folder35 = new List<object> (){ folder25, folder26 };
			List<object> folder36 = new List<object> (){ folder26, folder25 };
			List<object> folder37 = new List<object> (){ folder27, folder24 };
			List<object> folder38 = new List<object> (){ folder28, folder23 };
			List<object> folder39 = new List<object> (){ folder29, folder22 };
			List<object> folder40 = new List<object> (){ folder30, folder21 };


			//load tree
			this.tree = new List<object>(){
				folder31,folder32,folder33,folder34,folder35,folder36,folder37,folder38,folder39,folder40, 
			};

			Console.WriteLine (this.tree);
		}

		private List<string> loadFiles(string file, string ext, nint qty){
			List<string> files = new List<string> ();
			for (nint i = 0; i <= qty; i++) {
				files.Add (String.Format ("{0}{1}.{2}", file, i, ext));
			}
			return files;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.View.BackgroundColor = UIColor.FromRGB (241, 241, 242);
			this.scrollViewHeight = dimensions.Size.Height + 75f;

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


			this.mainScrollView = new UIScrollView {
				Frame = new CGRect (dimensions.X, topView.Frame.Bottom, dimensions.Width, dimensions.Height - topView.Frame.Bottom),
				BackgroundColor = UIColor.White,
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
				Bounces = true
			};

			UIImageView userPicture = new UIImageView (UIImage.FromBundle("Images/transparent.png"));
			userPicture.Frame = new CGRect (15f, 20f, 120f, 115f);

			UILabel nameLabel = new UILabel ();
			nameLabel.Frame = new CGRect (userPicture.Frame.Right + 10f, userPicture.Frame.Bottom - 65f, dimensions.Width, 20f);
			nameLabel.Text = "Sofia Vergara";
			nameLabel.Font = UIFont.BoldSystemFontOfSize (18f);
			nameLabel.TextAlignment = UITextAlignment.Left;

			UIImageView accountPicture = new UIImageView (UIImage.FromBundle("Images/transparent.png"));
			accountPicture.Frame = new CGRect (userPicture.Frame.Right + 10f, userPicture.Frame.Bottom - 40f, 15f, 15f);

			UILabel accountLabel = new UILabel ();
			accountLabel.Frame = new CGRect (userPicture.Frame.Right + 30f, userPicture.Frame.Bottom - 45f, dimensions.Width, 25f);
			accountLabel.Text =  String.Format("{0} Accounts Syncronized", this.myAccounts);
			accountLabel.TextAlignment = UITextAlignment.Left;
			accountLabel.Font = UIFont.SystemFontOfSize (12f);
			accountLabel.TextColor = UIColor.LightGray;

			UIButton buttonEdit = new UIButton ();
			buttonEdit = UIButton.FromType (UIButtonType.System);
			buttonEdit.Frame = new CGRect(userPicture.Frame.Right + 10f, userPicture.Frame.Bottom - 20f, dimensions.Width , 20f);
			buttonEdit.SetTitle ("EDIT PICTURE", UIControlState.Normal);
			buttonEdit.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;


			UIView tabView = this.customTabView (userPicture.Frame.Bottom);

			this.bodyView = this.createBodyView (tabView.Frame.Bottom);
			this.handleBodyView(Tabs.ACCOUNTS);

			//Remove this block after add final images
			topLogo.BackgroundColor = UIColor.LightGray;
			topButton.BackgroundColor = UIColor.LightGray;
			userPicture.BackgroundColor = UIColor.LightGray;
			accountPicture.BackgroundColor = UIColor.LightGray;

			// Add controls to view
			topView.AddSubview (topLogo);
			topView.AddSubview (topButton);

			this.mainScrollView.AddSubview (userPicture);
			this.mainScrollView.AddSubview (nameLabel);
			this.mainScrollView.AddSubview (accountPicture);
			this.mainScrollView.AddSubview (accountLabel);
			this.mainScrollView.AddSubview (buttonEdit);
			this.mainScrollView.AddSubview (tabView);
			this.mainScrollView.AddSubview (bodyView);

			this.View.AddSubview (topView);
			this.View.AddSubview (mainScrollView);

			CGSize size =  dimensions.Size;
			size.Height = this.scrollViewHeight;
			this.mainScrollView.ContentSize = size; //new SizeF (Convert.toF dimensions.Width, dimensions.Height);
		}

		private UIView customTabView(nfloat yPos)
		{
			UIView myView = new UIView ();
			myView.Frame = new CGRect (dimensions.X, yPos + 25f, dimensions.Width, 50f);
			myView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			UIView borderTop = new UIView (new CGRect (0f, 0f, myView.Frame.Width, 1f));
			borderTop.BackgroundColor = UIColor.LightGray;
			borderTop.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			UIColor selectedColor = UIColor.FromRGB (241, 241, 242);
			UIColor defaultColor = UIColor.LightGray;

			buttonCloud = new UIButton ();
			buttonCloud = UIButton.FromType (UIButtonType.System);
			buttonCloud.Frame = new CGRect(0f, 1f, myView.Frame.Width * 0.3f, myView.Frame.Height - 2f);
			buttonCloud.SetTitle ("Accounts", UIControlState.Normal);
			buttonCloud.SetTitleColor (UIColor.Black, UIControlState.Normal);
			buttonCloud.BackgroundColor = selectedColor;
			buttonCloud.ClipsToBounds = true;

			buttonFolder = new UIButton ();
			buttonFolder = UIButton.FromType (UIButtonType.System);
			buttonFolder.Frame = new CGRect(myView.Frame.Width * 0.3f, 1f, myView.Frame.Width * 0.3f, myView.Frame.Height - 2f);
			buttonFolder.SetTitle ("My Folders", UIControlState.Normal);
			buttonFolder.SetTitleColor (UIColor.LightGray, UIControlState.Normal);
			buttonFolder.ClipsToBounds = true;

			buttonFile = new UIButton ();
			buttonFile = UIButton.FromType (UIButtonType.System);
			buttonFile.Frame = new CGRect(myView.Frame.Width * 0.6f, 1f, myView.Frame.Width * 0.3f, myView.Frame.Height - 2f);
			buttonFile.SetTitle ("My Files", UIControlState.Normal);
			buttonFile.SetTitleColor (UIColor.LightGray, UIControlState.Normal);
			buttonFile.ClipsToBounds = true;


			borderBottom1 = new UIView (new CGRect (0f, myView.Frame.Height - 1f, myView.Frame.Width * 0.3f, 1f));
			borderBottom1.BackgroundColor = selectedColor;

			borderBottom2 = new UIView (new CGRect (borderBottom1.Frame.Right, myView.Frame.Height - 1f, myView.Frame.Width * 0.3f, 1f));
			borderBottom2.BackgroundColor = defaultColor;

			borderBottom3 = new UIView (new CGRect (borderBottom2.Frame.Right, myView.Frame.Height - 1f, myView.Frame.Width * 0.4f, 1f));
			borderBottom3.BackgroundColor = defaultColor;

			//buttonCloud.Font = UIFont.BoldSystemFontOfSize (12f);
			//buttonFolder.Font = UIFont.BoldSystemFontOfSize (18f);
			//buttonFile.Font = UIFont.BoldSystemFontOfSize (18f);

//			buttonCloud.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
//			buttonFolder.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
//			buttonFile.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;

			buttonCloud.TouchUpInside += delegate {
				buttonCloud.BackgroundColor = selectedColor;
				buttonFolder.BackgroundColor = UIColor.White;
				buttonFile.BackgroundColor = UIColor.White;

				borderBottom1.BackgroundColor = selectedColor;
				borderBottom2.BackgroundColor = defaultColor;
				borderBottom3.BackgroundColor = defaultColor;

				buttonCloud.SetTitleColor (UIColor.Black, UIControlState.Normal);
				buttonFolder.SetTitleColor (UIColor.LightGray, UIControlState.Normal);
				buttonFile.SetTitleColor (UIColor.LightGray, UIControlState.Normal);

				this.handleBodyView(Tabs.ACCOUNTS);
			};
			buttonFolder.TouchUpInside += delegate {
				buttonCloud.BackgroundColor = UIColor.White;
				buttonFolder.BackgroundColor = selectedColor;
				buttonFile.BackgroundColor = UIColor.White;

				borderBottom1.BackgroundColor = defaultColor;
				borderBottom2.BackgroundColor = selectedColor;
				borderBottom3.BackgroundColor = defaultColor;

				buttonCloud.SetTitleColor (UIColor.LightGray, UIControlState.Normal);
				buttonFolder.SetTitleColor (UIColor.Black, UIControlState.Normal);
				buttonFile.SetTitleColor (UIColor.LightGray, UIControlState.Normal);

				this.handleBodyView(Tabs.FOLDERS);
			};
			buttonFile.TouchUpInside += delegate {
				buttonCloud.BackgroundColor = UIColor.White;
				buttonFolder.BackgroundColor = UIColor.White;
				buttonFile.BackgroundColor = selectedColor;

				borderBottom1.BackgroundColor = defaultColor;
				borderBottom2.BackgroundColor = defaultColor;
				borderBottom3.BackgroundColor = selectedColor;

				buttonCloud.SetTitleColor (UIColor.LightGray, UIControlState.Normal);
				buttonFolder.SetTitleColor (UIColor.LightGray, UIControlState.Normal);
				buttonFile.SetTitleColor (UIColor.Black, UIControlState.Normal);

				this.handleBodyView(Tabs.FILES);
			};

			myView.AddSubview (borderTop);
			myView.AddSubview (buttonCloud);
			myView.AddSubview (buttonFolder);
			myView.AddSubview (buttonFile);
			myView.AddSubview (borderBottom1);
			myView.AddSubview (borderBottom2);
			myView.AddSubview (borderBottom3);
			return myView;
		}

		private UIView createBodyView(nfloat yPos)
		{
			UIView myView = new UIView ();
			myView.Frame = new CGRect (dimensions.X, yPos, dimensions.Width, this.scrollViewHeight - yPos);
			myView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			myView.BackgroundColor = UIColor.FromRGB (241, 241, 242);
			return myView;
		}

		private void handleBodyView(Tabs selectedTab)
		{
			UIView content = new UIView ();
			UIScrollView bodyScrollView = new UIScrollView {
				Frame = new CGRect ( 0f, 0f, bodyView.Frame.Width, bodyView.Frame.Height),
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth,
				Bounces = true
			};

			//clear body view
			foreach (UIView view in this.bodyView.Subviews) {
				view.RemoveFromSuperview ();
			}

			if (selectedTab == Tabs.ACCOUNTS) {
				content = this.createAccountsView ();
			} else if (selectedTab == Tabs.FILES) {
				content = this.createFilesView();
			} else if (selectedTab == Tabs.FOLDERS) {
				content =  this.createFolderView();
			}

			bodyScrollView.AddSubview (content);
			bodyScrollView.ContentSize = content.Frame.Size;
			this.bodyView.AddSubview(bodyScrollView);
		}

		private UIView createDefaultView()
		{
			UIView myView = new UIView ();
			myView.Frame = new CGRect (0f, 0f, this.bodyView.Frame.Width, this.bodyView.Frame.Height);
			myView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			myView.BackgroundColor = UIColor.FromRGB (241, 241, 242);
			return myView;
		}


		/*
		 *  ACCOUNTS VIEW  
		 *
		 */

		private UIView headerAccountView(CGRect frame)
		{
			UIView myView = new UIView ();
			myView.Frame = new CGRect (0f, 0f, frame.Width, 50f);
			myView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			if (this.myAccounts > 0) {
				UILabel label1 = new UILabel ();
				label1.Frame = new CGRect (0f,0f, myView.Frame.Width, myView.Frame.Height);
				label1.Text = String.Format ("You have {0} synchronized accounts", this.myAccounts);
				label1.Font = UIFont.BoldSystemFontOfSize (14f);
				label1.TextAlignment = UITextAlignment.Center;
				myView.AddSubview (label1);

			} else {
				myView.Frame = new CGRect (0f, 0f, frame.Width, 80f);

				UILabel label1 = new UILabel ();
				label1.Frame = new CGRect (0f,10f, myView.Frame.Width, 20f);
				label1.Text = "You do not have any synchronized accounts";
				label1.Font = UIFont.BoldSystemFontOfSize (14f);
				label1.TextAlignment = UITextAlignment.Center;

				UILabel label2 = new UILabel ();
				label2.Frame = new CGRect (0f,label1.Frame.Bottom, myView.Frame.Width, 20f);
				label2.Text = "Please sync your cloud accounts";
				label2.Font = UIFont.SystemFontOfSize (12f);
				label2.TextAlignment = UITextAlignment.Center;

				UILabel label3 = new UILabel ();
				label3.Frame = new CGRect (0f,label2.Frame.Bottom, myView.Frame.Width, 20f);
				label3.Text = "(a minimum of 2 cloud accounts are required)";
				label3.Font = UIFont.SystemFontOfSize (12f);
				label3.TextAlignment = UITextAlignment.Center;

				UIView borderBottom = new UIView (new CGRect (0f, myView.Frame.Height - 1f, myView.Frame.Width, 1f));
				borderBottom.BackgroundColor = UIColor.LightGray;

				myView.AddSubview (label1);
				myView.AddSubview (label2);
				myView.AddSubview (label3);
				myView.AddSubview (borderBottom);
			}

			return myView;
		}


		private UIView createField(nfloat yPos, nint number)
		{
			UIView myView = new UIView ();
			myView.Frame = new CGRect (0f, yPos, this.bodyView.Frame.Width, 40f);
			myView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			// Buttons
			UIButton button = new UIButton ();
			button = UIButton.FromType (UIButtonType.System);
			button.Frame = new CGRect(myView.Frame.Width * 0.2f, 10f, myView.Frame.Width * 0.6f, 30f);
			button.SetTitle (String.Format("Company {0}", number), UIControlState.Normal);
			button.SetTitleColor (UIColor.White, UIControlState.Normal);
			button.BackgroundColor = UIColor.FromRGB(66, 148, 182);
			button.Layer.CornerRadius = 5;
			button.ClipsToBounds = true;

			// Define action when user click button
			button.TouchUpInside +=  delegate {
				Console.WriteLine("tap");
			};

			myView.AddSubview (button);
			return myView;
		}

		private UIView listField(nfloat yPos, nint number, string usernameText = null)
		{
			UIView myView = new UIView ();
			myView.Frame = new CGRect (10f, yPos, this.bodyView.Frame.Width - 20f, 65f);
			myView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;

			UILabel label = new UILabel ();
			label.Frame = new CGRect (0f, 0f, myView.Frame.Width, 20f);
			label.Text = String.Format("COMPANY {0}", number);
			label.Font = UIFont.SystemFontOfSize (14f);
			label.TextAlignment = UITextAlignment.Left;

			//textfields
			var placeHolderAttributes = new UIStringAttributes {
				ForegroundColor = UIColor.LightGray,
				StrokeColor = UIColor.FromRGB(241, 241, 242),
				Font = UIFont.FromName("CenturyGothic", 15f)
			};

			// padding text in textfield 
			UIView padding = new UIView ();
			padding.Frame = new CGRect (0, 0, 10, 20);
			padding.BackgroundColor = UIColor.Clear;

			UIView padding2 = new UIView ();
			padding2.Frame = new CGRect (0, 0, 10, 20);
			padding2.BackgroundColor = UIColor.Clear;

			UITextField username = new UITextField ();
			username.TextColor = UIColor.Black;
			username.LeftView = padding;
			username.LeftViewMode = UITextFieldViewMode.Always;
			username.Frame = new CGRect (0f, label.Frame.Bottom + 5f, myView.Frame.Width * 0.4f, 30f);
			username.AttributedPlaceholder = new NSAttributedString("Email:", placeHolderAttributes);
			username.Layer.BorderColor = UIColor.LightGray.CGColor;
			username.BackgroundColor = UIColor.White;
			username.Layer.BorderWidth =  1;
			username.Layer.CornerRadius = 5;
			username.Font = UIFont.SystemFontOfSize (12f);

			UITextField password = new UITextField ();
			password.TextColor = UIColor.Black;
			password.SecureTextEntry = true;
			password.LeftView = padding2;
			password.LeftViewMode = UITextFieldViewMode.Always;
			password.Frame = new CGRect (username.Frame.Right + (myView.Frame.Width * 0.01f), label.Frame.Bottom + 5f, myView.Frame.Width * 0.4f, 30f);
			password.AttributedPlaceholder = new NSAttributedString("Password", placeHolderAttributes);
			password.Layer.BorderColor = UIColor.LightGray.CGColor;
			password.BackgroundColor = UIColor.White;
			password.Layer.BorderWidth =  1;
			password.Layer.CornerRadius = 5;
			password.Font = UIFont.SystemFontOfSize (12f);

			// Buttons
			UIButton button = new UIButton ();
			button = UIButton.FromType (UIButtonType.System);
			button.Frame = new CGRect(password.Frame.Right + (myView.Frame.Width * 0.01f), label.Frame.Bottom + 5f, myView.Frame.Width * 0.18f, 30f);
			button.SetTitle ("SYNC", UIControlState.Normal);
			button.SetTitleColor (UIColor.White, UIControlState.Normal);
			button.BackgroundColor = UIColor.FromRGB(66, 148, 182);
			button.Layer.CornerRadius = 5;
			button.ClipsToBounds = true;

			// Define action when user click button
			button.TouchUpInside +=  delegate {
				Console.WriteLine("tap " + username.Text);
			};


			if (!String.IsNullOrEmpty (usernameText)) {
				username.Text = usernameText;
				password.Text = "XXXXXXXXXX";
				username.Enabled = false;
				password.Enabled = false;
				button.SetTitle ("Delete", UIControlState.Normal);
				button.BackgroundColor = UIColor.FromRGB(241, 101, 44);
			}

			myView.AddSubview (label);
			myView.AddSubview (username);
			myView.AddSubview (password);
			myView.AddSubview (button);
			return myView;
		}


		private UIView listAccountView (CGRect frame)
		{
			UIView myView = new UIView ();
			myView.Frame = new CGRect (0f, frame.Bottom, frame.Width, 0);
			nfloat height = 0f;

			if (this.myAccounts > 0) {
				height = 15f;
				for (nint i = 1; i <= this.myAccounts; i++) {
					UIView view = this.listField (height, i, "sofiav@gmail.com");
					height += view.Frame.Height;
					myView.AddSubview (view);
				}
				height += 20f;

				myView.Frame = new CGRect (0f, frame.Bottom, frame.Width, height);
				UIView borderBottom = new UIView (new CGRect (0f, myView.Frame.Height - 1f, myView.Frame.Width, 1f));
				borderBottom.BackgroundColor = UIColor.LightGray;
				myView.AddSubview (borderBottom);
			}

			myView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			return myView;
		}

		private UIView addAccountView (CGRect frame)
		{
			UIView myView = new UIView ();
			nfloat height = 0f;
			myView.Frame = new CGRect (0f, frame.Bottom, frame.Width, height);

			nint missedAccounts = this.availableAccounts - this.myAccounts;

			if (missedAccounts > 0) {
				
				UILabel label = new UILabel ();
				label.Frame = new CGRect (0f, 10f, myView.Frame.Width, 20f);
				label.Text = "Add and Account";
				label.Font = UIFont.BoldSystemFontOfSize (14);
				label.TextAlignment = UITextAlignment.Center;

				myView.AddSubview (label);
				height += 20f + label.Frame.Bottom;

				for (nint i = 1; i <= missedAccounts; i++) {
					UIView view = this.listField (height, (i + this.myAccounts));
					height += view.Frame.Height;
					myView.AddSubview (view);
				}
				height += 20f;

				myView.Frame = new CGRect (0f, frame.Bottom, frame.Width, height);
				UIView borderBottom = new UIView (new CGRect (0f, myView.Frame.Height - 1f, myView.Frame.Width, 1f));
				borderBottom.BackgroundColor = UIColor.LightGray;
				myView.AddSubview (borderBottom);
			}

			myView.Frame = new CGRect (0f, frame.Bottom, frame.Width, height);
			myView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			return myView;
		}

		private UIView newsAccountView (CGRect frame)
		{
			UIView myView = new UIView ();
			nfloat height = 0f;
			myView.Frame = new CGRect (0f, frame.Bottom, frame.Width, height);

			nint missedAccounts = this.availableAccounts - this.myAccounts;

			if (missedAccounts > 0) {

				UILabel label = new UILabel ();
				label.Frame = new CGRect (0f, 10f, myView.Frame.Width, 20f);
				label.Text = "Or Create an Account";
				label.Font = UIFont.BoldSystemFontOfSize (14);
				label.TextAlignment = UITextAlignment.Center;

				myView.AddSubview (label);
				height += 15f + label.Frame.Bottom;

				for (nint i = 1; i <= missedAccounts; i++) {
					UIView view = this.createField (height, (i + this.myAccounts));
					height += view.Frame.Height;
					myView.AddSubview (view);
				}
				height += 20f;

				myView.Frame = new CGRect (0f, frame.Bottom, frame.Width, height);
				UIView borderBottom = new UIView (new CGRect (0f, myView.Frame.Height - 1f, myView.Frame.Width, 1f));
				borderBottom.BackgroundColor = UIColor.LightGray;
				myView.AddSubview (borderBottom);
			}

			myView.Frame = new CGRect (0f, frame.Bottom, frame.Width, height);
			myView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			return myView;
		}

		private UIView createAccountsView()
		{
			UIView myView = this.createDefaultView ();
			UIView header = headerAccountView (myView.Frame);
			UIView listAccount = listAccountView (header.Frame);
			UIView addAccount = addAccountView (listAccount.Frame);
			UIView newAccount = newsAccountView (addAccount.Frame);

			CGRect frame = myView.Frame;
			frame.Height = newAccount.Frame.Bottom;
			myView.Frame = frame;

			myView.AddSubview (header);
			myView.AddSubview (listAccount);
			myView.AddSubview (addAccount);
			myView.AddSubview (newAccount);

			return myView;
		}



		/*
		 *  FOLDER VIEW  
		 *
		 */

		private UIView createFolderView()
		{
			UIView myView = this.createDefaultView ();
			UIView containerView = this.bodyFolderView (myView.Frame);
			UIView utilityView = this.createUtilityView (myView.Frame);

			myView.AddSubview (containerView);
			myView.AddSubview (utilityView);

			return myView;
		}
		//efren
		private UIView bodyFolderView(CGRect frame)
		{
			UIView scroll = new UIView {
				Frame = new CGRect ( 0f, -1f, frame.Width, frame.Height * 0.75f),
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth
			};

			List<string> items = new List<string> ();
			int counter = 1;
			foreach(object obj in this.tree){
				items.Add (string.Format ("Folder {0}", counter));
				counter++;	
			}

			UITableView rootTable = new UITableView(){
				Frame = new CGRect (0f, 0f, scroll.Frame.Width * 0.5f, scroll.Frame.Height),
				AutoresizingMask = UIViewAutoresizing.All,
				SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine,
				TableFooterView = new UIView (),
				BackgroundColor = UIColor.FromRGB (231, 231, 232),
				Source = new RootTableSource (items)
			};

			scroll.AddSubview (rootTable);


			UIView borderBottom = new UIView (new CGRect (0f, scroll.Frame.Height - 1f, scroll.Frame.Width, 1f));
			borderBottom.BackgroundColor = UIColor.LightGray;
			scroll.AddSubview (borderBottom);
			return scroll;
		}

		private UIView bodyFileView(CGRect frame)
		{
			UIView scroll = new UIView {
				Frame = new CGRect ( 0f, 0f, frame.Width, frame.Height * 0.75f),
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth
			};




			UIView borderBottom = new UIView (new CGRect (0f, scroll.Frame.Height - 1f, scroll.Frame.Width, 1f));
			borderBottom.BackgroundColor = UIColor.LightGray;

			scroll.AddSubview (borderBottom);
			return scroll;
		}




		private UIView createUtilityView(CGRect frame)
		{
			UIView myView = new UIView ();
			myView.Frame = new CGRect (0f, frame.Height * 0.75f, frame.Width, frame.Height * 0.25f);

			UIView dragView = new UIView ();
			dragView.Frame = new CGRect (0f, 0f, myView.Frame.Width, myView.Frame.Height * 0.6f);

			UILabel nameLabel = new UILabel ();
			nameLabel.Frame = new CGRect (0f, 0f, dragView.Frame.Width, dragView.Frame.Height);
			nameLabel.Text = "Drag or paste files Here";
			nameLabel.Font = UIFont.BoldSystemFontOfSize (18f);
			nameLabel.TextAlignment = UITextAlignment.Center;


			UIView newFolderView = new UIView ();
			newFolderView.Frame = new CGRect (0f, myView.Frame.Height * 0.6f, frame.Width, myView.Frame.Height * 0.4f);

			// Buttons
			UIButton button = new UIButton ();
			button = UIButton.FromType (UIButtonType.System);
			button.Frame = new CGRect(newFolderView.Frame.Width * 0.15f, newFolderView.Frame.Height * 0.1f, newFolderView.Frame.Width * 0.7f, newFolderView.Frame.Height * 0.8f);
			button.SetTitle ("CREATE A FOLDER", UIControlState.Normal);
			button.SetTitleColor (UIColor.White, UIControlState.Normal);
			button.BackgroundColor = UIColor.FromRGB(66, 148, 182);
			button.Layer.CornerRadius = 5;
			button.ClipsToBounds = true;


			UIView border1 = new UIView (new CGRect (0f, dragView.Frame.Height - 1f, dragView.Frame.Width, 1f));
			border1.BackgroundColor = UIColor.LightGray;


			UIView border2 = new UIView (new CGRect (0f, newFolderView.Frame.Height - 1f, newFolderView.Frame.Width, 1f));
			border2.BackgroundColor = UIColor.LightGray;

			dragView.AddSubview (border1);
			newFolderView.AddSubview (border2);


			dragView.AddSubview (nameLabel);
			newFolderView.AddSubview (button);

			myView.AddSubview (dragView);
			myView.AddSubview (newFolderView);
			return myView;
		}


		/*
		 *  FILES VIEW  
		 *
		 */

		private UIView createFilesView()
		{
			UIView myView = this.createDefaultView ();
			UIView containerView = this.bodyFileView (myView.Frame);

			UIView utilityView = this.createUtilityView (myView.Frame);

			myView.AddSubview (containerView);
			myView.AddSubview (utilityView);
			return myView;
		}



		/*
		 *  BILLING VIEW  
		 *
		 */
		private UIView createBillingView()
		{
			UIView myView = this.createDefaultView ();

			return myView;
		}

	}
}

