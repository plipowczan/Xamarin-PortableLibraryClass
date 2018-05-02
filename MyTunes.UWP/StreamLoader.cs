#region usings

using System;
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
            var sf = Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(filename).AsTask().Result;
            return sf.OpenStreamForReadAsync().Result;
        }

        #endregion
    }
}