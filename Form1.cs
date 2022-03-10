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
            public int Quantity { get; set; }

            public Food(string name, decimal price, int quantity)
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

            string newFoodName = textBox1.Text;
            string newFoodPrice = textBox3.Text;
            string newFoodQuantity = textBox2.Text;

            Food newFood = new Food(newFoodName, decimal.Parse(newFoodPrice),int.Parse(newFoodQuantity));
            Foods.Add(newFood);

            foreach(Food food in Foods)
            {
                listBox1.Items.Add(food.Name + " " + food.Price.ToString() + "руб. " + food.Quantity.ToString() + " шт.");
            }
        }
    }
}
