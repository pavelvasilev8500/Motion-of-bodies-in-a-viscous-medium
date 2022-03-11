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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Motion_of_bodies_in_a_viscous_medium.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl, IIndexable
    {
        public int Index => 0;

        bool StateClosed = true;

        public HomeView()
        {
            InitializeComponent();
        }

        private void Task1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (StateClosed)
            {
                var sb = new Storyboard[] { this.FindResource("OpenTask1") as Storyboard,
                                            this.FindResource("OpenTaskAbout1") as Storyboard};
                foreach (var sb1 in sb)
                    sb1.Begin();
            }
            else
            {
                var sb = new Storyboard[] { this.FindResource("CloseTask1") as Storyboard,
                                            this.FindResource("CloseTaskAbout1") as Storyboard};
                foreach (var sb1 in sb)
                    sb1.Begin();
            }

            StateClosed = !StateClosed;
        }

        private void Task2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (StateClosed)
            {
                var sb = new Storyboard[] { this.FindResource("OpenTask2") as Storyboard,
                                            this.FindResource("OpenTaskAbout2") as Storyboard,};
                foreach (var sb1 in sb)
                    sb1.Begin();
            }
            else
            {
                var sb = new Storyboard[] { this.FindResource("CloseTask2") as Storyboard,
                                            this.FindResource("CloseTaskAbout2") as Storyboard,};
                foreach (var sb1 in sb)
                    sb1.Begin();
            }

            StateClosed = !StateClosed;
        }

        private void Task3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (StateClosed)
            {
                var sb = new Storyboard[] { this.FindResource("OpenTask3") as Storyboard,
                                            this.FindResource("OpenTaskAbout3") as Storyboard,};
                foreach (var sb1 in sb)
                    sb1.Begin();
            }
            else
            {
                var sb = new Storyboard[] { this.FindResource("CloseTask3") as Storyboard,
                                            this.FindResource("CloseTaskAbout3") as Storyboard,};
                foreach (var sb1 in sb)
                    sb1.Begin();
            }

            StateClosed = !StateClosed;
        }

        private void Task4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (StateClosed)
            {
                var sb = new Storyboard[] { this.FindResource("OpenTask4") as Storyboard,
                                            this.FindResource("OpenTaskAbout4") as Storyboard,};
                foreach (var sb1 in sb)
                    sb1.Begin();
            }
            else
            {
                var sb = new Storyboard[] { this.FindResource("CloseTask4") as Storyboard,
                                            this.FindResource("CloseTaskAbout4") as Storyboard,};
                foreach (var sb1 in sb)
                    sb1.Begin();
            }

            StateClosed = !StateClosed;
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
