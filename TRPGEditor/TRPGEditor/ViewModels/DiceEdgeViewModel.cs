using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPGEditor.ViewModels
{
    internal class DiceEdgeViewModel
    {
        public int Id { get; set; }
        private string _Content;
        public string Content
        {
            get
            { 
                return _Content; 
            }
            set 
            {
                _Content = value; 
            }
        }

        public DiceEdgeViewModel(int _Id)
        {
            Id = _Id;
        }

    }
}
