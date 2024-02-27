using System.Runtime.InteropServices;

namespace HVT.GDI;

public partial class DC
{
    #region Private

    [LibraryImport("gdi32.dll")]
    private static partial IntPtr CreateDCW([MarshalAs(UnmanagedType.LPWStr)] string pwszDriver,
        [MarshalAs(UnmanagedType.LPWStr)] string pwszDevice, [MarshalAs(UnmanagedType.LPWStr)] string? pszPort,
        IntPtr lpInitData);

    #endregion

    #region Public

    /// <summary>
    ///     The <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createdcw">CreateDCW</see>
    ///     function creates a device context (DC) for a device using the specified name.
    /// </summary>
    /// <param name="pwszDriver">
    ///     A pointer to a null-terminated character string that specifies either DISPLAY or the name of a
    ///     specific display device. For printing, we recommend that you pass NULL to lpszDriver because GDI ignores lpszDriver
    ///     for printer devices.
    /// </param>
    /// <param name="pwszDevice">
    ///     A pointer to a null-terminated character string that specifies the name of the specific output device being used,
    ///     as shown by the Print Manager (for example, Epson FX-80). It is not the printer model name. The lpszDevice
    ///     parameter must be used.
    ///     To obtain valid names for displays, call EnumDisplayDevices.
    ///     If lpszDriver is DISPLAY or the device name of a specific display device, then lpszDevice must be NULL or that same
    ///     device name. If lpszDevice is NULL, then a DC is created for the primary display device.
    ///     If there are multiple monitors on the system, calling CreateDC(TEXT("DISPLAY"),NULL,NULL,NULL) will create a DC
    ///     covering all the monitors.
    /// </param>
    /// <remarks>
    ///     Note that the handle to the DC can only be used by a single thread at any one time.
    ///     For parameters lpszDriver and lpszDevice, call EnumDisplayDevices to obtain valid names for displays.
    ///     When you no longer need the DC, call the DeleteDC function.
    ///     If lpszDriver or lpszDevice is DISPLAY, the thread that calls CreateDC owns the HDC that is created. When this
    ///     thread is destroyed, the HDC is no longer valid. Thus, if you create the HDC and pass it to another thread, then
    ///     exit the first thread, the second thread will not be able to use the HDC.
    ///     When you call CreateDC to create the HDC for a display device, you must pass to pdm either NULL or a pointer to
    ///     DEVMODE that matches the current DEVMODE of the display device that lpszDevice specifies. We recommend to pass NULL
    ///     and not to try to exactly match the DEVMODE for the current display device.
    ///     When you call CreateDC to create the HDC for a printer device, the printer driver validates the DEVMODE. If the
    ///     printer driver determines that the DEVMODE is invalid (that is, printer driver can’t convert or consume the
    ///     DEVMODE), the printer driver provides a default DEVMODE to create the HDC for the printer device.
    ///     ICM: To enable ICM, set the dmICMMethod member of the DEVMODE structure (pointed to by the pInitData parameter) to
    ///     the appropriate value.
    /// </remarks>
    /// <param name="lpInitData">
    ///     A pointer to a DEVMODE structure containing device-specific initialization data for the device
    ///     driver. The DocumentProperties function retrieves this structure filled in for a specified device. The pdm
    ///     parameter must be NULL if the device driver is to use the default initialization (if any) specified by the user. If
    ///     lpszDriver is DISPLAY, pdm must be NULL; GDI then uses the display device's current DEVMODE.
    /// </param>
    /// <returns>
    ///     If the function succeeds, the return value is the handle to a DC for the specified device. If the function
    ///     fails, the return value is NULL.
    /// </returns>
    public IntPtr CreateDCSafe(string pwszDriver, string pwszDevice, IntPtr lpInitData)
    {
        return CreateDCW(pwszDriver, pwszDevice, null, lpInitData);
    }

    #endregion
}