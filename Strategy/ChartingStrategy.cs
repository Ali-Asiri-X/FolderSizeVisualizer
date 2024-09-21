using FolderSizeVisualizer.Edoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSizeVisualizer.Strategy
{
    public interface ChartingStrategy
    {
        public void Draw(List<Edocument> list, Graphics graphics,PictureBox pictureBox);
    }
}
