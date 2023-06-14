// See https://aka.ms/new-console-template for more information
using DBBackup;
using System.Diagnostics;
using System.Runtime.InteropServices;

[DllImport("winmm.dll")]
static extern uint timeBeginPeriod(uint period);

[DllImport("winmm.dll")]
static extern uint timeEndPeriod(uint period);

timeBeginPeriod(1);

Console.WriteLine("Start");

int fieldCount = 326;

//Common.SetResolution(10000);

using (Profiling.Create($"Sequencial Processing {fieldCount} fields"))
{
    new Sequencial().Running(fieldCount);
}

using (Profiling.Create($"Parallelized Processing {fieldCount} fields"))
{
    new Parallelized().Running(fieldCount);
}

using (Profiling.Create($"Tasked Processing {fieldCount} fields"))
{
    await new Tasked().Running(fieldCount);
}

timeEndPeriod(1);