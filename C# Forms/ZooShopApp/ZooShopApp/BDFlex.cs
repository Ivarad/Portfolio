using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooShopApp
{
    public partial class BDFlex : Form
    {
        string data;

        private string[] Sales = new string[]
        {"Schedule", "Frequent_visitor_card", "Animal_log", "Animal", "Check", "Sales"};
        private string[] Marketig = new string[]
        {"Schedule", "Advertisement", "Marketing"};
        public BDFlex(string data)
        {
            InitializeComponent();
            this.data = data;
            if(data == "0")
            {
                foreach (var table in Sales)
                {
                    comboBox1.Items.Add(table);
                }
            }
            else
            {
                foreach (var table in Marketig)
                {
                    comboBox1.Items.Add(table);
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Table table = new Table(comboBox1.SelectedItem.ToString());
            table.ShowDialog();
        }

        
    }
}
