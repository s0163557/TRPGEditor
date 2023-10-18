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
    internal class BaseElementViewModel : ObservableClass
    {
        public ObservableCollection<StaticElementViewModel> staticElementButtonViewModels { get; }
            = new ObservableCollection<StaticElementViewModel>();

        private ICommand _addStaticButtonCommand;
        

        private string _radioButtonContent = "Правило";
        public string RadioButtonContent
        {
            get { return _radioButtonContent; }
            set
            {
                _radioButtonContent = value;
                OnPropertyChanged();
            }
        }

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

        private ICommand _addTextChangeListener;
        public ICommand addTextChangeListener
        {
            get
            {
                return _addTextChangeListener;
            }
            set
            {
                _addTextChangeListener = value;
            }
        }

        public BaseElementViewModel()
        {
            addStaticButtonCommand = new RelayCommand(new Action<object>(AddStaticButtonAction));
            OnPropertyChanged();
        }

        public void AddStaticButtonAction(object obj)
        {
            staticElementButtonViewModels.Add(new StaticElementViewModel());
        }
    }
}
