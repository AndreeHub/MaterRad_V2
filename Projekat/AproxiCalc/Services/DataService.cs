using AproxiCalc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AproxiCalc.Services
{
    public class DataService : IDataService
    {
        public ObservableCollection<Column> Columns { get; private set; }
        public ObservableCollection<Floor> Floors { get; private set; }
        public ObservableCollection<ColumnFloorQuantity> ColumnFloorQuantities { get; private set; }

        public DataService()
        {
            Columns = new ObservableCollection<Column>();
            Floors = new ObservableCollection<Floor>();
            ColumnFloorQuantities = new ObservableCollection<ColumnFloorQuantity>();
        }
    }
}
