using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Задача_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader streamReader = new StreamReader("C:\\задача3.txt"); //читаем из файла
            while (!streamReader.EndOfStream) //пока переменная не равна конечному значению
            {
                listBox1.Items.Add(streamReader.ReadLine() + "\r\n"); //выводим числа в ListBox1
            }
            streamReader.Close(); //закрываем чтение
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int s = Convert.ToInt32(textBox2.Text); //макс места на диске
            int n = Convert.ToInt32(textBox1.Text); //кол-во пользователей
            int summa = 0; //для подсчета размера файлов
            int max = 0; //макс число пользователей
            int[] file = new int[n + 1]; //чтобы потом перебирать
            string Text; //для чтения из файла
            int razmermax; //максимальный размер имеющегося файла
            if (s <= 10000) //условие, чтобы пользователь не превышал допустимый размер
            {
                if (n <= 1000) //условие, чтобы пользователь не превышал допустимый размер
                {
                    StreamReader sr = new StreamReader("C:\\задача3.txt"); //читаем из файла
                    Text = sr.ReadLine(); //присваиваем текстовой переменной значения из файла
                    while (Text != null) //пока переменная не равна конечному значению
                    {
                        for (int i = 1; i < file.Length; i++) //запускаем цикл для заполнения массива
                        {
                            file[i] = Convert.ToInt32(sr.ReadLine()); //заполняем массив
                        }
                        Text = sr.ReadLine(); //читаем следующую переменную
                    }
                    Hip(file); //активируем метод

                    for (int i = 1; i < n; i++) //запускаем цикл для подсчета макс кол-ва пользователей
                    {
                        if (summa + file[i] <= s) //если сумма размеров файла + размер нового файла < места на диске
                        {
                            summa += file[i]; //к имеющейся сумме прибавляется новое значение
                            max++; //прибавляем пользователя
                        }
                    }
                    razmermax = max; //присваиваем переменной максимальное кол-во пользователей
                    for (int i = max; i < n; i++) //запускаем цикл для выполнения второй части задания
                    {
                        if ((summa - razmermax) + file[i] <= s) //если размер файлов - макс. кл-во пользователей + размер файла следующего пользователя < места диска
                        {
                            summa = summa - razmermax + file[i]; //из имеющейся суммы размеров вычитаем макс. кол-во пользователей + размер файла следующего пользователя
                            razmermax = file[i]; //переменной присваиваем значение максимального размера имеющегося файла с учетом максимально возможного кол-ва пользователей
                        }
                    }
                    textBox3.Text = max.ToString(); //выводим результат
                    textBox4.Text = razmermax.ToString(); //выводим результат
                }
                else MessageBox.Show("Значение превышает критерии возможностей диска!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); //окно с ошибкой
            }
            else MessageBox.Show("Значение превышает критерии возможностей диска!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);  //окно с ошибкой
        }
        private static void Hip(int[] m) //пузырьковый метод
        {
            for (int i = 1; i < m.Length; i++) //запуск цикла по длине массива
            {
                for (int j = 1; j < m.Length - 1; j++) //запуск цикла, не включающего последний элемент, чтобы избежать ошибки программы
                {
                    if (m[j] > m[j + 1]) //если начальный элемент больше следующего
                    {
                        int r = m[j + 1]; //переменной присваивается наименьшее значение
                        m[j + 1] = m[j]; //переменная, которая больше начальной, принимает ее значение
                        m[j] = r; //начальная переменная берет наименьшее значение
                    }
                }
            }
        }
    }
}
