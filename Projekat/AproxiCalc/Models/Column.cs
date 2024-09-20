using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace AproxiCalc.Models
{
    public class Column : INotifyPropertyChanged
    {
        private string _name;
        private ColumnType _type;
        private double _modulusE;
        private double _momentOfInertia;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public ColumnType Type
        {
            get => _type;
            set { _type = value; OnPropertyChanged(nameof(Type)); }
        }

        public double ModulusE
        {
            get => _modulusE;
            set { _modulusE = value; OnPropertyChanged(nameof(ModulusE)); }
        }

        public double MomentOfInertia
        {
            get => _momentOfInertia;
            set { _momentOfInertia = value; OnPropertyChanged(nameof(MomentOfInertia)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public enum ColumnType
    {
        [Display(Name = "Rigid-Rigid")]
        RigidRigid,

        [Display(Name = "Pinned-Rigid")]
        PinnedRigid,

        [Display(Name = "Pinned-Pinned")]
        PinnedPinned
    }
}
