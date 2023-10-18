using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPGEditor.Commands;
using TRPGEditor.Data.Commands;
using TRPGEditor.ViewModels;

namespace TRPGEditor.Models
{
    internal class DiceElementModel : ObservableClass, IModel
    {

        private static DiceElementModel _diceElementModel;
        public ObservableCollection<DicePageButtonViewModel> DicePageButtonViewModels { get; }
            = new ObservableCollection<DicePageButtonViewModel>();
        public DiceElementViewModel currentBaseView;

        private DiceElementModel() { }

        public static DiceElementModel GetInstance()
        {
            if (_diceElementModel == null)
                _diceElementModel = new DiceElementModel();
            return _diceElementModel;
        }

        public void AddButtonAction()
        {
            DicePageButtonViewModels.Add(new DicePageButtonViewModel(this));
        }
        public void DeleteButtonAction(object Sender)
        {
            DicePageButtonViewModel sender = Sender as DicePageButtonViewModel;
            DicePageButtonViewModels.Remove(sender);
            OnPropertyChanged();
        }

        public void SelectRadioButton(object Sender)
        {
            DicePageButtonViewModel sender = Sender as DicePageButtonViewModel;
            currentBaseView = sender.thisBaseView;
            OnPropertyChanged();
        }

    }
}
