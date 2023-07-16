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
using TRPGEditor.Views;

//Сделай переключение между RadioButton и добавь прокрутку для всех панелек.

namespace TRPGEditor.ViewModels
{
    internal class MainWindowViewModel : ObservableClass
    {

        public ObservableCollection<BaseElementButtonViewModel> baseElementButtonViewModels { get; }
            = new ObservableCollection<BaseElementButtonViewModel>();

        private BaseElementViewModel _currentBaseView;

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
            addButtonCommand = new RelayCommand(new Action<object>(AddButtonAction));
        }

        //Поидее иметь тут такую кнопку - неправильно. Если делать чистым MVVM, то надо, чтобы была модель, в которой будут находиться данные
        //и в которой будет находиться функционал работы с данными. Тут должен быть только делегат в модель.
        public void AddButtonAction(object obj)
        {
            baseElementButtonViewModels.Add(new BaseElementButtonViewModel());
            CurrentBaseView = baseElementButtonViewModels[baseElementButtonViewModels.Count - 1].thisBaseView;
        }
    }
}
