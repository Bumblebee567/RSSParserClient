using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RSSReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Utiles.AddChannelsToCombobox(ChannelsList);
            Utiles.AddFeedsToListbox("Najnowsze", FeedList);
            FeedList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FeedID", System.ComponentModel.ListSortDirection.Descending));
        }
    }
}
