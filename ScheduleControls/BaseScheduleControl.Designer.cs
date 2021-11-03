/*
    Copyright 2011 Yogesh khandala
 
    This file is part of Syd.ScheduleControls.

    Syd.ScheduleControls is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Syd.ScheduleControls is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with Syd.ScheduleControls.  If not, see <http://www.gnu.org/licenses/>.
*/
using System.Windows.Forms;
using Syd.ScheduleControls.Grid;

namespace Syd.ScheduleControls
{
    partial class BaseScheduleControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseScheduleControl));
            this.pbDrag = new System.Windows.Forms.PictureBox();
            this.hiddenGrid = new Syd.ScheduleControls.Grid.HiddenGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDrag
            // 
            this.pbDrag.Image = ((System.Drawing.Image)(resources.GetObject("pbDrag.Image")));
            this.pbDrag.Location = new System.Drawing.Point(146, 58);
            this.pbDrag.Name = "pbDrag";
            this.pbDrag.Size = new System.Drawing.Size(21, 14);
            this.pbDrag.TabIndex = 0;
            this.pbDrag.TabStop = false;
            this.pbDrag.Visible = false;
            // 
            // hiddenGrid
            // 
            this.hiddenGrid.AutoGenerateColumns = false;
            this.hiddenGrid.Location = new System.Drawing.Point(0, 0);
            this.hiddenGrid.MultiSelect = false;
            this.hiddenGrid.Name = "hiddenGrid";
            this.hiddenGrid.ReadOnly = true;
            this.hiddenGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.hiddenGrid.ShowEditingIcon = false;
            this.hiddenGrid.Size = new System.Drawing.Size(1, 1);
            this.hiddenGrid.TabIndex = 1;
            // 
            // BaseScheduleControl
            // 
            this.Controls.Add(this.pbDrag);
            this.Controls.Add(this.hiddenGrid);
            //this.Controls.Add(this.toolTip);
            this.Name = "Schedule";
            this.Size = new System.Drawing.Size(525, 437);
            ((System.ComponentModel.ISupportInitialize)(this.pbDrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDrag;
        private HiddenGrid hiddenGrid;
    }
}
