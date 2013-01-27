using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZCZ_Calculator
{
    public partial class ZCZ_Calculator : Form
    {
        double temp;//记录上一次的结果
        string did;//记录上一次的运算
        bool didflag;//最近一次操作是否为运算操作
        public ZCZ_Calculator()
        {
            InitializeComponent();
            Initialization();
        }
        private void Initialization()
        {//初始化
            temp = 0;
            did = "Equal";
            didflag = false;
            this.textBoxThis.Text = "0";
            this.textBoxTemp.Text = "";
        }

        private void buttonNumbers_Click(object sender, EventArgs e)
        {//按下除0以外的任何数字
            if (didflag)
            {
                this.textBoxThis.Text = "";
                if (did.Equals("Equal"))
                {
                    this.textBoxTemp.Text = "";
                }
            }
            if (this.textBoxThis.Text.Equals("0"))
            {
                this.textBoxThis.Text = "";
            }
            this.textBoxThis.Text += sender.ToString().Substring(35);
            didflag = false;
        }

        private void button0_Click(object sender, EventArgs e)
        {//按下0
            if (sender.ToString().Substring(35).Equals("0") && this.textBoxThis.Text.Equals("0"))
            {
                return;
            }
            this.textBoxThis.Text += "0";
            didflag = false;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {//复位
            Initialization();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {//清零
            this.textBoxThis.Text = "0";
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (this.textBoxThis.TextLength.Equals(1))
            {
                this.textBoxThis.Text = "0";
                return;
            }
            this.textBoxThis.Text = this.textBoxThis.Text.Substring(0, this.textBoxThis.TextLength - 1);
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {//小数点
            if (did.Equals("Equal") && didflag.Equals(true))
            {
                this.textBoxThis.Text = "0";
            }
            this.textBoxThis.Text += ".";
            didflag = false;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {//切换正负
            if (this.textBoxThis.Text.Equals("0"))
            {
                return;
            }
            if (this.textBoxThis.Text.Substring(0, 1).Equals("-"))
            {
                this.textBoxThis.Text = this.textBoxThis.Text.Substring(1, this.textBoxThis.TextLength - 1);
                return;
            }
            this.textBoxThis.Text = "-" + this.textBoxThis.Text;
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {//进行“运算”
            didflag = true;
            done();
            string todo = sender.ToString().Substring(35);
            if (todo.Equals("="))
            {
                this.textBoxTemp.Text = "结果=";
                did = "Equal";
                this.textBoxThis.Text = temp.ToString();
                return;
            }
            if (todo.Equals("+"))
            {
                this.textBoxTemp.Text += todo;
                did = "Plus";
                this.textBoxThis.Text = "";
                this.textBoxThis.Text = "0";
                return;
            }
            if (todo.Equals("-"))
            {
                this.textBoxTemp.Text += todo;
                did = "Subtract";
                this.textBoxThis.Text = "";
                this.textBoxThis.Text = "0";
                return;
            }
            if (todo.Equals("*"))
            {
                this.textBoxTemp.Text += todo;
                did = "Times";
                this.textBoxThis.Text = "";
                this.textBoxThis.Text = "0";
                return;
            }
            if (todo.Equals("/"))
            {
                this.textBoxTemp.Text += todo;
                did = "Divide";
                this.textBoxThis.Text = "";
                this.textBoxThis.Text = "0";
                return;
            }
            if (todo.Equals("%"))
            {
                this.textBoxTemp.Text += todo;
                did = "Mod";
                this.textBoxThis.Text = "";
                this.textBoxThis.Text = "0";
                return;
            }
            if (todo.Equals("√"))
            {
                this.textBoxTemp.Text = "结果=";
                temp = Math.Sqrt(temp);
                did = "Equal";
                this.textBoxThis.Text = temp.ToString();
                return;
            }
            if (todo.Equals("1/x"))
            {
                this.textBoxTemp.Text = "结果=";
                temp = 1 / temp;
                did = "Equal";
                this.textBoxThis.Text = temp.ToString();
                return;
            }
        }

        private void done()
        {//完成上一次运算
            if (did.Equals("Equal"))
            {
                temp = System.Convert.ToDouble(this.textBoxThis.Text);
                this.textBoxTemp.Text = temp.ToString();
                return;
            }
            if (did.Equals("Plus"))
            {
                temp += System.Convert.ToDouble(this.textBoxThis.Text);
                this.textBoxTemp.Text = temp.ToString();
                return;
            }
            if (did.Equals("Subtract"))
            {
                temp -= System.Convert.ToDouble(this.textBoxThis.Text);
                this.textBoxTemp.Text = temp.ToString();
                return;
            }
            if (did.Equals("Times"))
            {
                temp *= System.Convert.ToDouble(this.textBoxThis.Text);
                this.textBoxTemp.Text = temp.ToString();
                return;
            }
            if (did.Equals("Divide"))
            {
                temp /= System.Convert.ToDouble(this.textBoxThis.Text);
                this.textBoxTemp.Text = temp.ToString();
                return;
            }
            if (did.Equals("Mod"))
            {
                temp %= System.Convert.ToDouble(this.textBoxThis.Text);
                this.textBoxTemp.Text = temp.ToString();
                return;
            }
        }

        private void textBoxThis_TextChanged(object sender, EventArgs e)
        {//文本框值改变的时候
            double _temp;
            if (double.TryParse(this.textBoxThis.Text, out _temp).Equals(false))
            {//如果文本框里的不是合法数字
                this.buttonPlus.Enabled = false;
                this.buttonSubtract.Enabled = false;
                this.buttonTimes.Enabled = false;
                this.buttonDivide.Enabled = false;
                this.buttonSqrt.Enabled = false;
                this.buttonMod.Enabled = false;
                this.buttonMultiplicativeInverse.Enabled = false;
                this.buttonEqual.Enabled = false;
                return;
            }
            else 
            {
                this.buttonPlus.Enabled = true;
                this.buttonSubtract.Enabled = true;
                this.buttonTimes.Enabled = true;
                this.buttonDivide.Enabled = true;
                this.buttonSqrt.Enabled = true;
                this.buttonMod.Enabled = true;
                this.buttonMultiplicativeInverse.Enabled = true;
                this.buttonEqual.Enabled = true;
            }

            if (textBoxThis.Text.IndexOf('.').Equals(-1))
            {//处理小数点
                this.buttonDot.Enabled = true;
            }
            else 
            {
                if (didflag.Equals(true))
                {
                    this.buttonDot.Enabled = true;
                }
                else 
                {
                    this.buttonDot.Enabled = false;
                }
            }

            if ((did.Equals("Divide") || did.Equals("Mod")) && this.textBoxThis.Text.Equals("0"))
            {//处理0做除数
                this.buttonPlus.Enabled = false;
                this.buttonSubtract.Enabled = false;
                this.buttonTimes.Enabled = false;
                this.buttonDivide.Enabled = false;
                this.buttonSqrt.Enabled = false;
                this.buttonMod.Enabled = false;
                this.buttonMultiplicativeInverse.Enabled = false;
                this.buttonEqual.Enabled = false;
            }
            else
            {
                this.buttonPlus.Enabled = true;
                this.buttonSubtract.Enabled = true;
                this.buttonTimes.Enabled = true;
                this.buttonDivide.Enabled = true;
                this.buttonSqrt.Enabled = true;
                this.buttonMod.Enabled = true;
                this.buttonMultiplicativeInverse.Enabled = true;
                this.buttonEqual.Enabled = true;
            }

            //进行预运算
            if (this.textBoxThis.Text.Equals(""))
            {
                return;
            }
            double temp_ = pre_do(_temp);
            if (temp_.Equals(0) || this.buttonDivide.Enabled.Equals(false))
            {
                this.buttonMultiplicativeInverse.Enabled = false;
            }
            else
            {
                this.buttonMultiplicativeInverse.Enabled = true;
            }

            if ((_temp < 0)||(temp_<0))
            {//处理开方
                this.buttonSqrt.Enabled = false;
            }
            else
            {
                this.buttonSqrt.Enabled = true;
            }
        }
        private double pre_do(double _temp)
        {//预运算
            if (did.Equals("Equal"))
            {
                return _temp;
            }
            if (did.Equals("Plus"))
            {
                return temp + _temp;
            }
            if (did.Equals("Subtract"))
            {
                return temp - _temp;
            }
            if (did.Equals("Times"))
            {
                return temp * _temp;
            }
            if (did.Equals("Divide"))
            {
                return temp / _temp;
            }
            if (did.Equals("Mod"))
            {
                return temp % _temp;
            }
            else
            {
                throw new Exception("内部错误：内存泄漏。");
            }
        }
    }
}
