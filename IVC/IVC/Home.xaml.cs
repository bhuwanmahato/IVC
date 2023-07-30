using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IVC.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        private static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(fullUrl);
            return response;
        }
        private void Submit_Clicked(object sender, EventArgs e)
        {

            try
            {
                decimal marketCap, sharePrice, totalShares;
                if (string.IsNullOrEmpty(companytxt.Text) ||
                   string.IsNullOrEmpty(stockSymboltxt.Text) ||
                   string.IsNullOrEmpty(sharePricetxt.Text) /*|| Decimal.TryParse(sharePricetxt.Text, out Decimal a)*/ ||
                   string.IsNullOrEmpty(marketCaptxt.Text) /*|| Decimal.TryParse(marketCaptxt.Text, out Decimal b)*/ ||
                   string.IsNullOrEmpty(yearNumbertxt.Text) /*|| int.TryParse(yearNumbertxt.Text, out int c) */||
                   string.IsNullOrEmpty(multiplyingFactor.Text) /*|| int.TryParse(multiplyingFactor.Text, out int d)*/)
                {
                    DisplayAlert("Required", "Please Enter all values correctly", "OK");
                }
                else
                {
                    marketCap = Convert.ToDecimal(marketCaptxt.Text);
                    sharePrice = Convert.ToDecimal(sharePricetxt.Text);
                    totalShares = Math.Round(((marketCap * 10000000) / sharePrice),2);
                    Navigation.PushAsync(new CalculatorPage2(yearNumbertxt.Text, marketCap, sharePrice, totalShares,multiplyingFactor.Text,companytxt.Text,stockSymboltxt.Text));
                }
            }
            catch (Exception E)
            {
                DisplayAlert("Error", E.Message, "OK");
            }
        }
    }
}