using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SorteioGrupos
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSortear_Click(object sender, EventArgs e)
        {
            int qtd;

            if (!string.IsNullOrWhiteSpace(txbQtd.Text))
            {
                lbGrupoA.Items.Clear();
                lbGrupoB.Items.Clear();
                chartEst.Series.Clear();
                chartEst.Legends.Clear();
                qtd = Convert.ToInt32(txbQtd.Text);
                Random r = new Random();
                
                for (int i = 0; i < qtd; i++)
                {
                    //Sorteio laringe d
                    if(r.Next(2) == 1)
                        lbGrupoA.Items.Add("Laringe " + (i+1) + "D");
                    else
                        lbGrupoB.Items.Add("Laringe " + (i + 1) + "D");

                    //Sorteio laringe e
                    if (r.Next(2) == 1)
                        lbGrupoA.Items.Add("Laringe " + (i + 1) + "E");
                    else
                        lbGrupoB.Items.Add("Laringe " + (i + 1) + "E");
                }

                chartEst.Series.Clear();
                chartEst.Legends.Clear();
                chartEst.Legends.Add("MyLegend");
                chartEst.Legends[0].LegendStyle = LegendStyle.Table;
                chartEst.Legends[0].Docking = Docking.Bottom;
                chartEst.Legends[0].Alignment = StringAlignment.Center;
                chartEst.Legends[0].Title = "Soluções";
                chartEst.Legends[0].BorderColor = Color.Black;
                
                string seriesname = "MySeriesName";
                chartEst.Series.Add(seriesname);
                chartEst.Series[seriesname].ChartType = SeriesChartType.Pie;
                chartEst.Series[seriesname].Label = "#PERCENT";
                chartEst.Series[0].LegendText = "#AXISLABEL";
                chartEst.Series[seriesname].Points.AddXY("Formol 10% - " + lbGrupoA.Items.Count, (lbGrupoA.Items.Count * 100) / qtd);
                chartEst.Series[seriesname].Points.AddXY("Glicerina - " + lbGrupoB.Items.Count, (lbGrupoB.Items.Count * 100) / qtd);
            }
                

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            chartEst.Series.Clear();
            chartEst.Legends.Clear();
            lbGrupoA.Items.Clear();
            lbGrupoB.Items.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gabriel Cardoso" + Environment.NewLine + "gcsantos@inf.ufsm.br" + Environment.NewLine +"Universidade Federal de Santa Maria", "Autor");
        }
    }
}
