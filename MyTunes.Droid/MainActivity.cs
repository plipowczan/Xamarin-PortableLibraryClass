#region usings

using System.Linq;
using Android.App;
using Android.OS;

#endregion

namespace MyTunes
{
    [Activity(Label = "My Tunes", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        #region Public methods

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SongLoader.StreamLoader = new StreamLoader(this.ApplicationContext);

            var data = await SongLoader.Load();

            this.ListAdapter = new ListAdapter<Song>
            {
                DataSource = data.ToList(),
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " - " + s.Album
            };
        }

        #endregion
    }
}