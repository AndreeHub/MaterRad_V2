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

        public ICommand AddColumnCommand { get; }
        public ICommand DeleteColumnCommand { get; }

        public ColumnsViewModel(IDataService dataService)
        {
            _dataService = dataService;
            AddColumnCommand = new RelayCommand(_ => AddColumn());
            DeleteColumnCommand = new RelayCommand(_ => DeleteColumn(), _ => SelectedColumn != null);
        }

        private void AddColumn()
        {
            var newColumn = new Column();
            _dataService.Columns.Add(newColumn);
            SelectedColumn = newColumn;
        }

        private void DeleteColumn()
        {
            if (SelectedColumn != null)
            {
                _dataService.Columns.Remove(SelectedColumn);
            }
        }
    }
}
