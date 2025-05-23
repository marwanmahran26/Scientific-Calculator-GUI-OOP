using System.Diagnostics.Eventing.Reader;
using System; 

namespace Calculator_oop_GUI
{
    public partial class Calculator : Form
    {
        double num1, num2;
        string operation;
        bool opPressed;

        public Calculator()
        {
            opPressed = false;
            InitializeComponent();
        }
        void Numberpressed(object x, EventArgs y)
        {
            textBox1.Text = textBox1.Text + (x as Button).Text;
        }
        void operations(object x, EventArgs y)
        {
            if (opPressed == false)
            {
                opPressed = true;
                try
                {
                    num1 = double.Parse(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("please enter a valid number 8)");
                    textBox1.Text = "";
                    return;
                }
                operation = (x as Button).Text;

                if (operation == "×") operation = "*";
                if (operation == "÷") operation = "/";

                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("You already entered one :)");
            }
        }
        void negative(object x, EventArgs y) 
        {
            try
            {
                string tmp = textBox1.Text;
                double num = double.Parse(tmp);
                num = num * -1;
                textBox1.Text = num.ToString("F4");
            }
            catch
            {
                MessageBox.Show("Please enter a valid number 8) ");
                textBox1.Text = "";
            }
        }
        void dot(object x, EventArgs y)
        {
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text = textBox1.Text + ".";
            }
            else
            {
                MessageBox.Show("You're really trying to put 2 dots :O");
            }
        }
        void abs(object x, EventArgs e)
        {
            try
            {
                string tmp = textBox1.Text;
                double num = double.Parse(tmp);
                num = Math.Abs(num);
                textBox1.Text = num.ToString("F4");
            }
            catch
            {
                MessageBox.Show("Please enter a valid number 8)");
                textBox1.Text = "";
            }
        }
        void squareRoot(object x, EventArgs e)
        {
            try
            {
                string tmp = textBox1.Text;
                double num = double.Parse(tmp);
                if (num < 0)
                {
                    MessageBox.Show("Cannot make square root to -ve number :D");
                    textBox1.Text = "";
                    return;
                }
                num = Math.Sqrt(num);
                textBox1.Text = num.ToString("F4");
            }
            catch
            {
                MessageBox.Show("Please enter a valid number -_-");
                textBox1.Text = "";
            }

        }
        void oneOverNum(object x, EventArgs e)
        {
            try
            {
                string tmp = textBox1.Text;
                double num = double.Parse(tmp);
                if (num == 0)
                {
                    MessageBox.Show("Cannot divide by zero :D ");
                    textBox1.Text = "";
                    return;
                }
                num = 1 / num;
                textBox1.Text = num.ToString("F4");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number 8)");
                textBox1.Text = "";
            }


        }
        void powertwo(object x, EventArgs e)
        {
            try
            {
                string tmp = textBox1.Text;
                double num = double.Parse(tmp);
                num = Math.Pow(num, 2);
                textBox1.Text = num.ToString("F4");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number 8)");
                textBox1.Text = "";
            }
        }

        void PressEqual(object x, EventArgs y)
        {

            opPressed = false;

            try
            {
                num2 = double.Parse(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number in calculator pad :)");
                textBox1.Text = "";
                return;
            }

            if (string.IsNullOrEmpty(operation))
            {
                MessageBox.Show("You didn't enter an operation :)");
                return;
            }

            try
            {
                if (operation == "+")
                {
                    num2 = num1 + num2;
                }
                else if (operation == "*")
                {
                    num2 = num1 * num2;
                }
                else if (operation == "/")
                {
                    if (num2 == 0)
                    {
                        MessageBox.Show("Cannot divide by zero :(");
                        textBox1.Text = "";
                        return;
                    }
                    num2 = num1 / num2;
                }
                else
                {
                    num2 = num1 - num2;
                }

                textBox1.Text = num2.ToString("F4");
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred: " + e.Message);
                textBox1.Text = "";
                return;
            }

            num1 = num2;
        }

        void Sinbuttom(object he, EventArgs ha)
        {
            try
            {
                double angle = double.Parse(textBox1.Text);
                double result = Math.Sin(angle * Math.PI / 180);
                textBox1.Text = result.ToString("F4");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number -_-");
                textBox1.Text = "";
            }
        }
        void Cosbuttom(object he, EventArgs ha)
        {
            try
            {
                double angle = double.Parse(textBox1.Text);
                double result = Math.Cos(angle * Math.PI / 180);
                textBox1.Text = result.ToString("F4");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number -_-");
                textBox1.Text = "";
            }
        }

        void Tanbuttom(object he, EventArgs ha)
        {
            try
            {
                double angle = double.Parse(textBox1.Text);
                if (angle % 180 == 90)
                {
                    MessageBox.Show("tan(" + angle + "°) is undefined (infinite)");
                    textBox1.Clear();
                    return;
                }
                double result = Math.Tan(angle * Math.PI / 180);
                textBox1.Text = result.ToString("F4");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number -_-");
                textBox1.Clear();
            }
        }

        void SineInverse(object he, EventArgs ha)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                if (num < -1 || num > 1)
                {
                    MessageBox.Show("Input out of range for arcsin (must be between -1 and 1)");
                    textBox1.Clear();
                    return;
                }
                double result = Math.Asin(num) * 180 / Math.PI;
                textBox1.Text = result.ToString("F4");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number -_-");
                textBox1.Clear();
            }
        }

        void cosineInverse(object he, EventArgs ha)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                if (num < -1 || num > 1)
                {
                    MessageBox.Show("Input out of range for arccos (must be between -1 and 1)");
                    textBox1.Clear();
                    return;
                }
                double result = Math.Acos(num) * 180 / Math.PI;
                textBox1.Text = result.ToString("F4");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number -_-");
                textBox1.Clear();
            }
        }

        void tanInverse(object he, EventArgs ha)
        {
            try
            {
                double num = double.Parse(textBox1.Text);
                double result = Math.Atan(num) * 180 / Math.PI;
                textBox1.Text = result.ToString("F4");
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid number -_-");
                textBox1.Clear();
            }
        }

        void PiButtom(object he, EventArgs ha)
        {
            textBox1.Text = Math.PI.ToString("F4");
        }

        void clearAll(object x, EventArgs y)
        {
            textBox1.Clear();
            num1 = 0;
            num2 = 0;
            operation = "";
            opPressed = false;
        }
        void clearInput(object x, EventArgs y)
        {
            textBox1.Clear();
        }
        void darkmode(object x, EventArgs y)
        {
            if (checkBox1.Checked)
            {
                this.BackColor = Color.Black;
                textBox1.BackColor = Color.Black;
                textBox1.ForeColor = Color.White;
                checkBox1.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
                checkBox1.ForeColor = Color.Black;
            }
        }

    }
}