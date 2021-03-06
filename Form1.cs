using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace _1303Test
{
    public partial class Form1 : Form
    {
        public class Food
        {
            private string Name;
            private decimal Price;
            private int Quantity;

            public string name
            {
                get { return Name; }
                set { Name = value; }
            }
            public decimal price
            {
                get { return Price; }
                set { Price = value; }
            }
            public int quantity
            {
                get { return Quantity; }
                set { Quantity = value; }
            }
            public Food(string _name, decimal _price, int _quantity)
            {
                name = _name;
                price = _price;
                quantity = _quantity;
            }
        }
        //список продуктов ТУТ!!!! spisokOchenNuzhnoyIVkusnoyEdi
        List<Food> Foods = new List<Food>();
        public Form1()
        {
            InitializeComponent();
        }
        public decimal PriceCount(List<Food> listToCount) //method to count price of all food
        {
            decimal sum = 0;
            foreach (Food _food in listToCount)
            {
                sum += _food.price * _food.quantity;
            }
            label4.Text = "Итоговая стоимость: " + sum.ToString();
            return sum;
        }
        private void button1_Click(object sender, EventArgs e)//add
        {
            string newFoodName = textBox1.Text;
            int quantity;
            decimal price;
            if (textBox1.Text.Length > 0 && int.TryParse(textBox2.Text, out quantity) && decimal.TryParse(textBox3.Text, out price))
            {
                Food newFood = new Food(newFoodName, price, quantity);
                Foods.Add(newFood);
                PrintList(Foods);
                PriceCount(Foods);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
        private void button2_Click(object sender, EventArgs e) //remove
        {
            if (listBox1.SelectedIndex > -1)
            {
                Foods.RemoveAt(listBox1.SelectedIndex);
                PrintList(Foods);
                PriceCount(Foods);
            }
        }
        public void PrintList(List<Food> listToPrint)//method to re-print list
        {
            listBox1.Items.Clear();
            foreach (Food food in listToPrint)
            {
                listBox1.Items.Add(food.name + " " + food.price.ToString() + "руб. " + food.quantity.ToString() + " шт.");
            }
        }
        private void Form1_Load(object sender, EventArgs e)//up, down button symbols
        {
            button3.Text = "\u2191";
            button4.Text = "\u2193";
        }
        private void button3_Click(object sender, EventArgs e)//up
        {
            int index = listBox1.SelectedIndex;
            if (index > 0)
            {
                Foods.Reverse(index - 1, 2);
                PrintList(Foods);
                listBox1.SelectedIndex = index - 1;
            }
        }
        private void button4_Click(object sender, EventArgs e)//down
        {
            int index = listBox1.SelectedIndex;
            if (index > -1 && index < listBox1.Items.Count - 1)
            {
                Foods.Reverse(index, 2);
                PrintList(Foods);
                listBox1.SelectedIndex = index + 1;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)//edit mode
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;

                button5.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;

                if (listBox1.SelectedIndex > -1)
                {

                    textBox4.Text = Foods[listBox1.SelectedIndex].name;
                    textBox5.Text = Foods[listBox1.SelectedIndex].quantity.ToString();
                    textBox6.Text = Foods[listBox1.SelectedIndex].price.ToString();
                }

            }
            else
            {
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;

                button5.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }
        }
        private void button5_Click(object sender, EventArgs e)//edit button
        {
            int quantityE;
            decimal priceE;
            if (listBox1.SelectedIndex > -1)
            {
                if (textBox4.Text.Length > 0 && int.TryParse(textBox5.Text, out quantityE) && decimal.TryParse(textBox6.Text, out priceE))
                {
                    Foods[listBox1.SelectedIndex].name = textBox4.Text;
                    Foods[listBox1.SelectedIndex].quantity = quantityE;
                    Foods[listBox1.SelectedIndex].price = priceE;

                    PrintList(Foods);
                    PriceCount(Foods);
                }
            }
            else
            {
                MessageBox.Show("Не выбран элемент списка");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {//save dialog
            string[] newLines = new string[Foods.Count];
            for (int i = 0; i < Foods.Count; i++)
            {
                newLines[i] = Foods[i].name + ";" + Foods[i].price.ToString()+";"+Foods[i].quantity.ToString();
            }

            File.WriteAllLines("food.txt", newLines);
            MessageBox.Show("Файл записан, БОЛЬШЕ НЕ ТЫКАЙ!!!");

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {//load dialog
            Foods.Clear();
            string[] foodLines = File.ReadAllLines("food.txt");
            for (int i = 0; i < foodLines.Length; i++)
            {
                string[] food1 = foodLines[i].Split(';');
                Food loadedFood = new Food(food1[0],decimal.Parse(food1[1]),int.Parse(food1[2]));
                Foods.Add(loadedFood);
            }
            PrintList(Foods);
            PriceCount(Foods);
        }
    }
}
