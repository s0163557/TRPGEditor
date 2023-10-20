using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TRPGEditor.Commands;
using TRPGEditor.Data.Commands;
using TRPGEditor.Models;

namespace TRPGEditor.ViewModels
{
    internal class DiceButtonViewModel : ObservableClass
    {
        public DiceViewModel DiceVM;
        public IModel CurrentModel;

        private ICommand _selectedCommand;

        public ICommand SelectedCommand
        {
            get
            {
                return _selectedCommand;
            }
            set
            {
                _selectedCommand = value;
            }
        }

        private string _ButtonContent;
        public string ButtonContent
        {
            get 
            { 
                return _ButtonContent; 
            }
            set
            {
                _ButtonContent = value;
                OnPropertyChanged();
            }
        }

        private ICommand _deletedCommand;
        public ICommand DeletedCommand
        {
            get
            {
                return _deletedCommand;
            }
            set
            {
                _deletedCommand = value;
            }
        }

        public DiceButtonViewModel(IModel parentModel)
        {
            DiceVM = new DiceViewModel();
            ButtonContent = DiceVM.DiceName;
            if (parentModel as TermModel != null)
                CurrentModel = TermModel.GetInstance();
            if (parentModel as DiceModel != null)
                CurrentModel = DiceModel.GetInstance();

            SelectedCommand = new RelayCommand(new Action<object>(SelectCommand));
            DeletedCommand = new RelayCommand(new Action<object>(DeleteCommand));

            DiceVM.PropertyChanged += (sender, args) =>
            {
                ButtonContent = DiceVM.DiceName;
            };
        }

        public void SelectCommand(object obj)
        {
            CurrentModel.SelectRadioButton(this);
        }

        public void DeleteCommand(object obj)
        {
            CurrentModel.DeleteButtonAction(this);
        }
    }
}
