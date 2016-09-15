using CQBE.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCBE.ViewModel
{
    public class UnitsControlViewModel : BaseViewModel, INotifyPropertyChanged
    {
       

        public UnitsControlViewModel()
        {
            

            //Units.Add(new Unit() { Feet = "Dummy1", Metric = @"C:\dummy1", Unit = new List<Units> { new Units() { Metric = "M1", Feet = "F@" }, new Units() { Metric = "M2", Feet = "F2" } } });
            //Units.Add(new Unit { Feet = "Dummy2", Metric = @"C:\dummy2" });
            //Units.Add(new Unit { Feet = "Dummy3", Metric = @"C:\dummy3" });
        }



        public Unit SelectedItemValue { get; set; }

        //public ObservableCollection<Unit> Units { set; get; }

        /// <summary>
            /// The <see cref="Units" /> property's name.
            /// </summary>
        public const string UnitsPropertyName = "Units";

        private ObservableCollection<Unit> _units ;

        /// <summary>
        /// Sets and gets the Units property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Unit> Units
        {
            get
            {
                return _units;
            }

            set
            {

                if (_units == value)
                {
                    return;
                }
                _units = value;
                RaisePropertyChanged(UnitsPropertyName);
            }
        }
            


        

        /// <summary>
        /// The <see cref="Metric" /> property's name.
        /// </summary>
        public const string MetricPropertyName = "Metric";

        private string _metric = string.Empty;

        /// <summary>
        /// Sets and gets the Metric property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Metric
        {
            get
            {
                return _metric;
            }

            set
            {
                if (_metric == value)
                {
                    return;
                }

                _metric = value;
                RaisePropertyChanged(() => Metric);
            }
        }



        /// <summary>
        /// The <see cref="Feet"/> property's name.
        /// </summary>
        public const string FeetPropertyName = "Feet";

        private string _feet = string.Empty;

        /// <summary>
        /// Sets and gets the Feet property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Feet
        {
            get
            {
                return _feet;
            }

            set
            {
                if (_feet == value)
                {
                    return;
                }

                _feet = value;
                RaisePropertyChanged(FeetPropertyName);
            }
        }


       

        private RelayCommand _add;

        /// <summary>
        /// Gets the Add.
        /// </summary>
        public RelayCommand Add
        {
            get
            {
                return _add
                    ?? (_add = new RelayCommand(
                    () =>
                    {
                        UnitsService.xAdd(new Unit() { xName = Metric, xNameFt = Feet });
                        Units = new ObservableCollection<Unit>(UnitsService.GetUnitList());
                        Metric = string.Empty;
                        Feet = string.Empty;
                    }));
            }
        }

        private RelayCommand _update;

        /// <summary>
        /// Gets the Update.
        /// </summary>
        public RelayCommand Update
        {
            get
            {
                return _update
                    ?? (_update = new RelayCommand(
                    () =>
                    {
                        if (SelectedItemValue == null)
                        {
                            DialogService.ShowError("Please Select the Units for the updated", "No Item Selected", "Ok", null);
                        }
                        else
                        {
                            UnitsService.xUpDate(SelectedItemValue);
                        }

                        Units = new ObservableCollection<Unit>(UnitsService.GetUnitList());

                    }));
            }
        }

        private RelayCommand _delete;

        /// <summary>
        /// Gets the Delete.
        /// </summary>
        public RelayCommand Delete
        {
            get
            {
                return _delete
                    ?? (_delete = new RelayCommand(
                    () =>
                    {
                        UnitsService.xDelete(SelectedItemValue.xId);
                        Units = new ObservableCollection<Unit>(UnitsService.GetUnitList());
                    }));
            }
        }

        private RelayCommand _up;

        /// <summary>
        /// Gets the Up.
        /// </summary>
        public RelayCommand Up
        {
            get
            {
                return _up
                    ?? (_up = new RelayCommand(
                    () =>
                    {
                        UnitsService.UpOrDown(SelectedItemValue.xId, false);
                        Units = new ObservableCollection<Unit>(UnitsService.GetUnitList());
                    }));
            }
        }

        private RelayCommand _down;

        /// <summary>
        /// Gets the Down.
        /// </summary>
        public RelayCommand Down
        {
            get
            {
                return _down
                    ?? (_down = new RelayCommand(
                    () =>
                    {
                        UnitsService.UpOrDown(SelectedItemValue.xId, true);
                        Units = new ObservableCollection<Unit>(UnitsService.GetUnitList());
                    }));
            }
        }
    }
}
