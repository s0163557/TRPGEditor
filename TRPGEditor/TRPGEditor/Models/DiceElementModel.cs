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
        public ObservableCollection<BaseElementButtonViewModel> baseElementButtonViewModels { get; }
            = new ObservableCollection<BaseElementButtonViewModel>();
        public BaseElementViewModel currentBaseView;

        private DiceElementModel() { }

        public static DiceElementModel GetInstance()
        {
            if (_diceElementModel == null)
                _diceElementModel = new DiceElementModel();
            return _diceElementModel;
        }

        public void AddButtonAction()
        {
            baseElementButtonViewModels.Add(new BaseElementButtonViewModel(this));
        }
        public void DeleteButtonAction(object Sender)
        {
            BaseElementButtonViewModel sender = Sender as BaseElementButtonViewModel;
            baseElementButtonViewModels.Remove(sender);
            OnPropertyChanged();
        }

        public void SelectRadioButton(object Sender)
        {
            BaseElementButtonViewModel sender = Sender as BaseElementButtonViewModel;
            currentBaseView = sender.thisBaseView;
            OnPropertyChanged();
        }

    }
}
