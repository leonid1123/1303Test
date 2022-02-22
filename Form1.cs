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
        public class Food
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }

            public Food(string name, decimal price, decimal quantity)
            {
                Name = name;
                Price = price; 
                Quantity = quantity;
            }
        }
        List<Food> Foods = new List<Food>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Food pechenki = new Food("Печеньки",120,1);
            Food chai = new Food("чай", 170, 2);

            Foods.Add(pechenki);
            Foods.Add(chai);

            foreach(Food food in Foods)
            {
                listBox1.Items.Add(food.Name + " " + food.Price.ToString() + "руб. " + food.Quantity.ToString() + " шт.");
            }

            //listBox1.Items.Add(pechenki.Name +" "+ pechenki.Price.ToString()+"руб. "+pechenki.Quantity.ToString()+" шт.");

            /*string name;
            int quantity;
            int price;
            //repo comment
            name = textBox1.Text.Trim();
            quantity = int.Parse(textBox2.Text);
            price = int.Parse(textBox3.Text);
            sum += price * quantity;


            listBox1.Items.Add(name +" "+ quantity.ToString()+"шт. "+price.ToString()+"руб.");
            label4.Text = "Итоговая стоимость: " + sum.ToString();
            */
        }
    }
}
