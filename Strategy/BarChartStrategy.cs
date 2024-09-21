using FolderSizeVisualizer.Edoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderSizeVisualizer.Strategy
{
    class BarChartStrategy : ChartingStrategy
    {
        public void Draw(List<Edocument> list, Graphics graphics, PictureBox pictureBox)
        {
            pictureBox.Dock = DockStyle.None;
            int barHeight = 40;
            
            double maxFileSize = GetMaxFileSize(list);
            pictureBox.Height = (list.Count) * 3 * barHeight + 10;
            

            for (int i = 0; i < list.Count; i++)
            {
                double fileSize = list[i].getSize();
                int barWidth = (int)(fileSize / maxFileSize * (pictureBox.Width - 100));
                // Calculate the width of the bar



                // Draw the bar
                if (list[i] is FolderNode)
                    graphics.FillRectangle(Brushes.Blue, 0, i * 3 * barHeight, barWidth, barHeight);
                else
                    graphics.FillRectangle(Brushes.Orange, 0, i * 3 * barHeight, barWidth, barHeight);
                // Draw the file name
                //add the file size to the text
                
                graphics.DrawString(list[i].Text + " (" + Math.Round(fileSize, 4) + " MB)", new Font("Segoe UI Black", 9F, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, 0, (i * 3 + 1) * barHeight);
                
            }
        


            }


        
        private double GetMaxFileSize(List<Edocument> list)
        {
            double maxFileSize = 0;
            foreach (Edocument file in list)
            {
                if (file.getSize() > maxFileSize)
                {
                    maxFileSize = file.getSize();
                }
            }
            return maxFileSize;
        }
    }
}
