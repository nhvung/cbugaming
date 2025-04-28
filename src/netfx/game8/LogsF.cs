using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game8
{
    public partial class LogsF : Form
    {
        public List<string> LogLines { get; set; }
        readonly DelegateProcess _dlg = new DelegateProcess();

        public LogsF()
        {
            InitializeComponent();
            LogLines = new List<string>();

            Shown += LogsF_Shown;
            FormClosing += LogsF_FormClosing;
            
        }

        private void LogsF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void LogsF_Shown(object sender, EventArgs e)
        {
            try
            {
                _dlg.SetText(rtxt_logs, "");
                if (LogLines?.Count > 0)
                {
                    _dlg.Execute(rtxt_logs, delegate {
                        rtxt_logs.Lines = LogLines.ToArray();
                    });
                }
            }
            catch
            {
            }
            
        }

        void _AppendLog(string log)
        {
            LogLines.Add(log);
        }

        public void AddErrorLog(string log)
        {
            _AppendLog(log);
        }
    }
}
