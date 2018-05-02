#region usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MyTunes.Shared;
using Newtonsoft.Json;

#endregion

namespace MyTunes
{
    public static class SongLoader
    {
        public static IStreamLoader StreamLoader { get; set; }

        #region Consts

        const string Filename = "songs.json";

        #endregion

        #region Private methods

        private static Stream OpenData()
        {
            if (StreamLoader == null)
            {
                throw new Exception("Must set the platform loader to load the data");
            }

            return StreamLoader.GetStreamForFilename(Filename);
        }

        #endregion

        #region Public methods

        public static async Task<IEnumerable<Song>> Load()
        {
            using (var reader = new StreamReader(OpenData()))
            {
                return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
            }
        }

        #endregion
    }
}