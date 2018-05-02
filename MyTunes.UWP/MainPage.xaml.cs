#region usings

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

#endregion

namespace MyTunes
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Constructors

        public MainPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public methods

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            SongLoader.StreamLoader = new StreamLoader();

            this.DataContext = await SongLoader.Load();
        }

        #endregion
    }
}