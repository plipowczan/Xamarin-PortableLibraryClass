#region usings

using System.Linq;
using UIKit;

#endregion

namespace MyTunes
{
    public class MyTunesViewController : UITableViewController
    {
        #region Public methods

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            this.TableView.ContentInset = new UIEdgeInsets(20, 0, 0, 0);
        }

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SongLoader.StreamLoader = new StreamLoader();

            // Load the data
            var data = await SongLoader.Load();

            // Register the TableView's data source
            this.TableView.Source = new ViewControllerSource<Song>(this.TableView)
            {
                DataSource = data.ToList(),
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " - " + s.Album
            };
        }

        #endregion
    }
}