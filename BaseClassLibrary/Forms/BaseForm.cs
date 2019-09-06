using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using BaseClassLibrary.Threading;
using BaseClassLibrary.Tools;
using System.ComponentModel;
using System.Reflection;

namespace BaseClassLibrary.Forms
{
    // [TypeDescriptionProvider(typeof(AbstractCommunicatorProvider))]
    public class BaseForm<T> :System.Windows.Forms.Form 
    {
        #region  variable
        /// <summary>
        /// MulitThread variable
        /// </summary>
        private Task<T> task;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        #endregion

        #region Threading functions
        /// <summary>
        /// Cancel Thread.
        /// </summary>
        public void CancelTask()
        {
            if (tokenSource != null)
            {
                if (tokenSource.IsCancellationRequested == false)
                {
                    tokenSource.Cancel();
                }
            }
        }
        /// <summary>
        /// Set tokenSource for Start a new Thread
        /// </summary>
        /// <returns></returns>
        public CancellationTokenSource StartNewTask()
        {
            tokenSource = new CancellationTokenSource();
            return tokenSource;
        }
        /// <summary>
        /// Execute a thread
        /// </summary>
        /// <param name="FullThreadName"></param>
        /// <returns></returns>
        public async Task<T> RunThread(StartThreadParameter startThread)
        {
            T rtn = default(T);
            try
            {
                //Set buttons enabled to be disenable
                this.SetButtonStatus(startThread.ButtonStatusFuncionName, false);

                CancellationTokenSource tokenSource = StartNewTask();
                //Get threadparameter
                ICloneable param = GetParameter(startThread.GetParamgeterFunctionName);
                //Get context for to execute thread
                ThreadContext<T> threadContext = new ThreadContext<T>(startThread.FullThreadName, tokenSource, param);
                //Thread  running
                task = threadContext.ThreadRun();
                // wait thread is over
                rtn = await task;

            }
            catch (Exception ex)
            {
                //throw new Exception(this.GetType().ToString() + "RunThread Function",ex);
                LoggerHelper.Error(this.GetType().ToString() + " - " + startThread.FullThreadName, ex);
            }
            finally
            {
                //Set buttons enabled from disabled to enabled.
                this.SetButtonStatus(startThread.ButtonStatusFuncionName, true);
                
            }
            return rtn;
        }
        #endregion threading

        public ICloneable GetParameter(string GetParameterFunctionName)
        {
            //throw new InvalidOperationException("Need to be override by childClass");
            MethodInfo mInfo = this.GetType().GetMethod(GetParameterFunctionName);
            return (ICloneable)mInfo.Invoke(this, null);
        }

        #region Button Status controll
        public void SetButtonStatus(string SetButtonStatusFunctionName, bool flag) {
            //throw new InvalidOperationException("Need to be override by childClass");
            MethodInfo mInfo = this.GetType().GetMethod(SetButtonStatusFunctionName);
            mInfo.Invoke(this, new object[] { flag });
        }
        #endregion Button Status controll

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }


}
