using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace RSSReader
{
    class UnitTests
    {
        [TestFixture]
        class UnitTestExample
        {
            [TestCase]
            public void CheckIf_FeedID_HaveID()
            {
                var target = new Feed();
                var items = target.FeedID;
                Assert.IsNotNull(items, "shouldn't be a null");
            }
            [TestCase]
            public void CheckIf_ChannelID_HaveID()
            {
                var target = new Feed();
                var items = target.ChannelID;
                Assert.IsNotNull(items, "shouldn't be a null");
            }
            [TestCase]
            public void CheckIf_Title_HaveTitle()
            {
                var target = new Feed();
                var items = target.Title;
                Assert.IsNull(items, " should be a null.");
            }
            [TestCase]
            public void CheckIf_Link_HaveLink()
            {
                var target = new Feed();
                var items = target.Link;
                Assert.IsNull(items, " should be a null.");
            }
            [TestCase]
            public void CheckIf_Description_HaveDescription()
            {
                var target = new Feed();
                var items = target.Description;
                Assert.IsNull(items, " should be a null.");
            }
            [TestCase]
            public void CheckIf_Imagelink_HaveImmageLink()
            {
                var target = new Feed();
                var items = target.Imagelink;
                Assert.IsNull(items, " should be a null.");
            }
            [TestCase]
            public void CheckIf_Date_HaveDate()
            {
                var target = new Feed();
                var items = target.Date;
                Assert.IsNull(items, " should be a null.");
            }
            [TestCase]
            public void CheckIf_Channel_HaveChanel()
            {
                var target = new Feed();
                var items = target.Channel;
                Assert.IsNull(items, " should be a null.");
            }
            [TestCase]
            public void CheckIf_Channel_HaveChanelNew()
            {
                var target = new Channel();
                var items = target.ChannelID;
                Assert.IsNotNull(items, " should't be a null.");
            }
            [TestCase]
            public void CheckIf_Title_HaveTitleNew()
            {
                var target = new Channel();
                var items = target.Title;
                Assert.IsNull(items, " should be a null.");
            }
            [TestCase]
            public void CheckIf_Address_HaveAddresslNew()
            {
                var target = new Channel();
                var items = target.Address;
                Assert.IsNull(items, " should be a null.");
            }
            [TestCase]
            public void CheckIf_Description_HaveDescriptionNew()
            {
                var target = new Channel();
                var items = target.Description;
                Assert.IsNull(items, " should be a null.");
            }
            [TestCase]
            public void CheckIf_Feed_HaveFeedNew()
            {
                var target = new Channel();
                var items = target.Feed;
                Assert.IsNotNull(items, " should't be a null.");
            }
            [TestCase]
            public void CheckIf_StartParser()
            {
                var startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\RSSParser\Parser\bin\Debug\Parser.exe";
                Assert.IsNotNull(Process.Start(startInfo), " should't be a not null.");
            }
        }
    }
}
