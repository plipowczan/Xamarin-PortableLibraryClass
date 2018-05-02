#region usings

using System.IO;
using Android.Content;
using MyTunes.Shared;

#endregion

namespace MyTunes
{
    public class StreamLoader : IStreamLoader
    {
        #region Fields

        private readonly Context context;

        #endregion

        #region Constructors

        public StreamLoader(Context context)
        {
            this.context = context;
        }

        #endregion

        #region Public methods

        public Stream GetStreamForFilename(string filename)
        {
            return this.context.Assets.Open(filename);
        }

        #endregion
    }
}