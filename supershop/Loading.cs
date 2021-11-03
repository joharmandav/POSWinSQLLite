using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supershop
{
    public partial class Loading : Form
    {
        public Loading(int X,int Y)
        {
            InitializeComponent();
            //X = X - (this.Width / 2);
            //Y = Y - (this.Height / 2);
            this.SetDesktopLocation(X, Y);
        }

    }
}
