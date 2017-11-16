using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;

namespace Uber_Universitario
{
    public interface IConfig
    {
        string DirectorioDB { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
