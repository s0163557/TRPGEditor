using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TRPGEditor.Commands;
using TRPGEditor.Data.Commands;
using TRPGEditor.ViewModels;

namespace TRPGEditor.Models
{
    internal class TermModel : ObservableClass, IModel
    {
        private static TermModel _termModel;
        public ObservableCollection<TermButtonViewModel> TermButtonVMs { get; }
            = new ObservableCollection<TermButtonViewModel>();
        public ObservableCollection<TermButtonViewModel> TermVMs { get; }
            = new ObservableCollection<TermButtonViewModel>();
        public ObservableCollection<TermButtonViewModel> TermComponentVMs { get; }
            = new ObservableCollection<TermButtonViewModel>();

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

        public void DeleteButtonAction(object Sender)
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