using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TRPGEditor.Commands;
using TRPGEditor.ViewModels;

namespace TRPGEditor.Models
{
    internal class BaseElementModel : ObservableClass
    {
        private static BaseElementModel _baseElementModel;
        public ObservableCollection<BaseElementButtonViewModel> baseElementButtonViewModels { get; }
            = new ObservableCollection<BaseElementButtonViewModel>();
        public BaseElementViewModel currentBaseView;

        private BaseElementModel(){}

        public static BaseElementModel GetInstance() 
        {
            if (_baseElementModel == null )
                _baseElementModel = new BaseElementModel();
            return _baseElementModel;
        }

        public void AddButtonAction()
        {
            baseElementButtonViewModels.Add(new BaseElementButtonViewModel());
        }

        public void SelectRadioButton(BaseElementButtonViewModel Sender)
        {
            currentBaseView = Sender.thisBaseView;
            OnPropertyChanged();
        }

    }
} 