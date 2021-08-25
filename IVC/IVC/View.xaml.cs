using IVC.Model;
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
        public View()
        {
            InitializeComponent();
        }
        public View(Company company)
        {
            InitializeComponent();
            Global.conn = DependencyService.Get<SQLite>().GetConnection();
            var data = (from comp in Global.conn.Table<Company>() select comp);
            CompanyList.ItemsSource = data;
        }
    }
}