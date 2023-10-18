using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPGEditor.Commands;

namespace TRPGEditor.ViewModels
{
    internal class DiceElementViewModel: ObservableClass
    {
        private string _DiceName = "Кубик";
        public string DiceName
        {
            get
            {
                return _DiceName;
            }
            set
            {
                _DiceName = value;
                OnPropertyChanged();
            }
        }

        private int _EdgeCount;
        public int EdgeCount
        {
            get
            {
                return _EdgeCount;
            }
            set
            {
                _EdgeCount = value;
                if (_EdgeCount >= EdgeVM.Count)
                {
                    for (int i = EdgeVM.Count; i < _EdgeCount; i++)
                        EdgeVM.Add(new EdgeViewModel(i + 1));
                }
                else
                {
                    for (int i = EdgeVM.Count; i > _EdgeCount; i--)
                        EdgeVM.RemoveAt(i-1);
                }
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EdgeViewModel> EdgeVM { get; set; }
            = new ObservableCollection<EdgeViewModel>();

    }
}