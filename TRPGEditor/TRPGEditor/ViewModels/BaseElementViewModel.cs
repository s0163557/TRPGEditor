using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TRPGEditor.Commands;

namespace TRPGEditor.ViewModels
{
    internal class BaseElementViewModel
    {
        public ObservableCollection<StaticElementViewModel> staticElementButtonViewModels { get; }
            = new ObservableCollection<StaticElementViewModel>();

        private ICommand _addStaticButtonCommand;

        public ICommand addStaticButtonCommand
        {
            get
            {
                return _addStaticButtonCommand;
            }
            set
            {
                _addStaticButtonCommand = value;
            }
        }

        public BaseElementViewModel()
        {
            addStaticButtonCommand = new RelayCommand(new Action<object>(AddStaticButtonAction));
        }

        public void AddStaticButtonAction(object obj)
        {
            staticElementButtonViewModels.Add(new StaticElementViewModel());
        }
    }
}
