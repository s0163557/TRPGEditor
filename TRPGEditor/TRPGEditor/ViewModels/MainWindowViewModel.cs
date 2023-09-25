using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TRPGEditor.Commands;
using TRPGEditor.Models;
using TRPGEditor.Views;

//Разберись, почему статический элемент только один добавляется.

namespace TRPGEditor.ViewModels
{
    internal class MainWindowViewModel : ObservableClass
    {

        public RelayCommand BaseViewCommand { get; set; }
        public RelayCommand DiceViewCommand { get; set; }

        private BaseElementModel _baseElementModel { get; set; }

        public BasePageViewModel BaseVM { get; set; }
        public DiceViewModel DiceVM { get; set; }

        private object _viewModel = null;

        public object CurrentView
        {
            get { return _viewModel; }
            set { _viewModel = value;
                OnPropertyChanged();
            }
        }
        
        public MainWindowViewModel() 
        {
            BaseVM = new BasePageViewModel();
            DiceVM = new DiceViewModel();
            CurrentView = BaseVM;
            BaseViewCommand = new RelayCommand(o => 
            {
                CurrentView = BaseVM;
            });
            DiceViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiceVM;
            });
            _baseElementModel = BaseElementModel.GetInstance();
        }

    }
}
