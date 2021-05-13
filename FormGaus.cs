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
    public partial class FormGaus : Form
    {
        Table A0Maintable = new Table(true);
        Table P0Maintable = new Table(false);
        Table M0Maintable = new Table(false);
        Table R0Maintable = new Table(true);
        Table A1Maintable = new Table(true);
        Table P1Maintable = new Table(false);
        Table M1Maintable = new Table(false);
        Table R1Maintable = new Table(true);
        Table A2Maintable = new Table(true);
        Table P2Maintable = new Table(false);
        Table M2Maintable = new Table(false);
        Table R2Maintable = new Table(true);
        Table A3Maintable = new Table(true);
        Table P3Maintable = new Table(false);
        Table M3Maintable = new Table(false);
        Table R3Maintable = new Table(true);
        Table R4Maintable = new Table(true);

        public FormGaus()
        {
            InitializeComponent();
            Reslabel.Text = "";
        }

        private void Calcbutton_Click_1(object sender, EventArgs e)
        {
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

                PMatrix(ref P0Maintable, A0Maintable);

                R0Maintable = new Table(A0Maintable.Mnog(P0Maintable), true);
                MMatrix(ref M0Maintable, R0Maintable, 1);

                R0Maintable = new Table(R0Maintable.Mnog(M0Maintable), true);

                Set_Amatrix(A0Maintable);
                Set_Pmatrix(P0Maintable);
                Set_Mmatrix(M0Maintable);
                Set_Rmatrix(R0Maintable);

                //------------------------------------------------------------------------

                A1Maintable = new Table(R0Maintable, true);

                PMatrix(ref P1Maintable, A1Maintable);

                R1Maintable = new Table(A1Maintable.Mnog(P1Maintable), true);
                MMatrix(ref M1Maintable, R1Maintable, 2);

                R1Maintable = new Table(R1Maintable.Mnog(M1Maintable), true);

                //------------------------------------------------------------------------

                A2Maintable = new Table(R1Maintable, true);

                PMatrix(ref P2Maintable, A2Maintable);

                R2Maintable = new Table(A2Maintable.Mnog(P2Maintable), true);
                MMatrix(ref M2Maintable, A2Maintable, 3);

                R2Maintable = new Table(R2Maintable.Mnog(M2Maintable), true);

                //------------------------------------------------------------------------

                A3Maintable = new Table(R2Maintable, true);

                PMatrix(ref P3Maintable, A3Maintable);

                R3Maintable = new Table(A3Maintable.Mnog(P3Maintable), true);
                MMatrix(ref M3Maintable, A3Maintable, 4);

                R3Maintable = new Table(R3Maintable.Mnog(M3Maintable), true);

                //------------------------------------------------------------------------

                if ((Check_matrix(A0Maintable) == 1) ||
                    (Check_matrix(A1Maintable) == 1) ||
                    (Check_matrix(A2Maintable) == 1) ||
                    (Check_matrix(A3Maintable) == 1) ||
                    (Check_matrix(R3Maintable) == 1))
                {
                    Reslabel.Text = "Матриця має безліч розв'язків";
                }
                else if ((Check_matrix(A0Maintable) == -1) ||
                    (Check_matrix(A1Maintable) == -1) ||
                    (Check_matrix(A2Maintable) == -1) ||
                    (Check_matrix(A3Maintable) == -1) ||
                    (Check_matrix(R3Maintable) == -1))
                {
                    Reslabel.Text = "Матриця не має розв'язків";
                }

                //------------------------------------------------------------------------

                R4Maintable = new Table(Final_Countdown(R3Maintable), true);
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
                cnt++;
            }
            while (norm > eps);
            return cnt;
        }

        public void PMatrix(ref Table PMaintable, Table RMaintable)
        {
            bool[] R = new bool[4];
            double b = RMaintable.GetEl(0, 0);
            int id, schet;
            for (int j = 0; j < 4; j++)
            {
                schet = 1;
                id = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (R[i] == true)
                    {
                        continue;
                    }
                    if (schet == 1)
                    {
                        id = i;
                        b = RMaintable.GetEl(i, j);
                        schet = 0;
                    }
                    else if (b < RMaintable.GetEl(i, j))
                    {
                        id = i;
                        b = RMaintable.GetEl(i, j);
                    }
                }
                R[id] = true;
                PMaintable.SetEl(id, j, 1);
            }
        }

        public void MMatrix(ref Table MMaintable, Table RMaintable, int shag)
        {
            MMaintable.SetMatrixE();
            MMaintable.SetEl(shag - 1, shag - 1, 1.0 / RMaintable.GetEl(shag - 1, shag - 1));
            for (int i = shag; i < 4; i++)
            {
                MMaintable.SetEl(i, shag - 1, -(RMaintable.GetEl(i, shag - 1) / RMaintable.GetEl(shag - 1, shag - 1)));
            }
        }

        public int Check_matrix(Table Main)
        {
            for (int i = 1; i < 4; i++)
            {
                if ((Main.GetEl(i, 0) == 0) &&
                    (Main.GetEl(i, 1) == 0) &&
                    (Main.GetEl(i, 2) == 0) &&
                    (Main.GetEl(i, 3) == 0))
                {
                    if (Main.GetEl(i, 4) == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }

        public void Set_Amatrix(Table Main)
        {
            label_element11.Text = Math.Round(Main.GetEl(0, 0), 2).ToString(); label_element12.Text = Math.Round(Main.GetEl(0, 1), 2).ToString(); label_element13.Text = Math.Round(Main.GetEl(0, 2), 2).ToString(); label_element14.Text = Math.Round(Main.GetEl(0, 3), 2).ToString(); label_element15.Text = Math.Round(Main.GetEl(0, 4), 2).ToString();
            label_element21.Text = Math.Round(Main.GetEl(1, 0), 2).ToString(); label_element22.Text = Math.Round(Main.GetEl(1, 1), 2).ToString(); label_element23.Text = Math.Round(Main.GetEl(1, 2), 2).ToString(); label_element24.Text = Math.Round(Main.GetEl(1, 3), 2).ToString(); label_element25.Text = Math.Round(Main.GetEl(1, 4), 2).ToString();
            label_element31.Text = Math.Round(Main.GetEl(2, 0), 2).ToString(); label_element32.Text = Math.Round(Main.GetEl(2, 1), 2).ToString(); label_element33.Text = Math.Round(Main.GetEl(2, 2), 2).ToString(); label_element34.Text = Math.Round(Main.GetEl(2, 3), 2).ToString(); label_element35.Text = Math.Round(Main.GetEl(2, 4), 2).ToString();
            label_element41.Text = Math.Round(Main.GetEl(3, 0), 2).ToString(); label_element42.Text = Math.Round(Main.GetEl(3, 1), 2).ToString(); label_element43.Text = Math.Round(Main.GetEl(3, 2), 2).ToString(); label_element44.Text = Math.Round(Main.GetEl(3, 3), 2).ToString(); label_element45.Text = Math.Round(Main.GetEl(3, 4), 2).ToString();
        }

        public void Set_Pmatrix(Table Main)
        {
            P_label_element11.Text = Main.GetEl(0, 0).ToString(); P_label_element12.Text = Main.GetEl(0, 1).ToString(); P_label_element13.Text = Main.GetEl(0, 2).ToString(); P_label_element14.Text = Main.GetEl(0, 3).ToString();
            P_label_element21.Text = Main.GetEl(1, 0).ToString(); P_label_element22.Text = Main.GetEl(1, 1).ToString(); P_label_element23.Text = Main.GetEl(1, 2).ToString(); P_label_element24.Text = Main.GetEl(1, 3).ToString();
            P_label_element31.Text = Main.GetEl(2, 0).ToString(); P_label_element32.Text = Main.GetEl(2, 1).ToString(); P_label_element33.Text = Main.GetEl(2, 2).ToString(); P_label_element34.Text = Main.GetEl(2, 3).ToString();
            P_label_element41.Text = Main.GetEl(3, 0).ToString(); P_label_element42.Text = Main.GetEl(3, 1).ToString(); P_label_element43.Text = Main.GetEl(3, 2).ToString(); P_label_element44.Text = Main.GetEl(3, 3).ToString();
        }

        public void Set_Mmatrix(Table Main)
        {
            M_label_element11.Text = Math.Round(Main.GetEl(0, 0), 2).ToString(); M_label_element12.Text = Math.Round(Main.GetEl(0, 1), 2).ToString(); M_label_element13.Text = Math.Round(Main.GetEl(0, 2), 2).ToString(); M_label_element14.Text = Math.Round(Main.GetEl(0, 3), 2).ToString();
            M_label_element21.Text = Math.Round(Main.GetEl(1, 0), 2).ToString(); M_label_element22.Text = Math.Round(Main.GetEl(1, 1), 2).ToString(); M_label_element23.Text = Math.Round(Main.GetEl(1, 2), 2).ToString(); M_label_element24.Text = Math.Round(Main.GetEl(1, 3), 2).ToString();
            M_label_element31.Text = Math.Round(Main.GetEl(2, 0), 2).ToString(); M_label_element32.Text = Math.Round(Main.GetEl(2, 1), 2).ToString(); M_label_element33.Text = Math.Round(Main.GetEl(2, 2), 2).ToString(); M_label_element34.Text = Math.Round(Main.GetEl(2, 3), 2).ToString();
            M_label_element41.Text = Math.Round(Main.GetEl(3, 0), 2).ToString(); M_label_element42.Text = Math.Round(Main.GetEl(3, 1), 2).ToString(); M_label_element43.Text = Math.Round(Main.GetEl(3, 2), 2).ToString(); M_label_element44.Text = Math.Round(Main.GetEl(3, 3), 2).ToString();
        }

        public void Set_Rmatrix(Table Main)
        {
            R_label_element11.Text = Math.Round(Main.GetEl(0, 0), 2).ToString(); R_label_element12.Text = Math.Round(Main.GetEl(0, 1), 2).ToString(); R_label_element13.Text = Math.Round(Main.GetEl(0, 2), 2).ToString(); R_label_element14.Text = Math.Round(Main.GetEl(0, 3), 2).ToString(); R_label_element15.Text = Math.Round(Main.GetEl(0, 4), 2).ToString();
            R_label_element21.Text = Math.Round(Main.GetEl(1, 0), 2).ToString(); R_label_element22.Text = Math.Round(Main.GetEl(1, 1), 2).ToString(); R_label_element23.Text = Math.Round(Main.GetEl(1, 2), 2).ToString(); R_label_element24.Text = Math.Round(Main.GetEl(1, 3), 2).ToString(); R_label_element25.Text = Math.Round(Main.GetEl(1, 4), 2).ToString();
            R_label_element31.Text = Math.Round(Main.GetEl(2, 0), 2).ToString(); R_label_element32.Text = Math.Round(Main.GetEl(2, 1), 2).ToString(); R_label_element33.Text = Math.Round(Main.GetEl(2, 2), 2).ToString(); R_label_element34.Text = Math.Round(Main.GetEl(2, 3), 2).ToString(); R_label_element35.Text = Math.Round(Main.GetEl(2, 4), 2).ToString();
            R_label_element41.Text = Math.Round(Main.GetEl(3, 0), 2).ToString(); R_label_element42.Text = Math.Round(Main.GetEl(3, 1), 2).ToString(); R_label_element43.Text = Math.Round(Main.GetEl(3, 2), 2).ToString(); R_label_element44.Text = Math.Round(Main.GetEl(3, 3), 2).ToString(); R_label_element45.Text = Math.Round(Main.GetEl(3, 4), 2).ToString();
        }

        public Table Final_Countdown(Table Main)
        {
            Table Res = new Table(Main, true);
            Res.SetEl(2, 4, Res.GetEl(2, 4) - Res.GetEl(2, 3) * Res.GetEl(3, 4));
            Res.SetEl(1, 4, Res.GetEl(1, 4) - Res.GetEl(1, 3) * Res.GetEl(3, 4) - Res.GetEl(1, 2) * Res.GetEl(2, 4));
            Res.SetEl(0, 4, Res.GetEl(0, 4) - Res.GetEl(0, 3) * Res.GetEl(3, 4) - Res.GetEl(0, 2) * Res.GetEl(2, 4) - Res.GetEl(0, 1) * Res.GetEl(1, 4));
            Res.SetEl(0, 3, 0); Res.SetEl(0, 2, 0); Res.SetEl(0, 1, 0);
            Res.SetEl(1, 3, 0); Res.SetEl(1, 2, 0);
            Res.SetEl(2, 3, 0);
            return Res;
        }

        private void button_step_1_Click(object sender, EventArgs e)
        {
            MatrixName1A.Text = "A0 = ";
            MatrixName1P.Text = "P0 = ";
            MatrixName1M.Text = "M0 = ";
            MatrixName1R.Text = "R0 = M0*P0*A0 =";
            Set_Amatrix(A0Maintable);
            Set_Pmatrix(P0Maintable);
            Set_Mmatrix(M0Maintable);
            Set_Rmatrix(R0Maintable);
        }

        private void button_step_2_Click(object sender, EventArgs e)
        {
            MatrixName1A.Text = "A1 = ";
            MatrixName1P.Text = "P1 = ";
            MatrixName1M.Text = "M1 = ";
            MatrixName1R.Text = "R1 = M1*P1*A1 =";
            Set_Amatrix(A1Maintable);
            Set_Pmatrix(P1Maintable);
            Set_Mmatrix(M1Maintable);
            Set_Rmatrix(R1Maintable);
        }

        private void button_step_3_Click(object sender, EventArgs e)
        {
            MatrixName1A.Text = "A2 = ";
            MatrixName1P.Text = "P2 = ";
            MatrixName1M.Text = "M2 = ";
            MatrixName1R.Text = "R2 = M2*P2*A2 =";
            Set_Amatrix(A2Maintable);
            Set_Pmatrix(P2Maintable);
            Set_Mmatrix(M2Maintable);
            Set_Rmatrix(R2Maintable);
        }

        private void button_step_4_Click(object sender, EventArgs e)
        {
            MatrixName1A.Text = "A3 = ";
            MatrixName1P.Text = "P3 = ";
            MatrixName1M.Text = "M3 = ";
            MatrixName1R.Text = "R3 = M3*P3*A3 =";
            Set_Amatrix(A3Maintable);
            Set_Pmatrix(P3Maintable);
            Set_Mmatrix(M3Maintable);
            Set_Rmatrix(R3Maintable);
        }

        private void button_step_5_Click(object sender, EventArgs e)
        {
            MatrixName1A.Text = "A3 = ";
            MatrixName1P.Text = "P3 = ";
            MatrixName1M.Text = "M3 = ";
            MatrixName1R.Text = "Фін. перетвор. =";
            Set_Amatrix(A3Maintable);
            Set_Pmatrix(P3Maintable);
            Set_Mmatrix(M3Maintable);
            Set_Rmatrix(R4Maintable);
        }

        //private void прикладякийМаєОдинРозвязокToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    element11.Text = 3.ToString(); element12.Text = 2.ToString(); element13.Text = 5.ToString(); element14.Text = 1.ToString(); element15.Text = 1.ToString();
        //    element21.Text = 1.ToString(); element22.Text = 6.ToString(); element23.Text = 6.ToString(); element24.Text = 2.ToString(); element25.Text = 2.ToString();
        //    element31.Text = 1.ToString(); element32.Text = 2.ToString(); element33.Text = 7.ToString(); element34.Text = 3.ToString(); element35.Text = 3.ToString();
        //    element41.Text = 2.ToString(); element42.Text = 4.ToString(); element43.Text = 15.ToString(); element44.Text = 6.ToString(); element45.Text = 6.ToString();
        //}

        //private void прикладякийМаєБезлічРозвязківToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    element11.Text = 3.ToString(); element12.Text = 2.ToString(); element13.Text = 5.ToString(); element14.Text = 1.ToString(); element15.Text = 1.ToString();
        //    element21.Text = 1.ToString(); element22.Text = 6.ToString(); element23.Text = 6.ToString(); element24.Text = 2.ToString(); element25.Text = 2.ToString();
        //    element31.Text = 1.ToString(); element32.Text = 2.ToString(); element33.Text = 7.ToString(); element34.Text = 3.ToString(); element35.Text = 3.ToString();
        //    element41.Text = 2.ToString(); element42.Text = 4.ToString(); element43.Text = 14.ToString(); element44.Text = 6.ToString(); element45.Text = 6.ToString();
        //}

        private void прикладякийНеМаєРозвязківToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            element11.Text = 3.ToString(); element12.Text = 2.ToString(); element13.Text = 5.ToString(); element14.Text = 1.ToString(); element15.Text = 1.ToString();
            element21.Text = 1.ToString(); element22.Text = 6.ToString(); element23.Text = 6.ToString(); element24.Text = 2.ToString(); element25.Text = 2.ToString();
            element31.Text = 1.ToString(); element32.Text = 2.ToString(); element33.Text = 7.ToString(); element34.Text = 3.ToString(); element35.Text = 3.ToString();
            element41.Text = 2.ToString(); element42.Text = 4.ToString(); element43.Text = 14.ToString(); element44.Text = 6.ToString(); element45.Text = 7.ToString();
        }

        private void прикладякийМаєОдинРозвязокToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            element11.Text = 3.ToString(); element12.Text = 2.ToString(); element13.Text = 5.ToString(); element14.Text = 1.ToString(); element15.Text = 1.ToString();
            element21.Text = 1.ToString(); element22.Text = 6.ToString(); element23.Text = 6.ToString(); element24.Text = 2.ToString(); element25.Text = 2.ToString();
            element31.Text = 1.ToString(); element32.Text = 2.ToString(); element33.Text = 7.ToString(); element34.Text = 3.ToString(); element35.Text = 3.ToString();
            element41.Text = 2.ToString(); element42.Text = 4.ToString(); element43.Text = 15.ToString(); element44.Text = 6.ToString(); element45.Text = 6.ToString();
        }

        private void прикладякийМаєБезлічРозвязківToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            element11.Text = 3.ToString(); element12.Text = 2.ToString(); element13.Text = 5.ToString(); element14.Text = 1.ToString(); element15.Text = 1.ToString();
            element21.Text = 1.ToString(); element22.Text = 6.ToString(); element23.Text = 6.ToString(); element24.Text = 2.ToString(); element25.Text = 2.ToString();
            element31.Text = 1.ToString(); element32.Text = 2.ToString(); element33.Text = 7.ToString(); element34.Text = 3.ToString(); element35.Text = 3.ToString();
            element41.Text = 2.ToString(); element42.Text = 4.ToString(); element43.Text = 14.ToString(); element44.Text = 6.ToString(); element45.Text = 6.ToString();
        }

        private void прикладякийНеМаєРозвязківToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

    //public class Table
    //{
    //    double[,] table = { };
    //    public Table(bool is_rosch)
    //    {
    //        if (is_rosch == false)
    //            table = new double[4, 4];
    //        else
    //            table = new double[4, 5];
    //    }
    //    public Table(Table Main, bool is_rosch)
    //    {
    //        if (is_rosch == false)
    //            table = new double[4, 4];
    //        else
    //            table = new double[4, 5];
    //        for (int i = 0; i < 4; i++)
    //        {
    //            for (int j = 0; j < 5; j++)
    //            {
    //                table[i, j] = Main.GetEl(i, j);
    //            }
    //        }
    //    }
    //    public void SetEl(int i, int j, double a)
    //    {
    //        table[i, j] = a;
    //        return;
    //    }
    //    public double GetEl(int i, int j)
    //    {
    //        return table[i, j];
    //    }
    //    public void SetMatrixE()
    //    {
    //        table[0, 0] = 1;
    //        table[1, 1] = 1;
    //        table[2, 2] = 1;
    //        table[3, 3] = 1;
    //    }
    //    public Table Mnog(Table Atable)
    //    {
    //        Table Resulttable = new Table(true);
    //        for (int i = 0; i < 4; i++)
    //        {
    //            for (int j = 0; j < 5; j++)
    //            {
    //                Resulttable.SetEl(i, j, (table[0, j] * Atable.GetEl(i, 0) +
    //                    table[1, j] * Atable.GetEl(i, 1) +
    //                    table[2, j] * Atable.GetEl(i, 2) +
    //                    table[3, j] * Atable.GetEl(i, 3)));
    //            }
    //        }
    //        return Resulttable;
    //    }
    //}
}
