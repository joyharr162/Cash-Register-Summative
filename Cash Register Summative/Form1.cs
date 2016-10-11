using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cash_Register_Summative
{
    public partial class Form1 : Form
    {
        //declare variables and constants
        int orderNumber = 1;
        int ccmQuantity;
        int cmQuantity;
        int bmQuantity;
        double tender;
        double change;
        const double carrotCost = 3.25;
        const double chocChipCost = 3.5;
        const double blueberryCost = 2.9;
        const double tax = .13;

        public Form1()
        {
            InitializeComponent();

            //assign number of each muffin to the appropriate variable
            ccmQuantity = Convert.ToInt16 (chocChipMuffinBox);
            cmQuantity = Convert.ToInt16(carrotMuffinBox);
            bmQuantity = Convert.ToInt16 (blueberryMuffinBox); 
        }

        private void subtotalButton_Click(object sender, EventArgs e)
        {
            //calculate the total before tax
            subtotalLabel.Text = (cmQuantity*carrotCost + ccmQuantity*chocChipCost + bmQuantity*blueberryCost).ToString("0.00");
        }

        private void taxButton_Click(object sender, EventArgs e)
        {
            //calculate tax
            taxLabel.Text = (tax*(cmQuantity*carrotCost + ccmQuantity*chocChipCost + bmQuantity*blueberryCost)).ToString("0.00");
        }

        private void grandTotalButton_Click(object sender, EventArgs e)
        {
            //calculate the total after tax
            grandTotalLabel.Text = (subtotalLabel.Text +taxLabel.Text).ToString("0.00");
        }

        private void receiptButton_Click(object sender, EventArgs e)
        {
            receiptLabel.Text = "Best Muffins EVER\n Order Number" + orderNumber + "October 2016\nChocolate Chip Muffins    " +ccmQuantity +;
        }
    }
}
