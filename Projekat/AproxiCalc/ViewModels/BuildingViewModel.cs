using AproxiCalc.Helpers;
using AproxiCalc.Models;
using AproxiCalc.Services;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AproxiCalc.ViewModels
{
    public class BuildingViewModel : BaseViewModel, IDataErrorInfo
    {
        private readonly IDataService _dataService;
        private Floor _selectedFloor;

        public ObservableCollection<Floor> Floors => _dataService.Floors;

        public Floor SelectedFloor
        {
            get => _selectedFloor;
            set { _selectedFloor = value; OnPropertyChanged(nameof(SelectedFloor)); }
        }

        // Properties for new floor inputs
        private string _newFloorName;
        public string NewFloorName
        {
            get => _newFloorName;
            set { _newFloorName = value; OnPropertyChanged(nameof(NewFloorName)); }
        }

        private double _newFloorHeight;
        public double NewFloorHeight
        {
            get => _newFloorHeight;
            set { _newFloorHeight = value; OnPropertyChanged(nameof(NewFloorHeight)); }
        }

        public ICommand AddFloorCommand { get; }
        public ICommand DeleteFloorCommand { get; }

        public BuildingViewModel(IDataService dataService)
        {
            _dataService = dataService;

            AddFloorCommand = new RelayCommand(_ => AddFloor(), _ => CanAddFloor());
            DeleteFloorCommand = new RelayCommand(_ => DeleteFloor(), _ => SelectedFloor != null);
        }

        private void AddFloor()
        {
            var newFloor = new Floor
            {
                Name = NewFloorName,
                Height = NewFloorHeight
            };

            _dataService.Floors.Add(newFloor);

            // Clear input fields
            NewFloorName = string.Empty;
            NewFloorHeight = 0;
        }

        private void DeleteFloor()
        {
            if (SelectedFloor != null)
            {
                _dataService.Floors.Remove(SelectedFloor);
                SelectedFloor = null;
            }
        }
        private bool CanAddFloor()
        {
            // The Add button will be enabled only if there are no validation errors
            return string.IsNullOrEmpty(this[nameof(NewFloorName)]) && string.IsNullOrEmpty(this[nameof(NewFloorHeight)]);
        }

        // IDataErrorInfo implementation
        public string this[string columnName]
        {
            get
            {
                string error = null;
                if (columnName == nameof(NewFloorName))
                {
                    if (string.IsNullOrWhiteSpace(NewFloorName))
                        error = "Floor Name is required.";
                }
                else if (columnName == nameof(NewFloorHeight))
                {
                    if (NewFloorHeight <= 0)
                        error = "Floor Height must be greater than zero.";
                }
                return error;
            }
        }

        public string Error => null;
    }

}
