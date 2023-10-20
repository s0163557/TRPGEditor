using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TRPGEditor.Commands;
using TRPGEditor.Models;

namespace TRPGEditor.ViewModels
{
    internal class TermsViewModel : ObservableClass
    {
        public ObservableCollection<TermButtonViewModel> TermButtonVMs { get; }
           = new ObservableCollection<TermButtonViewModel>();

        private TermViewModel _currentTermVM;
        private TermModel _termModel;

        public TermViewModel CurrentTermVM
        {
            get 
            { 
                return _currentTermVM; 
            }
            set
            {
                _currentTermVM = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addButtonCommand;

        public RelayCommand AddButtonCommand
        {
            get
            {
                return _addButtonCommand;
            }
            set
            {
                _addButtonCommand = value;
            }
        }

        public TermsViewModel()
        {
            _termModel = TermModel.GetInstance();
            AddButtonCommand = new RelayCommand(new Action<object>(AddButtonAction));
            //Он получает ссылку, и будет сам обновляться, когда изменится оригинал.
            TermButtonVMs = _termModel.TermButtonVMs;

            _termModel.PropertyChanged += (sender, args) =>
            {
                CurrentTermVM = _termModel.CurrentTermVM;
            };
        }

        public void AddButtonAction(object obj)
        {
            _termModel.AddButtonAction();
        }

    }
}