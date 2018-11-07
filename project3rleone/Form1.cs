using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Rob Leone
//COP 2010 - Project 3
//Point of sale application for a retail clothing business
//November 9th, 2017


namespace project3rleone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Initialized inputs
        
        const double DBL_TAX_RATE = .07;

        double dblDiscount = 0;
        double dblSubtotal = 0;
        double dblTotalSavings = 0;
        double dblTaxAmount = 0;
        double dblTotal = 0;

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.btnBlackChokerDress.Image = global::project3rleone.Properties.Resources.ChokerNeckSurpliceSheathDressFrontBtn;
        }//end event handler method

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.btnBlackChokerDress.Image = global::project3rleone.Properties.Resources.ChokerNeckSurpliceSheathDressRearBtn;
        }//end event handler method

        //Takes item cost and item description,  
        private void AddToCartAndCalculations(double dblItemCost, string strString)
        {
            //input
            double dblSavings = 0;

            //process
            DiscountPercent();//returns discount to be applied
            dblSavings = dblItemCost * dblDiscount;//determines item level savings
            dblItemCost = dblItemCost - dblSavings;//updates the item cost after savings

            dblSubtotal = dblSubtotal + dblItemCost;//updates/stores subtotal as new items are added

            dblTotalSavings = dblTotalSavings + dblSavings;//stores the total savings as items are processed 

            dblTaxAmount = dblSubtotal * DBL_TAX_RATE;//updates the amount of taxes to be paid

            dblTotal = dblSubtotal + dblTaxAmount;//updates the shopping cart total

            //output to form
            lstShoppingCart.Items.Add(strString + dblItemCost.ToString("c"));
            

            txtSubtotal.Text = dblSubtotal.ToString("c");
            txtTaxes.Text = dblTaxAmount.ToString("c");
            txtTotal.Text = dblTotal.ToString("c");
            txtTotalSavings.Text = dblTotalSavings.ToString("c");
        }//end method

        //Changes the image to give alternate view of item
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.btnBlackLaceColdShoulderDress.Image = global::project3rleone.Properties.Resources.LacePipedColdShoulderSheathDressRearBtn;
        }//end event handler method

        //Changes the image to give alternate view of item
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.btnBlackLaceColdShoulderDress.Image = global::project3rleone.Properties.Resources.LacePipedColdShoulderSheathDressFrontBtn;
        }//end event handler method

        //Changes the image to give alternate view of item
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            this.btnRibbedColdShoulderDress.Image = global::project3rleone.Properties.Resources.RibbedColdShoulderSweaterDressRearBtn;
        }//end event handler method

        //Changes the image to give alternate view of item
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            this.btnRibbedColdShoulderDress.Image = global::project3rleone.Properties.Resources.RibbedColdShoulderSweaterDressFrontBtn;
        }//end event handler method

        //Changes the image to give alternate view of item
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            this.btnLongSleeveWrapDress.Image = global::project3rleone.Properties.Resources.LongSleeveWrapDressRearBtn;
        }//end event handler method

        //Changes the image to give alternate view of item
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            this.btnLongSleeveWrapDress.Image = global::project3rleone.Properties.Resources.LongSleeveWrapDressFrontBtn;
        }//end event handler method

        //Changes the image to give alternate view of item
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            this.btnMarledRuchedCrewNeckDress.Image = global::project3rleone.Properties.Resources.MarledRuchedCrewNeckSweaterDressRearBtn;
        }//end event handler method

        //Changes the image to give alternate view of item
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            this.btnMarledRuchedCrewNeckDress.Image = global::project3rleone.Properties.Resources.MarledRuchedCrewNeckSweaterDressFrontBtn;
        }//end event handler method

        //Changes the image to give alternate view of item
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            this.btnSilverShoes.Image = global::project3rleone.Properties.Resources.SilverShoesPairBtn;
        }//end event handler method

        //Changes the image to give alternate view of item
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.btnSilverShoes.Image = global::project3rleone.Properties.Resources.SilverShoesSoloBtn;
        }//end event handler method

        //Clears all outputs on form and resets the variables
        private void btnClear_Click(object sender, EventArgs e)
        {
            dblDiscount = 0;
            dblSubtotal = 0;
            dblTotalSavings = 0;
            dblTaxAmount = 0;
            dblTotal = 0;

            lstShoppingCart.Items.Clear();
            txtSubtotal.Clear();
            txtTaxes.Clear();
            txtTotal.Clear();
            txtTotalSavings.Clear();
            
        }//end event handler method

        //Method to exit application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//end event handler method

        //Determines and returns item discount. Resets radio button to None.
        private double DiscountPercent()
        {
            //Determine discount to be applied based on the radio button selected
            if (rbtnMilitaryDiscount20.Checked == true)
                dblDiscount = .2;
            else if (rbtnEmployeeDiscount15.Checked == true)
                dblDiscount = .15;
            else if (rbtnStudentDiscount10.Checked == true)
                dblDiscount = .1;
            else
                dblDiscount = 0;

            //Resets the radio button so that the next time an item is selected the discount will default to 0 as per the request
            rbtnNoDiscount.Checked = true;

            return dblDiscount;
        }//end method

        //Adds item to shopping cart
        private void button1_Click(object sender, EventArgs e)
        {
            string strItemName = "Black Choker Dress @ \t\t";
            double dblItemAmount = 50.00;
            AddToCartAndCalculations(dblItemAmount, strItemName);
        }//end event handler method

        //Adds item to shopping cart
        private void btnBlackLaceColdShoulderDress_Click(object sender, EventArgs e)
        {
            string strItemName = "Black Lace Cold Shoulder Dress @ \t";
            double dblItemAmount = 80.00;
            AddToCartAndCalculations(dblItemAmount, strItemName);
        }//end event handler method

        //Adds item to shopping cart
        private void btnRibbedColdShoulderDress_Click(object sender, EventArgs e)
        {
            string strItemName = "Ribbed Cold Shoulder Dress @ \t";
            double dblItemAmount = 75.00;
            AddToCartAndCalculations(dblItemAmount, strItemName);
        }//end event handler method

        //Adds item to shopping cart
        private void btnLongSleeveWrapDress_Click(object sender, EventArgs e)
        {
            string strItemName = "Long Sleeve Wrap Dress @ \t\t";
            double dblItemAmount = 70.00;
            AddToCartAndCalculations(dblItemAmount, strItemName);
        }//end event handler method

        //Adds item to shopping cart
        private void btnSilverShoes_Click(object sender, EventArgs e)
        {
            string strItemName = "Silver Boots @ \t\t\t";
            double dblItemAmount = 100.00;
            AddToCartAndCalculations(dblItemAmount, strItemName);
        }//end event handler method

        //Adds item to shopping cart
        private void btnMarledRuchedCrewNeckDress_Click(object sender, EventArgs e)
        {
            string strItemName = "Marled Ruched Crew Neck Dress @ \t";
            double dblItemAmount = 60.00;
            AddToCartAndCalculations(dblItemAmount, strItemName);
        }//end event handler method
    }//end class
}//end namespace
