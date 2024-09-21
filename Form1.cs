using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System.Drawing;
using System.IO;
using FolderSizeVisualizer.Strategy;
using FolderSizeVisualizer.Edoc;
using System.Windows.Forms;

namespace FolderSizeVisualizer
{
    public partial class Form1 : Form
    {
        ChartingContext chartingContext = new ChartingContext(new BarChartStrategy());
        FolderNode currentSelection;
        public Form1()
        {
            InitializeComponent();
            //
            //commented out the following code to avoid errors, it will cause errors if you run the code on other machines
            //##############################################################################################
            //default folder
            FolderNode parentNode = new FolderNode("D:\\Downloads");
            treeView1.Nodes.Add(parentNode);
            currentSelection = parentNode;
            //
            //##############################################################################################
            //



        }

        public Edocument holds
        {
            get => default;
            set
            {
            }
        }

        public ChartingContext uses
        {
            get => default;
            set
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.ShowNewFolderButton = false;

                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;
                    //print the path
                    DirectoryInfo dirInfo = new DirectoryInfo(selectedFolderPath);
                    // Create a new TreeNode with the selected folder path

                    // Add the node to the TreeView
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(new Edoc.FolderNode(selectedFolderPath));
                }

            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            currentSelection = (Edoc.FolderNode)e.Node;
            pictureBox1.Controls.Clear();
            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chartingContext = new ChartingContext(new PieChartStartegy());
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            chartingContext.DrawChart(currentSelection.getChildren(), e.Graphics, pictureBox1);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Width = panel1.Width;
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chartingContext = new ChartingContext(new BarChartStrategy());
            pictureBox1.Controls.Clear();
            pictureBox1.Invalidate();
        }
    }
}
