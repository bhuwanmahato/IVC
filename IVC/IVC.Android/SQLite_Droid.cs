using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IVC.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLite_Droid))]
namespace IVC.Droid
{
    class SQLite_Droid : SQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbname = "mydatabase.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbPath, dbname);
            var conn = new SQLiteConnection(path);
            return conn;

        }
    }
}