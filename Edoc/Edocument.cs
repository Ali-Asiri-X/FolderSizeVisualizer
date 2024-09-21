using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSizeVisualizer.Edoc
{
    public abstract class Edocument : TreeNode
    {
        //create constructor
        private String path;
        public Edocument(String path) : base(Path.GetFileName(path))
        {
            this.path = path;
        }
        public String getPath()
        {
            return path;
        }
        
        public abstract double getSize();
        

    }
}
