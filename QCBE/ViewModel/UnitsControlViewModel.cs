﻿using CQBE.Common.Types;
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
            Units = new ObservableCollection<Unit>();
        }

        public Unit SelectedItemValue { get; set; }

        //public ObservableCollection<Unit> Units { set; get; }

        /// <summary>
        /// The <see cref="Units" /> property's name.
        /// </summary>
        public const string UnitsPropertyName = "Units";

        private ObservableCollection<Unit> _units;

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
                        UnitResult result = UnitsService.xAdd(new Unit() { xName = Metric, xNameFt = Feet }, Units);
                        if (UnitResult.UnitsAlreadyExist == result)
                        {
                            DialogService.ShowError("Unit Name already exist in list.", "Dublicate Unit Name", "Ok", null);
                            return;
                        }

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
                        else if (SelectedItemValue.xName == Metric && SelectedItemValue.xNameFt == Feet)
                        {
                            DialogService.ShowError("You have not updated the value.", "No Updated happend.", "Ok", null);
                        }
                        else
                        {
                            UnitResult result = UnitsService.xUpDate(SelectedItemValue, new Unit() { xNameFt = Feet, xName = Metric }, Units);
                            if (result == UnitResult.UnitsAlreadyExist)
                            {
                                DialogService.ShowError("Unit Name already exist in list.", "Dublicate Unit Name", "Ok", null);
                            }
                        }



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
                        if (SelectedItemValue == null)
                        {
                            DialogService.ShowError("Please Select the Units for the updated", "No Item Selected", "Ok", null);
                        }
                        else
                        {
                            UnitsService.xDelete(SelectedItemValue, Units);
                        }

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
                     UnitResult   result =   UnitsService.xMoveUp(SelectedItemValue, Units);

                        if (result == UnitResult.UnitAtTopPosition)
                        {
                            DialogService.ShowError("Unit is alreday at top position.", "Unit at top Position.", "Ok", null);
                        }
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
                        UnitResult result = UnitsService.xMoveDown(SelectedItemValue, Units);

                        if (result == UnitResult.UnitAtBottomPosition)
                        {
                            DialogService.ShowError("Unit is alreday at bottom position.", "Unit at bottom Position.", "Ok", null);
                        }

                    }));
            }
        }
    }
}
