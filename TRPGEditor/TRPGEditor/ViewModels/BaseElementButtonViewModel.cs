using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPGEditor.Commands;
using TRPGEditor.Views;

namespace TRPGEditor.ViewModels
{
    internal class BaseElementButtonViewModel
    {
        public BaseElementViewModel thisBaseView;

        public BaseElementButtonViewModel()
        { 
            thisBaseView = new BaseElementViewModel();    
        }

    }
}
