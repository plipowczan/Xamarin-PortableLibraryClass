#region usings

using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

#endregion

namespace MyTunes
{
    public class ViewControllerSource<T> : UITableViewSource
    {
        #region Fields

        IList<T> dataSource;

        readonly UITableView tableView;

        #endregion

        #region Constructors

        public ViewControllerSource(UITableView tableView)
        {
            this.tableView = tableView;
        }

        #endregion

        #region Properties

        public IList<T> DataSource
        {
            get
            {
                return this.dataSource;
            }
            set
            {
                this.dataSource = value;
                this.tableView.ReloadData();
            }
        }

        public Func<T, string> TextProc { get; set; }

        public Func<T, string> DetailTextProc { get; set; }

        #endregion

        #region Public methods

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return this.DataSource.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(this.CellStyleName);
            if (cell == null)
            {
                cell = new UITableViewCell(
                    (this.DetailTextProc == null) ? UITableViewCellStyle.Default : UITableViewCellStyle.Subtitle,
                    this.CellStyleName);
            }

            T item = this.DataSource[indexPath.Row];

            cell.TextLabel.Text = this.TextProc == null ? item.ToString() : this.TextProc(item);
            if (this.DetailTextProc != null)
            {
                cell.DetailTextLabel.Text = this.DetailTextProc(item);
            }

            return cell;
        }

        #endregion

        public readonly string CellStyleName = "ViewControllerSource~" + typeof(T).Name;
    }
}