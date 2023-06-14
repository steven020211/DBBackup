using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBackup;
internal class Tasked
{
    public async Task Running(int fieldCount)
    {
        ThreadPool.SetMinThreads(1024, 50);

        DataWriter writer = new DataWriter();

        List<Task> tasks = new List<Task>();
        for (int i = 0; i < fieldCount; i++)
        {
            var index = i + 1;
            tasks.Add(Task.Run(() =>
            {
                var data = new DataRetriver(index.ToString("D4")).RetrivingData();
                writer.WriteData(data);
            }));
        }

        await Task.WhenAll(tasks);
    }
}
