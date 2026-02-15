using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graficadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var area = chart1.ChartAreas[0];

            area.AxisX.Minimum = -5;
            area.AxisX.Maximum = 5;
            area.AxisX.Interval = 1;

            area.AxisY.Minimum = -5;
            area.AxisY.Maximum = 5;
            area.AxisY.Interval = 1;

            area.AxisX.Crossing = 0;
            area.AxisY.Crossing = 0;

            area.AxisX.MajorGrid.LineColor = Color.Gray;
            area.AxisY.MajorGrid.LineColor = Color.Gray;


            DibujarPlanoBase();


        }
        private void DibujarPlanoBase()
        {
            
            var ejeX = new Series("EjeX")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 1,
                Color = Color.Gray
            };

            ejeX.Points.AddXY(-5, 0);
            ejeX.Points.AddXY(5, 0);

         
            var ejeY = new Series("EjeY")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 1,
                Color = Color.Gray
            };

            ejeY.Points.AddXY(0, -5);
            ejeY.Points.AddXY(0, 5);

            chart1.Series.Add(ejeX);
            chart1.Series.Add(ejeY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String formula = txtExpresion.Text;

            if (chart1.Series.IndexOf("Resultado") != -1)
            {
                chart1.Series.Remove(chart1.Series["Resultado"]);
            }

            var serie = new Series("Resultado")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2
            };

            try
            {
                Expression expression = new Expression(formula);


                for (double x = -5; x <= 5; x += 0.01)
                {
                    expression.Parameters["x"] = x;



                    object resultado = expression.Evaluate();
                  double y = Convert.ToDouble(resultado);

                    serie.Points.AddXY(x, y);
                }

                chart1.Series.Add(serie);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la formula " + ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtExpresion.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = txtExpresion.Text + "Sqrt()";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = txtExpresion.Text + "Sin(x)";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = txtExpresion.Text + "Cos(x)";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = txtExpresion.Text + "Tan(x)";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = txtExpresion.Text + "Asin(x)";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = txtExpresion.Text + "Acos(x)";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = txtExpresion.Text + "Atan(x)";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = txtExpresion.Text + "Log(,10)";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = txtExpresion.Text + "Exp(x)";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = "Pow(" + txtExpresion.Text + ",2)";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtExpresion.Text = "Pow("+  txtExpresion.Text + ",)";
        }

    }
}
