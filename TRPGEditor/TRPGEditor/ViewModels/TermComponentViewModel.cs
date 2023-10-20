using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TRPGEditor.Commands;
using TRPGEditor.Models;

namespace TRPGEditor.ViewModels
{
    internal class TermComponentViewModel
    {
        private string _name;
        public string Name
        { 
            get
            { 
                return _name;
            }
            set
            { 
                _name = value;
            }
        }
        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            { 
                _content = value; 
            }
        }

        public TermComponentViewModel()
        {
        }

    }
}
