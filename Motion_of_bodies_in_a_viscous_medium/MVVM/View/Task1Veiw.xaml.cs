using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для Task1Veiw.xaml
    /// </summary>
    public partial class Task1Veiw : UserControl, IIndexable, INotifyPropertyChanged
    {
        public int Index => 1;
        public Task1Veiw()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private async void Compute_Click(object sender, RoutedEventArgs e)
    {
        using (var kernel = new MathKernel())
        {
            var kernel1 = new MathKernel();
            const string Path = @"latest-graphics-task1.png";
            await Task.Run(() =>
            {
                //Расчёт уравнения
                kernel1.Compute("U0 = 10;");
                kernel1.Compute("t = {1, 2, 3, 4, 5};");
                kernel1.Compute("k1 = 6*Pi*R*eto;");
                kernel1.Compute("eto = 0.018;");
                kernel1.Compute("m = 2;");
                kernel1.Compute("R = 3;");
                kernel1.Compute("f[x_] = U0*Exp[-k1/m*t];");
                kernel1.Compute("f[x]");
                //Расчёт графика
                kernel.Compute("U0 = 10;");
                kernel.Compute("t = {1,2,3,4,5};"); ;
                kernel.Compute("k1 = 6*Pi*R*eto;");
                kernel.Compute("eto = 0.018;");
                kernel.Compute("m = 2;");
                kernel.Compute("R = 3;");
                kernel.Compute("f[x_] = U0*Exp[-k1/m*t];");
                kernel.Compute("f[x]");
                const string Input = "Plot[U0*Exp[-k1/m*t], {t, 1, 27}, PlotRange -> Full, AxesLabel-> { t, U[t]}]";
                kernel.Compute($"Export[\"{Path}\", {Input}]");
            });
            Result.Text = ($"U(t) = {kernel1.Result.ToString()}");
            Output.Source = new BitmapImage(new Uri($"file://{AppDomain.CurrentDomain.BaseDirectory}/{Path}"));
        }
    }

        // Stolen from:
        // http://lotrex.blogspot.com/2013/09/image-systemdrawingimage-win-forms.html
        private static ImageSource AdaptGraphics(System.Drawing.Image image)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                var source = new BitmapImage();
                source.BeginInit();
                source.UriSource = null;
                source.CacheOption = BitmapCacheOption.OnLoad;
                source.StreamSource = stream;
                source.EndInit();
                return source;
            }
        }

    }
}
