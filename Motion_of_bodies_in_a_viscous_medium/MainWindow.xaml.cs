using Motion_of_bodies_in_a_viscous_medium.MVVM.View;
using Motion_of_bodies_in_a_viscous_medium.MVVM.ViewModel;
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

namespace Motion_of_bodies_in_a_viscous_medium
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Brush transparent = new SolidColorBrush(Colors.Transparent);
        Brush markerColor = new SolidColorBrush(Color.FromRgb(0, 125, 255));
        bool StateClosed = true;

        private UserControl HomePage     = new HomeView(); 
        private UserControl Task1Page    = new Task1Veiw();
        private UserControl Task2Page    = new Task2View();
        private UserControl Task3Page    = new Task3View();
        private UserControl Task4Page    = new Task4View();
        private UserControl UserPage     = new UserView();
        private UserControl SettingsPage = new SettingsView();
        private UserControl[] _pages;

        public void Navigate(int index)
        {
            var page = _pages[index];
            SetMarker(index);
            SetTitle(index);
            NavigateFrame.Navigate(page);
            CanGoBack();
            Remember(page);
        }

        public MainWindow()
        {
            
            InitializeComponent();
            _pages = new UserControl[]
            {
                HomePage,
                Task1Page,
                Task2Page,
                Task3Page,
                Task4Page,
                UserPage,
                SettingsPage
            };
            Navigate(0);
            //TraceHistory();
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            if (StateClosed)
            {
                var sb = new Storyboard[] { this.FindResource("OpenMenu") as Storyboard,
                                            this.FindResource("Element1Open") as Storyboard,
                                            this.FindResource("Element2Open") as Storyboard,
                                            this.FindResource("Element3Open") as Storyboard,
                                            this.FindResource("Element4Open") as Storyboard,
                                            this.FindResource("Element5Open") as Storyboard,
                                            this.FindResource("UserOpen") as Storyboard,
                                         };
                //var elements = new string[] { "OpenMenu", "Element1Open", "Element2Open", "Element3Open", "Element4Open", "Element5Open", "UserOpen", "SettingsOpen", "AppTitleOpen", "BackButtonOpen" };
                //var sb = from element in elements select this.FindResource(element) as Storyboard;
                foreach (var sb1 in sb)
                    sb1.Begin();
            }
            else
            {
                var sb = new Storyboard[] { this.FindResource("CloseMenu") as Storyboard,
                                            this.FindResource("Element1Close") as Storyboard,
                                            this.FindResource("Element2Close") as Storyboard,
                                            this.FindResource("Element3Close") as Storyboard,
                                            this.FindResource("Element4Close") as Storyboard,
                                            this.FindResource("Element5Close") as Storyboard,
                                            this.FindResource("UserClose") as Storyboard,
                                          };
                foreach (var sb1 in sb)
                    sb1.Begin();
            }

            StateClosed = !StateClosed;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void PageSelected(object sender, RoutedEventArgs e)
        {
            var page  = (ListViewItem)sender;
            int index = (int)page.Name[page.Name.Length - 1] - '1';
            Navigate(index);
            //TraceHistory();
        }

        private void CanGoBack()
        {
            if(_history.Count >= 1)
            {
                var sb = new Storyboard[] {
                                            this.FindResource("BackButtonOpen") as Storyboard,
                                            this.FindResource("AppTitleOpen") as Storyboard,
                                          };
                foreach (var sb1 in sb)
                    sb1.Begin();
            }
            else if (NavigateFrame.CanGoBack)
            {
                var sb = new Storyboard[] {
                                            this.FindResource("BackButtonOpen") as Storyboard,
                                            this.FindResource("AppTitleOpen") as Storyboard,
                                          };
                foreach (var sb1 in sb)
                    sb1.Begin();
            }
            else
            {
                var sb = new Storyboard[] {
                                            this.FindResource("BackButtonClose") as Storyboard,
                                            this.FindResource("AppTitleClose") as Storyboard,
                                          };
                foreach (var sb1 in sb)
                    sb1.Begin();
            }
        }

        #region Установка маркеров.
        private readonly Stack<int> _history = new Stack<int>();

        private readonly Stack<string> _title = new Stack<string>();

        private void Remember(object page)
        {
            int position = ((IIndexable)page).Index;
            if (_history.Count == 0 || position != _history.Peek())
            {
                _history.Push(position);
            }
        }

        private void Recall()
        {
            _history.Pop();
            int position = _history.Peek();
            SetMarker(position);
            SetTitle(position);
        }

        //private void TraceHistory()
        //{
        //    var buffer = new StringBuilder();
        //    buffer.Append('[');
        //    var indices = _history.ToArray();
        //    for (var i = 0; i < indices.Length; i++)
        //    {
        //        buffer.Append(indices[i]);
        //        if (i + 1 != indices.Length)
        //        {
        //            buffer.Append(", ");
        //        }
        //    }
        //    buffer.Append(']');
        //    Title.Text = buffer.ToString();
        //}
        #endregion

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            NavigateFrame.GoBack();
            Recall();
            //TraceHistory();
            if (!NavigateFrame.CanGoBack)
            {
                var sb = new Storyboard[] {
                                            this.FindResource("BackButtonClose") as Storyboard,
                                            this.FindResource("AppTitleClose") as Storyboard,
                                          };
                foreach (var sb1 in sb)
                    sb1.Begin();
            }
            //var position = 0;
            //foreach (var _ in NavigateFrame.BackStack)
            //{
            //    position++;
            //}
        }

        private void SetMarker(int index)
        {
            var markers = new Grid[] { Marker1, Marker2, Marker3, Marker4, Marker5, UserMarker };
            for (var i = 0; i < markers.Length; i++)
            {
                markers[i].Background = i == index
                    ? markerColor
                    : transparent;
            }
        }

        private void SetTitle(int index)
        {
            var pagestitle = new String[]
            {
                "Главная",
                "Задание 1",
                "Задание 2",
                "Задание 3",
                "Задание 4",
                "Пользователь",
                "Параметры"
            };
            for (var i = 0; i < pagestitle.Length; i++)
            {
                if (i == index)
                {
                    Title.Text = pagestitle[i].ToString();
                }
            }
        }
    }
}
