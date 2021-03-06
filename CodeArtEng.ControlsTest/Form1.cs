﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CodeArtEng.Controls;
using System.Drawing.Design;

namespace CodeArtEng.ControlsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fileExplorer1.AttachToMyComputer();
            fileExplorer1.FileDoubleClicked += new EventHandler<CodeArtEng.Controls.FileExplorerEventArgs>(fileExplorer1_FileDoubleClicked);
            propertyGrid1.SelectedObject = new PropertyGridTest();
        }

        void fileExplorer1_FileDoubleClicked(object sender, Controls.FileExplorerEventArgs e)
        {
            Debug.WriteLine("File double clicked.");
            Debug.WriteLine("Files:");
            string[] files = fileExplorer1.SelectedFiles();
            foreach (string ptrFile in files) Debug.WriteLine(ptrFile);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static int ID = 0;
        private void addRecentFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMruList1.AddRecentFileToMruList("C:\\Test_" + ID.ToString() + ".txt");
            ID++;
        }

        private void toolStripMruList1_RecentFileClicked(object sender, Controls.RecentFileClickedEventArgs e)
        {
            MessageBox.Show(e.FileName + " clicked.");
        }

        private void openFilePanel1_TextChanged(object sender, EventArgs e)
        {
            Trace.WriteLine("Text Changed: " + openFilePanel1.SelectedFile);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            multiLineButton1.Enabled = !multiLineButton1.Enabled;
        }

        private void badge1_Click(object sender, EventArgs e)
        {
        }

        private void multiLineButton2_Click(object sender, EventArgs e)
        {
            multiLineButton2.Image = Properties.Resources.CAELogoSmall;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Text :" + hintedTextBox1.Text;
        }
    }

    public class PropertyGridTest
    {
        [Editor(typeof(TimePickerEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(DateTimeConverter2))]
        public DateTime TimePicker_DateTime { get; set; }
    }

}
