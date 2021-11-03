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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Syd.ScheduleControls.Data;
using Syd.ScheduleControls.Region;
using Syd.ScheduleControls.Events;

namespace Syd.ScheduleControls
{
    /// <summary>
    /// The BaseScheduleControl defines properties common to the three schedule controls. 
    /// </summary>
    public  partial class BaseScheduleControl : Control, System.ComponentModel.ISupportInitialize
    {

      	//private ToolTip toolTip;

        /// <summary>
        /// Gets the appointment grid.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected DataGridView AppointmentGrid { get { return hiddenGrid; } }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is dragging an appointment.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is dragging; otherwise, <c>false</c>.
        /// </value>
        protected bool IsDragging { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is initialising.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is initialising; otherwise, <c>false</c>.
        /// </value>
        protected bool IsInitialising { get; set; }
        private bool IsUpdating =false;
        internal List<BaseRegion> DayRegions { get; private set; }
        private Appointment draggedAppointment = null;


        private AppointmentList appointments = new AppointmentList();
        /// <summary>
        /// Gets or sets the appointments.
        /// </summary>
        /// <value>
        /// The appointments.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AppointmentList Appointments
        {
            get { return appointments; }
            set
            {
                appointments = value;
                RefreshAppointments();
                //BoundsValidTimeSlot = false;
                //BoundsValidAppointment = false;
                //AppointmentGrid.DataSource = Appointments;
                //RefreshAppointments();
            }
        }

        /// <summary>
        /// The appointment list or an appointment in it has changed,
        /// so we need to refresh everything from the underlying
        /// grid control to the boundaries of the appointments.
        /// </summary>
        public void RefreshAppointments()
        {
             
        	//sort the appointments by date
            Appointments.SortAppointments();
            
//            if (appointments != null)
//            {
//                var sortedApps =
//                from a in appointments
//                orderby a.DateStart
//                select a;
//                
//                appointments = sortedApps.ToList();
//                appointments.Clear();
//                foreach (var app in sortedApps.ToList())
//                	appointments.Add(app);
//            }
            //BoundsValidTimeSlot = false;
            BoundsValidAppointment = false;
            AppointmentGrid.DataSource = Appointments as List<Appointment>;
            //RefreshAppointments();
   		 }


		/// <summary>
		/// Initialise a new control instance and set up the appointment grid.
		/// </summary>
        public BaseScheduleControl()
        {
            startX = 0;
            DayRegions = new List<BaseRegion>();

            InitializeComponent();
            
            //init tooltip
            //this.toolTip = new ToolTip();
              
            this.DoubleBuffered = true;
            this.MouseMove+=ScheduleControl_MouseMove;
            this.MouseDown += ScheduleControl_MouseDown;
            this.MouseUp += ScheduleControl_MouseUp;
            //this.MouseHover +=  ScheduleControl_MouseHover;

            AppointmentGrid.ColumnCount = 2;
            AppointmentGrid.Columns[0].Name = "Date";
            AppointmentGrid.Columns[0].DataPropertyName = "Date";
            AppointmentGrid.Columns[1].Name = "Subject";
            AppointmentGrid.Columns[1].DataPropertyName = "Subject";
            AppointmentGrid.SelectionChanged += grid_SelectionChanged;
            AppointmentGrid.KeyDown += grid_KeyDown;
 
            this.ContextMenu= new ContextMenu();
            this.ContextMenu.MenuItems.Add("Add appointment",this.OnNewAppointmentClick);
}








        /// <summary>
        /// Handles the SelectionChanged event of the grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            //if we didn't trigger this
            if (!IsUpdating)
            {
                //change the selected appointment and day, if an appointment is selected
                if (AppointmentGrid.SelectedRows != null && AppointmentGrid.SelectedRows.Count > 0)
                {
                    if (AppointmentGrid.SelectedRows[0] != null && AppointmentGrid.SelectedRows[0].DataBoundItem is Appointment)
                    {
                        //TODO: turn this back into AppointmentRender somehow
                        SelectedAppointment = AppointmentGrid.SelectedRows[0].DataBoundItem as Appointment;
                        Invalidate();
                    }
                }
                else
                {
                    SelectedAppointment = null;
                }
            }

        }



