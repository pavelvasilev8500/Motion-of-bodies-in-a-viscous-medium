using Motion_of_bodies_in_a_viscous_medium.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motion_of_bodies_in_a_viscous_medium.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand Task1ViewCommand { get; set; }

        public RelayCommand Task2ViewCommand { get; set; }

        public RelayCommand Task3ViewCommand { get; set; }

        public RelayCommand Task4ViewCommand { get; set; }

        public RelayCommand UserViewCommand { get; set; }

        public RelayCommand SettingsViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public Task1ViewModel Task1VM { get; set; }

        public Task2ViewModel Task2VM { get; set; }

        public Task3ViewModel Task3VM { get; set; }

        public Task4ViewModel Task4VM { get; set; }

        public UserVeiwModel UserVM { get; set; }

        public SettingsViewModel SettingsVM { get; set; }




        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();

            Task1VM = new Task1ViewModel();

            Task2VM = new Task2ViewModel();

            Task3VM = new Task3ViewModel();

            Task4VM = new Task4ViewModel();

            UserVM = new UserVeiwModel();

            SettingsVM = new SettingsViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            Task1ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Task1VM;
            });

            Task2ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Task2VM;
            });

            Task3ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Task3VM;
            });

            Task4ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Task4VM;
            });

            UserViewCommand = new RelayCommand(o =>
            {
                CurrentView = UserVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });

        }
    }
}
