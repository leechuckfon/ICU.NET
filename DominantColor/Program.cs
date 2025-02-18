using Corsair.NET.Corsair;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;

var details = CorsairSDK.CorsairPerformProtocolHandshake();
var devices = CorsairSDK.CorsairGetDeviceCount();
var ledPositions = CorsairSDK.CorsairGetLedPositionsByDeviceIndex(0);

var ledTest = ledPositions.pLedPosition.Select(x => new CorsairLedColor() { ledId = x.ledId, b = 0, g = 0, r = 0 }).ToArray();
while (true)
{
  var dominantColor = FindDominantColor();

  for (int j = 0; j < ledTest.Length; j++)
  {
      ledTest[j].b = dominantColor.b; ledTest[j].r = dominantColor.r; ledTest[j].g = dominantColor.g;

      var worked = CorsairSDK.CorsairSetLedsColorsAsync(ledPositions.numberOfLed, ledTest, (x, y, z) => {
          //Console.WriteLine("Callback Called");
      });
  }
    Thread.Sleep(100);
}




(int r, int g, int b) FindDominantColor()
{
    var captureMap = new Bitmap(2560,1440, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

    var captureGraphics = Graphics.FromImage(captureMap);

    captureGraphics.CopyFromScreen(new Point(0,0), Point.Empty, new Size(2560,1440));

    var pixels = new List<Color>();
    for (int h = 0; h < 1440; h+=50 ) {
        for (int w = 0; w < 2560; w += 50)
        {
            pixels.Add(captureMap.GetPixel(w,h));

        }
    }
    captureMap.Dispose();
    captureGraphics.Dispose();

    var distinctColors = pixels.Distinct(new ColorComparer());

    var counted = distinctColors.Select(x => new { Color = x ,Count = pixels.Count(y => x.R == y.R && x.G == y.G && x.B == y.B) });

    var dominantColor = counted.MaxBy(x => x.Count);

    return (dominantColor.Color.R, dominantColor.Color.G, dominantColor.Color.B);
}


class ColorComparer : IEqualityComparer<Color>
{
    public bool Equals(Color x, Color y)
    {
        return x.R == y.R && x.G == y.G && x.B == y.B;
    }

    public int GetHashCode([DisallowNull] Color obj)
    {
        return obj.GetHashCode();
    }
}
