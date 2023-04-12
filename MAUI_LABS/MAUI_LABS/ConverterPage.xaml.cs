using MAUI_LABS.Entities;
using MAUI_LABS.Services;

namespace MAUI_LABS;

public partial class ConverterPage : ContentPage
{
    private readonly IRateService _rateService;
    private DateTime _date;
    private int curIndex;
    private double YrCurvalue;
    private double BYNvalue;


    private List<Currency> Currencies = new List<Currency>
    {
          new Currency(456, "RUB", "Российский рубль"),
          new Currency(451, "EUR", "Евро"),
          new Currency(431, "USD", "Доллар США"),
          new Currency(426, "CHF", "Швейцарский франк"),
          new Currency(462, "CNY", "Китайский юань"),
          new Currency(429, "GBP", "Фунт стерлингов"),
    };

    public ConverterPage(IRateService rateService)
    {
        _rateService = rateService;

        InitializeComponent();
        fromCurrencyPicker.ItemsSource = Currencies;
        fromCurrencyPicker.ItemDisplayBinding = new Binding("Cur_Name");

    }

    private void DateSelected(object sender, DateChangedEventArgs e)
    {
        _date = e.NewDate;
    }

    private void Button_Clicked_BYN(object sender, EventArgs e)
    {
        double temp = (Convert.ToDouble(_rateService.GetRates(_date, Currencies[curIndex]).Last<Rate>().Cur_OfficialRate) * YrCurvalue);

        if (curIndex == 0) temp /=100;
        
        ResultInBYN.Text = temp.ToString() + " BYN";

    }

    private void fromCurrencyPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        curIndex = fromCurrencyPicker.SelectedIndex;
    }

    private void ChangedValueTo(object sender, EventArgs e)
    {
        YrCurvalue = Convert.ToDouble(YrCurCount.Text);
    }

    private void ChangedValueFrom(object sender, EventArgs e)
    {
        BYNvalue = Convert.ToDouble(BYNCount.Text);
    }

    private void Button_Clicked_Other_Cur(object sender, EventArgs e)
    {
        double temp = BYNvalue/(Convert.ToDouble(_rateService.GetRates(_date, Currencies[curIndex]).Last<Rate>().Cur_OfficialRate));

        if (curIndex == 0) temp *= 100;
        ResultInOtherCur.Text = temp.ToString() + " " + Currencies[curIndex].Cur_Abbreviation;
    }
}