        /// <summary>
        /// Handles the KeyDown event of the grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="keyEvent">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void grid_KeyDown(object sender, KeyEventArgs keyEvent)
        {
            if (keyEvent.KeyData == Keys.Enter)
            {
                if (SelectedAppointment != null)
                {
                    FireAppointmentEdit(SelectedAppointment);
                    keyEvent.Handled = true;
                }
            }
        }

        /// <summary>
        /// Fires the appointment edit.
        /// </summary>
        /// <param name="appointment">The appointment.</param>
        protected void FireAppointmentEdit(Appointment appointment)
        {
                EventHandler<AppointmentEditEventArgs> handler = AppointmentEdit;
         		if (handler != null)
         		{
              		AppointmentEditEventArgs args = new AppointmentEditEventArgs(appointment,this);
            		handler(this, args);
       			}                

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDoubleClick"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //handle day clicks
            foreach (BaseRegion day in this.DayRegions)
            {
                if (day.Bounds.Contains(e.Location))
                {
                    foreach (AppointmentRegion appt in day.Appointments)
                    {
                        if (appt.Bounds.Contains(e.Location))
                        {
                            AppointmentGrid.Focus();
                            SelectedSlot = day;
                            SelectedAppointment = appt.Appointment;
                                        if (SelectedAppointment != null)
            {

                                        	FireAppointmentEdit(SelectedAppointment);
                                        }
                            return;
                        }
                    }
                    //they probably want a new appointment
		            this.LastRightMouseClickCoords=null;
		            OnNewAppointmentClick(this,new EventArgs());
                    return;
                }
            }
            

            base.OnMouseDoubleClick(e);
        }
        private Appointment DragDropStart(int x, int y)
        {
            return HitTestAppointment(x, y);
        }

        internal BaseRegion SelectedSlot = null;
        protected Appointment SelectedAppointment = null;


        /// <summary>
        /// Gets or sets the last right mouse click coordinates.
        /// </summary>
        /// <value>
        /// The last right mouse click coordinates.
        /// </value>
		protected Point? LastRightMouseClickCoords{get;set;}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            AppointmentGrid.Focus();
            
            //record the location of a right mouse click
            if (e.Button == MouseButtons.Right)
            {
            	//TODO: for right clicks, should all other code be aborted
            	LastRightMouseClickCoords=e.Location;
            }
            
            //handle day clicks
            foreach (BaseRegion day in this.DayRegions)
            {
                if (day.TitleBounds.Contains(e.Location))
                {
                    SelectedSlot = day;
                    this.Invalidate();
                    return;
                }
                if (day.BodyBounds.Contains(e.Location))
                {
                    foreach (AppointmentRegion appt in day.Appointments)
                    {
                        if (appt.Bounds.Contains(e.Location))
                        {
                            SelectedSlot = day;
                            SelectedAppointment = appt.Appointment;
                            IsUpdating = true;
                            AppointmentGrid.ClearSelection();
                            foreach (DataGridViewRow row in AppointmentGrid.Rows)
                            {
                                if (row.DataBoundItem == SelectedAppointment)
                                {
                                    row.Selected = true;
                                    AppointmentGrid.CurrentCell = row.Cells[0];
                                    break;
                                }
                            }
                            IsUpdating = false;
                            this.Invalidate();
                            return;
                        }
                    }
                    break;
                }
            }
            base.OnMouseClick(e);
        }



 
		/// <summary>
		/// Doesn't work
		/// </summary>
        private void ScheduleControl_MouseHover(object sender, EventArgs e)
        { 
        	//TODO: Doesn't work to a satisfactory level. Needs investigation.
//        	Point mousePoint = this.PointToClient(MousePosition);
//        	Appointment appt = HitTestAppointment(mousePoint.X,mousePoint.Y);
//        	if (appt!=null  )
//        	{       
//        		toolTip.Hide(this);
//            	toolTip.Show(appt.Subject,this,mousePoint.X,mousePoint.Y);
//        	}
        }






