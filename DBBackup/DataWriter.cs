using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBackup;
internal class DataWriter
{
    private Random _rnd = new Random((int)DateTime.Now.Ticks);
    public TimeSpan WriteData(DataInfo dataInfo)
    {
        //模擬寫入, 1 ~ 6 seconds
        using var _ = Profiling.Create($"Field {dataInfo.FieldId} Writed");

        var p = _rnd.NextDouble() * 5 + 1.0f;
        lock (this)
        {
            var time = TimeSpan.FromSeconds(p);
            return Common.Delay(time);
        }
    }
}
