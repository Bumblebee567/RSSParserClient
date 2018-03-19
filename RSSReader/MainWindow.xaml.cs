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
        public static Process process;
        public static int numOfFeeds;
        public MainWindow()
        {
            InitializeComponent();
            Utiles.AddChannelsToCombobox(ChannelsList);

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\RSSParser\Parser\bin\Debug\Parser.exe";
            process = Process.Start(startInfo);

            Timer tmr = new Timer();
            tmr.Elapsed += Tmr_Elapsed;
            tmr.Interval = 330000;
            tmr.Start();

            using (var context = new RSSFeedDatabaseEntities())
            {
                numOfFeeds = context.Feed.Count();
            }

            Application.Current.MainWindow.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            process.Kill();
        }

        private void Tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (var context = new RSSFeedDatabaseEntities())
            {
                var newFeedsNumber = context.Feed.Count() - numOfFeeds;
                if (newFeedsNumber != 0)
                {
                    MessageBox.Show($"Nowe wiadomości ({newFeedsNumber}) zostały pobrane, kliknij \"pokaż\" by odświeżyć", "TVN RSS Reader",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    numOfFeeds = newFeedsNumber;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Utiles.AddFeedsToListbox(ChannelsList.Text, FeedList);
            TitleBlock.Text = String.Empty;
            DateBlock.Text = String.Empty;
            DescriptionBlock.Text = String.Empty;
            ImageCanvas.Children.Clear();
        }

        private void FeedList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FeedList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FeedID", System.ComponentModel.ListSortDirection.Descending));
            ImageCanvas.Children.Clear();
            Feed currentFeed = (Feed)FeedList.Items.CurrentItem;
            if (currentFeed != null)
            {
                TitleBlock.Text = currentFeed.Title;
                if (currentFeed.Description.Length > 400)
                {
                    DescriptionBlock.Text = currentFeed.Description.Substring(0, currentFeed.Description.Length - (currentFeed.Description.Length - 300));
                }
                else
                {
                    DescriptionBlock.Text = currentFeed.Description;
                }
                DateBlock.Text = currentFeed.Date;
                ImageCanvas.Children.Add(Utiles.GetImage(currentFeed.Imagelink));
                HyperlinkBox.NavigateUri = new Uri(currentFeed.Link);
            }
        }

        private void HyperlinkBox_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
