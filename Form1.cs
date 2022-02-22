using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1303Test
{
    public partial class Form1 : Form
    {
        public float sum = 0f;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name;
            int quantity;
            int price;
            //repo comment
            name = textBox1.Text.Trim();
            quantity = int.Parse(textBox2.Text);
            price = int.Parse(textBox3.Text);
            sum += price * quantity;


            listBox1.Items.Add(name +" "+ quantity.ToString()+"шт. "+price.ToString()+"руб.");
            label4.Text = "Итоговая стоимость: " + sum.ToString();
        }
    }
}
