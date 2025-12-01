using OpenCvSharp;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Aion2MapOverlay;

public static class ScreenCapture
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetDesktopWindow();

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("gdi32.dll")]
    private static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest,
        IntPtr hdcSrc, int xSrc, int ySrc, int rop);

    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDc);

    [DllImport("gdi32.dll")]
    private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

    private const int SRCCOPY = 0x00CC0020;
    private const int DESKTOPVERTRES = 117;
    private const int DESKTOPHORZRES = 118;

    public static Mat CaptureScreen()
    {
        IntPtr hWnd = GetDesktopWindow();
        IntPtr hDC = GetWindowDC(hWnd);

        try
        {
            int width = GetDeviceCaps(hDC, DESKTOPHORZRES);
            int height = GetDeviceCaps(hDC, DESKTOPVERTRES);

            if (width <= 0 || height <= 0)
                return new Mat();

            using var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using var graphics = Graphics.FromImage(bitmap);
            IntPtr hDest = graphics.GetHdc();

            BitBlt(hDest, 0, 0, width, height, hDC, 0, 0, SRCCOPY);

            graphics.ReleaseHdc(hDest);

            return BitmapToGrayMat(bitmap);
        }
        finally
        {
            ReleaseDC(hWnd, hDC);
        }
    }

    private static Mat BitmapToGrayMat(Bitmap bitmap)
    {
        var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
        var bmpData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

        var mat = new Mat(bitmap.Height, bitmap.Width, MatType.CV_8UC4);
        unsafe
        {
            Buffer.MemoryCopy(
                (void*)bmpData.Scan0,
                (void*)mat.Data,
                mat.Total() * mat.ElemSize(),
                mat.Total() * mat.ElemSize());
        }

        bitmap.UnlockBits(bmpData);

        var grayMat = new Mat();
        Cv2.CvtColor(mat, grayMat, ColorConversionCodes.BGRA2GRAY);
        mat.Dispose();

        return grayMat;
    }
}
