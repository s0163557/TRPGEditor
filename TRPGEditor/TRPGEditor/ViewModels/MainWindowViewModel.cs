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

        private TermModel _baseElementModel { get; set; }

        public TermsViewModel BaseVM { get; set; }
        public DicesViewModel DiceVM { get; set; }

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
            BaseVM = new TermsViewModel();
            DiceVM = new DicesViewModel();
            CurrentView = BaseVM;
            BaseViewCommand = new RelayCommand(o => 
            {
                CurrentView = BaseVM;
                OnPropertyChanged();
            });
            DiceViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiceVM;
                OnPropertyChanged();
            });
            _baseElementModel = TermModel.GetInstance();
        }

    }
}
