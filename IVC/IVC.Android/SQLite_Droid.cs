using IVC.Droid;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
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