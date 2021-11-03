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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Syd.ScheduleControls.Test.Dialog
{
	/// <summary>
	/// Dialog for adding a new appointment.
	/// </summary>
	public partial class NewAppointment : Form
	{
		
		public NewAppointment()
		{
			InitializeComponent();
			
		}

        /// <summary>
        /// Gets or sets the appointment title.
        /// </summary>
        /// <value>
        /// The appointment title.
        /// </value>
		public string AppointmentTitle {get{return this.txtTitle.Text;}set{this.txtTitle.Text=value;}}
        /// <summary>
        /// Gets or sets the appointment date end.
        /// </summary>
        /// <value>
        /// The appointment date end.
        /// </value>
		public DateTime AppointmentDateEnd {get{return this.dtpDateEnd.Value;}set{this.dtpDateEnd.Value=value;}}
        /// <summary>
        /// Gets or sets the appointment date start.
        /// </summary>
        /// <value>
        /// The appointment date start.
        /// </value>
		public DateTime AppointmentDateStart {get{return this.dtpDateStart.Value;}set{this.dtpDateStart.Value=value;}}
		
		void BtnSaveClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtTitle.Text))
			{
				lblValidation.Text="Title is mandatory.";
			}
			else if (dtpDateStart.Value >= dtpDateEnd.Value)
			{
				lblValidation.Text="End date must be after the start date.";
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		void DtpDateStartValueChanged(object sender, EventArgs e)
		{
			if (dtpDateEnd.Value <= dtpDateStart.Value)
			{
				dtpDateEnd.Value = dtpDateStart.Value.AddMinutes(15);
			}
		}
	}
}
