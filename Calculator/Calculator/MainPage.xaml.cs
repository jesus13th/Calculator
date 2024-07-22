using System;

using NCalc;

using Xamarin.Forms;

namespace Calculator {
    public partial class MainPage : ContentPage {
        private bool mustDelete = false;

        public MainPage() {
            InitializeComponent();
        }

        private void showResult_Clicked(object sender, EventArgs e) {
            string expression = currentOperation.Text.Replace("x", "*").Replace("÷", "/");
            double res = CalculateResult(expression);
            result.Text = $"= {res}";
            mustDelete = true;
        }
        private double CalculateResult(string expression) {
            Expression e = new Expression(expression);
            return e.ToLambda<double>()();
        }

        private void addValue_Clicked(object sender, EventArgs e) {
            if (mustDelete) {
                currentOperation.Text = string.Empty;
                result.Text = "0";
                mustDelete = false;
            }
            string data = ((Button)sender).BindingContext as string;
            currentOperation.Text = currentOperation.Text == "0" ? data : currentOperation.Text + data;
        }

        private void clear_Clicked(object sender, EventArgs e) {
            currentOperation.Text = "0";
            result.Text = string.Empty;
        }

        private void backspace_Clicked(object sender, EventArgs e) {
            string t = currentOperation.Text;
            mustDelete = false;
            if (t.Length > 0) {
                currentOperation.Text = t.Substring(0, t.Length - 1);
            }
        }
    }
}
