using IVC.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IVC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorPage3 : ContentPage
    {
        //public SQLiteConnection con;
        public Company company;
        public IVCService ivcservice;

        static int _multiplier;
        static decimal _marketCap, _sharePrice, _totalShares, _intrinsicValue, _percentage, _avgIncome;
        string _companyName, _stockSymbol;

        public CalculatorPage3(decimal intrinsicValue_, decimal percentage_, decimal avgIncome_, decimal totalShares_, decimal marketCap_, string companyName_, string stockSymbol_, decimal sharePrice_, int multiplier_)
        {
            InitializeComponent();

            //Global.conn = DependencyService.Get<SQLite>().GetConnection();
            //Global.conn.CreateTable<Company>();

            _companyName = companyName_;
            _sharePrice = sharePrice_;
            _multiplier = multiplier_;
            _intrinsicValue = intrinsicValue_;
            _percentage = percentage_;
            _stockSymbol = stockSymbol_;
            _totalShares = totalShares_;
            _avgIncome = avgIncome_;

            companyName.Text = "Company : " + companyName_;
            intrinsicValue.Text = "Intrinsic Value : " + intrinsicValue_.ToString() + " ₹";
            PercentageUpDown.Text = "Percentage Up/Down : " + percentage_.ToString();
            averageIncome.Text = "Average Income : " + avgIncome_.ToString() + " Cr";
            totalShares.Text = "Total Shares : " + totalShares_.ToString();
            marketCap.Text = "Market Cap : " + marketCap_.ToString() + " Cr";
            stockSymbol.Text = "Stock Symbol : " + stockSymbol_;
            sharePrice.Text = "Share Price : " + sharePrice_.ToString() + " ₹";
            Multiplier.Text = "Multiplying Factor : " + multiplier_.ToString();
        }

        private void SaveBtnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Pages.View());
            ivcservice.AddCompany(_intrinsicValue, _percentage, _avgIncome, _totalShares, _marketCap, _companyName, _stockSymbol, _sharePrice, _multiplier);
            DisplayAlert("Success", "Data Saved Sucessfully", "OK");
            
            //company = new Company();
            //company.CompanyName = _companyName;
            //company.IntrinsicValue = _intrinsicValue;
            //company.MarketCap = _marketCap;
            //company.Multiplier = _multiplier;
            //company.PercentageUpDown = _percentage;
            //company.SharePrice = _sharePrice;
            //company.StockSymbol = _stockSymbol;
            //company.TotalShares = _totalShares;

            //Global.conn.Insert(company);
            //DisplayAlert("Success", "Data Saved Sucessfully", "OK");
            //Navigation.PushAsync(new Pages.View(company));
        }
    }
}