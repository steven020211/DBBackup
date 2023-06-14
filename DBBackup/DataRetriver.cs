using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DBBackup;
internal class DataRetriver
{
    public string FieldId { get; set; }

    public DataRetriver(string fieldId)
    {
        FieldId = fieldId;
    }

    public DataInfo RetrivingData()
    {
        using var _ = Profiling.Create($"Field {FieldId} Retrived");

        var data = new DataInfo(FieldId);

        data.Elapsed = Retriving();

        return data;
    }


    private TimeSpan Retriving()
    {
        //模擬取回資料, 4 ~ 10 minutes, 5% 的機率會再加 0 ~ 10 minutes

        Random rnd1 = new Random((int)DateTime.Now.Ticks);
        Random rnd2 = new Random((int)DateTime.Now.Ticks + FieldId.GetHashCode());
        var seconds = rnd1.Next(240, 600);
        var seconds2 = rnd2.Next(100);
        if (seconds2 < 5)
            seconds += GetHashCode() % 600;


        return Common.Delay(TimeSpan.FromSeconds(seconds));
    }
}
