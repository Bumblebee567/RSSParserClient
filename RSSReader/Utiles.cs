using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RSSReader
{
    class Utiles
    {
        public static Image GetImage (string imageUrl)
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
            image.Width = 155;
            image.Height = 112;
            return image;
        }
    }
}
