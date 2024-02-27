using System.Runtime.InteropServices;

namespace HVT.GDI;

public partial class EnhancedMetafile
{
    #region Private

    [LibraryImport("gdi32.dll")]
    private static partial IntPtr CreateEnhMetaFileW(IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)] string lpFilename,
        RECT lpRect, [MarshalAs(UnmanagedType.LPWStr)] string lpDescription);

    #endregion

    #region Public

    /// <summary>
    ///     The RECT structure defines a rectangle by the coordinates of its upper-left and lower-right corners.
    /// </summary>
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createenhmetafilew">CreateEnhMetaFileW</see>
    ///     function creates a device context for an enhanced-format metafile. This device context can be used to store a
    ///     device-independent picture.
    /// </summary>
    /// <param name="hdc">
    ///     A handle to a reference device for the enhanced metafile. This parameter can be NULL; for more
    ///     information, see Remarks.
    /// </param>
    /// <param name="lpFilename">
    ///     A pointer to the file name for the enhanced metafile to be created. If this parameter is NULL,
    ///     the enhanced metafile is memory based and its contents are lost when it is deleted by using the DeleteEnhMetaFile
    ///     function.
    /// </param>
    /// <param name="lpRect">
    ///     A pointer to a RECT structure that specifies the dimensions (in .01-millimeter units) of the
    ///     picture to be stored in the enhanced metafile.
    /// </param>
    /// <param name="lpDescription">
    ///     A pointer to a string that specifies the name of the application that created the picture,
    ///     as well as the picture's title. This parameter can be NULL; for more information, see Remarks.
    /// </param>
    /// <remarks>
    ///     Where text arguments must use Unicode characters, use the CreateEnhMetaFile function as a wide-character function.
    ///     Where text arguments must use characters from the Windows character set, use this function as an ANSI function. The
    ///     system uses the reference device identified by the hdcRef parameter to record the resolution and units of the
    ///     device on which a picture originally appeared.If the hdcRef parameter is NULL, it uses the current display device
    ///     for reference. The left and top members of the RECT structure pointed to by the lpRect parameter must be less than
    ///     the right and bottom members, respectively.Points along the edges of the rectangle are included in the picture. If
    ///     lpRect is NULL, the graphics device interface (GDI) computes the dimensions of the smallest rectangle that
    ///     surrounds the picture drawn by the application.The lpRect parameter should be provided where possible. The string
    ///     pointed to by the lpDescription parameter must contain a null character between the application name and the
    ///     picture name and must terminate with two null characters, for example, "XYZ Graphics Editor\0Bald Eagle\0\0", where
    ///     \0 represents the null character. If lpDescription is NULL, there is no corresponding entry in the enhanced-metafile
    ///     header. Applications use the device context created by this function to store a graphics picture in an enhanced
    ///     metafile.The handle identifying this device context can be passed to any GDI function. After an application stores
    ///     a picture in an enhanced metafile, it can display the picture on any output device by calling the PlayEnhMetaFile
    ///     function. When displaying the picture, the system uses the rectangle pointed to by the lpRect parameter and the
    ///     resolution data from the reference device to position and scale the picture. The device context returned by this
    ///     function contains the same default attributes associated with any new device context. Applications must use the
    ///     GetWinMetaFileBits function to convert an enhanced metafile to the older Windows metafile format. The file name for
    ///     the enhanced metafile should use the .emf extension.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value is a handle to the device context for the enhanced metafile. If the
    ///     function fails, the return value is NULL.
    /// </returns>
    public IntPtr CreateEnhMetaFileSafe(IntPtr hdc, string lpFilename, RECT lpRect, string lpDescription)
    {
        return CreateEnhMetaFileW(hdc, lpFilename, lpRect, lpDescription);
    }

    #endregion
}