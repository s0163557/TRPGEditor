using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using TRPGEditor.Commands;
using TRPGEditor.Data.Commands;
using TRPGEditor.ViewModels;

namespace TRPGEditor.Models
{
    public class Dice
    {
        string name;
        int edgeCount;

    }

    internal class DiceModel : ObservableClass, IModel
    {

    private static DiceModel _diceModel;
        public ObservableCollection<DiceButtonViewModel> DiceButtonVMs { get; }
            = new ObservableCollection<DiceButtonViewModel>();
        public DiceViewModel CurrentDiceVM;

        public List<string> DiceNames;


        private DiceModel() { }

        public static DiceModel GetInstance()
        {
            if (_diceModel == null)
                _diceModel = new DiceModel();
            return _diceModel;
        }

        public void AddButtonAction()
        {
            DiceButtonVMs.Add(new DiceButtonViewModel(this));
        }

        public void DeleteButtonAction(object Sender)
        {
            DiceButtonViewModel sender = Sender as DiceButtonViewModel;
            DiceButtonVMs.Remove(sender);
            OnPropertyChanged();
        }

        public void SelectRadioButton(object Sender)
        {
            DiceButtonViewModel sender = Sender as DiceButtonViewModel;
            CurrentDiceVM = sender.DiceVM;
            OnPropertyChanged();
        }
    }
}
