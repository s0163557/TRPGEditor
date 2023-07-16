using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPGEditor.Models
{
    internal class BaseElementModel
    {
        private static BaseElementModel _baseElementModel;
        private BaseElementModel() 
        {}

        public static BaseElementModel GetInstance() 
        {
            if (_baseElementModel == null )
                _baseElementModel = new BaseElementModel();
            return _baseElementModel;
        }



    }
} 