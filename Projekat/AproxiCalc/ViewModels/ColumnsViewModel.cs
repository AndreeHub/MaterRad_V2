using AproxiCalc.Helpers;
using AproxiCalc.Models;
using AproxiCalc.Services;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace AproxiCalc.ViewModels
{
    public class ColumnsViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;
        private Column _selectedColumn;

        public ObservableCollection<Column> Columns => _dataService.Columns;

        public Column SelectedColumn
        {
            get => _selectedColumn;
            set { _selectedColumn = value; OnPropertyChanged(nameof(SelectedColumn)); }
        }

        // Properties for new column inputs
        private string _newColumnName;
        public string NewColumnName
        {
            get => _newColumnName;
            set { _newColumnName = value; OnPropertyChanged(nameof(NewColumnName)); }
        }

        private ColumnType _newColumnType;
        public ColumnType NewColumnType
        {
            get => _newColumnType;
            set { _newColumnType = value; OnPropertyChanged(nameof(NewColumnType)); }
        }

        private double _newColumnModulusE;
        public double NewColumnModulusE
        {
            get => _newColumnModulusE;
            set { _newColumnModulusE = value; OnPropertyChanged(nameof(NewColumnModulusE)); }
        }

        private double _newColumnMomentOfInertia;
        public double NewColumnMomentOfInertia
        {
            get => _newColumnMomentOfInertia;
            set { _newColumnMomentOfInertia = value; OnPropertyChanged(nameof(NewColumnMomentOfInertia)); }
        }

        public ICommand AddColumnCommand { get; }
        public ICommand DeleteColumnCommand { get; }
        public IEnumerable<ColumnType> ColumnTypes => Enum.GetValues(typeof(ColumnType)).Cast<ColumnType>();

        public ColumnsViewModel(IDataService dataService)
        {
            _dataService = dataService;

            // Initialize default values
            NewColumnType = ColumnType.RigidRigid;

            AddColumnCommand = new RelayCommand(_ => AddColumn(), _ => CanAddColumn());
            DeleteColumnCommand = new RelayCommand(_ => DeleteColumn(), _ => SelectedColumn != null);
        }

        private void AddColumn()
        {
            var newColumn = new Column
            {
                Name = NewColumnName,
                Type = NewColumnType,
                ModulusE = NewColumnModulusE,
                MomentOfInertia = NewColumnMomentOfInertia
            };

            _dataService.Columns.Add(newColumn);

            // Clear input fields
            NewColumnName = string.Empty;
            NewColumnType = ColumnType.RigidRigid;
            NewColumnModulusE = 0;
            NewColumnMomentOfInertia = 0;

            OnPropertyChanged(nameof(NewColumnName));
            OnPropertyChanged(nameof(NewColumnType));
            OnPropertyChanged(nameof(NewColumnModulusE));
            OnPropertyChanged(nameof(NewColumnMomentOfInertia));
        }

        private bool CanAddColumn()
        {
            // Simple validation to ensure Name is provided
            return !string.IsNullOrWhiteSpace(NewColumnName);
        }

        private void DeleteColumn()
        {
            if (SelectedColumn != null)
            {
                _dataService.Columns.Remove(SelectedColumn);
                SelectedColumn = null;
            }
        }
    }
}