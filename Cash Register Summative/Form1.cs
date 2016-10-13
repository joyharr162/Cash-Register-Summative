using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cash_Register_Summative
{
    public partial class Form1 : Form
    {
        //declare variables and constants
        int orderNumber = 1;
        int ccmQuantity;
        int cmQuantity;
        int bmQuantity;
        double change;
        const double CARROTCOST = 3.25;
        const double CHOCCHIPCOST = 3.5;
        const double BLUEBERRYCOST = 2.9;
        const double TAX = .13;

        public Form1()
        {
            InitializeComponent();

            //assign number of each muffin to the appropriate variable
            try
            {
              ccmQuantity = Convert.ToInt16(chocChipMuffinBox);
              cmQuantity = Convert.ToInt16(carrotMuffinBox);
              bmQuantity = Convert.ToInt16(blueberryMuffinBox);
            }
            catch
            {
                //if letters are used, tell user to input integers only
                tryCatchLabel.Text = "Please input integrs only";
            }
        }

        private void subtotalButton_Click(object sender, EventArgs e)
        {
            //calculate the total before tax
            subtotalLabel.Text = (cmQuantity*CARROTCOST + ccmQuantity*CHOCCHIPCOST + bmQuantity*BLUEBERRYCOST).ToString("0.00");
        }

        private void taxButton_Click(object sender, EventArgs e)
        {
            //calculate tax
            taxLabel.Text = (TAX*(cmQuantity*CARROTCOST + ccmQuantity*CHOCCHIPCOST + bmQuantity*BLUEBERRYCOST)).ToString("0.00");
        }

        private void grandTotalButton_Click(object sender, EventArgs e)
        {
            //calculate the total after tax
            grandTotalLabel.Text = Convert.ToString(subtotalLabel.Text +taxLabel.Text);
        }

        private void receiptButton_Click(object sender, EventArgs e)
        {
            //make pens, fonts, etc.
            Font drawFont = new Font("Consolas", 16, FontStyle.Bold);
            Pen receiptPen = new Pen(Color.LightPink, 5);
            SolidBrush receiptBrush = new SolidBrush(Color.Red);
            Graphics formGraphics = this.CreateGraphics();

            //draw receipt
            formGraphics.FillRectangle(receiptBrush, 150, 150, 100, 200);
            Thread.Sleep(500);
            formGraphics.DrawString("Best Muffins Ever\nOrder Nuumber " + orderNumber + " October 2016", drawFont, receiptBrush, 200, 40);
            Thread.Sleep(500);
            formGraphics.DrawString("Chocolate Chip Muffins  " + ccmQuantity + "@ $" + chocChipCost, drawFont, receiptBrush, 200, 60);
            Thread.Sleep(500);
            formGraphics.DrawString("Carrot Muffins          " + cmQuantity + "@ $" + carrotCost, drawFont, receiptBrush, 200, 70);
            Thread.Sleep(500);
            formGraphics.DrawString("Blueberry Muffins       " + bmQuantity + "@ $" + blueberryCost, drawFont, receiptBrush, 200, 80);
            Thread.Sleep(500);
            formGraphics.DrawString("Subtotal                " + ccmQuantity*chocChipCost +cmQuantity*carrotCost +bmQuantity*blueberryCost, drawFont, receiptBrush, 200, 100);
            Thread.Sleep(500);
            formGraphics.DrawString("Tax @ 13%               " + tax*ccmQuantity * chocChipCost + tax*cmQuantity * carrotCost + tax*bmQuantity * blueberryCost, drawFont, receiptBrush, 200, 110);
            Thread.Sleep(500);
            formGraphics.DrawString("Grand Total             " + taxLabel.Text + subtotalLabel.Text ,drawFont, receiptBrush, 200, 120);
            Thread.Sleep(500);
            formGraphics.DrawString("Tendered                " + tenderBox.Text, drawFont, receiptBrush, 200, 130);
            Thread.Sleep(500);

            try
            {
                change = Convert.ToInt16(tenderBox) - Convert.ToInt16(grandTotalLabel);
            }
            catch
            {
                tryCatchLabel.Text = "Please input numbers only";
            }

            formGraphics.DrawString("Change                     " + change, drawFont, receiptBrush, 200, 130);

        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            //clear input and output areas
            carrotMuffinBox.Text = "";
            chocChipMuffinBox.Text = "";
            blueberryMuffinBox.Text = "";
            subtotalLabel.Text = "";
            grandTotalLabel.Text = "";
            taxLabel.Text = "";
            tenderBox.Text = "";


        }
    }
}
