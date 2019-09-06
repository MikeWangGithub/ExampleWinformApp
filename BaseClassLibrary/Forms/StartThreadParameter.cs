using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassLibrary.Forms
{
    public class StartThreadParameter
    {
        public string _FullThreadName;
        public string FullThreadName { get { return _FullThreadName; } }

        public void SetFullThreadName(string value)
        {
            _FullThreadName = value;
        }
        public string _GetParamgeterFunctionName;
        public string GetParamgeterFunctionName { get { return _GetParamgeterFunctionName; } }
        public void SetGetParamgeterFunctionName(string value)
        {
            _GetParamgeterFunctionName = value;
        }

        public string _ButtonStatusFuncionName;
        public string ButtonStatusFuncionName { get { return _ButtonStatusFuncionName; } }
        public void SetButtonStatusFuncionName(string value)
        {
            _ButtonStatusFuncionName = value;
        }


    }
}