        private int startX;
        private int startY;
        /// <summary>
        /// Handles the MouseDown event of the current control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ScheduleControl_MouseDown(object sender,MouseEventArgs e)
        {
            //base.OnMouseDown(e);

            // see if we hit an appointment, only do next stuff if we hit one
            if (e.Button == MouseButtons.Left && BoundsValidTimeSlot)
            {
                draggedAppointment = DragDropStart(e.X, e.Y);
                if (draggedAppointment != null)
                {
                    IsDragging = true;
                    pbDrag.Top = e.Y - 6;
                    pbDrag.Left = e.X - 8;
                    //pbDrag.Visible = true;
                    startX = e.X;
                    startY = e.Y;
                }
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the current control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ScheduleControl_MouseMove(object sender, MouseEventArgs e)
        {
        	
            //base.OnMouseMove(e);
            if (IsDragging && startX != e.X && startY != e.Y)
            {
                Cursor = Cursors.Hand;
                pbDrag.Visible = true;
                pbDrag.Top = e.Y - 6;
                pbDrag.Left = e.X - 8;
            }
       }

        /// <summary>
        /// Handles the MouseUp event of the current control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ScheduleControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDragging && startX != e.X && startY != e.Y)
            {
                Cursor = Cursors.Default;
                IsDragging = false;
                pbDrag.Visible = false;

                DragDropEnd(draggedAppointment, e.X, e.Y);
                draggedAppointment = null;
            }
            else
            {
                Cursor = Cursors.Default;
                IsDragging = false;
                pbDrag.Visible = false;                
                OnMouseClick(e);
            }
        }

        /// <summary>
        /// Perform a test on a mouse click location and see what appointment
        /// region they hit.
        /// </summary>
        /// <param name="x">The x coordinate of the click.</param>
        /// <param name="y">The y coordinate of the click.</param>
        /// <returns>The BaseRegion that was clicked</returns>
	    internal Appointment HitTestAppointment(int x, int y)
        {
            foreach (BaseRegion day in this.DayRegions)
            {
                if (day.BodyBounds.Contains(x, y))
                {
                    foreach (AppointmentRegion appt in day.Appointments)
                    {
                        if (appt.Bounds.Contains(x, y))
                        {
                            return appt.Appointment;
                        }
                    }
                    break;
                }
            }
            return null;
        }

        /// <summary>
        /// Perform a test on a mouse click location and see what day
        /// region they hit.
        /// </summary>
        /// <param name="x">The x coordinate of the click.</param>
        /// <param name="y">The y coordinate of the click.</param>
        /// <returns>The BaseRegion that was clicked</returns>
        internal BaseRegion HitTestDayRegion(int x, int y)
        {
            foreach (BaseRegion day in this.DayRegions)
            {
                if (day.BodyBounds.Contains(x, y))
                {
                    return day;
                }
            }
            return null;
        }
        
        /// <summary>
        /// Perform a test on a mouse click location and see what date
        /// time value they hit.
        /// </summary>
        /// <param name="x">The x coordinate of the click.</param>
        /// <param name="y">The y coordinate of the click.</param>
        /// <returns>The DateTime that was clicked</returns>
        protected virtual DateTime? HitTestDateTime(int x, int y)
        {
            foreach (BaseRegion day in this.DayRegions)
            {
                if (day.Bounds.Contains(x, y))
                {
                 	//use a default time ( 9am)
                 	//TODO: make this configurable
               		return new DateTime(day.Date.Year,day.Date.Month,day.Date.Day,9,0,0);
                }
            }
            return null;
        }

        /// <summary>
        /// Notify child form that the drag drop event has ended.
        /// </summary>
        /// <param name="appointment">The dragged appointment</param>
        /// <param name="x">The x coordinate it was dropped on.</param>
        /// <param name="y">The y coordinate it was dropped on.</param>
        protected virtual void DragDropEnd(Appointment appointment, int x, int y)
        {
           // BaseRegion day = HitTestDayRegion(x, y);
           // if (day != null && day.Date.DayOfYear!=appointment.DateStart.DayOfYear)
           // {
           //     var newDate = new DateTime(day.Date.Year,day.Date.Month,day.Date.Day,appointment.DateStart.Hour,appointment.DateStart.Minute,appointment.DateStart.Second);
           //     FireAppointmentMove( appointment,  newDate);
           //}
        }

        /// <summary>
        /// Fires the appointment move.
        /// </summary>
        /// <param name="appointment">The appointment.</param>
        /// <param name="newDate">The new date.</param>
        protected void FireAppointmentMove(Appointment appointment, DateTime newDate)
        {
        	    EventHandler<AppointmentMoveEventArgs> handler = AppointmentMove;
         		if (handler != null)
         		{
              		AppointmentMoveEventArgs args = new AppointmentMoveEventArgs(appointment,newDate,this);
            		handler(this, args);
       			}

        }


        /// <summary>
        /// Fires the appointment new.
        /// </summary>
        /// <param name="newApptDate">The new appt date.</param>
        protected void FireAppointmentNew(DateTime newApptDate)
        {
        	    EventHandler<AppointmentCreateEventArgs> handler = AppointmentCreate;
         		if (handler != null)
         		{
              		AppointmentCreateEventArgs args = new AppointmentCreateEventArgs(newApptDate,this);
            		handler(this, args);
       			}

        }

      private void OnNewAppointmentClick(object sender, EventArgs e)
      {
            Point menuLocation = Control.MousePosition;
            menuLocation = PointToClient(menuLocation);
         	if (LastRightMouseClickCoords!=null)
         		menuLocation=LastRightMouseClickCoords.Value;
         	DateTime? newDate=this.HitTestDateTime(menuLocation.X,menuLocation.Y);
         	if (newDate!=null)
         		FireAppointmentNew(newDate.Value);
         	else
         		FireAppointmentNew(DateTime.Now);

      }

      /// <summary>
      /// Occurs when [appointment create].
      /// </summary>
       	public event EventHandler<AppointmentCreateEventArgs> AppointmentCreate;
        /// <summary>
        /// Occurs when [appointment move].
        /// </summary>
     	public event EventHandler<AppointmentMoveEventArgs> AppointmentMove;
        /// <summary>
        /// Occurs when [appointment edit].
        /// </summary>
     	public event EventHandler<AppointmentEditEventArgs> AppointmentEdit;


        /// <summary>
        /// Calculate the time slot bounds. This works out the size and
        /// shape that days will take up on the screen. This method
        /// is called from OnPaint only when the property BoundsValidTimeSlot
        /// is set to false (this property is set to false in cases such as 
        /// when the control has been resized or the date shown has 
        /// changed).
        /// </summary>
        protected virtual void CalculateTimeSlotBounds(Graphics graphics)
        {
        }


        /// <summary>
        /// Calculate the appointment bounds. This works out the size and
        /// shape that the appointments will take up on the screen,
        /// and handles any other calculations such as overlaps. This method
        /// is called from OnPaint only when the property BoundsValidAppointment
        /// is set to false (this property is set to false in cases such as 
        /// when the control has been resized or the appointment list has 
        /// changed).
        /// </summary>
        protected virtual void CalculateAppointmentBounds(Graphics graphics)
        {
        }


        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        public void BeginInit()
        {
            IsInitialising = true;
            hiddenGrid.SuspendLayout();
            SuspendLayout();
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public void EndInit()
        {
            IsInitialising = false;            
            hiddenGrid.ResumeLayout(false);
            ResumeLayout(false);
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            BoundsValidTimeSlot = false;
            BoundsValidAppointment = false;
            //Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!BoundsValidTimeSlot)
                CalculateTimeSlotBounds(e.Graphics);

            if (!BoundsValidAppointment)
                CalculateAppointmentBounds(e.Graphics);

        }



        /// <summary>
        /// Are the bounds values for the time slots still valid. 
        /// If the control is resized, this is false.
        /// </summary>
        protected bool BoundsValidTimeSlot { get; set; }
         /// <summary>
        /// Are the bounds values for the appointments still valid. 
        /// If the control is resized, or the appointments are changed,
        /// this is false.
        /// </summary>
       protected bool BoundsValidAppointment { get; set; }
        
        
    }
}