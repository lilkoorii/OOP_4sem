using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace Laba1
{
    public partial class CalCalculator : Form, ICalculator
    {
        int BMR;
        double IMT;
        double diffWeight;
        int minusCal;
        int dailyMinusCal;
        public delegate void Calculated(string message);
        public event Calculated Calc;

        public CalCalculator()
        {
            InitializeComponent();
            Calc += (message) =>
            {
                MessageBox.Show($"Выполнение завершено!", message);
            };
        }
        private void trackBarAge_Scroll(object sender, EventArgs e)
        {
            textBoxAge.Text = trackBarAge.Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((double.Parse(Weight.Text) < 50) || (double.Parse(Weight.Text) > 260))
            {
                MessageBox.Show("Неправильный вес!");
                Environment.Exit(1);
            }
            if ((double.Parse(Height.Text) < 50) || (double.Parse(Height.Text) > 260))
            {
                MessageBox.Show("Неправильный рост!");
                Environment.Exit(1);
            }
            try
            {
                int height = Convert.ToInt32(Height.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный рост!");
                Height.Text = "";
            }
            int count = groupBox2.Controls
                    .OfType<RadioButton>()
                    .Where(i => i.Checked)
                    .Count();
            if (count < 1)
            {
                MessageBox.Show("Выберите вашу цель!");
            }
            IMTType();
            if (radioMale.Checked)
            {
                BMR = CalcMale();
                if (radioSameWeight.Checked)
                {
                    MessageBox.Show("Вам нужно потреблять ровно " + BMR + " калорий в день, чтобы поддержать вес.");
                }
                if (radioLowerWeight.Checked)
                {
                    MessageBox.Show("Вам нужно потреблять меньше чем " + BMR + " калорий в день, чтобы похудеть.");
                    MessageBox.Show("Нужно сжигать в день " + CalcFuture() + " калорий, чтобы похудеть за указанный срок.");
                }
                if (radioHigherWeight.Checked)
                {
                    MessageBox.Show("Вам нужно потреблять больше чем " + BMR + " калорий в день, чтобы набрать вес.");
                    MessageBox.Show("Нужно съедать в день " + CalcFuture() + " калорий, чтобы набрать вес за указанный срок.");
                }
            }
            if (radioFemale.Checked)
            {
                BMR = CalcFemale();
                if (radioSameWeight.Checked)
                {
                    MessageBox.Show("Вам нужно потреблять ровно " + BMR + " калорий в день, чтобы поддержать вес.");
                }
                if (radioLowerWeight.Checked)
                {
                    MessageBox.Show("Вам нужно потреблять меньше чем " + BMR + " калорий в день, чтобы похудеть.");
                    MessageBox.Show("Нужно сжигать в день " + CalcFuture() + " калорий, чтобы похудеть за указанный срок.");
                }
                if (radioHigherWeight.Checked)
                {
                    MessageBox.Show("Вам нужно потреблять больше чем " + BMR + " калорий в день, чтобы набрать вес.");
                    MessageBox.Show("Нужно съедать в день " + CalcFuture() + " калорий, чтобы набрать вес за указанный срок.");
                }
            }
            Calc?.Invoke("Вычисления завершены");
        }
        public int CalcMale()
        {
            int res;
            res = Convert.ToInt32(88.36 + (13.4 * double.Parse(Weight.Text)) + (4.8 * double.Parse(Height.Text)) - (5.7 * trackBarAge.Value));
            return res;
        }
        public int CalcFemale()
        {
            int res;
            res = Convert.ToInt32(447.6 + (9.2 * double.Parse(Weight.Text)) + (3.1 * double.Parse(Height.Text)) - (4.3 * trackBarAge.Value));
            return res;
        }
        public double CalcIMT()
        {
            double res;
            res = double.Parse(Weight.Text)/(Math.Pow((double.Parse(Height.Text)/100), 2));
            return res;
        }
        public void IMTType()
        {
            IMT = Math.Round(CalcIMT(), 2);
            if (IMT < 18.5) { MessageBox.Show("Ваш ИМТ: " + IMT + ". Ваш вес ниже нормального, рекомендуем набрать вес!"); }
            if ((IMT >= 18.5) && (IMT < 25)) { MessageBox.Show("Ваш ИМТ: " + IMT + ". Ваш вес нормальный, изменение веса не рекомендуется."); }
            if ((IMT >= 25) && (IMT < 30)) { MessageBox.Show("Ваш ИМТ: " + IMT + ". У вас избыточный вес!"); }
            if ((IMT >= 30) && (IMT < 35)) { MessageBox.Show("Ваш ИМТ: " + IMT + ". У вас ожирение I степени!"); }
            if ((IMT >= 35) && (IMT < 40)) { MessageBox.Show("Ваш ИМТ: " + IMT + ". У вас ожирение II степени!"); }
            if (IMT > 40) { MessageBox.Show("Ваш ИМТ: " + IMT + ". У вас ожирение III степени!"); }
        }
        public int CalcFuture()
        {
            diffWeight = Math.Abs(double.Parse(FutureWeight.Text) - double.Parse(Weight.Text));
            minusCal = Convert.ToInt32(diffWeight * 7700);
            dailyMinusCal = minusCal / int.Parse(FutureTime.Text);
            return dailyMinusCal;
        }
    }

}