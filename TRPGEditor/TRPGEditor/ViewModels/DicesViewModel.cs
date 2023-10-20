using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TRPGEditor.Commands;
using TRPGEditor.Models;

namespace TRPGEditor.ViewModels
{
    internal class DicesViewModel : ObservableClass
    {
        public ObservableCollection<DiceButtonViewModel> DiceButtonVMs { get; }
            = new ObservableCollection<DiceButtonViewModel>();
        
        private DiceViewModel _currentDiceVM;
        private DiceModel _diceModel;

        public DiceViewModel CurrentDiceVM
        {
            get 
            { 
                return _currentDiceVM; 
            }
            set
            {
                _currentDiceVM = value;
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

        public DicesViewModel()
        {
            _diceModel = DiceModel.GetInstance();
            AddButtonCommand = new RelayCommand(new Action<object>(AddButtonAction));
            //Он получает ссылку, и будет сам обновляться, когда изменится оригинал.
            DiceButtonVMs = _diceModel.DiceButtonVMs;

            _diceModel.PropertyChanged += (sender, args) =>
            {
                CurrentDiceVM = _diceModel.CurrentDiceVM;
            };
        }

        public void AddButtonAction(object obj)
        {
            _diceModel.AddButtonAction();
        }

    }
}
