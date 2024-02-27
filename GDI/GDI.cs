using System.Runtime.InteropServices;

namespace HVT.GDI;

public partial class GDI
{
    #region Private

    [LibraryImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool DeleteObject(IntPtr hObject);

    [LibraryImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool DeleteDc(IntPtr hdc);

    [LibraryImport("gdi32.dll")]
    private static partial int ReleaseDC(IntPtr hWnd, IntPtr hDc);

    [LibraryImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool DeleteEnhMetaFile(IntPtr hmf);

    [LibraryImport("gdi32.dll")]
    private static partial IntPtr CloseEnhMetaFile(IntPtr hdc);

    [LibraryImport("gdi32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool DeleteMetaFile(IntPtr hmf);

    [LibraryImport("gdi32.dll")]
    private static partial IntPtr CloseMetaFile(IntPtr hdc);

    #endregion

    #region Public

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deleteobject">DeleteObject</see>
    ///     function deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated
    ///     with the object. After the object is deleted, the specified handle is no longer valid.
    /// </summary>
    /// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette. </param>
    /// <remarks>
    ///     Do not delete a drawing object (pen or brush) while it is still selected into a DC. When a pattern brush is
    ///     deleted, the bitmap associated with the brush is not deleted.The bitmap must be deleted independently.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently
    ///     selected into a DC, the return value is zero.
    /// </returns>
    public bool DeleteObjectSafe(IntPtr hObject)
    {
        return DeleteObject(hObject);
    }

    /// <summary>
    ///     The <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deletedc">DeleteDC</see>
    ///     function deletes the specified device context (DC).
    /// </summary>
    /// <param name="hdc">A handle to the device context. </param>
    /// <remarks>
    ///     An application must not delete a DC whose handle was obtained by calling the GetDC function. Instead, it must
    ///     call the ReleaseDC function to free the DC.
    /// </remarks>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. </returns>
    public bool DeleteDcSafe(IntPtr hdc)
    {
        return DeleteDc(hdc);
    }

    /// <summary>
    ///     The <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-releasedc">ReleaseDC</see>
    ///     function releases a device context (DC), freeing it for use by other applications. The effect of the ReleaseDC
    ///     function depends on the type of DC. It frees only common and window DCs. It has no effect on class or private DCs.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose DC is to be released. </param>
    /// <param name="hDc">A handle to the DC to be released. </param>
    /// <remarks>
    ///     The application must call the ReleaseDC function for each call to the GetWindowDC function and for each call
    ///     to the GetDC function that retrieves a common DC. An application cannot use the ReleaseDC function to release a DC
    ///     that was created by calling the CreateDC function; instead, it must use the DeleteDC function.ReleaseDC must be
    ///     called from the same thread that called GetDC.
    /// </remarks>
    /// <returns>
    ///     The return value indicates whether the DC was released. If the DC was released, the return value is 1. If the
    ///     DC was not released, the return value is zero.
    /// </returns>
    public int ReleaseDcSafe(IntPtr hWnd, IntPtr hDc)
    {
        return ReleaseDC(hWnd, hDc);
    }

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deleteenhmetafile">DeleteEnhMetaFile</see>
    ///     function deletes an enhanced-format metafile or an enhanced-format metafile handle.
    /// </summary>
    /// <param name="hmf">A handle to an enhanced metafile. </param>
    /// <remarks>
    ///     If the hemf parameter identifies an enhanced metafile stored in memory, the DeleteEnhMetaFile function deletes
    ///     the metafile. If hemf identifies a metafile stored on a disk, the function deletes the metafile handle but does not
    ///     destroy the actual metafile. An application can retrieve the file by calling the GetEnhMetaFile function.
    /// </remarks>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. </returns>
    public bool DeleteEnhMetaFileSafe(IntPtr hmf)
    {
        return DeleteEnhMetaFile(hmf);
    }

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-closeenhmetafile"> CloseEnhMetaFile </see>
    ///     function closes an enhanced-metafile device context and returns a handle that identifies an enhanced-format
    ///     metafile.
    /// </summary>
    /// <param name="hdc">Handle to an enhanced-metafile device context. </param>
    /// <remarks>
    ///     An application can use the enhanced-metafile handle returned by the CloseEnhMetaFile function to perform the
    ///     following tasks: Display a picture stored in an enhanced metafile, Create copies of the enhanced metafile,
    ///     Enumerate, edit, or copy individual records in the enhanced metafile, Retrieve an optional description of the
    ///     metafile contents from the enhanced-metafile header, Retrieve a copy of the enhanced-metafile header, Retrieve a
    ///     binary copy of the enhanced metafile, Enumerate the colors in the optional palette and Convert an enhanced-format
    ///     metafile into a Windows-format metafile. When the application no longer needs the enhanced metafile handle, it
    ///     should release the handle by calling the DeleteEnhMetaFile function.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value is a handle to an enhanced metafile. If the function fails, the
    ///     return value is NULL.
    /// </returns>
    public IntPtr CloseEnhMetaFileSafe(IntPtr hdc)
    {
        return CloseEnhMetaFile(hdc);
    }

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deletemetafile">DeleteMetaFile</see>
    ///     function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
    ///     superior functionality and are recommended for new applications. The corresponding function for an enhanced-format
    ///     metafile is DeleteEnhMetaFile.
    /// </summary>
    /// <param name="hmf">A handle to a Windows-format metafile. </param>
    /// <remarks>
    ///     If the metafile identified by the hmf parameter is stored in memory (rather than on a disk), its content is
    ///     lost when it is deleted by using the DeleteMetaFile function.
    /// </remarks>
    /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. </returns>
    [Obsolete(
        "This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is DeleteEnhMetaFile.")]
    public bool DeleteMetaFileSafe(IntPtr hmf)
    {
        return DeleteMetaFile(hmf);
    }

    /// <summary>
    ///     The
    ///     <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-closemetafile">CloseMetaFile</see>
    ///     function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide
    ///     superior functionality and are recommended for new applications. The corresponding function for an enhanced-format
    ///     metafile is CloseEnhMetaFile.
    /// </summary>
    /// <param name="hdc">Handle to a metafile device context used to create a Windows-format metafile. </param>
    /// <remarks>
    ///     To convert a Windows-format metafile into a new enhanced-format metafile, use the SetWinMetaFileBits function.
    ///     When an application no longer needs the Windows-format metafile handle, it should delete the handle by calling the
    ///     DeleteMetaFile function.
    /// </remarks>
    /// <returns>
    ///     If the function succeeds, the return value is a handle to a Windows-format metafile. If the function fails,
    ///     the return value is NULL.
    /// </returns>
    [Obsolete(
        "This function is provided only for compatibility with Windows-format metafiles. Enhanced-format metafiles provide superior functionality and are recommended for new applications. The corresponding function for an enhanced-format metafile is CloseEnhMetaFile.")]
    public IntPtr CloseMetaFileSafe(IntPtr hdc)
    {
        return CloseMetaFile(hdc);
    }

    #endregion
}