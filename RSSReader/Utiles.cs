using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace RSSReader
{
    class Utiles
    {
        public static void StartParser()
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\RSSParser\Parser\bin\Debug\Parser.exe";
            Process.Start(startInfo);
        }
        public static Image GetImage(string imageUrl)
        {
            if (imageUrl == "brak zdjęcia")
            {
                imageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/Feed-icon.svg/1200px-Feed-icon.svg.png";
            }
            var image = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imageUrl, UriKind.Absolute);
            bitmap.EndInit();
            image.Source = bitmap;
            image.Width = 241;
            image.Height = 200;
            return image;
        }
        public static void AddChannelsToCombobox(ComboBox channelsComboBox)
        {
            using (var context = new RSSFeedDatabaseEntities())
            {
                List<string> channels = new List<string>();
                foreach (var channel in context.Channel)
                {
                    channels.Add(channel.Title);
                }
                channelsComboBox.ItemsSource = channels;
            }
        }
        public static void AddFeedsToListbox(string channelTitle, ListBox feedListBox)
        {
            IQueryable<Feed> feedsOnChannel;
            using (var context = new RSSFeedDatabaseEntities())
            {
                feedsOnChannel = context.Feed.Where(x => x.Channel.Title == channelTitle);
                feedListBox.ItemsSource = feedsOnChannel.ToList();
            }
        }
        public static void ClearUserControls(TextBlock title, TextBlock date, TextBlock description, Canvas image)
        {
            title.Text = String.Empty;
            date.Text = String.Empty;
            description.Text = String.Empty;
            image.Children.Clear();
        }
        public static void SortFeedsInList(ListBox feedList)
        {
            feedList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FeedID", System.ComponentModel.ListSortDirection.Descending));
        }
        public static void GetDetailsOfSelectedFeed(ListBox feeds, TextBlock title, TextBlock date, TextBlock description, Canvas image, Hyperlink link)
        {
            image.Children.Clear();
            Feed currentFeed = (Feed)feeds.Items.CurrentItem;
            if (currentFeed != null)
            {
                title.Text = currentFeed.Title;
                if (currentFeed.Description.Length > 400)
                {
                    description.Text = currentFeed.Description.Substring(0, currentFeed.Description.Length - (currentFeed.Description.Length - 300));
                }
                else
                {
                    description.Text = currentFeed.Description;
                }
                date.Text = currentFeed.Date;
                image.Children.Add(Utiles.GetImage(currentFeed.Imagelink));
                link.NavigateUri = new Uri(currentFeed.Link);
            }
        }
        public static int GetNumberOfNewFeedsOnChannel(string channelTitle, int numOfFeeds)
        {
            using (var context = new RSSFeedDatabaseEntities())
            {
                return context.Feed.Where(x => x.Channel.Title == channelTitle).Count() - numOfFeeds;
            }
        }
    }
}
