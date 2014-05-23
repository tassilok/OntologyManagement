using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace FileSystem_Connector_Module
{
    public static class UNCHelper
    {
        [DllImport("mpr.dll")]
        static extern int WNetGetUniversalNameA(
            string lpLocalPath, int dwInfoLevel, IntPtr lpBuffer, ref int lpBufferSize
        );

        // I think max length for UNC is actually 32,767
        public static string LocalToUNC(string localPath, int maxLen = 32767)
        {
            IntPtr lpBuff;

            // Allocate the memory
            try
            {
                lpBuff = Marshal.AllocHGlobal(maxLen);
            }
            catch (OutOfMemoryException)
            {
                return null;
            }

            try
            {
                int res = WNetGetUniversalNameA(localPath, 1, lpBuff, ref maxLen);

                if (res != 0)
                    return localPath;

                // lpbuff is a structure, whose first element is a pointer to the UNC name (just going to be lpBuff + sizeof(int))
                return Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(lpBuff));
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Marshal.FreeHGlobal(lpBuff);
            }
        }

    }
}
