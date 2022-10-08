using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // button click event to call isvaliddata method checks entered data is valid or not.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
                    string operator1 = txtOperator.Text;
                    decimal operand2 = Convert.ToDecimal(txtOperand2.Text);
                    decimal result = Calculate(operand1, operator1, operand2);
                    result = Math.Round(result, 4);
                    this.txtResult.Text = result.ToString();
                    txtOperand1.Focus();
                }
            }
         
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                ex.GetType().ToString() + "\n" +
                ex.StackTrace, " Exception");
            }
        }
        // is present method checks whether data is entered into the text boxes or not.
        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", " Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        // isdecimal method checks whether entered data is decimal or not
        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;

            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }

            else
            {
                MessageBox.Show(name + " must be a decimal value.", " Entry Error");
                textBox.Focus();
                return false;
            }
        }
        // isWithonrange method checks wether entered data is in giving range or not
        public bool IsWithinRange(TextBox textBox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);

            if (number < min || number > max)
            {
                MessageBox.Show(name +  " must be between " + min.ToString()

                    + " and " + max.ToString() + ".", " Entry Error");

                textBox.Focus();

                return false;
            }

            return true;
        }
        // isoperator method checks wether entered operand is in these four or any other if any other throws error message
        public bool IsOperator(TextBox textBox, string name)
        {
            if (textBox.Text != "+" && textBox.Text != "-" && textBox.Text != "/" && textBox.Text != "*")
            {
                MessageBox.Show("Please enter a valid operator in the operator text box.", " Entry Error");

                return false;
            }

            return true;
        }
        // isvaliddata method is calling all methods and verifies the data.
        public bool IsValidData()
        {
            return
            IsPresent(txtOperand1, "Operand 1") &&

            IsWithinRange(txtOperand1, "Operand 1", 0, 1000000) &&

            IsDecimal(txtOperand1, "Operand 1") &&

            IsOperator(txtOperator, "Operator") &&

            IsPresent(txtOperand2, "Operand 2") &&

            IsWithinRange(txtOperand2, "Operand 2", 0, 1000000) &&

            IsDecimal(txtOperand2, "Operand 2");
            
        }
        // calculate method calculates the data entered by user if it is valid data
        private decimal Calculate(decimal operand1, string operator1,
            decimal operand2)
        {
            decimal result = 0;
            if (operator1 == "+")
                result = operand1 + operand2;
            else if (operator1 == "-")
                result = operand1 - operand2;
            else if (operator1 == "*")
                result = operand1 * operand2;
            else if (operator1 == "/")
                result = operand1 / operand2;
            return result;
        }
        // btnexit event to close the window
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // clearresult method to clear the result text box
        private void ClearResult(object sender, EventArgs e)
        {
            this.txtResult.Text = "";
        }
    }
}