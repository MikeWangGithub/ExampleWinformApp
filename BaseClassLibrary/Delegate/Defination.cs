﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClassLibrary.Delegate
{
    public class Defination
    {
        public delegate void SafeCallDelegateLog(string text);
        public delegate void SafeCallDelegate();
        public delegate void InvokeLogWithColor(string text, System.Drawing.Color color);
        public delegate void SetbuttonStatus(bool flag);
    }
}
