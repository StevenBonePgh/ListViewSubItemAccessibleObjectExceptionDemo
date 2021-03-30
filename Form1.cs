using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewSubItemAccessibleObjectExceptionDemo
{
    public partial class Form1 : Form
    {
        private class MyClass
        {
            public string One { get; set; }
            public string Two { get; set; }
        }

        public Form1()
        {
            InitializeComponent();

            var list = new List<MyClass>();
            list.Add( new MyClass { One="Click in this column to crash.", Two = "This Column is safe to click in"});
            list.Add(new MyClass { One = "2nd One", Two = "2nd Two" });
            dataListView1.DataSource = list;
            dataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
