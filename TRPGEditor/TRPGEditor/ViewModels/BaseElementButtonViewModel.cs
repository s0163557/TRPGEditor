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
    internal class BaseElementButtonViewModel : ObservableClass
    {
        public BaseElementViewModel thisBaseView;
        public IModel thisBaseModel;

        private ICommand _selectedCommand;

        public ICommand selectedCommand
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

        private string _radioButtonContent;
        public string RadioButtonContent
        {
            get { return _radioButtonContent; }
            set
            {
                _radioButtonContent = value;
                OnPropertyChanged();
            }
        }

        private ICommand _deletedCommand;
        public ICommand deletedCommand
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

        public BaseElementButtonViewModel(IModel parentModel)
        { 
            thisBaseView = new BaseElementViewModel();
            RadioButtonContent = thisBaseView.RadioButtonContent;
            if (parentModel as BaseElementModel != null)
                thisBaseModel = BaseElementModel.GetInstance();
            if (parentModel as DiceElementModel != null)
                thisBaseModel = DiceElementModel.GetInstance();

            selectedCommand = new RelayCommand(new Action<object>(SelectCommand));
            deletedCommand = new RelayCommand(new Action<object>(DeleteCommand));
        }

        public void SelectCommand(object obj)
        {
            thisBaseModel.SelectRadioButton(this);
        }

        public void DeleteCommand(object obj)
        {
            thisBaseModel.DeleteButtonAction(this);
        }

    }
}
