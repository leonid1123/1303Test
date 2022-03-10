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
        //TODO кнопки вверх и вниз
        //TODO разделить листбокс на 3 столбика
        //TODO поправить инкапсуляцию класса

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
        //список продуктов ТУТ!!!!
        List<Food> Foods = new List<Food>();
        public Form1()
        {
            InitializeComponent();
        }
        public decimal PriceCount(List<Food> listToCount)
        {
            decimal sum = 0;
            foreach (Food _food in listToCount)
            {
                sum += _food.Price * _food.Quantity;
            }
            label4.Text = "Итоговая стоимость: "+sum.ToString();
            return sum;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string newFoodName = textBox1.Text;
            int quantity;
            decimal price;
            if (textBox1.Text.Length > 0 && int.TryParse(textBox2.Text, out quantity) && decimal.TryParse(textBox3.Text, out price))
            {
                Food newFood = new Food(newFoodName, price, quantity);
                Foods.Add(newFood);
                foreach (Food food in Foods)
                {
                    listBox1.Items.Add(food.Name + " " + food.Price.ToString() + "руб. " + food.Quantity.ToString() + " шт.");
                }
                PriceCount(Foods);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex>-1)
            {
                Foods.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                PriceCount(Foods);
            }
        }
    }
}
