using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.SalesRagister
{
    public partial class Currency_Shortcuts : UserControl
    {
        public Currency_Shortcuts()
        {
            InitializeComponent();
        }

        //properties        
        public Delegate CoinandNotesFunctionPointer;
        public Delegate NumaricKeypad;

        #region  Coin and Notes
        private void btnCoinOne_Click(object sender, EventArgs e)
        {
            CoinandNotesFunctionPointer.DynamicInvoke("1");
        }

        private void btnCoinTwo_Click(object sender, EventArgs e)
        {
            CoinandNotesFunctionPointer.DynamicInvoke("2");
        }

        private void btnPaper5_Click(object sender, EventArgs e)
        {
            CoinandNotesFunctionPointer.DynamicInvoke("5");
        }

        private void btnPaper10_Click(object sender, EventArgs e)
        {
            CoinandNotesFunctionPointer.DynamicInvoke("10");
        }

        private void btnPaper20_Click(object sender, EventArgs e)
        {
            CoinandNotesFunctionPointer.DynamicInvoke("20");
        }

        private void btnPaper50_Click(object sender, EventArgs e)
        {
            CoinandNotesFunctionPointer.DynamicInvoke("50");
        }

        private void btnPaper100_Click(object sender, EventArgs e)
        {
            CoinandNotesFunctionPointer.DynamicInvoke("100");
        }

        #endregion

        #region Numaric Key pad
        private void btnNum1_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("1");
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("2");
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("3");
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("4");
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("5");
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("6");
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("7");
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("8");
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("9");
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke(".");
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            NumaricKeypad.DynamicInvoke("0");
        }

        private void btnClear_Click(object sender, EventArgs e)
        { 
            CoinandNotesFunctionPointer.DynamicInvoke("XX");
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            CoinandNotesFunctionPointer.DynamicInvoke("BXC");
        }

        #endregion



       
    }
}
