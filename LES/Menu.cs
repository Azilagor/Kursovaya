/*
Программа LES
Курсовой проект по профессиональному модулю МДК.03.01 Технология разработки программного обеспечения
Разработал: Бакдаулет Алибек
Дата: 19.05.2020
Программа написана на языке C#
Задание:
  Разработка программы решения системы линейных уравнений:
  - методом Гаусса;
  - методом квадратных корней.
Используемые переменные в основной программе:
  size - размерность СЛУ;
  f - выбранный метод;
Используемые функции:
  btnIn_Click - переход в форме ввода СЛУ;
  btnRes_Click - формирование результатов программы;
  step - подсчет степени;
  LESgauss - решение СЛУ методом Гаусса;
  LESholetsky - формирование матриц методом квадратных корней;
  holRes - решение СЛУ методом квадратных корней.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LES
{
    public partial class Menu : Form
    {
        // Объявление объектов окна
        public Menu()
        {
            InitializeComponent();
        }

        // Переход к форме ввода СЛУ
        /*
            Формальные параметры:
            sender - объект, издающий события;
            e - данные событий.
            Локальные параметры:
            size - количество уравнений и коэффициентов;
            f - флаг мвыбранного метода;
            inpt - форма ввода СЛУ.
        */
        private void btnIn_Click(object sender, EventArgs e)
        {
            int size = 0;
            bool f = false;
            // Определение метода решения СЛУ
            if (radioGauss.Checked)
            {
                f = true;
            }
            // Проверка размерности
            if (int.TryParse(textBoxSize.Text, out size))
            {
                if ((size > 1) && (size <= 10))
                {
                    // Переход к форме ввода матрицы
                    InputForm inpt = new InputForm(size, f);
                    inpt.Show();
                }
                else MessageBox.Show("Размреность СЛУ должна быть в пределах от 2 до 10", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Введите целое число от 2 до 10", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
