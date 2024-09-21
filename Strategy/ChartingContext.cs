using FolderSizeVisualizer.Edoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSizeVisualizer.Strategy
{
    public class ChartingContext
    {
        private ChartingStrategy strategy;


        public ChartingContext(ChartingStrategy strategy)
        {
            this.strategy = strategy;
        }

        public ChartingStrategy choosingStartegy
        {
            get => default;
            set
            {
            }
        }

        public void DrawChart(List<Edocument> list, Graphics graphics, PictureBox pictureBox)
        {
            strategy.Draw(list, graphics, pictureBox);
        }
    }
}
