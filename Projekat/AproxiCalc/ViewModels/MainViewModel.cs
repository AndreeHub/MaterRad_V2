using AproxiCalc.Helpers;
using AproxiCalc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AproxiCalc.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        private readonly IDataService _dataService;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(nameof(CurrentViewModel)); }
        }

        public ICommand ShowColumnsViewCommand { get; }
        public ICommand ShowBuildingViewCommand { get; }
        public ICommand ShowModelViewCommand { get; }
        public ICommand ShowCalculationViewCommand { get; }

        public MainViewModel()
        {
            _dataService = new DataService();

            ShowColumnsViewCommand = new RelayCommand(_ => ShowColumnsView());
            ShowBuildingViewCommand = new RelayCommand(_ => ShowBuildingView());
            ShowModelViewCommand = new RelayCommand(_ => ShowModelView());
            ShowCalculationViewCommand = new RelayCommand(_ => ShowCalculationView());

            CurrentViewModel = new ColumnsViewModel(_dataService);
        }

        private void ShowColumnsView() =>
            CurrentViewModel = new ColumnsViewModel(_dataService);

        private void ShowBuildingView() =>
            CurrentViewModel = new BuildingViewModel(_dataService);

        private void ShowModelView() =>
            CurrentViewModel = new ModelViewModel(_dataService);

        private void ShowCalculationView() =>
            CurrentViewModel = new CalculationViewModel(_dataService);
    }
}
