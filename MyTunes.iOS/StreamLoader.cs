#region usings

using System.IO;
using MyTunes.Shared;

#endregion

namespace MyTunes
{
    public class StreamLoader : IStreamLoader
    {
        #region Public methods

        public Stream GetStreamForFilename(string filename)
        {
            return File.OpenRead(filename);
        }

        #endregion
    }
}