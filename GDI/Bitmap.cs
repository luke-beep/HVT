using System.Runtime.InteropServices;

namespace HVT.GDI;

public partial class Bitmap
{
    #region Private

    [LibraryImport("gdi32.dll")]
    private static partial IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);

    #endregion

    #region Public

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createbitmap">CreateBitmap</see>
    ///     function creates a bitmap with the specified width, height, and color format (color planes and bits-per-pixel).
    /// </summary>
    /// <param name="width">The bitmap width, in pixels. </param>
    /// <param name="height">The bitmap height, in pixels. </param>
    /// <param name="planes">The number of color planes used by the device. </param>
    /// <param name="bitCount">The number of bits required to identify the color of a single pixel. </param>
    /// <param name="bits">
    ///     A pointer to an array of color data used to set the colors in a rectangle of pixels. Each scan line
    ///     in the rectangle must be word aligned (scan lines that are not word aligned must be padded with zeros).
    /// </param>
    /// <remarks>
    ///     The CreateBitmap function creates a device-dependent bitmap.
    ///     After a bitmap is created, it can be selected into a device context by calling the SelectObject function. However,
    ///     the bitmap can only be selected into a device context if the bitmap and the DC have the same format.
    ///     The CreateBitmap function can be used to create color bitmaps. However, for performance reasons applications should
    ///     use CreateBitmap to create monochrome bitmaps and CreateCompatibleBitmap to create color bitmaps. Whenever a color
    ///     bitmap returned from CreateBitmap is selected into a device context, the system checks that the bitmap matches the
    ///     format of the device context it is being selected into. Because CreateCompatibleBitmap takes a device context, it
    ///     returns a bitmap that has the same format as the specified device context. Thus, subsequent calls to SelectObject
    ///     are faster with a color bitmap from CreateCompatibleBitmap than with a color bitmap returned from CreateBitmap
    ///     If the bitmap is monochrome, zeros represent the foreground color and ones represent the background color for the
    ///     destination device context.
    ///     If an application sets the nWidth or nHeight parameters to zero, CreateBitmap returns the handle to a 1-by-1 pixel,
    ///     monochrome bitmap.
    ///     When you no longer need the bitmap, call the DeleteObject function to delete it.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value is a handle to a bitmap. If the function fails, the return value is
    ///     NULL. This function can return the following value.
    /// </returns>
    public IntPtr CreateBitmapSafe(int width, int height, uint planes, uint bitCount, byte[] bits)
    {
        return CreateBitmap(width, height, planes, bitCount, Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0));
    }

    #endregion
}