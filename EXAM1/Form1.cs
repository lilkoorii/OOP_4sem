using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace EXAM1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime1 = new DateTime();
            DateTime dateTime2 = new DateTime();
            dateTime1 = dateTimePicker1.Value;
            DateTimeEditor editor = new DateTimeEditor();
            //if (dateTime1.Day <= 20)
            //{
                dateTime2 = dateTimePicker1.Value + DateTime.("0/10/0000 00:00:00");
            //}
            textBox1.Text = dateTime2.ToString();
            //DateTimeConverter converter = new DateTimeConverter();
            //converter.CanConvertTo("0/10/0000 00:00:00");
        }
    }
}