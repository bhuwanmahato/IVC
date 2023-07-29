using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IVC.Model
{
    public class IVCService
    {
        //static SQLiteAsyncConnection db;

        public SQLiteConnection _sqlconnection;

        public IVCService()
        {
            //Getting connection and Creating table
            _sqlconnection = DependencyService.Get<SQLite>().GetConnection();
            _sqlconnection.CreateTable<Company>();
        }

        public void Init()
        {
            if (_sqlconnection != null)
                return;
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            _sqlconnection = new SQLiteConnection(databasePath);
            _sqlconnection.CreateTable<Company>();

        }
        public void AddCompany(decimal intrinsicValue_, decimal percentage_, decimal avgIncome_, decimal totalShares_, decimal marketCap_, string companyName_, string stockSymbol_, decimal sharePrice_, int multiplier_)
        {
            Init();
            var company = new Company
            {
                CompanyName = companyName_,
                //IntrinsicValue = intrinsicValue_,
                //PercentageUpDown = percentage_,
                //MarketCap = marketCap_,
                //SharePrice = sharePrice_,
                //Multiplier = multiplier_,
                //StockSymbol = stockSymbol_,
                //TotalShares = totalShares_,
            };
            //var id = await _.InsertAsync(company);
            _sqlconnection.Insert(company);
        }
        public IEnumerable<Company> GetCompanyList()
        {
            Init();
            //var data = await db.Table<Company>().ToListAsync();
            var data = (from comp in _sqlconnection.Table<Company>() select comp).ToList();
            //    CompanyList.ItemsSource = data;
            return data;
        }
        //public static async Task RemoveCompany(int id)
        //{
        //    await Init();
        //    await db.DeleteAsync<Company>(id);
        //}
    }
}
