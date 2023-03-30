namespace MAUI_LABS;

public partial class CalculatorPage : ContentPage
{
    public string operation;
    public string firstNum;
    public string secondNum;
    public bool flag;

    public CalculatorPage()
    {
        InitializeComponent();
    }

    private void OnButtonClicked(object sender, System.EventArgs e)
    {
        Button button = (Button)sender;

        if (flag)
        {
            flag = false;
            res.Text = "0";
        }

        if (res.Text == "0") res.Text = button.Text;

        else res.Text += button.Text;
    }

    private void ClearAll(object sender, System.EventArgs e)
    {
        res.Text = "0";
    }

    private void ClearLast(object sender, EventArgs e)
    {
        res.Text = res.Text.Substring(0, res.Text.Length - 1);

        if (res.Text == "") res.Text = "0";

    }

    private void Operation(object sender, EventArgs e)
    {
        Button B = (Button)sender;
        operation = B.Text;
        firstNum = res.Text;
        flag = true;

    }

    private void Equel(object sender, EventArgs e)
    {
        double first, second, answer = 0;
        first = Convert.ToDouble(firstNum);
        second = Convert.ToDouble(res.Text);

        if (operation == "+") answer = first + second;
        if (operation == "-") answer = first - second;
        if (operation == "×") answer = first * second;
        if (operation == "÷") answer = first / second;
        if (operation == "%") answer = first * second / 100;

        operation = "=";
        flag = true;
        res.Text = answer.ToString();

    }

    private void Point(object sender, EventArgs e)
    {
        if (!res.Text.Contains(",")) res.Text += ",";

    }

    private void MyFunc(object sender, EventArgs e)
    {
        double first;
        first = Convert.ToDouble(res.Text);
        double answer = first * first * 3.14;
        res.Text = answer.ToString();

    }

}