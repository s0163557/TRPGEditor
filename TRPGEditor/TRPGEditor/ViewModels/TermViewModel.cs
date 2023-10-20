using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TRPGEditor.Commands;

namespace TRPGEditor.ViewModels
{
    internal class TermViewModel : ObservableClass
    {
        public ObservableCollection<TermComponentViewModel> TermComponentVMs { get; }
            = new ObservableCollection<TermComponentViewModel>();

        private RelayCommand _addTermComponentCommand;
        
        private string _buttonContent = "Правило";
        public string ButtonContent
        {
            get { return _buttonContent; }
            set
            {
                _buttonContent = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddTermComponentCommand
        {
            get
            {
                return _addTermComponentCommand;
            }
            set
            {
                _addTermComponentCommand = value;
            }
        }

        public TermViewModel()
        {
            AddTermComponentCommand = new RelayCommand(new Action<object>(AddTermComponentAction));
            OnPropertyChanged();
        }

        public void AddTermComponentAction(object obj)
        {
            TermComponentVMs.Add(new TermComponentViewModel());
        }
    }
}
