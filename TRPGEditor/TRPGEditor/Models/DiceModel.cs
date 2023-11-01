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
        private long _id;
        string name = "Кубик";
        int edgeCount = 0;
        List<string> edgeContent = new List<string>();

        public Dice(long id) 
        {
            _id = id;
        }

    }

    internal class DiceModel : ObservableClass, IModel
    { 
        private static DiceModel _diceModel;
        //Тут будут храниться ссылки на вьюмодльки, за которыми мы будем подглядывать.
        public ObservableCollection<DiceButtonViewModel> DiceButtonVMs
            = new ObservableCollection<DiceButtonViewModel>();

        public ObservableCollection<DiceViewModel> DiceVMs { get; }
            = new ObservableCollection<DiceViewModel>();

        public DiceViewModel CurrentDiceVM;

        private long _newDiceID = 0;
        public Dictionary<long, Dice> DiceData = new Dictionary<long, Dice>();

        private DiceModel() { }

        public static DiceModel GetInstance()
        {
            if (_diceModel == null)
                _diceModel = new DiceModel();
            return _diceModel;
        }

        public void AddButtonAction()
        {
            DiceData.Add(_newDiceID, new Dice(_newDiceID));
            DiceButtonVMs.Add(new DiceButtonViewModel(_diceModel, _newDiceID));
            DiceVMs.Add(new DiceButtonViewModel(_diceModel, _newDiceID));
            _newDiceID++;
        }

        public void AddEdgeAction()
        {
            DiceData.Add(_newDiceID, new Dice(_newDiceID));
            DiceButtonVMs.Add(new DiceButtonViewModel(_diceModel, _newDiceID));
            _newDiceID++;
        }

        public void DeleteButtonAction(int ID)
        {
            DiceData.Remove(ID);
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
