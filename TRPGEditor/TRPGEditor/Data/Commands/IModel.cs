using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPGEditor.ViewModels;

namespace TRPGEditor.Data.Commands
{
    internal interface IModel
    {
        //По хорошему, тут должен быть не object а какой-нибудь родительский интерфейс всех ViewModel
        //но я пока не уверен, что там должно быть, поэтому отложу до поры до времени
        void SelectRadioButton(object Sender);
        void DeleteButtonAction(object Sender);
    }
}
