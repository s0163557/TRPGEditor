using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TRPGEditor.Commands;
using TRPGEditor.Models;
using TRPGEditor.Views;

//Разберись, почему статический элемент только один добавляется.

namespace TRPGEditor.ViewModels
{
    internal class MainWindowViewModel : ObservableClass
    {

        public ObservableCollection<BaseElementButtonViewModel> baseElementButtonViewModels { get; }
            = new ObservableCollection<BaseElementButtonViewModel>();

        private BaseElementViewModel _currentBaseView;
        private BaseElementModel _baseElementModel { get; set; }

        public BaseElementViewModel CurrentBaseView
        {
            get { return _currentBaseView; }
            set 
            {
                _currentBaseView = value;
                OnPropertyChanged();
            }
        }

        private ICommand _addButtonCommand;

        public ICommand addButtonCommand
        {
            get
            {
                return _addButtonCommand;
            }
            set
            {
                _addButtonCommand = value;
            }
        }

        public MainWindowViewModel()
        {
            _baseElementModel = BaseElementModel.GetInstance();
            addButtonCommand = new RelayCommand(new Action<object>(AddButtonAction));
            //Он получает ссылку, и будет сам обновляться, когда изменится оригинал.
            baseElementButtonViewModels = _baseElementModel.baseElementButtonViewModels;

            _baseElementModel.PropertyChanged += (sender, args) =>
            {
                CurrentBaseView = _baseElementModel.currentBaseView;
            };
        }

        public void AddButtonAction(object obj)
        {
            _baseElementModel.AddButtonAction();
        }
        
    }
}
