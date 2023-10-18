using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TRPGEditor.Commands;
using TRPGEditor.Models;

namespace TRPGEditor.ViewModels
{
    internal class DicePageViewModel : ObservableClass
    {
        public ObservableCollection<DicePageButtonViewModel> DicePageButtonViewModel { get; }
            = new ObservableCollection<DicePageButtonViewModel>();

        private DiceElementViewModel _currentDiceView;
        private DiceElementModel _diceElementModel { get; set; }

        public DiceElementViewModel CurrentBaseView
        {
            get { return _currentDiceView; }
            set
            {
                _currentDiceView = value;
                OnPropertyChanged();
            }
        }

        private ICommand _addButtonCommand;
        public ICommand addButtonCommand
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

        public DicePageViewModel()
        {
            _diceElementModel = DiceElementModel.GetInstance();
            addButtonCommand = new RelayCommand(new Action<object>(AddButtonAction));
            //Он получает ссылку, и будет сам обновляться, когда изменится оригинал.
            DicePageButtonViewModel = _diceElementModel.DicePageButtonViewModels;

            _diceElementModel.PropertyChanged += (sender, args) =>
            {
                CurrentBaseView = _diceElementModel.currentBaseView;
            };
        }

        public void AddButtonAction(object obj)
        {
            _diceElementModel.AddButtonAction();
        }

    }
}
