
using IVC.Model;
using MvvmHelpers;
using MvvmHelpers.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IVC.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View : ContentPage
    {
        //public ObservableRangeCollection<Company> company { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Company> RemoveCommand { get; }

        public IVCService _database;

        public View()
        {
            InitializeComponent();
            Title = "Company Logs";

            _database = new IVCService();
            var companies = _database.GetCompanyList();
            CompanyList.ItemsSource = companies;
            //CompanyList.ItemsSource = (System.Collections.IEnumerable)IVCService.GetCompanyList();

            //company = new ObservableRangeCollection<Company>();

            //RefreshCommand = new AsyncCommand(Refresh);

        }

        //async Task Refresh()
        //{
        //    IsBusy = true;

        //    await Task.Delay(2000);

        //    company.Clear();

        //    var companies = await IVCService.GetCompanyList();

        //    company.AddRange(companies);

        //    IsBusy = false;
        //}
        //public View(Company company)
        //{
        //    InitializeComponent();
        //    Global.conn = DependencyService.Get<SQLite>().GetConnection();
        //    var data = (from comp in Global.conn.Table<Company>() select comp);
        //    CompanyList.ItemsSource = data;
        //}
    }
}