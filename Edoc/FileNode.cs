using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSizeVisualizer.Edoc
{
    class FileNode : Edocument
    {
        FileInfo file;
        public FileNode(string path) : base(path)
        {
            file = new FileInfo(path);
        }
        
        public override double getSize()
        {
            return file.Length /(double) (1024 * 1024); //coverting to bytes;
            
        }
    }
}
