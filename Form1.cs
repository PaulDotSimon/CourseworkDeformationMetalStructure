using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace KP_Simonenko.V54
{
    public partial class Form1 : Form
    {

            private static double
            b_Ширина_СплБалки = 75,
            h_Высота_СплБалки = 120,
            l_Длина_Балки = 3500,
            B_Ширина_ПолБалки = 75,
            H_Высота_ПолБалки = 120,
            b_Ширина_Отверстия = 60,
            h_Высота_Отверстия = 30,
            P_Сила = 10,
            q_Расп_Нагрузка = 20,
            q1_min_НеравРасп_Нагрузка = 12,
            q1_max_НеравРасп_Нагрузка = 22,
            Е_Модуль_упругости = 100000,
            G_Модуль_сдвига = 35000,
            К_Пуассона = 0.44,
            Плотность = 7550,
            L1 = 1550,
            L2 = 570,
            L3 = 800;

            private static double
            Коэф_P = 2,
            Коэф_q = 2,
            Коэф_q1_max = 2,
            Коэф_q1_min = 2;

            private static double
            P_Нач = 0.1,
            P_Кон = 100,
            P_Нач1 = 0.1,
            P_Кон1 = 100,
            P_Нач2 = 0.1,
            P_Кон2 = 100;

            private static double 
            Коэф_Отв = 0.8,
            Коэф_При = 0.1,
            Кэф_Сокр = 100;

        private void comboBox25_TextChanged(object sender, EventArgs e)
        {
            bool check = true;
            check &= double.TryParse(comboBox25.Text, out P_Нач);
            if (!check)
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void comboBox26_TextChanged(object sender, EventArgs e)
        {
            bool check = true;
            check &= double.TryParse(comboBox26.Text, out P_Кон);
            if (!check)
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void comboBox27_TextChanged(object sender, EventArgs e)
        {
            bool check = true;
            check &= double.TryParse(comboBox27.Text, out P_Нач1);
            if (!check)
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void comboBox28_TextChanged(object sender, EventArgs e)
        {
            bool check = true;
            check &= double.TryParse(comboBox28.Text, out P_Кон1);
            if (!check)
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void comboBox29_TextChanged(object sender, EventArgs e)
        {
            bool check = true;
            check &= double.TryParse(comboBox29.Text, out P_Нач2);
            if (!check)
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void comboBox30_TextChanged(object sender, EventArgs e)
        {
            bool check = true;
            check &= double.TryParse(comboBox30.Text, out P_Кон2);
            if (!check)
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = comboBox4.Text;
            textBox4.Text = comboBox5.Text;
            textBox5.Text = comboBox11.Text;
            textBox6.Text = comboBox6.Text;
            textBox10.Text = comboBox4.Text;
            textBox9.Text = comboBox5.Text;
            textBox8.Text = comboBox11.Text;
            textBox7.Text = comboBox6.Text;

            bool check = true;
            check &= double.TryParse(comboBox1.Text, out b_Ширина_СплБалки);
            check &= double.TryParse(comboBox2.Text, out h_Высота_СплБалки);
            check &= double.TryParse(comboBox3.Text, out l_Длина_Балки);
            check &= double.TryParse(comboBox18.Text, out b_Ширина_Отверстия);
            check &= double.TryParse(comboBox19.Text, out h_Высота_Отверстия);
            check &= double.TryParse(comboBox4.Text, out P_Сила);
            check &= double.TryParse(comboBox5.Text, out q_Расп_Нагрузка);
            check &= double.TryParse(comboBox11.Text, out q1_max_НеравРасп_Нагрузка);
            check &= double.TryParse(comboBox6.Text, out q1_min_НеравРасп_Нагрузка);
            check &= double.TryParse(comboBox7.Text, out Е_Модуль_упругости);
            check &= double.TryParse(comboBox8.Text, out G_Модуль_сдвига);
            check &= double.TryParse(comboBox9.Text, out К_Пуассона);
            check &= double.TryParse(comboBox10.Text, out Плотность);
            check &= double.TryParse(comboBox15.Text, out L1);
            check &= double.TryParse(comboBox16.Text, out L2);
            check &= double.TryParse(comboBox17.Text, out L3);
            

            if (!check)
            {
                MessageBox.Show("Введите корректные значения");
            }

            if ((L1+L2+L3)> l_Длина_Балки)
            {
                MessageBox.Show("Выбранные L1, L2 и L3 Больше чем l - Вся длина, впроверьте введённые значения ");
            }

            if (b_Ширина_Отверстия> b_Ширина_СплБалки | h_Высота_СплБалки< h_Высота_Отверстия*3)
            {
                MessageBox.Show("Введите корректные значения для ширины и высоты отверстий");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool check = true;
            check &= double.TryParse(comboBox12.Text, out Коэф_P);
            check &= double.TryParse(comboBox13.Text, out Коэф_q);
            check &= double.TryParse(comboBox14.Text, out Коэф_q1_max);
            check &= double.TryParse(comboBox20.Text, out Коэф_q1_min);

            if (!check)
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool check = true;
            check &= double.TryParse(comboBox24.Text, out Коэф_P);
            check &= double.TryParse(comboBox23.Text, out Коэф_q);
            check &= double.TryParse(comboBox22.Text, out Коэф_q1_max);
            check &= double.TryParse(comboBox21.Text, out Коэф_q1_min);

            if (!check)
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            L1 = L1 / 1000;
            L2 = L2 / 1000;
            L3 = L3 / 1000;
            l_Длина_Балки = l_Длина_Балки / 1000;
            double Ra = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки-L1) + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * (l_Длина_Балки - ((L1+L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;
            double Rb = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * ((L1+L2+L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка * L3 * ((L1+L2+L3) - (1 / 2) * L3)) / l_Длина_Балки;
            textBox1.Text = Convert.ToString(Ra);
            textBox2.Text = Convert.ToString(Rb);
            zedGraphControl1.GraphPane.CurveList.Clear();

            PointPairList list = new PointPairList();
            //list.Add(0, 0);
            list.Add(0, Ra);
            list.Add(L1, (Ra- q_Расп_Нагрузка*(L1)));
            list.Add(L1, (Ra - q_Расп_Нагрузка * (L1) - P_Сила));
            list.Add((L1 + L2), (Ra - q_Расп_Нагрузка * ((L1 + L2)) - P_Сила));
            int i = 0;
            double k = (L1 + L2);
            while (i < 26)
            {
                list.Add(k, (Ra - q_Расп_Нагрузка * (k) - P_Сила - (((q1_max_НеравРасп_Нагрузка - (q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * (k - (L1+L2+L3)) / L3 + q1_min_НеравРасп_Нагрузка) * (k - (L1 + L2))) / 2 + (q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * ((L1 + L2) - k) / L3 + q1_min_НеравРасп_Нагрузка * (k - (L1 + L2)))));
                k = k + 0.032;
                i++;
            }
            list.Add((L1+L2+L3), Ra - q_Расп_Нагрузка * ((L1+L2+L3) - 0) - P_Сила - ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3 / 2 + q1_min_НеравРасп_Нагрузка * L3));
            list.Add(l_Длина_Балки, Ra - q_Расп_Нагрузка * (l_Длина_Балки - 0) - P_Сила - ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3 / 2 + q1_min_НеравРасп_Нагрузка * L3));



            LineItem MyLine = zedGraphControl1.GraphPane.AddCurve("Q экстремум", list, Color.Black, SymbolType.None);
            MyLine.Line.Width = 3;
            MyLine.Line.Fill = new Fill(Color.MintCream);
            MyLine.Symbol.IsVisible = false;
            zedGraphControl1.RestoreScale(zedGraphControl1.GraphPane);
            l_Длина_Балки = l_Длина_Балки * 1000;
            L1 = L1 * 1000;
            L2 = L2 * 1000;
            L3 = L3 * 1000;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            double K1_max = 0;
            double K2_max = 0;
            double K3_max = 0;
            double K4_max = 0;
            double MX1_max = 0;
            double MX2_max = 0;
            double MX3_max = 0;
            double MX4_max = 0;
            double MX_MAX = 0;

            L1 = L1 / 1000;
            L2 = L2 / 1000;
            L3 = L3 / 1000;
            l_Длина_Балки = l_Длина_Балки / 1000;
            double Ra = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки-L1) + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;
            double Rb = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * ((L1+L2+L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка * L3 * ((L1+L2+L3) - (1 / 2) * L3)) / l_Длина_Балки;
            textBox1.Text = Convert.ToString(Ra);
            textBox2.Text = Convert.ToString(Rb);
            zedGraphControl2.GraphPane.CurveList.Clear();

            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            int i = 0;
            double k = 0;
            while (i<6) {
                double MX1= Ra * k - q_Расп_Нагрузка * Math.Pow((k - 0), 2) / 2;
                list1.Add(k, MX1);

                if (MX1 > MX1_max) 
                {
                    MX1_max = MX1;
                    K1_max = k;
                }

                k = k + (L1/5);
                i++;
            }

            i = 0;
            k = L1;
            while (i < 4)
            {
                double MX2 = Ra * k - q_Расп_Нагрузка * Math.Pow((k - 0), 2) / 2 - P_Сила * (k - L1);
                list1.Add(k, MX2);

                if (MX2 > MX2_max)
                {
                    MX2_max = MX2;
                    K2_max = k;
                }

                k = k + (L2/3);
                i++;
            }

            i = 0;
            k = (L1 + L2);
            while (i < 5)
            {
                double MX3 = Ra * k - q_Расп_Нагрузка * Math.Pow(k, 2) / 2 - P_Сила * (k - L1) - (((q1_max_НеравРасп_Нагрузка - (q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * ((L1 + L2 + L3) - k) / L3 + q1_min_НеравРасп_Нагрузка) * (k - (L1 + L2))) / 2 * (k - (L1 + L2)) * (1 / 3) + (q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * (k - (L1 + L2)) / L3 + q1_min_НеравРасп_Нагрузка * (k - (L1 + L2)) * (k - (L1 + L2)) * (1 / 2));

                list1.Add(k, MX3);

                if (MX3 > MX3_max)
                {
                    MX3_max = MX3;
                    K3_max = k;
                }

                k = k + (L3/4);
                i++;
            }

            i = 0;
            k = (L1+L2+L3);
            while (i<3)
            {
                double MX4 = Ra * k - q_Расп_Нагрузка * Math.Pow(k, 2) / 2 - P_Сила * (k - L1) - ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3 / 2 * (k - ((L1 + L2) + L3 * 1 / 3)) + q1_min_НеравРасп_Нагрузка * L3 * (k - ((L1 + L2) + L3 * (1 / 2))));

                list1.Add(k, MX4);

                if (MX4 > MX4_max)
                {
                    MX4_max = MX4;
                    K4_max = k;
                }

                k = k + (l_Длина_Балки - (L1 + L2 + L3)) / 2;
                i++;
            }

            if (Math.Abs(MX1_max) >= Math.Abs(MX2_max) & Math.Abs(MX1_max) > Math.Abs(MX3_max) & Math.Abs(MX1_max) > Math.Abs(MX4_max))
            {
                MX_MAX = MX1_max;
                list2.Add(K1_max, 0);
                list2.Add(K1_max, MX1_max);
            }

            if (Math.Abs(MX2_max) > Math.Abs(MX1_max) & Math.Abs(MX2_max) >= Math.Abs(MX3_max) & Math.Abs(MX2_max) > Math.Abs(MX4_max))
            {
                MX_MAX = MX2_max;
                list2.Add(K2_max, 0);
                list2.Add(K2_max, MX2_max);

            }

            if (Math.Abs(MX3_max) > Math.Abs(MX2_max) & Math.Abs(MX3_max) > Math.Abs(MX1_max) & Math.Abs(MX3_max) >= Math.Abs(MX4_max))
            {
                MX_MAX = MX3_max;
                list2.Add(K3_max, 0);
                list2.Add(K3_max, MX3_max);

            }

            if (Math.Abs(MX4_max) > Math.Abs(MX2_max) & Math.Abs(MX4_max) > Math.Abs(MX1_max) & Math.Abs(MX4_max) > Math.Abs(MX3_max))
            {
                MX_MAX = MX4_max;
                list2.Add(K4_max, 0);
                list2.Add(K4_max, MX4_max);

            }
            LineItem myCurve2 = zedGraphControl2.GraphPane.AddCurve("Опасное сечение", list2, Color.Red, SymbolType.None);
            myCurve2.Line.Width = 4;
            myCurve2.Symbol.IsVisible = false;
            zedGraphControl2.RestoreScale(zedGraphControl2.GraphPane);

            LineItem MyLine1 = zedGraphControl2.GraphPane.AddCurve("M экстремум = " + MX_MAX, list1, Color.Black, SymbolType.None);
            MyLine1.Line.Width = 4;
            MyLine1.Line.Fill = new Fill(Color.AliceBlue);
            MyLine1.Symbol.IsVisible = false;
            zedGraphControl2.RestoreScale(zedGraphControl2.GraphPane);
            l_Длина_Балки = l_Длина_Балки * 1000;
            L1 = L1 * 1000;
            L2 = L2 * 1000;
            L3 = L3 * 1000;
        }

        private double МИ_СплошногоСБ(double Jx_S, double h_S, double b_P)
        {
            Jx_S = b_P * Math.Pow(h_S, 3) / 12;
            return Jx_S;
        }

        private double МИ_ПологоСБ(double Jx_P, double H_S, double B_P, double h_O, double b_O)
        {
            Jx_P = (B_P*Math.Pow(H_S, 3) - b_O*Math.Pow(1.5*h_O + 0.5* H_S, 3) + b_O * Math.Pow(-0.5 * h_O + 0.5 * H_S, 3) - b_O * Math.Pow(h_O, 3)) / 12;
            return Jx_P;
        }

        private double Ширина_ПологоСБ(double B_ПолБалки, double Jx, double H_ПолБалки,
    double Jн_отверстия)
        {
            B_ПолБалки = (12 * Jx * H_ПолБалки / h_Высота_СплБалки + Jн_отверстия) / H_ПолБалки /
            H_ПолБалки / H_ПолБалки;
            return B_ПолБалки;
        }
        // Функция вычисления массы полой балки
        private double Масса_Полой_Балки(double Масса_Пол_балки, double Ширина_ПСБалки,
        double H_ПолБалки, double Ш_отверстия, double В_отверстия)
        {
            if ((Ширина_ПСБалки - Ш_отверстия > 0) && (H_ПолБалки - В_отверстия > 0))
                Масса_Пол_балки = (Ширина_ПСБалки * H_ПолБалки - Ш_отверстия * В_отверстия) *
                l_Длина_Балки * Плотность / 1000 / 1000 / 1000;
            else Масса_Пол_балки = h_Высота_СплБалки * b_Ширина_СплБалки * l_Длина_Балки *
            Плотность / 1000 / 1000 / 1000;

            return Масса_Пол_балки;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            l_Длина_Балки = l_Длина_Балки / 1000;
            L1 = L1 / 1000;
            L2 = L2 / 1000;
            L3 = L3 / 1000;

            double Jx_ССБ = 0, Jx_ПСБ = 0;
            zedGraphControl3.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            Jx_ССБ = МИ_СплошногоСБ(Jx_ССБ, h_Высота_СплБалки, b_Ширина_СплБалки);
            Jx_ПСБ = МИ_ПологоСБ(Jx_ПСБ, H_Высота_ПолБалки, B_Ширина_ПолБалки, h_Высота_Отверстия, b_Ширина_Отверстия);

            P_Сила = -1 * P_Сила;

            double P_Сила1 = P_Сила * Коэф_P;
            double q_Расп_Нагрузка1 = q_Расп_Нагрузка * Коэф_q;
            double q1_max_НеравРасп_Нагрузка1 = q1_max_НеравРасп_Нагрузка * Коэф_q1_max;
            double q1_min_НеравРасп_Нагрузка1 = q1_min_НеравРасп_Нагрузка * Коэф_q1_min;

            double Ra = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки - l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

            double Ra1 = (q_Расп_Нагрузка1 * l_Длина_Балки * (l_Длина_Балки - l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка1 - q1_min_НеравРасп_Нагрузка1) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка1 * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

            double Rb = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки;

            double Rb1 = (q_Расп_Нагрузка1 * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка1 - q1_min_НеравРасп_Нагрузка1) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка1 * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки;

            double EIO = (-(Ra * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + P_Сила * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;

            double EIO1 = (-(Ra1 * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка1 * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка1 * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка1 * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + P_Сила1 * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;


            double z;

            for (z = 0; z <= L1; z = z + 0.01)
            {
                double w = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                double w1 = (EIO1 * z + Ra1 * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка1 * Math.Pow(z, 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1; z <= L1 + L2; z = z + 0.001)
            {
                double w = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - P_Сила * Math.Pow((z - L1), 3) / 6) / Е_Модуль_упругости / Jx_ССБ;
                double w1 = (EIO1 * z + Ra1 * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка1 * Math.Pow(z, 4) / 24 - P_Сила1 * Math.Pow((z - L1), 3) / 6) / Е_Модуль_упругости / Jx_ССБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1 + L2; z <= L1 + L2 + L3; z = z + 0.001)
            {
                double w = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - P_Сила * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                double w1 = (EIO1 * z + Ra1 * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка1 * Math.Pow(z, 4) / 24 - P_Сила1 * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2)), 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1 + L2 + L3; z <= l_Длина_Балки; z = z + 0.001)
            {
                double w = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - P_Сила * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 4) / 24 + q1_min_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                double w1 = (EIO1 * z + Ra1 * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка1 * Math.Pow(z, 4) / 24 - P_Сила1 * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2)), 4) / 24 + q1_min_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            LineItem MyLine1 = zedGraphControl3.GraphPane.AddCurve("Исходный прогиб срединной линии балки, w ", list1, Color.Black, SymbolType.None);
            MyLine1.Line.Width = 3;
            MyLine1.Symbol.IsVisible = false;
            LineItem MyLine2 = zedGraphControl3.GraphPane.AddCurve("Новый прогиб срединной линии балки, w1 ", list2, Color.Orange, SymbolType.None);
            MyLine2.Line.Width = 3;
            MyLine2.Symbol.IsVisible = false;
            zedGraphControl3.RestoreScale(zedGraphControl3.GraphPane);

            l_Длина_Балки = l_Длина_Балки * 1000;
            L1 = L1 * 1000;
            L2 = L2 * 1000;
            L3 = L3 * 1000;
            P_Сила = P_Сила * -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            l_Длина_Балки = l_Длина_Балки / 1000;
            L1 = L1 / 1000;
            L2 = L2 / 1000;
            L3 = L3 / 1000;
            P_Сила = -1 * P_Сила;
            double Jx_ССБ = 0, Jx_ПСБ = 0;
            zedGraphControl5.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            Jx_ССБ = МИ_СплошногоСБ(Jx_ССБ, h_Высота_СплБалки, b_Ширина_СплБалки);
            Jx_ПСБ = МИ_ПологоСБ(Jx_ПСБ, H_Высота_ПолБалки, B_Ширина_ПолБалки, h_Высота_Отверстия, b_Ширина_Отверстия);

            double q3_НеравРасп_Нагрузка = q1_max_НеравРасп_Нагрузка / 2 + q1_min_НеравРасп_Нагрузка;
            double P_Сила1 = P_Сила * Коэф_P;
            double q_Расп_Нагрузка1 = q_Расп_Нагрузка * Коэф_q;
            double q1_max_НеравРасп_Нагрузка1 = q1_max_НеравРасп_Нагрузка * Коэф_q1_max;
            double q1_min_НеравРасп_Нагрузка1 = q1_min_НеравРасп_Нагрузка * Коэф_q1_min;
            double q3_НеравРасп_Нагрузка1 = q1_max_НеравРасп_Нагрузка1 / 2 + q1_min_НеравРасп_Нагрузка1;




            double Ra = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

            double Ra1 = (q_Расп_Нагрузка1 * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка1 - q1_min_НеравРасп_Нагрузка1) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка1 * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

            double Rb = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки; ;

            double Rb1 = (q_Расп_Нагрузка1 * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка1 - q1_min_НеравРасп_Нагрузка1) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка1 * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки; ;

            double EIO = (-(Ra * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + P_Сила * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;

            double EIO1 = (-(Ra1 * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка1 * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка1 * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка1 * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + P_Сила1 * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;

            double z;

            for (z = 0; z <= L1; z = z + 0.01)
            {
                double w = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;
                double w1 = (EIO1 * z + Ra1 * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка1 * Math.Pow(z, 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1; z <= L1 + L2; z = z + 0.001)
            {
                double w = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - P_Сила * Math.Pow((z - L1), 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;
                double w1 = (EIO1 * z + Ra1 * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка1 * Math.Pow(z, 4) / 24 - P_Сила1 * Math.Pow((z - L1), 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1 + L2; z <= L1 + L2 + L3; z = z + 0.001)
            {
                double w = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - P_Сила * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;
                double w1 = (EIO1 * z + Ra1 * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка1 * Math.Pow(z, 4) / 24 - P_Сила1 * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2)), 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1 + L2 + L3; z <= l_Длина_Балки; z = z + 0.001)
            {
                double w = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - P_Сила * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 4) / 24 + q1_min_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;
                double w1 = (EIO1 * z + Ra1 * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка1 * Math.Pow(z, 4) / 24 - P_Сила1 * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2)), 4) / 24 + q1_min_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            LineItem MyLine1 = zedGraphControl5.GraphPane.AddCurve("Исходный прогиб срединной линии балки, w ", list1, Color.Black, SymbolType.None);
            MyLine1.Line.Width = 3;
            MyLine1.Symbol.IsVisible = false;
            LineItem MyLine2 = zedGraphControl5.GraphPane.AddCurve("Новый прогиб срединной линии балки, w1 ", list2, Color.Orange, SymbolType.None);
            MyLine2.Line.Width = 3;
            MyLine2.Symbol.IsVisible = false;
            zedGraphControl5.RestoreScale(zedGraphControl5.GraphPane);

            l_Длина_Балки = l_Длина_Балки * 1000;
            L1 = L1 * 1000;
            L2 = L2 * 1000;
            L3 = L3 * 1000;
            P_Сила = -1 * P_Сила;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double Jx_ССБ = 0;
            zedGraphControl4.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            Jx_ССБ = МИ_СплошногоСБ(Jx_ССБ, h_Высота_СплБалки, b_Ширина_СплБалки);

            l_Длина_Балки = l_Длина_Балки / 1000;
            L1 = L1 / 1000;
            L2 = L2 / 1000;
            L3 = L3 / 1000;
            P_Сила = -1 * P_Сила;
            double P_Сила1 = P_Сила * Коэф_P;
            double q_Расп_Нагрузка1 = q_Расп_Нагрузка * Коэф_q;
            double q1_max_НеравРасп_Нагрузка1 = q1_max_НеравРасп_Нагрузка * Коэф_q1_max;
            double q1_min_НеравРасп_Нагрузка1 = q1_min_НеравРасп_Нагрузка * Коэф_q1_min;



            double Ra = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

            double Ra1 = (q_Расп_Нагрузка1 * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка1 - q1_min_НеравРасп_Нагрузка1) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка1 * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

            double Rb = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки; ;

            double Rb1 = (q_Расп_Нагрузка1 * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка1 - q1_min_НеравРасп_Нагрузка1) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка1 * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки; ;

            double EIO = (-(Ra * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + P_Сила * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;

            double EIO1 = (-(Ra1 * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка1 * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка1 * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка1 * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + P_Сила1 * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;

            double z;

            for (z = 0; z <= L1; z = z + 0.01)
            {
                double w = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 ) / Е_Модуль_упругости / Jx_ССБ;
                double w1 = (EIO1 + Ra1 * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка1 * Math.Pow(z, 3) / 6 ) / Е_Модуль_упругости / Jx_ССБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1; z <= L1 + L2; z = z + 0.001)
            {
                double w = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - P_Сила * Math.Pow((z - L1), 2) / 2) / Е_Модуль_упругости / Jx_ССБ;
                double w1 = (EIO1 + Ra1 * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка1 * Math.Pow(z, 3) / 6 - P_Сила1 * Math.Pow((z - L1), 2) / 2) / Е_Модуль_упругости / Jx_ССБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1 + L2; z <= L1 + L2 + L3; z = z + 0.001)
            {
                double w = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - P_Сила * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 3) / 6) / Е_Модуль_упругости / Jx_ССБ;
                double w1 = (EIO1 + Ra1 * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка1 * Math.Pow(z, 3) / 6 - P_Сила1 * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2)), 3) / 6) / Е_Модуль_упругости / Jx_ССБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1 + L2 + L3; z <= l_Длина_Балки; z = z + 0.001)
            {
                double w = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - P_Сила * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 3) / 6 + q1_min_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                double w1 = (EIO1 + Ra1 * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка1 * Math.Pow(z, 3) / 6 - P_Сила1 * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2)), 3) / 6 + q1_min_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2 + L3)), 3) / 6) / Е_Модуль_упругости / Jx_ССБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }



            LineItem MyLine1 = zedGraphControl4.GraphPane.AddCurve("Исходный угол поворота балки ", list1, Color.Black, SymbolType.None);
            MyLine1.Line.Width = 3;
            MyLine1.Symbol.IsVisible = false;
            LineItem MyLine2 = zedGraphControl4.GraphPane.AddCurve("Новый угол поворота балки ", list2, Color.Orange, SymbolType.None);
            MyLine2.Line.Width = 3;
            MyLine2.Symbol.IsVisible = false;
            zedGraphControl4.RestoreScale(zedGraphControl4.GraphPane);


            l_Длина_Балки = l_Длина_Балки * 1000;
            L1 = L1 * 1000;
            L2 = L2 * 1000;
            L3 = L3 * 1000;
            P_Сила = -1 * P_Сила;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double Jx_ПСБ = 0;
            zedGraphControl6.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            Jx_ПСБ = МИ_ПологоСБ(Jx_ПСБ, H_Высота_ПолБалки, B_Ширина_ПолБалки, h_Высота_Отверстия, b_Ширина_Отверстия);

            l_Длина_Балки = l_Длина_Балки / 1000;
            L1 = L1 / 1000;
            L2 = L2 / 1000;
            L3 = L3 / 1000;
            P_Сила = -1 * P_Сила;

            double P_Сила1 = P_Сила * Коэф_P;
            double q_Расп_Нагрузка1 = q_Расп_Нагрузка * Коэф_q;
            double q1_max_НеравРасп_Нагрузка1 = q1_max_НеравРасп_Нагрузка * Коэф_q1_max;
            double q1_min_НеравРасп_Нагрузка1 = q1_min_НеравРасп_Нагрузка * Коэф_q1_min;



            double Ra = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

            double Ra1 = (q_Расп_Нагрузка1 * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка1 - q1_min_НеравРасп_Нагрузка1) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка1 * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

            double Rb = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки;

            double Rb1 = (q_Расп_Нагрузка1 * l_Длина_Балки * (l_Длина_Балки / 2) + P_Сила * L1 + ((q1_max_НеравРасп_Нагрузка1 - q1_min_НеравРасп_Нагрузка1) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка1 * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки;

            double EIO = (-(Ra * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + P_Сила * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;

            double EIO1 = (-(Ra1 * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка1 * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка1 * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка1 * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + P_Сила1 * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;

            double z;

            for (z = 0; z <= L1; z = z + 0.01)
            {
                double w = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;
                double w1 = (EIO1 + Ra1 * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка1 * Math.Pow(z, 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1; z <= L1 + L2; z = z + 0.001)
            {
                double w = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - P_Сила * Math.Pow((z - L1), 2) / 2) / Е_Модуль_упругости / Jx_ПСБ;
                double w1 = (EIO1 + Ra1 * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка1 * Math.Pow(z, 3) / 6 - P_Сила1 * Math.Pow((z - L1), 2) / 2) / Е_Модуль_упругости / Jx_ПСБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1 + L2; z <= L1 + L2 + L3; z = z + 0.001)
            {
                double w = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - P_Сила * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;
                double w1 = (EIO1 + Ra1 * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка1 * Math.Pow(z, 3) / 6 - P_Сила1 * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2)), 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }

            for (z = L1 + L2 + L3; z <= l_Длина_Балки; z = z + 0.001)
            {
                double w = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - P_Сила * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 3) / 6 + q1_min_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;
                double w1 = (EIO1 + Ra1 * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка1 * Math.Pow(z, 3) / 6 - P_Сила1 * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2)), 3) / 6 + q1_min_НеравРасп_Нагрузка1 * Math.Pow((z - (L1 + L2 + L3)), 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;
                list1.Add(z, w);
                list2.Add(z, w1);
            }



            LineItem MyLine1 = zedGraphControl6.GraphPane.AddCurve("Исходный угол поворота балки ", list1, Color.Black, SymbolType.None);
            MyLine1.Line.Width = 3;
            MyLine1.Symbol.IsVisible = false;
            LineItem MyLine2 = zedGraphControl6.GraphPane.AddCurve("Новый угол поворота балки ", list2, Color.Orange, SymbolType.None);
            MyLine2.Line.Width = 3;
            MyLine2.Symbol.IsVisible = false;
            zedGraphControl6.RestoreScale(zedGraphControl6.GraphPane);


            l_Длина_Балки = l_Длина_Балки * 1000;
            L1 = L1 * 1000;
            L2 = L2 * 1000;
            L3 = L3 * 1000;
            P_Сила = -1 * P_Сила;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            l_Длина_Балки = l_Длина_Балки / 1000;
            L1 = L1 / 1000;
            L2 = L2 / 1000;
            L3 = L3 / 1000;


            zedGraphControl7.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            double Jx_ССБ = 0, Jx_ПСБ = 0;

            double f1_max = 0, f_max = 0;
            double f, f1, Ra, Rb, EIO;

            Jx_ССБ = МИ_СплошногоСБ(Jx_ССБ, h_Высота_СплБалки, b_Ширина_СплБалки);
            Jx_ПСБ = МИ_ПологоСБ(Jx_ПСБ, H_Высота_ПолБалки, B_Ширина_ПолБалки, h_Высота_Отверстия, b_Ширина_Отверстия);


            double k;
            for (k = P_Нач; k <= P_Кон + 0.1; k = k + 0.1)
            {
                double z;
                Ra = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + k * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

                Rb = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + k * L1 + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки;

                EIO = (-(Ra * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + k * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;

                for (z = 0; z <= L1; z = z + 0.1)
                {
                    f = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                    f1 = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;


                    if (Math.Abs(f) >= Math.Abs(f_max))
                    {
                        f_max = f;
                    }
                    if (Math.Abs(f1) >= Math.Abs(f1_max))
                    {
                        f1_max = f1;
                    }
                }

                for (z = L1; z <= L1 + L2; z = z + 0.1)
                {
                    f = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - k * Math.Pow((z - L1), 3) / 6) / Е_Модуль_упругости / Jx_ССБ;
                    f1 = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - k * Math.Pow((z - L1), 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;

                    if (Math.Abs(f) >= Math.Abs(f_max))
                    {
                        f_max = f;
                    }
                    if (Math.Abs(f1) >= Math.Abs(f1_max))
                    {
                        f1_max = f1;
                    }
                }

                for (z = L1 + L2; z <= L1 + L2 + L3; z = z + 0.1)
                {
                    f = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - k * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                    f1 = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - k * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;

                    if (Math.Abs(f) >= Math.Abs(f_max))
                    {
                        f_max = f;
                    }
                    if (Math.Abs(f1) >= Math.Abs(f1_max))
                    {
                        f1_max = f1;
                    }
                }

                for (z = L1 + L2 + L3; z <= l_Длина_Балки; z = z + 0.1)
                {
                    f = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - k * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 4) / 24 + q1_min_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                    f1 = (EIO * z + Ra * Math.Pow(z, 3) / 6 - q_Расп_Нагрузка * Math.Pow(z, 4) / 24 - k * Math.Pow((z - L1), 3) / 6 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 4) / 24 + q1_min_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;

                    if (Math.Abs(f) >= Math.Abs(f_max))
                    {
                        f_max = f;
                    }
                    if (Math.Abs(f1) >= Math.Abs(f1_max))
                    {
                        f1_max = f1;
                    }
                }

                list1.Add(k, f_max);
                list2.Add(k, f1_max);
            }

            LineItem MyLine1 = zedGraphControl7.GraphPane.AddCurve("Сплошная балка ", list1, Color.Black, SymbolType.None);
            MyLine1.Line.Width = 3;
            MyLine1.Symbol.IsVisible = false;
            LineItem MyLine2 = zedGraphControl7.GraphPane.AddCurve("Полая балка", list2, Color.Orange, SymbolType.None);
            MyLine2.Line.Width = 3;
            MyLine2.Symbol.IsVisible = false;
            zedGraphControl7.RestoreScale(zedGraphControl7.GraphPane);


            l_Длина_Балки = l_Длина_Балки * 1000;
            L1 = L1 * 1000;
            L2 = L2 * 1000;
            L3 = L3 * 1000;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            l_Длина_Балки = l_Длина_Балки / 1000;
            L1 = L1 / 1000;
            L2 = L2 / 1000;
            L3 = L3 / 1000;


            zedGraphControl8.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            double Jx_ССБ = 0, Jx_ПСБ = 0;

            double f1_max = 0, f_max = 0;
            double f, f1, Ra, Rb, EIO;
            Jx_ССБ = МИ_СплошногоСБ(Jx_ССБ, h_Высота_СплБалки, b_Ширина_СплБалки);
            Jx_ПСБ = МИ_ПологоСБ(Jx_ПСБ, H_Высота_ПолБалки, B_Ширина_ПолБалки, h_Высота_Отверстия, b_Ширина_Отверстия);
            double k;

            for (k = P_Нач1; k <= P_Кон1 + 0.01; k = k + 0.01)
            {
                double z;

                Ra = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + k * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;

                Rb = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + k * L1 + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки;

                EIO = (-(Ra * Math.Pow(l_Длина_Балки, 3)) / 6 + q_Расп_Нагрузка * Math.Pow(l_Длина_Балки, 4) / 24 + q1_max_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2)), 4) / 24 - q1_min_НеравРасп_Нагрузка * Math.Pow((l_Длина_Балки - (L1 + L2 + L3)), 4) / 24 + k * Math.Pow((l_Длина_Балки - L1), 3) / 6) / l_Длина_Балки;

                for (z = 0; z <= L1; z = z + 0.01)
                {
                    f = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6) / Е_Модуль_упругости / Jx_ССБ;
                    f1 = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;

                    if (Math.Abs(f) >= Math.Abs(f_max))
                    {
                        f_max = f;
                    }
                    if (Math.Abs(f1) >= Math.Abs(f1_max))
                    {
                        f1_max = f1;
                    }
                }

                for (z = L1; z <= L1 + L2; z = z + 0.001)
                {
                    f = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - k * Math.Pow((z - L1), 2) / 2) / Е_Модуль_упругости / Jx_ССБ;
                    f1 = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - k * Math.Pow((z - L1), 2) / 2) / Е_Модуль_упругости / Jx_ПСБ;

                    if (Math.Abs(f) >= Math.Abs(f_max))
                    {
                        f_max = f;
                    }
                    if (Math.Abs(f1) >= Math.Abs(f1_max))
                    {
                        f1_max = f1;
                    }
                }

                for (z = L1 + L2; z <= L1 + L2 + L3; z = z + 0.001)
                {
                    f = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - k * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 3) / 6) / Е_Модуль_упругости / Jx_ССБ;
                    f1 = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - k * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 3) / 6) / Е_Модуль_упругости / Jx_ПСБ;

                    if (Math.Abs(f) >= Math.Abs(f_max))
                    {
                        f_max = f;
                    }
                    if (Math.Abs(f1) >= Math.Abs(f1_max))
                    {
                        f1_max = f1;
                    }
                }

                for (z = L1 +L2 + L3; z <= l_Длина_Балки; z = z + 0.001)
                {
                    f = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - k * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 3) / 6 + q1_min_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ССБ;
                    f1 = (EIO + Ra * Math.Pow(z, 2) / 2 - q_Расп_Нагрузка * Math.Pow(z, 3) / 6 - k * Math.Pow((z - L1), 2) / 2 - q1_max_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2)), 3) / 6 + q1_min_НеравРасп_Нагрузка * Math.Pow((z - (L1 + L2 + L3)), 4) / 24) / Е_Модуль_упругости / Jx_ПСБ;

                    if (Math.Abs(f) >= Math.Abs(f_max))
                    {
                        f_max = f;
                    }
                    if (Math.Abs(f1) >= Math.Abs(f1_max))
                    {
                        f1_max = f1;
                    }
                }

                list1.Add(k, f_max);
                list2.Add(k, f1_max);
            }


            LineItem MyLine1 = zedGraphControl8.GraphPane.AddCurve("Сплошная балка ", list1, Color.Black, SymbolType.None);
            MyLine1.Line.Width = 3;
            MyLine1.Symbol.IsVisible = false;
            LineItem MyLine2 = zedGraphControl8.GraphPane.AddCurve("Полая балка", list2, Color.Orange, SymbolType.None);
            MyLine2.Line.Width = 3;
            MyLine2.Symbol.IsVisible = false;
            zedGraphControl8.RestoreScale(zedGraphControl8.GraphPane);


            l_Длина_Балки = l_Длина_Балки * 1000;
            L1 = L1 * 1000;
            L2 = L2 * 1000;
            L3 = L3 * 1000;


        }

        private void button12_Click(object sender, EventArgs e)
        {
            l_Длина_Балки = l_Длина_Балки / 1000;
            L1 = L1 / 1000;
            L2 = L2 / 1000;
            L3 = L3 / 1000;

            zedGraphControl9.GraphPane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();

            double Jx_ССБ = 0, Jx_ПСБ = 0;

            double K1_max = 0;
            double K2_max = 0;
            double K3_max = 0;
            double K4_max = 0;
            double MX1_max = 0;
            double MX2_max = 0;
            double MX3_max = 0;
            double MX4_max = 0;
            double MX_MAX = 0;

            Jx_ССБ = МИ_СплошногоСБ(Jx_ССБ, h_Высота_СплБалки, b_Ширина_СплБалки);
            Jx_ПСБ = МИ_ПологоСБ(Jx_ПСБ, H_Высота_ПолБалки, B_Ширина_ПолБалки, h_Высота_Отверстия, b_Ширина_Отверстия);

            double z = 0;

            for (z = P_Нач2; z <= P_Кон2 + 0.01; z = z + 0.01)
            {
                double Ra = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + z * (l_Длина_Балки - L1) + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * (l_Длина_Балки - ((L1 + L2) + 1 / 3 * L3)) + q1_min_НеравРасп_Нагрузка * L3 * (l_Длина_Балки - ((L1 + L2) + (1 / 2) * L3))) / l_Длина_Балки;
                double Rb = (q_Расп_Нагрузка * l_Длина_Балки * (l_Длина_Балки / 2) + z * L1 + ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3) / 2 * ((L1 + L2 + L3) - (2 / 3) * L3) + q1_min_НеравРасп_Нагрузка * L3 * ((L1 + L2 + L3) - (1 / 2) * L3)) / l_Длина_Балки;

                int i = 0;
                double k = 0;


                while (i < 6)
                {
                    double MX1 = Ra * k - q_Расп_Нагрузка * Math.Pow((k - 0), 2) / 2;

                    if (MX1 > MX1_max)
                    {
                        MX1_max = MX1;
                        K1_max = k;
                    }

                    k = k + (L1 / 5);
                    i++;
                }

                i = 0;
                k = L1;
                while (i < 4)
                {
                    double MX2 = Ra * k - q_Расп_Нагрузка * Math.Pow((k - 0), 2) / 2 - P_Сила * (k - L1);


                    if (MX2 > MX2_max)
                    {
                        MX2_max = MX2;
                        K2_max = k;
                    }

                    k = k + (L2 / 3);
                    i++;
                }

                i = 0;
                k = (L1 + L2);
                while (i < 5)
                {
                    double MX3 = Ra * k - q_Расп_Нагрузка * Math.Pow(k, 2) / 2 - P_Сила * (k - L1) - (((q1_max_НеравРасп_Нагрузка - (q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * ((L1 + L2 + L3) - k) / L3 + q1_min_НеравРасп_Нагрузка) * (k - (L1 + L2))) / 2 * (k - (L1 + L2)) * (1 / 3) + (q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * (k - (L1 + L2)) / L3 + q1_min_НеравРасп_Нагрузка * (k - (L1 + L2)) * (k - (L1 + L2)) * (1 / 2));



                    if (MX3 > MX3_max)
                    {
                        MX3_max = MX3;
                        K3_max = k;
                    }

                    k = k + (L3 / 4);
                    i++;
                }

                i = 0;
                k = (L1 + L2 + L3);
                while (i < 3)
                {
                    double MX4 = Ra * k - q_Расп_Нагрузка * Math.Pow(k, 2) / 2 - P_Сила * (k - L1) - ((q1_max_НеравРасп_Нагрузка - q1_min_НеравРасп_Нагрузка) * L3 / 2 * (k - ((L1 + L2) + L3 * 1 / 3)) + q1_min_НеравРасп_Нагрузка * L3 * (k - ((L1 + L2) + L3 * (1 / 2))));



                    if (MX4 > MX4_max)
                    {
                        MX4_max = MX4;
                        K4_max = k;
                    }

                    k = k + (l_Длина_Балки - (L1 + L2 + L3)) / 2;
                    i++;
                }

                if (Math.Abs(MX1_max) >= Math.Abs(MX2_max) & Math.Abs(MX1_max) > Math.Abs(MX3_max) & Math.Abs(MX1_max) > Math.Abs(MX4_max))
                {
                    MX_MAX = MX1_max;
                }

                if (Math.Abs(MX2_max) > Math.Abs(MX1_max) & Math.Abs(MX2_max) >= Math.Abs(MX3_max) & Math.Abs(MX2_max) > Math.Abs(MX4_max))
                {
                    MX_MAX = MX2_max;

                }

                if (Math.Abs(MX3_max) > Math.Abs(MX2_max) & Math.Abs(MX3_max) > Math.Abs(MX1_max) & Math.Abs(MX3_max) >= Math.Abs(MX4_max))
                {
                    MX_MAX = MX3_max;

                }

                if (Math.Abs(MX4_max) > Math.Abs(MX2_max) & Math.Abs(MX4_max) > Math.Abs(MX1_max) & Math.Abs(MX4_max) > Math.Abs(MX3_max))
                {
                    MX_MAX = MX4_max;

                }


                double o = MX_MAX * h_Высота_СплБалки / 2 / Jx_ССБ;
                double o1 = MX_MAX * H_Высота_ПолБалки / 2 / Jx_ПСБ;

                list1.Add(z, o);
                list2.Add(z, o1);
            }


            LineItem MyLine1 = zedGraphControl9.GraphPane.AddCurve("Сплошная балка ", list1, Color.Black, SymbolType.None);
            MyLine1.Line.Width = 3;
            MyLine1.Symbol.IsVisible = false;
            LineItem MyLine2 = zedGraphControl9.GraphPane.AddCurve("Полая балка", list2, Color.Orange, SymbolType.None);
            MyLine2.Line.Width = 3;
            MyLine2.Symbol.IsVisible = false;
            zedGraphControl9.RestoreScale(zedGraphControl9.GraphPane);


            l_Длина_Балки = l_Длина_Балки * 1000;
            L1 = L1 * 1000;
            L2 = L2 * 1000;
            L3 = L3 * 1000;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            double Jx_ССБ = 0, Ширина_ПСБалки = 0, Jн_отверстия = 0, Масса_Сп_балки = 0,
            Масса_Пол_балки = 0, Масса_min = 0, Min_Высота = 0, Min_Ширина = 0, Min_Высота_Отв = 0,
            Min_Ширина_Отв = 0;

            Jx_ССБ = МИ_СплошногоСБ(Jx_ССБ, h_Высота_СплБалки, b_Ширина_СплБалки);
            Jн_отверстия = 12 * МИ_СплошногоСБ(Jн_отверстия, Коэф_Отв * h_Высота_СплБалки,
            Коэф_Отв * b_Ширина_СплБалки);
            Масса_Сп_балки = h_Высота_СплБалки * b_Ширина_СплБалки * l_Длина_Балки * Плотность / 1000
            / 1000 / 1000;
            Масса_min = Масса_Сп_балки;

            zedGraphControl10.GraphPane.CurveList.Clear();


            PointPairList Область = new PointPairList();
            Область.Add(h_Высота_СплБалки, b_Ширина_СплБалки);
            Область.Add(2 * h_Высота_СплБалки, b_Ширина_СплБалки);
            Область.Add(2 * h_Высота_СплБалки, 2 * b_Ширина_СплБалки);
            Область.Add(h_Высота_СплБалки, 2 * b_Ширина_СплБалки);
            Область.Add(h_Высота_СплБалки, b_Ширина_СплБалки);

            for (double Коэф_Отв1 = Коэф_Отв; Коэф_Отв1 < 2; Коэф_Отв1 += Коэф_При)
            {
                PointPairList list = new PointPairList();
                Jн_отверстия = 12 * МИ_СплошногоСБ(Jн_отверстия, Коэф_Отв1 * h_Высота_СплБалки,
                Коэф_Отв1 * b_Ширина_СплБалки);
                for (double H_ПолБалки = h_Высота_СплБалки; H_ПолБалки <= 2 * h_Высота_СплБалки;
                H_ПолБалки += h_Высота_СплБалки / Кэф_Сокр)
                {
                    Ширина_ПСБалки = Ширина_ПологоСБ(Ширина_ПСБалки, Jx_ССБ, H_ПолБалки, Jн_отверстия);
                    if ((Коэф_Отв1 * b_Ширина_СплБалки <= Ширина_ПСБалки) &&
                    (Коэф_Отв1 * h_Высота_СплБалки <= H_ПолБалки))
                        if ((Ширина_ПСБалки >= b_Ширина_СплБалки) &&
                        (Ширина_ПСБалки <= 2 * b_Ширина_СплБалки))
                        {
                            list.Add(H_ПолБалки, Ширина_ПСБалки);
                            Масса_Пол_балки = Масса_Полой_Балки(Масса_Пол_балки, Ширина_ПСБалки,
                            H_ПолБалки, Коэф_Отв1 * b_Ширина_СплБалки, Коэф_Отв1 * h_Высота_СплБалки);
                            if (Масса_min > Масса_Пол_балки)
                            {
                                Масса_min = Масса_Пол_балки;
                                Min_Высота = H_ПолБалки;
                                Min_Ширина = Ширина_ПСБалки;
                                Min_Высота_Отв = Коэф_Отв1 * h_Высота_СплБалки;
                                Min_Ширина_Отв = Коэф_Отв1 * b_Ширина_СплБалки;
                            }
                        }
                }
                LineItem MyLine;
                if (Коэф_Отв1 == Коэф_Отв) MyLine = zedGraphControl10.GraphPane.AddCurve("Допустимая область выделена красным цветом", list, Color.Black, SymbolType.None);
                else MyLine = zedGraphControl10.GraphPane.AddCurve("", list, Color.Black,
                 SymbolType.None);
                MyLine.Line.Width = 2;
                MyLine.Symbol.IsVisible = false;
                zedGraphControl10.RestoreScale(zedGraphControl10.GraphPane);
            }
            LineItem Доп_Область = zedGraphControl10.GraphPane.AddCurve("", Область, Color.Red,
            SymbolType.None);
            Доп_Область.Line.Width = 4;
            Доп_Область.Symbol.IsVisible = false;
            zedGraphControl10.RestoreScale(zedGraphControl10.GraphPane);

            Min_Высота_Отв = (Min_Высота_Отв - (Min_Высота - Min_Высота_Отв)) / 3;
            Масса_min = Масса_min + (Min_Высота) * Min_Ширина_Отв * l_Длина_Балки / 1000 / 1000 / 1000;

            textBox11.Text = Convert.ToString(Convert.ToDouble(Масса_Сп_балки).ToString("N2"));
            textBox12.Text = Convert.ToString(Convert.ToDouble(Масса_min).ToString("N2"));
            textBox13.Text = Convert.ToString(Convert.ToDouble(Min_Высота).ToString("N2"));
            textBox14.Text = Convert.ToString(Convert.ToDouble(Min_Ширина).ToString("N2"));
            textBox15.Text = Convert.ToString(Convert.ToDouble(Min_Высота_Отв).ToString("N2"));
            textBox16.Text = Convert.ToString(Convert.ToDouble(Min_Ширина_Отв).ToString("N2"));
        }


        private ZedGraphControl ZedGraph1, ZedGraph2, ZedGraph3, ZedGraph4, ZedGraph5, ZedGraph6, ZedGraph7, ZedGraph8, ZedGraph9, ZedGraph10;

        public Form1()
        {
            InitializeComponent();

            comboBox1.Text = Convert.ToString(b_Ширина_СплБалки);
            this.comboBox1.Items.AddRange(new object[] { "75,0" });
            comboBox2.Text = Convert.ToString(h_Высота_СплБалки);
            this.comboBox2.Items.AddRange(new object[] { "120,0" });
            comboBox3.Text = Convert.ToString(l_Длина_Балки);
            this.comboBox3.Items.AddRange(new object[] { "3500,0" });
            comboBox4.Text = Convert.ToString(P_Сила);
            this.comboBox4.Items.AddRange(new object[] { "5,0", "10,0", "20,0", "30,0", "40,0", "50,0", "60,0", "70,0", "80,0", "90,0", "100,0" });
            comboBox5.Text = Convert.ToString(q_Расп_Нагрузка);
            this.comboBox5.Items.AddRange(new object[] { "16", "18", "20", "22", "24", "26", "28", "30" });
            comboBox11.Text = Convert.ToString(q1_max_НеравРасп_Нагрузка);
            this.comboBox11.Items.AddRange(new object[] { "18", "20", "22", "24", "26", "28", "30", "32" });
            comboBox6.Text = Convert.ToString(q1_min_НеравРасп_Нагрузка);
            this.comboBox6.Items.AddRange(new object[] { "8", "10", "12", "14", "16", "18", "20", "22" });
            comboBox7.Text = Convert.ToString(Е_Модуль_упругости);
            this.comboBox7.Items.AddRange(new object[] { "98000" });
            comboBox8.Text = Convert.ToString(G_Модуль_сдвига);
            this.comboBox8.Items.AddRange(new object[] { "33000" });
            comboBox9.Text = Convert.ToString(К_Пуассона);
            this.comboBox9.Items.AddRange(new object[] { "0,32" });
            comboBox10.Text = Convert.ToString(Плотность);
            this.comboBox10.Items.AddRange(new object[] { "8500,0" });
            comboBox18.Text = Convert.ToString(b_Ширина_Отверстия);
            this.comboBox18.Items.AddRange(new object[] { "60,0" });
            comboBox19.Text = Convert.ToString(h_Высота_Отверстия);
            this.comboBox19.Items.AddRange(new object[] { "30,0" });


            comboBox15.Text = Convert.ToString(L1);
            this.comboBox15.Items.AddRange(new object[] { "1550,0" });
            comboBox16.Text = Convert.ToString(L2);
            this.comboBox16.Items.AddRange(new object[] { "570,0" });
            comboBox17.Text = Convert.ToString(L3);
            this.comboBox17.Items.AddRange(new object[] { "800,0" });



            comboBox12.Text = Convert.ToString(Коэф_P);
            this.comboBox12.Items.AddRange(new object[] { "0,1", "0,2", "0,3", "0,4", "0,5", "0,6", "0,7", "0,8", "0,9", "1,0", "1,1", "1,2" });
            comboBox13.Text = Convert.ToString(Коэф_q);
            this.comboBox13.Items.AddRange(new object[] { "0,1", "0,2", "0,3", "0,4", "0,5", "0,6", "0,7", "0,8", "0,9", "1,0", "1,1", "1,2" });
            comboBox14.Text = Convert.ToString(Коэф_q1_max);
            this.comboBox14.Items.AddRange(new object[] { "0,1", "0,2", "0,3", "0,4", "0,5", "0,6", "0,7", "0,8", "0,9", "1,0", "1,1", "1,2" });
            comboBox20.Text = Convert.ToString(Коэф_q1_min);
            this.comboBox20.Items.AddRange(new object[] { "0,1", "0,2", "0,3", "0,4", "0,5", "0,6", "0,7", "0,8", "0,9", "1,0", "1,1", "1,2" });

            comboBox24.Text = Convert.ToString(Коэф_P);
            this.comboBox24.Items.AddRange(new object[] { "0,1", "0,2", "0,3", "0,4", "0,5", "0,6", "0,7", "0,8", "0,9", "1,0", "1,1", "1,2" });
            comboBox23.Text = Convert.ToString(Коэф_q);
            this.comboBox23.Items.AddRange(new object[] { "0,1", "0,2", "0,3", "0,4", "0,5", "0,6", "0,7", "0,8", "0,9", "1,0", "1,1", "1,2" });
            comboBox22.Text = Convert.ToString(Коэф_q1_max);
            this.comboBox22.Items.AddRange(new object[] { "0,1", "0,2", "0,3", "0,4", "0,5", "0,6", "0,7", "0,8", "0,9", "1,0", "1,1", "1,2" });
            comboBox21.Text = Convert.ToString(Коэф_q1_min);
            this.comboBox21.Items.AddRange(new object[] { "0,1", "0,2", "0,3", "0,4", "0,5", "0,6", "0,7", "0,8", "0,9", "1,0", "1,1", "1,2" });

            comboBox25.Text = Convert.ToString(P_Нач);
            comboBox26.Text = Convert.ToString(P_Кон);
            comboBox27.Text = Convert.ToString(P_Нач1);
            comboBox28.Text = Convert.ToString(P_Кон1);
            comboBox29.Text = Convert.ToString(P_Нач2);
            comboBox30.Text = Convert.ToString(P_Кон2);


            textBox3.Text = Convert.ToString(Convert.ToDouble(P_Сила).ToString("N2"));
            textBox4.Text = Convert.ToString(Convert.ToDouble(q_Расп_Нагрузка).ToString("N2"));
            textBox5.Text = Convert.ToString(Convert.ToDouble(q1_max_НеравРасп_Нагрузка).ToString("N2"));
            textBox6.Text = Convert.ToString(Convert.ToDouble(q1_min_НеравРасп_Нагрузка).ToString("N2"));
            textBox10.Text = Convert.ToString(Convert.ToDouble(P_Сила).ToString("N2"));
            textBox9.Text = Convert.ToString(Convert.ToDouble(q_Расп_Нагрузка).ToString("N2"));
            textBox8.Text = Convert.ToString(Convert.ToDouble(q1_max_НеравРасп_Нагрузка).ToString("N2"));
            textBox7.Text = Convert.ToString(Convert.ToDouble(q1_min_НеравРасп_Нагрузка).ToString("N2"));


            ZedGraph1 = zedGraphControl1;
            GraphPane pane = ZedGraph1.GraphPane;
            ZedGraph1.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Эпюра поперечных сил, Qy";
            pane.XAxis.Title.Text = "l, [м]";
            pane.YAxis.Title.Text = "Qy, [кН]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            ZedGraph2 = zedGraphControl2;
            pane = ZedGraph2.GraphPane;
            ZedGraph2.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Эпюра изгибающих моментов, Mx";
            pane.XAxis.Title.Text = "l, [м]";
            pane.YAxis.Title.Text = "Mx, [кН*м]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            ZedGraph3 = zedGraphControl3;
            pane = ZedGraph3.GraphPane;
            ZedGraph3.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Прогиб срединной линии балки - w(z)";
            pane.XAxis.Title.Text = "l, [м]";
            pane.YAxis.Title.Text = "w, [мм]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            ZedGraph5 = zedGraphControl5;
            pane = ZedGraph5.GraphPane;
            ZedGraph5.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Прогиб срединной линии балки - w(z)";
            pane.XAxis.Title.Text = "l, [м]";
            pane.YAxis.Title.Text = "w, [мм]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            ZedGraph4 = zedGraphControl4;
            pane = ZedGraph4.GraphPane;
            ZedGraph4.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Угол поворота балки";
            pane.XAxis.Title.Text = "l, [м]";
            pane.YAxis.Title.Text = "Угол поворота, [град]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            ZedGraph6 = zedGraphControl6;
            pane = ZedGraph6.GraphPane;
            ZedGraph6.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Угол поворота балки";
            pane.XAxis.Title.Text = "l, [м]";
            pane.YAxis.Title.Text = "Угол поворота, [град]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            ZedGraph7 = zedGraphControl7;
            pane = ZedGraph7.GraphPane;
            ZedGraph7.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Изменение максимального прогиба f от нагрузки";
            pane.XAxis.Title.Text = "Нагрузка P, [кН]";
            pane.YAxis.Title.Text = "f, [мм]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            ZedGraph8 = zedGraphControl8;
            pane = ZedGraph8.GraphPane;
            ZedGraph8.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Изменение максимального угла поворота от нагрузки";
            pane.XAxis.Title.Text = "Нагрузка P, [кН]";
            pane.YAxis.Title.Text = "Угол поворота, [град]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            ZedGraph9 = zedGraphControl9;
            pane = ZedGraph9.GraphPane;
            ZedGraph9.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Изменение максимального напряжения от нагрузки";
            pane.XAxis.Title.Text = "Нагрузка P, [кН]";
            pane.YAxis.Title.Text = "Напряжение, [Па]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;

            ZedGraph10 = zedGraphControl10;
            pane = ZedGraph10.GraphPane;
            ZedGraph10.RestoreScale(pane);
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.Title.Text = "Зависимость габаритных размеров полого сечения балки";
            pane.XAxis.Title.Text = "Нпол, [мм]";
            pane.YAxis.Title.Text = "Впол, [мм]";
            pane.XAxis.MajorGrid.DashOn = 10;
            pane.XAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.DashOn = 10;
            pane.YAxis.MajorGrid.DashOff = 5;
            pane.YAxis.MinorGrid.IsVisible = true;
            pane.YAxis.MinorGrid.DashOn = 1;
            pane.YAxis.MinorGrid.DashOff = 2;
            pane.XAxis.MinorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = 2;
        }
    }
}
