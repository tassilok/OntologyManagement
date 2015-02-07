using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;

namespace TextParser
{
    public partial class ParseLogWindow : Form
    {
        public ParseLogWindow()
        {
            InitializeComponent();

            scintilla_Log.Styles[0].BackColor = scintilla_Log.BackColor;
            scintilla_Log.Styles[0].ForeColor = scintilla_Log.ForeColor;
            scintilla_Log.Styles[0].Font = new Font(scintilla_Log.Font, FontStyle.Regular);
            scintilla_Log.Styles[1].BackColor = Color.Yellow;
            scintilla_Log.Styles[1].ForeColor = Color.Black;
            scintilla_Log.Styles[1].Font = new Font(scintilla_Log.Font,FontStyle.Bold);
        }

        public void AddLines(List<string> lines)
        {
            var start = scintilla_Log.Caret.Position;
            lines.ForEach(line =>
            {
                var range = scintilla_Log.InsertText(line);
                var length = 10;
                if (scintilla_Log.TextLength < 10)
                {
                    length = scintilla_Log.TextLength;
                }
                var rangeMark = new Range(start, start + length, scintilla_Log);
                rangeMark.SetStyle(1);
                scintilla_Log.InsertText("\r\n");
                scintilla_Log.Caret.Position = scintilla_Log.TextLength - 1;
                start = scintilla_Log.Caret.Position;
            }); 
        }

        public void ClearLog()
        {
            scintilla_Log.Text = "";
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
