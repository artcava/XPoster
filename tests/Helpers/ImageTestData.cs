using SkiaSharp;

namespace XPoster.Tests.Helpers;

internal static class ImageTestData
{
    public static byte[] CreateValidJpeg(int width = 1, int height = 1)
    {
        using var bitmap = new SKBitmap(width, height);
        using var canvas = new SKCanvas(bitmap);
        canvas.Clear(SKColors.White);

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Jpeg, 90);

        return data.ToArray();
    }

    public static byte[] CreateValidPng(int width = 1, int height = 1)
    {
        using var bitmap = new SKBitmap(width, height);
        using var canvas = new SKCanvas(bitmap);
        canvas.Clear(SKColors.White);

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);

        return data.ToArray();
    }
}