using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPGEditor.RandomObjects
{
    // Интерфейс для общего поведения всех случайных объектов.
    // Если они вообще ещё будут.
    internal interface IRandomObject
    {
        string GetRandomValue();
    }
}
