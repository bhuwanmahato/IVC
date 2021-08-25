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
    public partial class CalculatorPage2 : ContentPage
    {
        static int yearNumber_, multiplier_;
        static decimal marketCap_, sharePrice_, totalShares_, avgIncome, totalIncome=0, intrinsicValue, percentage;
        string companyName_, stockSymbol_;
        public CalculatorPage2(string yearNumber, decimal marketCap, decimal sharePrice, decimal totalShares, string multiplier, string companyName, string stockSymbol)
        {
            yearNumber_ = Int32.Parse(yearNumber);
            marketCap_ = marketCap;
            sharePrice_ = sharePrice;
            totalShares_ = totalShares;
            companyName_ = companyName;
            stockSymbol_ = stockSymbol;
            multiplier_ = Int32.Parse(multiplier);
            InitializeComponent();
        }

        private void submitBtnforSummary_clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(year1txt.Text) ||
                   string.IsNullOrEmpty(year2txt.Text) ||
                   string.IsNullOrEmpty(year3txt.Text) /*|| Decimal.TryParse(sharePricetxt.Text, out Decimal a)*/ ||
                   string.IsNullOrEmpty(year4txt.Text) /*|| Decimal.TryParse(marketCaptxt.Text, out Decimal b)*/ ||
                   string.IsNullOrEmpty(year5txt.Text) /*|| int.TryParse(yearNumbertxt.Text, out int c) */||
                   string.IsNullOrEmpty(year6txt.Text) /*|| int.TryParse(multiplyingFactor.Text, out int d)*/ ||
                   string.IsNullOrEmpty(year7txt.Text) ||
                   string.IsNullOrEmpty(year8txt.Text))
                {
                    DisplayAlert("Required", "Please Enter all values correctly", "OK");
                }
                else
                {
                    totalIncome += (Decimal.Parse(year1txt.Text) +
                                    Decimal.Parse(year1txt.Text) +
                                    Decimal.Parse(year1txt.Text) +
                                    Decimal.Parse(year1txt.Text) +
                                    Decimal.Parse(year1txt.Text) +
                                    Decimal.Parse(year1txt.Text) +
                                    Decimal.Parse(year1txt.Text) +
                                    Decimal.Parse(year1txt.Text));
                    avgIncome = Math.Round((totalIncome / yearNumber_),2);
                    intrinsicValue = Math.Round((((avgIncome * 10000000) / totalShares_) * multiplier_),2);
                    percentage = Math.Round((((intrinsicValue - sharePrice_) / sharePrice_) * 100),2);
                    Navigation.PushAsync(new CalculatorPage3(intrinsicValue, percentage, avgIncome, totalShares_, marketCap_, companyName_, stockSymbol_, sharePrice_, multiplier_));

                }
            }
            catch (Exception E)
            {

            }
        }
    }
}