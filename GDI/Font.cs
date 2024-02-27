using System.Runtime.InteropServices;

namespace HVT.GDI;

public partial class Font
{
    #region Private

    [LibraryImport("gdi32.dll")]
    private static partial IntPtr CreateFontW(int nHeight, int nWidth, int nEscapement, int nOrientation,
        FontWeight fnWeight, uint fdwItalic, uint fdwUnderline, uint fdwStrikeOut, uint fdwCharSet,
        uint fdwOutputPrecision, uint fdwClipPrecision, uint fdwQuality, uint fdwPitchAndFamily,
        [MarshalAs(UnmanagedType.LPWStr)] string lpszFace);

    #endregion

    #region Public

    /// <summary>
    ///     Weight of the font in the range 0 through 1000. For example, 400 is normal and 700 is bold.
    /// </summary>
    public enum FontWeight
    {
        FW_DONTCARE = 0,
        FW_THIN = 100,
        FW_EXTRALIGHT = 200,
        FW_ULTRALIGHT = 200,
        FW_LIGHT = 300,
        FW_NORMAL = 400,
        FW_REGULAR = 400,
        FW_MEDIUM = 500,
        FW_SEMIBOLD = 600,
        FW_DEMIBOLD = 600,
        FW_BOLD = 700,
        FW_EXTRABOLD = 800,
        FW_ULTRABOLD = 800,
        FW_HEAVY = 900,
        FW_BLACK = 900
    }

    /// <summary>
    ///     The <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createfontw">CreateFontW</see>
    ///     function creates a logical font with the specified characteristics. The logical font can subsequently be selected
    ///     as the current font for any device.
    /// </summary>
    /// <param name="nHeight">
    ///     The height, in logical units, of the font's character cell or character. The character height
    ///     value (also known as the em height) is the character cell height value minus the internal-leading value.
    /// </param>
    /// <param name="nWidth">
    ///     The average width, in logical units, of characters in the requested font. If this value is zero,
    ///     the font mapper chooses a closest match value. The closest match value is determined by comparing the absolute
    ///     values of the difference between the current device's aspect ratio and the digitized aspect ratio of available
    ///     fonts.
    /// </param>
    /// <param name="nEscapement">
    ///     The angle, in tenths of degrees, between the escapement vector and the x-axis of the device. The escapement vector
    ///     is parallel to the base line of a row of text.
    ///     When the graphics mode is set to GM_ADVANCED, you can specify the escapement angle of the string independently of
    ///     the orientation angle of the string's characters.
    ///     When the graphics mode is set to GM_COMPATIBLE, nEscapement specifies both the escapement and orientation. You
    ///     should set nEscapement and nOrientation to the same value.
    /// </param>
    /// <param name="nOrientation">
    ///     The angle, in tenths of degrees, between each character's base line and the x-axis of the device.
    /// </param>
    /// <param name="fnWeight">
    ///     The weight of the font in the range 0 through 1000. For example, 400 is normal and 700 is bold. If this value is
    ///     zero, a default weight is used.
    /// </param>
    /// <param name="fdwItalic">
    ///     Specifies an italic font if set to TRUE.
    /// </param>
    /// <param name="fdwUnderline">Specifies an underlined font if set to TRUE.</param>
    /// <param name="fdwStrikeOut">A strikeout font if set to TRUE.</param>
    /// <param name="fdwCharSet">The character set.</param>
    /// <param name="fdwOutputPrecision">
    ///     The output precision. The output precision defines how closely the output must match
    ///     the requested font's height, width, character orientation, escapement, pitch, and font type.
    /// </param>
    /// <param name="fdwClipPrecision">
    ///     The clipping precision. The clipping precision defines how to clip characters that are
    ///     partially outside the clipping region. It can be one or more of the following values.
    /// </param>
    /// <param name="fdwQuality">
    ///     The output quality. The output quality defines how carefully GDI must attempt to match the
    ///     logical-font attributes to those of an actual physical font. It can be one of the following values.
    /// </param>
    /// <param name="fdwPitchAndFamily">The pitch and family of the font.</param>
    /// <param name="lpszFace">
    ///     A pointer to a null-terminated string that specifies the typeface name of the font. The length
    ///     of this string must not exceed 32 characters, including the terminating null character. The EnumFontFamilies
    ///     function can be used to enumerate the typeface names of all currently available fonts. For more information, see
    ///     the Remarks. If lpszFace is NULL or empty string, GDI uses the first font that matches the other specified
    ///     attributes.
    /// </param>
    /// <remarks>
    ///     When you no longer need the font, call the DeleteObject function to delete it.
    ///     To help protect the copyrights of vendors who provide fonts for Windows, applications should always report the
    ///     exact name of a selected font. Because available fonts can vary from system to system, do not assume that the
    ///     selected font is always the same as the requested font. For example, if you request a font named Palatino, but no
    ///     such font is available on the system, the font mapper will substitute a font that has similar attributes but a
    ///     different name. Always report the name of the selected font to the user.
    ///     To get the appropriate font on different language versions of the OS, call EnumFontFamiliesEx with the desired font
    ///     characteristics in the LOGFONT structure, then retrieve the appropriate typeface name and create the font using
    ///     CreateFont or CreateFontIndirect.
    ///     The font mapper for CreateFont,CreateFontIndirect, and CreateFontIndirectEx recognizes both the English and the
    ///     localized typeface name, regardless of locale.
    ///     The following situations do not support ClearType antialiasing:
    ///     Text rendered on a printer.
    ///     A display set for 256 colors or less.
    ///     Text rendered to a terminal server client.
    ///     The font is not a TrueType font or an OpenType font with TrueType outlines. For example, the following do not
    ///     support ClearType antialiasing: Type 1 fonts, Postscript OpenType fonts without TrueType outlines, bitmap fonts,
    ///     vector fonts, and device fonts.
    ///     The font has tuned embedded bitmaps, only for the font sizes that contain the embedded bitmaps. For example, this
    ///     occurs commonly in East Asian fonts.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value is a handle to a logical font. If the function fails, the return
    ///     value is NULL.
    /// </returns>
    public IntPtr CreateFontSafe(int nHeight, int nWidth, int nEscapement, int nOrientation, FontWeight fnWeight,
        uint fdwItalic, uint fdwUnderline, uint fdwStrikeOut, uint fdwCharSet, uint fdwOutputPrecision,
        uint fdwClipPrecision, uint fdwQuality, uint fdwPitchAndFamily, string lpszFace)
    {
        return CreateFontW(nHeight, nWidth, nEscapement, nOrientation, fnWeight, fdwItalic, fdwUnderline, fdwStrikeOut,
            fdwCharSet, fdwOutputPrecision, fdwClipPrecision, fdwQuality, fdwPitchAndFamily, lpszFace);
    }

    #endregion
}