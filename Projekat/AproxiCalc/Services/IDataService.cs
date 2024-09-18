using AproxiCalc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AproxiCalc.Services
{
    public interface IDataService
    {
        ObservableCollection<Column> Columns { get; }
        ObservableCollection<Floor> Floors { get; }
        ObservableCollection<ColumnFloorQuantity> ColumnFloorQuantities { get; }
    }
}
