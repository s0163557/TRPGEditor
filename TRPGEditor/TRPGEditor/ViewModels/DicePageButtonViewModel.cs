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
    internal class DicePageButtonViewModel : ObservableClass
    {
        public DiceElementViewModel thisBaseView;
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

        public DicePageButtonViewModel(IModel parentModel)
        {
            thisBaseView = new DiceElementViewModel();
            RadioButtonContent = thisBaseView.DiceName;
            if (parentModel as BasePageModel != null)
                thisBaseModel = BasePageModel.GetInstance();
            if (parentModel as DiceElementModel != null)
                thisBaseModel = DiceElementModel.GetInstance();

            selectedCommand = new RelayCommand(new Action<object>(SelectCommand));
            deletedCommand = new RelayCommand(new Action<object>(DeleteCommand));

            thisBaseView.PropertyChanged += (sender, args) =>
            {
                RadioButtonContent = thisBaseView.DiceName;
            };

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
