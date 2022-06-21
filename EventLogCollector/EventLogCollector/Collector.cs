using System.Runtime.InteropServices;

namespace EventLogCollector
{
    public class Collector
    {
        [Flags]
        internal enum EventExportLogFlags
        {
            ChannelPath = 1,
            LogFilePath = 2,
            TolerateQueryErrors = 0x1000
        };

        [DllImport(@"wevtapi.dll",
            CallingConvention = CallingConvention.Winapi,
            CharSet = CharSet.Auto,
            SetLastError = true)]
        internal static extern bool EvtExportLog(
            IntPtr sessionHandle,
            string path,
            string query,
            string targetPath,
            [MarshalAs(UnmanagedType.I4)] EventExportLogFlags flags);

        public static bool Collect(string logSource, string query, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return EvtExportLog(IntPtr.Zero, logSource, query, path, EventExportLogFlags.ChannelPath);
        }

    }
}