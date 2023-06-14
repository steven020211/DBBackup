using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBackup;
internal class DataInfo
{
    public string FieldId { get; set; } = null!;

    public TimeSpan Elapsed { get; set; } = TimeSpan.Zero;
    public DataInfo(string fieldId)
    {
        FieldId = fieldId;
    }

}
