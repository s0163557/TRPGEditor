using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using TRPGEditor.Commands;
using TRPGEditor.Data.Commands;
using TRPGEditor.ViewModels;

namespace TRPGEditor.Models
{

    public class Term
    {
        private long _id;
        string name = "Правило";
        List< KeyValuePair<string, string> > listNameContent = new List< KeyValuePair<string, string> >();
    }

    internal class TermModel : ObservableClass, IModel
    {
        private static TermModel _termModel;
        public ObservableCollection<TermButtonViewModel> TermButtonVMs { get; }
            = new ObservableCollection<TermButtonViewModel>();
        public ObservableCollection<TermButtonViewModel> TermVMs { get; }
            = new ObservableCollection<TermButtonViewModel>();
        public ObservableCollection<TermButtonViewModel> TermComponentVMs { get; }
            = new ObservableCollection<TermButtonViewModel>();

        public Dictionary<long, Term> DiceData = new Dictionary<long, Dice>();

        public TermViewModel CurrentTermVM; 

        private TermModel(){}

        public static TermModel GetInstance() 
        {
            if (_termModel == null )
                _termModel = new TermModel();
            return _termModel;
        }

        public void AddButtonAction()
        {
            TermButtonVMs.Add(new TermButtonViewModel(this));
        }

        public void DeleteButtonAction(int ID)
        {
            TermButtonViewModel sender = Sender as TermButtonViewModel;
            TermButtonVMs.Remove(sender);
            OnPropertyChanged();
        }

        public void SelectRadioButton(object Sender)
        {
            TermButtonViewModel sender = Sender as TermButtonViewModel;
            CurrentTermVM = sender.TermVM;
            OnPropertyChanged();
        }

    }
} 