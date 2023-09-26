using System;
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
    internal class BaseElementModel : ObservableClass, IModel
    {
        private static BaseElementModel _baseElementModel;
        public ObservableCollection<BaseElementButtonViewModel> baseElementButtonViewModels { get; }
            = new ObservableCollection<BaseElementButtonViewModel>();
        public BaseElementViewModel currentBaseView;

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

        private BaseElementModel(){}

        public static BaseElementModel GetInstance() 
        {
            if (_baseElementModel == null )
                _baseElementModel = new BaseElementModel();
            return _baseElementModel;
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