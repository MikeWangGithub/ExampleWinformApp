using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseClassLibrary.Forms;
using ExampleWinformApp.Threading;

namespace ExampleWinformApp
{
    public partial class MainForm : BaseForm<int>
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region parameter functions

        public RandomNumberParameter GetRandomNumberParameter()
        {
            RandomNumberParameter param = new RandomNumberParameter();
            param.Min = 1;
            param.Max = 100;
            return param;
        }
        #endregion parameter functions

        #region Button Status
        public void SetRandomNumberButtonStatus(bool flag)
        {
            //throw new NotImplementedException();
            this.button1.Enabled = flag;
        }
        #endregion Button Status 

        private async void Button1_Click(object sender, EventArgs e)
        {
            StartThreadParameter st = new StartThreadParameter();
            st.SetFullThreadName("ExampleWinformApp.Threading.GetRandomNumber");
            st.SetGetParamgeterFunctionName("GetRandomNumberParameter");
            st.SetButtonStatusFuncionName("SetRandomNumberButtonStatus");
            int x = await RunThread(st);
            this.richTextBox1.AppendText(x.ToString() + "\r\n");
        }
    }
}
