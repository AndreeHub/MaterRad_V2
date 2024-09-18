using AproxiCalc.Helpers;
using AproxiCalc.Models;
using AproxiCalc.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AproxiCalc.ViewModels
{
    public class BuildingViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;
        private Floor _selectedFloor;

        public ObservableCollection<Floor> Floors => _dataService.Floors;

        public Floor SelectedFloor
        {
            get => _selectedFloor;
            set { _selectedFloor = value; OnPropertyChanged(nameof(SelectedFloor)); }
        }

        public ICommand AddFloorCommand { get; }
        public ICommand DeleteFloorCommand { get; }

        public BuildingViewModel(IDataService dataService)
        {
            _dataService = dataService;
            AddFloorCommand = new RelayCommand(_ => AddFloor());
            DeleteFloorCommand = new RelayCommand(_ => DeleteFloor(), _ => SelectedFloor != null);
        }

        private void AddFloor()
        {
            var newFloor = new Floor();
            _dataService.Floors.Add(newFloor);
            SelectedFloor = newFloor;
        }

        private void DeleteFloor()
        {
            if (SelectedFloor != null)
            {
                _dataService.Floors.Remove(SelectedFloor);
            }
        }
    }
}
