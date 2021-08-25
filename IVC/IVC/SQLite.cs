using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IVC
{
    public interface SQLite
    {
        SQLiteConnection GetConnection();
    }
}
