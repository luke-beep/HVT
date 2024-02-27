using System.Runtime.InteropServices;

namespace HVT.GDI;

public partial class Brush
{
    #region Private

    [LibraryImport("gdi32.dll")]
    private static partial IntPtr CreateHatchBrush(HatchStyle fnStyle, Rgb rgb);

    [LibraryImport("gdi32.dll")]
    private static partial IntPtr CreatePatternBrush(IntPtr hbmp);

    [LibraryImport("gdi32.dll")]
    private static partial IntPtr CreateSolidBrush(Rgb rgb);

    #endregion

    #region Public

    /// <summary>
    ///     Specifies the hatch style of a brush, which is used in filling a shape in CreateHatchBrush.
    /// </summary>
    public enum HatchStyle
    {
        HsBdiagonal = 0,
        HsCross = 1,
        HsDiagcross = 2,
        HsFdiagonal = 3,
        HsHorizontal = 4,
        HsVertical = 5
    }

    /// <summary>
    ///     Contains the red, green, and blue color values for a color. Used instead of COLORREF.
    /// </summary>
    public struct Rgb
    {
        public byte Red;
        public byte Green;
        public byte Blue;
    }

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createhatchbrush">CreateHatchBrush</see>
    ///     function creates a logical brush that has the specified hatch pattern and color.
    /// </summary>
    /// <param name="iHatch">
    ///     The hatch style of the brush. This parameter can be one of the following values.
    ///     HS_BDIAGONAL = 0,
    ///     HS_CROSS = 1,
    ///     HS_DIAGCROSS = 2,
    ///     HS_FDIAGONAL = 3,
    ///     HS_HORIZONTAL = 4,
    ///     HS_VERTICAL = 5.
    /// </param>
    /// <param name="rgb">The foreground color of the brush that is used for the hatches. </param>
    /// <remarks>
    ///     A brush is a bitmap that the system uses to paint the interiors of filled shapes.
    ///     After an application creates a brush by calling CreateHatchBrush, it can select that brush into any device context
    ///     by calling the SelectObject function. It can also call SetBkMode to affect the rendering of the brush.
    ///     If an application uses a hatch brush to fill the backgrounds of both a parent and a child window with matching
    ///     color, you must set the brush origin before painting the background of the child window. You can do this by calling
    ///     the SetBrushOrgEx function. Your application can retrieve the current brush origin by calling the GetBrushOrgEx
    ///     function.
    ///     When you no longer need the brush, call the DeleteObject function to delete it.
    ///     ICM: No color is defined at brush creation. However, color management is performed when the brush is selected into
    ///     an ICM-enabled device context.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value identifies a logical brush. If the function fails, the return value
    ///     is NULL.
    /// </returns>
    public IntPtr CreateHatchBrushSafe(HatchStyle iHatch, Rgb rgb)
    {
        return CreateHatchBrush(iHatch, rgb);
    }

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createhatchbrush">CreatePatternBrush</see>
    ///     function creates a logical brush with the specified bitmap pattern. The bitmap can be a DIB section bitmap, which
    ///     is created by the CreateDIBSection function, or it can be a device-dependent bitmap.
    /// </summary>
    /// <param name="hbmp">A handle to the bitmap to be used to create the logical brush. </param>
    /// <remarks>
    ///     A pattern brush is a bitmap that the system uses to paint the interiors of filled shapes.
    ///     After an application creates a brush by calling CreatePatternBrush, it can select that brush into any device
    ///     context by calling the SelectObject function.
    ///     You can delete a pattern brush without affecting the associated bitmap by using the DeleteObject function.
    ///     Therefore, you can then use this bitmap to create any number of pattern brushes.
    ///     A brush created by using a monochrome (1 bit per pixel) bitmap has the text and background colors of the device
    ///     context to which it is drawn. Pixels represented by a 0 bit are drawn with the current text color; pixels
    ///     represented by a 1 bit are drawn with the current background color.
    ///     ICM: No color is done at brush creation. However, color management is performed when the brush is selected into an
    ///     ICM-enabled device context.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value identifies a logical brush. If the function fails, the return value
    ///     is NULL.
    /// </returns>
    public IntPtr CreatePatternBrushSafe(IntPtr hbmp)
    {
        return CreatePatternBrush(hbmp);
    }

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createsolidbrush">CreateSolidBrush</see>
    ///     function creates a logical brush that has the specified solid color.
    /// </summary>
    /// <param name="rgb">The color of the brush. </param>
    /// <remarks>
    ///     When you no longer need the HBRUSH object, call the DeleteObject function to delete it.
    ///     A solid brush is a bitmap that the system uses to paint the interiors of filled shapes.
    ///     After an application creates a brush by calling CreateSolidBrush, it can select that brush into any device context
    ///     by calling the SelectObject function.
    ///     To paint with a system color brush, an application should use GetSysColorBrush (nIndex) instead of
    ///     CreateSolidBrush(GetSysColor(nIndex)), because GetSysColorBrush returns a cached brush instead of allocating a new
    ///     one.
    ///     ICM: No color management is done at brush creation. However, color management is performed when the brush is
    ///     selected into an ICM-enabled device context.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value identifies a logical brush. If the function fails, the return value
    ///     is NULL.
    /// </returns>
    public IntPtr CreateSolidBrushSafe(Rgb rgb)
    {
        return CreateSolidBrush(rgb);
    }

    #endregion
}