﻿using System;
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
using System.Windows.Shapes;

namespace PW13
{
    /// <summary>
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public PasswordWindow()
        {
            InitializeComponent();            
        }
        bool _enter;//Проверка на закрытие окна при успешном вводе
        //P.S.Используется для задания bool _closeWithoutMessage - закрытие программы без подтверждения
        //посредством закрытия окна авторизации или отмены (другое сообщение задается для авторизации при выходе, чтобы не было повторений)
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordLine.Password == "123")
            {
                _enter = true;
                Close();
            }
            else
            {
                MessageBox.Show("Неправильно введен пароль, повторите попытку снова", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                PasswordLine.Focus();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!_enter)//Проверка на успешное закрытие последством правильного ввода пароля
            {
                MainWindow._closeWithoutMessage = true;
                Owner.Close();
            }
        }
        /// <summary>
        /// Используется для закрытия программы(если требуется в соответствии с условием) и окна авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_enter)
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите закрыть окно авторизации и выйти из программы?", "Закрытие программы", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) e.Cancel = false;
                else e.Cancel = true;                
            }
        }

        private void PasswordLine_Loaded(object sender, RoutedEventArgs e)
        {
            PasswordLine.Focus();
        }
    }
}
