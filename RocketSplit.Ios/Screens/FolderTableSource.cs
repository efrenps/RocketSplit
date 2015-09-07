using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

using Foundation;
using UIKit;

namespace RocketSplit.Ios
{
	public class FolderTableSource : UITableViewSource
	{
		public FolderTableSource ()
		{
		}

		protected List<String> tableItems;
		protected string cellIdentifier = "TableCell";

		/// Called by the TableView to determine how many sections(groups) there are.
		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		/// Called by the TableView to determine how many cells to create for that particular section.
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Count;
		}

		/// Called when a row is touched
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			//tableView.DeselectRow (indexPath, true);
			//var selectedCell = (DealListCellView) tableView.CellAt (indexPath);
		}

		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			string dataCell = tableItems[indexPath.Row];
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier); }

			cell.TextLabel.Text = dataCell;
			cell.TextLabel.Font = UIFont.FromName("AmericanTypewriter", 15f);

			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;

			//
			//			var cell = (DealListCellView)tableView.DequeueReusableCell (DealListCellView.Key);
			//			if (cell == null) {
			//				cell = DealListCellView.Create ();
			//			}
			//			cell.Model = dataCell; //new DealListCell (dataCell);
			//			return cell;
		}
		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 145f;
		}
	}
}

