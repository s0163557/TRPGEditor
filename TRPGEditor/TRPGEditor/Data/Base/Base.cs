using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPGEditor.RandomObjects;

namespace TRPGEditor.Base
{
    internal class SimpleBase
    {
        string description;
        List<string> staticObjectsList = new List<string>();
        List<IRandomObject> randomObjectsList = new List<IRandomObject>();
    }
}
