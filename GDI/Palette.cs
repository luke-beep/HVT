using System.Runtime.InteropServices;

namespace HVT.GDI;

public class Palette
{
    #region Private

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreatePalette([MarshalAs(UnmanagedType.Struct)] LOGPALETTE lplgpl);

    #endregion

    #region Public

    [StructLayout(LayoutKind.Sequential)]
    public struct LOGPALETTE
    {
        public ushort palVersion;
        public ushort palNumEntries;
        public PALETTEENTRY[] palPalEntry;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PALETTEENTRY
    {
        public byte peRed;
        public byte peGreen;
        public byte peBlue;
        public byte peFlags;
    }

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createpalette">CreatePalette</see>
    ///     function creates a logical palette.
    /// </summary>
    /// <param name="lplgpl">
    ///     A pointer to a LOGPALETTE structure that contains information about the colors in the logical
    ///     palette.
    /// </param>
    /// <remarks>
    ///     An application can determine whether a device supports palette operations by calling the GetDeviceCaps function and
    ///     specifying the RASTERCAPS constant.
    ///     Once an application creates a logical palette, it can select that palette into a device context by calling the
    ///     SelectPalette function. A palette selected into a device context can be realized by calling the RealizePalette
    ///     function.
    ///     When you no longer need the palette, call the DeleteObject function to delete it.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value is a handle to a logical palette. If the function fails, the return
    ///     value is NULL.
    /// </returns>
    public IntPtr CreatePaletteSafe(LOGPALETTE lplgpl)
    {
        return CreatePalette(lplgpl);
    }

    #endregion
}