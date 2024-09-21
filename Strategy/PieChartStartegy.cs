using FolderSizeVisualizer.Edoc;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.Measure;

namespace FolderSizeVisualizer.Strategy
{
    internal class PieChartStartegy : ChartingStrategy
    {
       

        public void Draw(List<Edocument> list, Graphics graphics, PictureBox pictureBox)
        {
            pictureBox.Dock = DockStyle.Fill;
            
            ISeries[] series = new ISeries[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                
                series[i] = new PieSeries<double>
                {
                    Values = new double[] { Math.Round(list[i].getSize(), 4) },
                    Name = list[i].Text,
                    
                };
                
            }
            
            PieChart pieChart1 = new PieChart();
            pieChart1.Series = series;
            
            pieChart1.LegendPosition = LegendPosition.Right;
            
            pieChart1.Dock = DockStyle.Fill;
            pictureBox.Controls.Add(pieChart1);
            
        }
    }

}

