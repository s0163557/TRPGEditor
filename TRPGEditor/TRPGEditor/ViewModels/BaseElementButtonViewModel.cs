using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TRPGEditor.Commands;
using TRPGEditor.Models;
using TRPGEditor.Views;

namespace TRPGEditor.ViewModels
{
    internal class BaseElementButtonViewModel
    {
        public BaseElementViewModel thisBaseView;
        public BaseElementModel thisBaseModel;

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

        public BaseElementButtonViewModel()
        { 
            thisBaseView = new BaseElementViewModel();
            thisBaseModel = BaseElementModel.GetInstance();

            selectedCommand = new RelayCommand(new Action<object>(SelectCommand));
        }

        public void SelectCommand(object obj)
        {
            thisBaseModel.SelectRadioButton(this);
            
        }

    }
}
