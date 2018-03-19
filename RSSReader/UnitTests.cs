using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Assert.IsNotNull(items);
            }
            [TestCase]
            public void CheckIf_ChannelID_HaveID()
            {
                var target = new Feed();
                var items = target.ChannelID;
                Assert.IsNotNull(items);
            }
            [TestCase]
            public void CheckIf_Title_HaveTitle()
            {
                var target = new Feed();
                var items = target.Title;
                Assert.IsNull(items);
            }
            [TestCase]
            public void CheckIf_Link_HaveLink()
            {
                var target = new Feed();
                var items = target.Link;
                Assert.IsNull(items);
            }
            [TestCase]
            public void CheckIf_Description_HaveDescription()
            {
                var target = new Feed();
                var items = target.Description;
                Assert.IsNull(items);
            }
            [TestCase]
            public void CheckIf_Imagelink_HaveImmageLink()
            {
                var target = new Feed();
                var items = target.Imagelink;
                Assert.IsNull(items);
            }
            [TestCase]
            public void CheckIf_Date_HaveDate()
            {
                var target = new Feed();
                var items = target.Date;
                Assert.IsNull(items);
            }
            [TestCase]
            public void CheckIf_Channel_HaveChanel()
            {
                var target = new Feed();
                var items = target.Channel;
                Assert.IsNull(items);
            }
        }
    }
}
