using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPGEditor.StaticObjects
{
    // Интерфейс для общего поведения всех случайных объектов.
    // Не уверен, действительно ли он нужен.
    internal interface IStaticObject
    {
        string GetValue();
    }

}
