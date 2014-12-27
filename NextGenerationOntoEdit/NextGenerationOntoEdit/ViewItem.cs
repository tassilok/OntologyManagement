using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NextGenerationOntoEdit
{
    public class ViewItem
    {
        public string Relation { get; set; }
        public string IdItem { get; set; }
        public string SubType { get; set; }
        public string NameItem { get; set; }
        public Label LabelOfItem { get; set; }
        public TextBox TextBoxOfItem { get; set; }
        public ComboBox ComboBoxOfItem { get; set; }
    }
}
