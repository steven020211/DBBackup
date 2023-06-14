using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBackup;
internal class Profiling : IDisposable
{
    public static Profiling Create(string title) => new Profiling(title);

    Stopwatch _stopwatch = Stopwatch.StartNew();

    public Profiling(string title)
    {
        _title = title;
    }

    private bool _disposedValue;
    private readonly string _title;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // TODO: 處置受控狀態 (受控物件)
                var elapsed = _stopwatch.Elapsed.Normalize();
                string ts = elapsed.ToString("mm\\:ss\\.fff");
                if (elapsed.TotalDays >= 1.0)
                    ts = elapsed.ToString();
                else if (elapsed.TotalHours >= 1.0)
                    ts = elapsed.ToString("hh\\:mm\\:ss\\.fff");
                Console.WriteLine($"{_title} \t: {ts}");
            }

            // TODO: 釋出非受控資源 (非受控物件) 並覆寫完成項
            // TODO: 將大型欄位設為 Null
            _disposedValue = true;
        }
    }

    // // TODO: 僅有當 'Dispose(bool disposing)' 具有會釋出非受控資源的程式碼時，才覆寫完成項
    // ~Profiling()
    // {
    //     // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
