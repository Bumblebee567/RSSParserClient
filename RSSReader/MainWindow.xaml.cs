using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace RSSReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int numOfFeeds;
        public MainWindow()
        {
            InitializeComponent();
            Utiles.AddChannelsToCombobox(ChannelsList);
            Utiles.StartParser();
            Application.Current.MainWindow.Closing += MainWindow_Closing;
            using (var context = new RSSFeedDatabaseEntities())
            {
                numOfFeeds = context.Feed.Count();
            }
            Timer tmr = new Timer();
            tmr.Elapsed += Tmr_Elapsed;
            tmr.Interval = 330000;
            tmr.Start();
        }
        private void Tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (var context = new RSSFeedDatabaseEntities())
            {
                var newFeedsOnChannel = Utiles.GetNumberOfNewFeedsOnChannel(ChannelsList.Text, numOfFeeds);
                if (newFeedsOnChannel != 0)
                {
                    MessageBox.Show($"Nowe wiadomości ({newFeedsOnChannel}) zostały pobrane, kliknij \"pokaż\" by odświeżyć", "TVN RSS Reader",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    numOfFeeds = newFeedsOnChannel;
                }
            }
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var process = Process.GetProcessesByName("Parser").First();
            process.Kill();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Utiles.AddFeedsToListbox(ChannelsList.Text, FeedList);
            Utiles.ClearUserControls(TitleBlock, DateBlock, DescriptionBlock, ImageCanvas);
        }
        private void FeedList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Utiles.SortFeedsInList(FeedList);
            Utiles.GetDetailsOfSelectedFeed(FeedList, TitleBlock, DateBlock, DescriptionBlock, ImageCanvas, HyperlinkBox);
        }
        private void HyperlinkBox_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
