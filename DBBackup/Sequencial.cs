using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBackup;
internal class Sequencial
{
    public void Running(int fieldCount)
    {
        DataWriter writer = new DataWriter();
        for (int i = 1; i <= fieldCount; i++)
        {
            var data = new DataRetriver(i.ToString("D4")).RetrivingData();
            writer.WriteData(data);
        }
    }
}
