using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBackup;
internal static class Common
{
    private static long RESOLUTION = 1000;

    public static void SetResolution(long resolution) => RESOLUTION = resolution;

    internal static TimeSpan Delay(TimeSpan delayTime)
    {
        TimeSpan realDelay = TimeSpan.FromMilliseconds(delayTime.TotalMilliseconds / RESOLUTION);

        Thread.Sleep(realDelay.Milliseconds);

        return delayTime;
    }

    internal static TimeSpan Normalize(this TimeSpan timeSpan) =>
        TimeSpan.FromMilliseconds(timeSpan.TotalMilliseconds * RESOLUTION);
}
