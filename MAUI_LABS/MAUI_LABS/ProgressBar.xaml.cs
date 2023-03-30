namespace MAUI_LABS;

public partial class ProgressBarPage : ContentPage
{
    public ProgressBarPage()
    {
        InitializeComponent();
    }

    private CancellationTokenSource cancelTokenSource;

    CancellationToken token;

    private const double step = 0.00000001;

    private Task<double> task;

    private double GetStep { get { return step; } set { } }

    private double Method()
    {
        double result = 0;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            BarName.Progress = 0;
        });

        MainThread.BeginInvokeOnMainThread(() =>
        {
            LabelName.Text = "Вычисление";
        });

        for (int i = 0; i <= (1 / GetStep) - 1; i++)
        {
            if (token.IsCancellationRequested)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    LabelName.Text = "Отмена вычислений";
                });
                return 0;
            }

            result += Math.Sin(0 + i * GetStep) * GetStep;

            if (i % (1 / (GetStep * 100)) == 0)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    BarName.Progress += 0.01;
                    LabelPercentName.Text = $"{Math.Round(BarName.Progress, 2) * 100} %";
                });
            }

        }

        return result;

    }

    public async void GetIntegral(object sender, System.EventArgs e)
    {
        if (task?.Status != TaskStatus.Running)
        {
            task = new Task<double>(() => Method());

            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;

            task.Start();

            double res = await task;
            if (res != 0) LabelName.Text = Convert.ToString(res);

            else LabelName.Text = "Отмена вычислений";

            cancelTokenSource.Dispose();
            cancelTokenSource = null;
        }
    }

    private void Cancel(object sender, System.EventArgs e)
    {

        if (task?.Status == TaskStatus.Running)
        {
            cancelTokenSource.Cancel();
            token = cancelTokenSource.Token;
        }

    }

}
