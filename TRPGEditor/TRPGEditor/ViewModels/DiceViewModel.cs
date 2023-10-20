using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPGEditor.Commands;

namespace TRPGEditor.ViewModels
{
    internal class DiceViewModel: ObservableClass
    {
        public ObservableCollection<DiceEdgeViewModel> EdgeVMs { get; set; }
            = new ObservableCollection<DiceEdgeViewModel>();

        private string _diceName = "Кубик";
        public string DiceName
        {
            get
            {
                return _diceName;
            }
            set
            {
                _diceName = value;
                OnPropertyChanged();
            }
        }

        private int _edgeCount;
        public int EdgeCount
        {
            get
            {
                return _edgeCount;
            }
            set
            {
                _edgeCount = value;
                if (_edgeCount >= EdgeVMs.Count)
                {
                    for (int i = EdgeVMs.Count; i < _edgeCount; i++)
                        EdgeVMs.Add(new DiceEdgeViewModel(i + 1));
                }
                else
                {
                    for (int i = EdgeVMs.Count; i > _edgeCount; i--)
                        EdgeVMs.RemoveAt(i-1);
                }
                OnPropertyChanged();
            }
        }

    }
}