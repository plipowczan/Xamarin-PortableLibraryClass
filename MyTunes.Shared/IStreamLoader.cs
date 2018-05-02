#region usings

using System.IO;

#endregion

namespace MyTunes.Shared
{
    public interface IStreamLoader
    {
        #region Public methods

        Stream GetStreamForFilename(string filename);

        #endregion
    }
}