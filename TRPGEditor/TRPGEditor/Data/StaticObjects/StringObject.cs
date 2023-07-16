using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPGEditor.StaticObjects
{
    // Статический объект, представляемый в виде строки.
    public class StringObject : IStaticObject
    {
        string value;

        /// <summary>
        /// Устанавливает значение в StringObject.
        /// </summary>
        /// <param name="newValue"></param>
        public void SetValue(string newValue)
        {
            value = newValue;
        }

        /// <summary>
        /// Возвращает значение в StringObject.
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            return value;
        }

    }
}
