using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wolfram.NETLink;

namespace Motion_of_bodies_in_a_viscous_medium.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для Task2View.xaml
    /// </summary>
    public partial class Task2View : UserControl, IIndexable
    {
        public int Index => 2;
        public Task2View()
        {
            InitializeComponent();
        }

    private async void Compute_Click(object sender, RoutedEventArgs e)
    {
        using (var kernel = new MathKernel())
        {
            var kernel1 = new MathKernel();
            const string Path = @"latest-graphics-task2.png";
            await Task.Run(() =>
            {
                //Расчёт уравнения
                kernel1.Compute("U0 = 10;");
                kernel1.Compute("t = {1, 2, 3};");
                kernel1.Compute("k1 = 6*Pi*R*eto;");
                kernel1.Compute("eto = 0.018;");
                kernel1.Compute("m = 2;");
                kernel1.Compute("R = 3;");
                kernel1.Compute("g = 9.8;");
                kernel1.Compute("f[x_] = Exp[(-k1/m)*t] + (m*g)/k1;");
                kernel1.Compute("f[x]");
                //Расчёт графика
                kernel.Compute("U0 = 10;");
                kernel.Compute("t = {1,2,3};");
                kernel.Compute("k1 = 6*Pi*R*eto;");
                kernel.Compute("eto = 0.018;");
                kernel.Compute("m = 2;");
                kernel.Compute("R = 3;");
                kernel.Compute("g = 9.8;");
                kernel.Compute("f[x_] = Exp[-k1/m*t] + m*g/k1;");
                kernel.Compute("f[x]");
                const string Input = "Plot[Exp[(-k1/m*t)] + (m*g)/k1, {t, 1, 10}, PlotRange -> Full, AxesLabel-> { t, U[t]}]";
                kernel.Compute($"Export[\"{Path}\", {Input}]");
            });
            Result.Text = ($"U(t) = {kernel1.Result.ToString()}");
            Output.Source = new BitmapImage(new Uri($"file://{AppDomain.CurrentDomain.BaseDirectory}/{Path}"));
        }
    }

    }
}
