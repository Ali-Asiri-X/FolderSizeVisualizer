using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSizeVisualizer.Edoc
{
    class FolderNode : Edocument
    {
        private List<Edocument> children = new List<Edocument>();
        private double size;
        public FolderNode(string path) : base(path)
        {
            
            String[] Directories = Directory.GetDirectories(path);

            foreach (String Directory in Directories)
            {
                FolderNode newNode = new FolderNode(Directory);
                children.Add(newNode);
                Nodes.Add(newNode);
                //get the size of the folder
            }
            String[] files = Directory.GetFiles(path);
            
            foreach (String file in files)
            {
                children.Add(new FileNode(file));
            }
            
            initSize();
        }

        public Edocument contains
        {
            get => default;
            set
            {
            }
        }

        public override double getSize()
        {
            return size;
        }
        private void initSize()
        {
            
            
            size = 0;
            foreach (Edocument child in children)
            {
                size += child.getSize();
                
            }
        }
        public List<Edocument> getChildren()
        {
            return children;
        }
    }
}
