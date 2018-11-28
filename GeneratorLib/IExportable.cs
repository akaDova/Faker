﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLib
{
    public interface IExportable
    {
        object GetGenerator();

        Type ExportType
        {
            get;
        }
    }
}
