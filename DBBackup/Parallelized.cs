using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBackup;
internal class Parallelized
{
    public void Running(int fieldCount)
    {
        DataWriter writer = new DataWriter();
        ParallelOptions op = new ParallelOptions();
        op.MaxDegreeOfParallelism = fieldCount;
        Parallel.For(1, fieldCount + 1, op, i =>
        {
            var data = new DataRetriver(i.ToString("D4")).RetrivingData();
            writer.WriteData(data);
        });
    }
}
