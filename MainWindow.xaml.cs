using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace PIT_PR_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flag = true;
        Regex onlyNumbers = new Regex(@"^-?\d+$");

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Solution_1()
        { // (f(x) + y)^2 - /f(x)y, xy > 0
            double answer = 0, x = Convert.ToDouble(X_TextBox.Text), y = Convert.ToDouble(Y_TextBox.Text);

            if (RB_1.IsChecked == true) // sh(x)
            {
                answer = Math.Pow(Math.Sinh(x) + y, 2) - Math.Pow(Math.Sinh(x) * y, -2); // ответ 1
            }
            else if (RB_2.IsChecked == true) // x^2
            {
                answer = Math.Pow(Math.Pow(x, 2) + y, 2) - Math.Pow(Math.Pow(x, 2) * y, -2); // ответ 2
            }
            else if (RB_3.IsChecked == true) // e^x
            {
                answer = Math.Pow(Math.Exp(x) + y, 2) - Math.Pow(Math.Exp(x) * y, -2); // ответ 3
            }

            Solve_TextBox.Text = Math.Round(answer, 3).ToString();
        }

        public void Solution_2()
        { // (f(x) + y)^2 + / |f(x)y|, xy< 0
            double answer = 0, x = Convert.ToDouble(X_TextBox.Text), y = Convert.ToDouble(Y_TextBox.Text);

            if (RB_1.IsChecked == true) // sh(x)
            {
                answer = Math.Pow(Math.Sinh(x) + y, 2) + Math.Pow( Math.Abs(Math.Sinh(x) * y), -2); // ответ 1
            }
            else if (RB_2.IsChecked == true) // x^2
            {
                answer = Math.Pow(Math.Pow(x, 2) + y, 2) + Math.Pow(Math.Abs(Math.Pow(x, 2) * y), -2); // ответ 2
            }
            else if (RB_3.IsChecked == true) // e^x
            {
                answer = Math.Pow(Math.Exp(x) + y, 2) + Math.Pow(Math.Abs(Math.Exp(x) * y), -2); // ответ 3
            }

            Solve_TextBox.Text = Math.Round(answer, 3).ToString();
        }

        public void Solution_3()
        { // (f(x) + y)^2 + 1, xy = 0
            double answer = 0, x = Convert.ToDouble(X_TextBox.Text), y = Convert.ToDouble(Y_TextBox.Text);

            if (RB_1.IsChecked == true) // sh(x)
            {
                answer = Math.Pow(Math.Sinh(x) + y, 2) + 1; // ответ 1
            }
            else if (RB_2.IsChecked == true) // x^2
            {
                answer = Math.Pow(Math.Pow(x, 2) + y, 2) + 1; // ответ 2
            }
            else if (RB_3.IsChecked == true) // e^x
            {
                answer = Math.Pow(Math.Exp(x) + y, 2) + 1; // ответ 3
            }

            Solve_TextBox.Text = Math.Round(answer, 3).ToString();
        }

        private void Solve_Button_Click(object sender, RoutedEventArgs e)
        {
            Solve_TextBox.Text = "";
            X_TextBox.IsEnabled = true;
            Y_TextBox.IsEnabled = true;
            flag = true;

            if (X_TextBox.Text == "" || Y_TextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибочка");
                flag = false;
            }
            else if (!onlyNumbers.IsMatch(X_TextBox.Text) || !onlyNumbers.IsMatch(Y_TextBox.Text))
            {
                MessageBox.Show("Неккоректный ввод в полях! Пожалуйста, напишите правильно", "Ошибочка");
                flag = false;
            }
            else if (RB_1.IsChecked == false && RB_2.IsChecked == false && RB_3.IsChecked == false)
            {
                MessageBox.Show("Выберите математическую функцию!", "Ошибочка");
                flag = false;
            }

            if (flag == true)
            {
                if (Convert.ToInt32(X_TextBox.Text) * Convert.ToInt32(Y_TextBox.Text) > 0) Solution_1();
                else if (Convert.ToInt32(X_TextBox.Text) * Convert.ToInt32(Y_TextBox.Text) < 0) Solution_2();
                else if (Convert.ToInt32(X_TextBox.Text) * Convert.ToInt32(Y_TextBox.Text) == 0) Solution_3();

                X_TextBox.IsEnabled = false;
                Y_TextBox.IsEnabled = false;
            }
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            X_TextBox.Text = "";
            Y_TextBox.Text = "";
            Solve_TextBox.Text = "";

            RB_1.IsChecked = false;
            RB_2.IsChecked = false;
            RB_3.IsChecked = false;

            X_TextBox.IsEnabled = true;
            Y_TextBox.IsEnabled = true;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            var exitConfirmation = MessageBox.Show("Вы действительно хотите выйти?  :(", "Пока-пока", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (exitConfirmation == MessageBoxResult.No) e.Cancel = true; // Отменяем закрытие окна
        }
    }
}