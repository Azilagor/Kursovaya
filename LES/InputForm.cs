

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
    public partial class InputForm : Form
    {
		float[][] data, L, Lt;
		float[] B, X;
		bool method;
		int len;
		// Объявление компонентов
		/*
            Формальные параметры:
            size - размерность матриц;
            f - метод.
        */
		public InputForm(int size, bool f)
        {
			// Объявление объектов окна
            InitializeComponent(size, f);

			// Выделение памяти
			method = f;
			data = new float[size][];
			L = new float[size][];
			Lt = new float[size][];
			B = new float[size];
			X = new float[size];
			for (int i = 0; i < size; i++)
			{
				data[i] = new float[size];
				L[i] = new float[size];
				Lt[i] = new float[size];
				B[i] = new float();
				X[i] = new float();
				for (int j = 0; j < size; j++)
				{
					data[i][j] = new float();
					L[i][j] = new float();
					Lt[i][j] = new float();
				}
			}
			len = size;
		}

		// Формирование результатов программы
		/*
            Формальные параметры:
            sender - объект, издающий события;
            e - данные событий.
            Локальные параметры:
            strval - строка введенного значения;
            res - результат;
            fz - флаг корректности матрицы;
			fval - вещественная форма введенного значения;
			valid - флаг корректности ввода.
        */
		private void btnRes_Click(object sender, EventArgs e)
        {
			string strval = "", res = "";
			bool fz = true;
			float flval = 0;
			bool valid = true;
			for (int i = 0; (i < len) && valid; i++)
			{
				for (int j = 0; (j < len) && valid; j++)
				{
					strval = textBoxVal[i][j].Text;
					strval = strval.Replace(".", ",");
					if (float.TryParse(strval, out flval))
					{
						data[i][j] = flval;
					}else
					{ valid = false; }
				}
				strval = textBoxRes[i].Text;
				strval = strval.Replace(".", ",");
				if (float.TryParse(strval, out flval))
				{
					B[i] = flval;
				}
				else
				{ valid = false; }
			}
			if (valid)
			{
				if (method)
				{

					if (LESgauss(data, B, ref X, len) == 0)
					{
						fz = false;
						MessageBox.Show("Решение этим методом невозможно\n Так как определитель равен нулю", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				else { LESholetsky(data, ref L, ref Lt, len, ref fz); if (fz) holRes(L, Lt, ref X, B, len); else MessageBox.Show("Решение этим методом невозможно\n Этим методом можно решить симметричные матрицы, у которых определитель больше нуля","Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
				if (fz)
				{
					for (int i = 0; (i < len); i++)
					{
						res += "X" + (i + 1) + ":" + X[i] + "\n";
					}
					MessageBox.Show(res, "Результат", MessageBoxButtons.OK);
				}
			}
			else { MessageBox.Show("Введите вещественное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

		// Решение СЛУ методом Гаусса
		/*
            Формальные параметры:
            A - исходная матрица коэффициентов;
			B - вектор свободных коэффициентов;
			X - вектор неизвестных коэффициентов;
			n - размерность массивов данных.
            Локальные параметры:
            max - номер строки с максимальным элементом;
			E - округление;
			k - итератор;
			ind - копия итератора;
			val - копия элемента;
        */
		int LESgauss(float[][] A, float[] B, ref float[] X, int n)
		{
			float max;
			int k, ind;
			float E = 0.00001F;
			float val = 0;
			k = 0;
			while (k < n)
			{
				// Определение максимума
				max = Math.Abs(A[k][k]);
				ind = k;
				for (int i = k + 1; i < n; i++)
				{
					if (Math.Abs(A[i][k]) > max)
					{
						max = Math.Abs(A[i][k]);
						ind = i;
					}
				}
				if (max < E)
				{
					return 0; // Решения нет
				}
				// Перегруппировка элементов
				for (int j = 0; j < n; j++)
				{
					val = A[k][j];
					A[k][j] = A[ind][j];
					A[ind][j] = val;
				}
				val = B[k];
				B[k] = B[ind];
				B[ind] = val;
				for (int i = k; i < n; i++)
				{
					val = A[i][k];
					if (Math.Abs(val) < E) continue;
					for (int j = 0; j < n; j++)
						A[i][j] = A[i][j] / val;
					B[i] = B[i] / val;
					if (i == k) continue;
					for (int j = 0; j < n; j++)
						A[i][j] = A[i][j] - A[k][j];
					B[i] = B[i] - B[k];
				}
				k++;
			}
			// Инверсия элементов
			ind = 0;
			for (k = n - 1; k >= 0; k--)
			{
				X[ind]=B[k];
				for (int i = 0; i < k; i++)
					B[i] = B[i] - A[i][k] * X[n - k - 1];
				ind++;
			}
			for (int i = 0; i < n; i++)
			{
				B[i] = X[i];
			}
			k = 0;
			for (int i = n - 1; i >= 0; i--)
			{
				X[k] = B[i];
				k++;
			}
			return 1; // Решение есть
		}

		//// Подсчет степени
		///*
  //          Формальные параметры:
  //          val - основание степени;
		//	st - показатель степени.
  //          Локальный параметр:
  //          p - результат функции.
  //      */
		//float step(float val, float st)
		//{
		//	float p = val;
		//	while (st > 1)
		//	{               // Подсчет степени
		//		p = p * val;
		//		st--;
		//	}
		//	return p;
		//}

		// Формирование матриц методом квадратных корней
		/*
            Формальные параметры:
            A - исходная матрица;
			L - сформированная матрица;
			Lt - транспонированная матрица L;
			size - размерность матриц;
			fz - флаг верного выполнения преобразований.
            Локальный параметр:
            s - сумма элементов.
        */
		void LESholetsky(float[][] A, ref float[][] L, ref float[][] Lt, int size, ref bool fz)
		{
			for(int i = 0; i < size; i++)
			{
				// Проверка симметричности матрицы
				for (int j = 0; j < size; j++)
				{
					if (A[i][j] != A[j][i])
					{
						fz = false;
					}
				}
			}
			// Формирование матрицы
			for (int i = 0; (i < size) && fz; i++)
			{
				float s = A[i][i];
				for (int k = 0; (k < i) && fz; k++)
					s -= L[i][k] * L[i][k];
				// Проверка определителя на неотрицательность
				if (s < 0)
				{
					fz = false;
				}
				L[i][i] = (float)Math.Sqrt(s);
				for (int j = i + 1; (j < size)&&fz; j++)
				{
					s = A[j][i];
					for (int k = 0; k < i; k++)
						s -= L[i][k] * L[j][k];
					L[j][i] = s / L[i][i];
				}
			}

			// Транспонирование сформированной матрицы
			for (int i = 0; (i < size)&&fz; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Lt[i][j] = L[j][i];
				}
			}

		}

		// Формирование результатов методом квадратных корней
		/*
            Формальные параметры:
			L - исходная матрица;
			Lt - транспонированная матрица L;
			X - вектор неизвестных коэффициентов;
			B - вектор свободных коэффициентов;
			n - размерность матриц/
            Локальные параметры:
            Y - промежуточный вектор результатов;
			sum - сумма элементов матрицы;
			iter - итератор.
        */
		void holRes(float[][] L, float[][] Lt, ref float[] X, float[] B, int n)
		{
			float[] Y = new float[n];
			for (int i = 0; i < n; i++)
			{
				Y[i] = new float();
			}
			float sum = 0;
			int k = 0;
			// Формирование промежуточных результатов
			for (int i = 0; i < n; i++)
			{
				sum = 0;
				
				for (int j = 0; j < i; j++)
				{
					sum = sum + (L[i][j] * Y[j]);
				}
				Y[i] = (B[i] - sum) / L[i][i];
			}
			int iter = 0;
			// Формирование результатов
			for (int i = n - 1; i >= 0; i--)
			{
				sum = 0;
				for (int j = i; j < n - 1; j++)
				{
					sum = sum + Lt[i][j + 1] * X[k];
					k--;
				}
				X[iter] =(Y[i] - sum) / Lt[i][i];
				k = iter;
				iter++;
			}
			// Перестановка элементов
			for (int i = 0; i < n; i++)
			{
				Y[i] = X[i];
			}
			for (int i = 0; i < n; i++)
			{
				X[n - i - 1] = Y[i];
			}
		}
	}
}
