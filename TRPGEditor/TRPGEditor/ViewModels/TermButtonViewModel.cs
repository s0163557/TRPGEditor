using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TRPGEditor.Commands;
using TRPGEditor.Data.Commands;
using TRPGEditor.Models;
using TRPGEditor.Views;

namespace TRPGEditor.ViewModels
{
    internal class TermButtonViewModel : ObservableClass
    {
        public TermViewModel TermVM;
        public IModel CurrentModel;

        private RelayCommand _selectedCommand;

        public RelayCommand SelectedCommand
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

        private string _buttonContent;
        public string ButtonContent
        {
            get { return _buttonContent; }
            set
            {
                _buttonContent = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _deletedCommand;
        public RelayCommand DeletedCommand
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

        public TermButtonViewModel(IModel parentModel)
        {
            TermVM = new TermViewModel();
            ButtonContent = TermVM.ButtonContent;
            if (parentModel as TermModel != null)
                CurrentModel = TermModel.GetInstance();
            if (parentModel as DiceModel != null)
                CurrentModel = DiceModel.GetInstance();

            SelectedCommand = new RelayCommand(new Action<object>(SelectCommand));
            DeletedCommand = new RelayCommand(new Action<object>(DeleteCommand));

            TermVM.PropertyChanged += (sender, args) =>
            {
                ButtonContent = TermVM.ButtonContent;
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
