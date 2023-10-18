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
    internal class BasePageModel : ObservableClass, IModel
    {
        private static BasePageModel _basePageModel;
        public ObservableCollection<BaseElementButtonViewModel> baseElementButtonViewModels { get; }
            = new ObservableCollection<BaseElementButtonViewModel>();
        public BaseElementViewModel currentBaseView; 

        private BasePageModel(){}

        public static BasePageModel GetInstance() 
        {
            if (_basePageModel == null )
                _basePageModel = new BasePageModel();
            return _basePageModel;
        }

        public void AddButtonAction()
        {
            baseElementButtonViewModels.Add(new BaseElementButtonViewModel(this));
        }

        public void DeleteButtonAction(object Sender)
        {
            BaseElementButtonViewModel sender = Sender as BaseElementButtonViewModel;
            baseElementButtonViewModels.Remove(sender);
            OnPropertyChanged();
        }

        public void SelectRadioButton(object Sender)
        {
            BaseElementButtonViewModel sender = Sender as BaseElementButtonViewModel;
            currentBaseView = sender.thisBaseView;
            OnPropertyChanged();
        }

    }
} 