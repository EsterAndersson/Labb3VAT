using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Labb3
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            setupClicked();
            
        }

        public void setupClicked()
        {
            eightPercentButton.Clicked += CalculateSetValuesWhenClicked;
            twelvePercentButton.Clicked += CalculateSetValuesWhenClicked;
            twentyfivePercentButton.Clicked += CalculateSetValuesWhenClicked;
        }

      

        public void CalculateSetValuesWhenClicked(object sender, EventArgs args)
        {
            double.TryParse(userInput.Text, out double amount);

            string vatString = ((Button)sender).Text;
            vatRate.Text = vatString;
            vatString = vatString.Remove(vatString.Length - 1);
            double.TryParse(vatString, out double VAT);

            Calculate(amount, VAT);
        }

        public void Calculate(double amount, double VAT)
        {

            double vatCalc = 1 / (VAT / 100 + 1);
            double calculatedAmountValue = Math.Round(vatCalc * amount);
            double calculatedVatValue = Math.Round(amount - calculatedAmountValue);

            inputAmount.Text = $"{amount} Sek";
            calculatedAmount.Text = $"{calculatedAmountValue} Sek";
            calculatedVat.Text = $"{calculatedVatValue} Sek";
            
           


        }
    }
}