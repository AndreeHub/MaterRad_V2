using AproxiCalc.Models;
using AproxiCalc.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AproxiCalc.ViewModels
{
    public class ModelViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;

        public ObservableCollection<ColumnFloorQuantity> ColumnFloorQuantities => _dataService.ColumnFloorQuantities;
        public ObservableCollection<Column> Columns => _dataService.Columns;
        public ObservableCollection<Floor> Floors => _dataService.Floors;

        public ModelViewModel(IDataService dataService)
        {
            _dataService = dataService;
            InitializeColumnFloorQuantities();
        }

        private void InitializeColumnFloorQuantities()
        {
            _dataService.ColumnFloorQuantities.Clear();

            foreach (var column in Columns)
            {
                foreach (var floor in Floors)
                {
                    var cfq = new ColumnFloorQuantity
                    {
                        Column = column,
                        Floor = floor,
                        Quantity = 0
                    };
                    _dataService.ColumnFloorQuantities.Add(cfq);
                }
            }

            Columns.CollectionChanged += (s, e) => UpdateQuantities();
            Floors.CollectionChanged += (s, e) => UpdateQuantities();
        }

        private void UpdateQuantities()
        {
            var existingPairs = _dataService.ColumnFloorQuantities
                .Select(cfq => (cfq.Column, cfq.Floor))
                .ToList();

            var allPairs = from c in Columns
                           from f in Floors
                           select (c, f);

            var newPairs = allPairs.Except(existingPairs);

            foreach (var (column, floor) in newPairs)
            {
                _dataService.ColumnFloorQuantities.Add(new ColumnFloorQuantity
                {
                    Column = column,
                    Floor = floor,
                    Quantity = 0
                });
            }

            var removedPairs = existingPairs.Except(allPairs);

            foreach (var (column, floor) in removedPairs)
            {
                var item = _dataService.ColumnFloorQuantities
                    .FirstOrDefault(cfq => cfq.Column == column && cfq.Floor == floor);
                if (item != null)
                    _dataService.ColumnFloorQuantities.Remove(item);
            }
        }
    }
}
