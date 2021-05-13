using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch_m_Lab_2_1_method_gaus
{
    public partial class FormYakobi : Form
    {
        double[] First_yakobi = new double[4];
        double[] Nextt_yakobi = new double[4];
        Table A0Maintable = new Table(true);
        public FormYakobi()
        {
            InitializeComponent();
        }

        private void Calcbutton_Click(object sender, EventArgs e)
        {
            double ksi = Convert.ToDouble(Ksi_textBox.Text);
            A0Maintable.SetEl(0, 0, Convert.ToDouble(element11.Text));
            A0Maintable.SetEl(0, 1, Convert.ToDouble(element12.Text));
            A0Maintable.SetEl(0, 2, Convert.ToDouble(element13.Text));
            A0Maintable.SetEl(0, 3, Convert.ToDouble(element14.Text));
            A0Maintable.SetEl(1, 0, Convert.ToDouble(element21.Text));
            A0Maintable.SetEl(1, 1, Convert.ToDouble(element22.Text));
            A0Maintable.SetEl(1, 2, Convert.ToDouble(element23.Text));
            A0Maintable.SetEl(1, 3, Convert.ToDouble(element24.Text));
            A0Maintable.SetEl(2, 0, Convert.ToDouble(element31.Text));
            A0Maintable.SetEl(2, 1, Convert.ToDouble(element32.Text));
            A0Maintable.SetEl(2, 2, Convert.ToDouble(element33.Text));
            A0Maintable.SetEl(2, 3, Convert.ToDouble(element34.Text));
            A0Maintable.SetEl(3, 0, Convert.ToDouble(element41.Text));
            A0Maintable.SetEl(3, 1, Convert.ToDouble(element42.Text));
            A0Maintable.SetEl(3, 2, Convert.ToDouble(element43.Text));
            A0Maintable.SetEl(3, 3, Convert.ToDouble(element44.Text));

            A0Maintable.SetEl(0, 4, Convert.ToDouble(element15.Text));
            A0Maintable.SetEl(1, 4, Convert.ToDouble(element25.Text));
            A0Maintable.SetEl(2, 4, Convert.ToDouble(element35.Text));
            A0Maintable.SetEl(3, 4, Convert.ToDouble(element45.Text));

            element11.Visible = false; element12.Visible = false; element13.Visible = false; element14.Visible = false; element15.Visible = false;
            element21.Visible = false; element22.Visible = false; element23.Visible = false; element24.Visible = false; element25.Visible = false;
            element31.Visible = false; element32.Visible = false; element33.Visible = false; element34.Visible = false; element35.Visible = false;
            element41.Visible = false; element42.Visible = false; element43.Visible = false; element44.Visible = false; element45.Visible = false;
            skobka1.Visible = false; skobka2.Visible = false; ravno3.Visible = false; skobka4.Visible = false; skobka5.Visible = false;
            Calcbutton.Visible = false;

            if (Is_Jacobi(A0Maintable) == false)
            {
                Result_label.Text = "Метод Якобі не збігається";
            }
            else
            {
                double x1e = 1 / A0Maintable.GetEl(0, 0),
                    x2e = 1 / A0Maintable.GetEl(1, 1),
                    x3e = 1 / A0Maintable.GetEl(2, 2),
                    x4e = 1 / A0Maintable.GetEl(3, 3);

                x1_label.Text += Math.Round(x1e, 3).ToString();
                x1_label.Text += "((";
                x1_label.Text += A0Maintable.GetEl(0, 1).ToString();
                x1_label.Text += "x(2, n)) + (";
                x1_label.Text += A0Maintable.GetEl(0, 2).ToString();
                x1_label.Text += "x(3, n)) + (";
                x1_label.Text += A0Maintable.GetEl(0, 3).ToString();
                x1_label.Text += "x(4, n)) + (";
                x1_label.Text += A0Maintable.GetEl(0, 4).ToString();
                x1_label.Text += "))";

                x2_label.Text += Math.Round(x2e, 3).ToString();
                x2_label.Text += "((";
                x2_label.Text += A0Maintable.GetEl(1, 0).ToString();
                x2_label.Text += "x(1, n)) + (";
                x2_label.Text += A0Maintable.GetEl(1, 2).ToString();
                x2_label.Text += "x(3, n)) + (";
                x2_label.Text += A0Maintable.GetEl(1, 3).ToString();
                x2_label.Text += "x(4, n)) + (";
                x2_label.Text += A0Maintable.GetEl(1, 4).ToString();
                x2_label.Text += "))";

                x3_label.Text += Math.Round(x3e, 3).ToString();
                x3_label.Text += "((";
                x3_label.Text += A0Maintable.GetEl(2, 0).ToString();
                x3_label.Text += "x(1, n)) + (";
                x3_label.Text += A0Maintable.GetEl(2, 1).ToString();
                x3_label.Text += "x(2, n)) + (";
                x3_label.Text += A0Maintable.GetEl(2, 3).ToString();
                x3_label.Text += "x(4, n)) + (";
                x3_label.Text += A0Maintable.GetEl(2, 4).ToString();
                x3_label.Text += "))";

                x4_label.Text += Math.Round(x4e, 3).ToString();
                x4_label.Text += "((";
                x4_label.Text += A0Maintable.GetEl(3, 0).ToString();
                x4_label.Text += "x(1, n)) + (";
                x4_label.Text += A0Maintable.GetEl(3, 1).ToString();
                x4_label.Text += "x(2, n)) + (";
                x4_label.Text += A0Maintable.GetEl(3, 2).ToString();
                x4_label.Text += "x(3, n)) + (";
                x4_label.Text += A0Maintable.GetEl(3, 4).ToString();
                x4_label.Text += "))";

                Rst_label.Text += Jacobi(A0Maintable, ref Nextt_yakobi, 0.0001).ToString();
                Result_label.Text += "(";
                Result_label.Text += Math.Round(Nextt_yakobi[0], 3).ToString();
                Result_label.Text += "; ";
                Result_label.Text += Math.Round(Nextt_yakobi[1], 3).ToString();
                Result_label.Text += "; ";
                Result_label.Text += Math.Round(Nextt_yakobi[2], 3).ToString();
                Result_label.Text += "; ";
                Result_label.Text += Math.Round(Nextt_yakobi[3], 3).ToString();
                Result_label.Text += ")";
            }
        }

        public bool Is_Jacobi(Table Maintable)
        {
            double res;
            for (int i = 0; i < 4; i++)
            {
                res = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (i != j)
                    {
                        res += Math.Abs(Maintable.GetEl(i, j));
                    }
                }
                if (Maintable.GetEl(i, i) < res)
                    return false;
            }
            return true;
        }

        public int Jacobi(Table Maintable, ref double[] Nextt_yakobi, double eps)
        {
            int N = 4;
            double norm;
            double[] TempX = new double[N];
            for (int k = 0; k < N; k++)
                TempX[k] = Nextt_yakobi[k];
            int cnt = 0;
            do
            {
                for (int i = 0; i < N; i++)
                {
                    TempX[i] = Maintable.GetEl(i, 4);
                    for (int g = 0; g < N; g++)
                        if (i != g)
                            TempX[i] -= Maintable.GetEl(i, g) * Nextt_yakobi[g];
                    TempX[i] /= Maintable.GetEl(i, i);
                }
                norm = Math.Abs(Nextt_yakobi[0] - TempX[0]);
                for (int h = 0; h < N; h++)
                {
                    if (Math.Abs(Nextt_yakobi[h] - TempX[h]) > norm)
                        norm = Math.Abs(Nextt_yakobi[h] - TempX[h]);
                    Nextt_yakobi[h] = TempX[h];
                }
                iter_textBox.Text += "(";
                iter_textBox.Text += Math.Round(Nextt_yakobi[0], 3).ToString();
                iter_textBox.Text += "; ";
                iter_textBox.Text += Math.Round(Nextt_yakobi[1], 3).ToString();
                iter_textBox.Text += "; ";
                iter_textBox.Text += Math.Round(Nextt_yakobi[2], 3).ToString();
                iter_textBox.Text += "; ";
                iter_textBox.Text += Math.Round(Nextt_yakobi[3], 3).ToString();
                iter_textBox.Text += ")";
                iter_textBox.Text += "\n";
                cnt++;
            }
            while (norm > eps);
            return cnt;
        }

        private void прикладякийМаєОдинРозвязокToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            element11.Text = 3.ToString(); element12.Text = (-1).ToString(); element13.Text = 1.ToString(); element14.Text = 0.ToString(); element15.Text = 1.ToString();
            element21.Text = (-1).ToString(); element22.Text = 2.ToString(); element23.Text = (0.5).ToString(); element24.Text = 0.ToString(); element25.Text = (1.75).ToString();
            element31.Text = 1.ToString(); element32.Text = (0.5).ToString(); element33.Text = 3.ToString(); element34.Text = 0.ToString(); element35.Text = (2.5).ToString();
            element41.Text = 0.ToString(); element42.Text = 0.ToString(); element43.Text = 0.ToString(); element44.Text = 1.ToString(); element45.Text = 1.ToString();
            Ksi_textBox.Text = (0.0001).ToString();
        }
    }
}
