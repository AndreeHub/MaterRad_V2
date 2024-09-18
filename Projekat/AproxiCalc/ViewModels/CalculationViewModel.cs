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
    public class CalculationViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;
        private double _appliedForce;

        public ObservableCollection<FloorCalculation> FloorCalculations { get; }

        public double AppliedForce
        {
            get => _appliedForce;
            set { _appliedForce = value; OnPropertyChanged(nameof(AppliedForce)); CalculateDisplacements(); }
        }

        public CalculationViewModel(IDataService dataService)
        {
            _dataService = dataService;
            FloorCalculations = new ObservableCollection<FloorCalculation>();
            CalculateStiffnesses();
        }

        private void CalculateStiffnesses()
        {
            FloorCalculations.Clear();
            var floors = _dataService.Floors.OrderByDescending(f => f.Height).ToList();
            foreach (var floor in floors)
            {
                var floorCalc = new FloorCalculation { Floor = floor };
                floorCalc.Stiffness = CalculateFloorStiffness(floor);
                FloorCalculations.Add(floorCalc);
            }
            CalculateDisplacements();
        }

        private double CalculateFloorStiffness(Floor floor)
        {
            double totalStiffness = 0;

            var columnsOnFloor = _dataService.ColumnFloorQuantities
                .Where(cfq => cfq.Floor == floor && cfq.Quantity > 0);

            foreach (var cfq in columnsOnFloor)
            {
                double EI = cfq.Column.ModulusE * cfq.Column.MomentOfInertia;
                double L = floor.Height;
                double stiffness = cfq.Quantity * CalculateColumnStiffness(cfq.Column.Type, EI, L);
                totalStiffness += stiffness;
            }
            return totalStiffness;
        }

        private double CalculateColumnStiffness(ColumnType type, double EI, double L)
        {
            switch (type)
            {
                case ColumnType.RigidRigid:
                    return (12 * EI) / (L * L * L);
                case ColumnType.PinnedRigid:
                    return (3 * EI) / (L * L * L);
                case ColumnType.PinnedPinned:
                    return 0;
                default:
                    return 0;
            }
        }

        private void CalculateDisplacements()
        {
            // Implement displacement calculations based on stiffness and applied force
            // This will follow the method outlined in the paper
        }
    }

    public class FloorCalculation : BaseViewModel
    {
        public Floor Floor { get; set; }
        public double Stiffness { get; set; }
        public double Displacement { get; set; }
    }
}
