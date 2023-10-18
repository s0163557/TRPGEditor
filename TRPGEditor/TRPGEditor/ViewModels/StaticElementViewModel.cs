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
    internal class StaticElementViewModel
    {
        private BasePageModel _baseElementModel { get; set; }
        private string _name;
        public string name
        { 
            get
            { return _name; }
            set
            { _name = value;}
        }
        private string _content;
        public string content
        {
            get
            { return _content; }
            set
            { _content = value; }
        }

        public StaticElementViewModel()
        {
            _baseElementModel = BasePageModel.GetInstance();
        }

    }
}
