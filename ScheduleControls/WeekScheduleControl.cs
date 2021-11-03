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
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using Syd.ScheduleControls.Data;
using Syd.ScheduleControls.Region;
using Syd.ScheduleControls.Renderer;

namespace Syd.ScheduleControls
{
    /// <summary>
    /// Shows a week of appointments.
    /// </summary>
    public class WeekScheduleControl : BaseScheduleControl
    {
        private readonly DayRegion Monday;
        private readonly DayRegion Tuesday;
        private readonly DayRegion Wednesday;
        private readonly DayRegion Thursday;
        private readonly DayRegion Friday;
        private readonly DayRegion Saturday;
        private readonly DayRegion Sunday;
        private List<BaseRegion> Days { get { return base.DayRegions; } }

        /// <summary>
        /// Set up the days to display in this WeekScheduleControl.
        /// </summary>
        public WeekScheduleControl()
        {
            Monday = new DayRegion("Monday");
            Tuesday = new DayRegion("Tuesday");
            Wednesday = new DayRegion("Wednesday");
            Thursday = new DayRegion("Thursday");
            Friday = new DayRegion("Friday");
            Saturday = new DayRegion("Saturday");
            Sunday = new DayRegion("Sunday");
            Days.Add(Monday);
            Days.Add(Tuesday);
            Days.Add(Wednesday);
            Days.Add(Thursday);
            Days.Add(Friday);
            Days.Add(Saturday);
            Days.Add(Sunday);
        }

        private DateTime weekStart;
        /// <summary>
        /// Gets or sets the date to display.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date
        {
            get { return weekStart; }
            set
            {
                if (value.DayOfWeek != DayOfWeek.Monday)
                {
                    DateTime temp=value;
                    while (temp.DayOfWeek != DayOfWeek.Monday)
                    {
                        temp=temp.AddDays(-1);
                    }
                    weekStart = temp;
                }
                else
                {
                weekStart = value;
                }
                BoundsValidTimeSlot = false;
                BoundsValidAppointment = false;
               //recalculateDays();
            }
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
        protected override void CalculateAppointmentBounds(Graphics g)
        {
            // this code should only run on paint

            if (Width == 0 || Monday == null)
                return;


            //clear appointments on days
            foreach (DayRegion day in Days)
            {
                day.Appointments.Clear();

                if (Appointments != null)
                {
	                
                    //reallocate appointments to days
                    foreach (Appointment app in Appointments)
                    {
                        if (app.DateStart.Year == day.Date.Year && app.DateStart.DayOfYear == day.Date.DayOfYear)
                        {
                            day.Appointments.Add(new AppointmentRegion(app));
                        }
                    }
                }
            }
            BoundsValidAppointment = true;
        }

        /// <summary>
        /// Calculate the time slot bounds. This works out the size and
        /// shape that days will take up on the screen. This method
        /// is called from OnPaint only when the property BoundsValidTimeSlot
        /// is set to false (this property is set to false in cases such as 
        /// when the control has been resized or the date shown has 
        /// changed).
        /// </summary>
        protected override void CalculateTimeSlotBounds(Graphics g)
        {
            // this code should only run on paint
            if (Width == 0 || Monday==null)
                return;

            //this code is kind of stupid
            Monday.Date = weekStart;
            Tuesday.Date = weekStart.AddDays(1);
            Wednesday.Date = weekStart.AddDays(2);
            Thursday.Date = weekStart.AddDays(3);
            Friday.Date = weekStart.AddDays(4);
            Saturday.Date = weekStart.AddDays(5);
            Sunday.Date = weekStart.AddDays(6);


            //calculate day sizes - row 1
            int regularDayWidth = ((this.Width-1) / 2);

            int regularDayHeight = (this.Height / 3); //minus 3 is the border
            //int weekendDayWidth = regularDayWidth;
            int weekendDayHeight = ((regularDayHeight - 1) / 2); //minus 1 is the border
            int row1Y = 0; //y location of row 1
            int row2Y = regularDayHeight;//y location of row 2
            int row3Y = row2Y+regularDayHeight;//y location of row 2

            int mondayX = 0;
            Monday.Bounds = new Rectangle(mondayX, row1Y, regularDayWidth, regularDayHeight);

            int tuesdayX = mondayX + regularDayWidth;
            Tuesday.Bounds = new Rectangle(tuesdayX, row1Y, regularDayWidth, regularDayHeight);


            //calculate day sizes - row 2
            int wednesdayX = 0;
            Wednesday.Bounds = new Rectangle(wednesdayX, row2Y, regularDayWidth, regularDayHeight);

            int thursdayX = tuesdayX;
            Thursday.Bounds = new Rectangle(thursdayX, row2Y, regularDayWidth, regularDayHeight);


            //calculate day sizes - row 3
            int fridayX = 0;
            Friday.Bounds = new Rectangle(fridayX, row3Y, regularDayWidth, regularDayHeight);

            int saturdayX = tuesdayX;
            int saturdayHeight = weekendDayHeight;
            Saturday.Bounds = new Rectangle(saturdayX, row3Y, regularDayWidth, saturdayHeight);

            int sundayX = tuesdayX;
            int sundayY = row3Y + saturdayHeight;
            int sundayHeight = regularDayHeight - saturdayHeight;
            Sunday.Bounds = new Rectangle(sundayX, sundayY, regularDayWidth, sundayHeight);

            fontHeight = (int)(RendererCache.Current.Header.GetTextInfo(g, Font).Height * 1.3);

            //figure out the header and body size
            foreach (DayRegion day in this.Days)
            {
                //render if we can fit
                if (fontHeight < Bounds.Height)
                {
                    //work out title bounds
                    day.TitleBounds = new Rectangle(day.Bounds.X, day.Bounds.Y, day.Bounds.Width, fontHeight);

                    //work out body bounds
                    day.BodyBounds = new Rectangle(day.Bounds.X, day.Bounds.Y + day.TitleBounds.Height, day.Bounds.Width, day.Bounds.Height - day.TitleBounds.Height);// day.Bounds;
                }
            }

            BoundsValidTimeSlot = true;
        }
        private int fontHeight;



        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int apptHeight = RendererCache.Current.Appointment.GetTextInfo(e.Graphics, Font).Height + 2;
            
            //paint the days
            foreach (DayRegion day in this.Days)
            {
                //render if we can fit
                if (fontHeight < Bounds.Height)
                {
                    if (day == SelectedSlot)
                    {
                        RendererCache.Current.HeaderSelected.DrawBox(e.Graphics, Font, day.TitleBounds, day.FormattedName);
                    }
                    else
                    {
                        RendererCache.Current.Header.DrawBox(e.Graphics, Font, day.TitleBounds, day.FormattedName);
                    }
                    //paint the body
                    RendererCache.Current.Item.DrawBox(e.Graphics, Font, day.BodyBounds);

                    //TODO: Move the appointment width calc to CalculateAppointmentBounds
                    
                    //calculate how many appointments can be visible at once
                    int maxAppts = 0;
                    if (day.BodyBounds.Height > apptHeight)
                    {
                    	maxAppts = day.BodyBounds.Height/apptHeight;
                    }
                    //figure out if we'll need scrolling
                    bool useScrolling = day.Appointments.Count > maxAppts;

                    //decided to use columns for no reason - this could be done with scrolling, probably be better
                    int columnCount = 1;
                    if (maxAppts > 0)
                    {
                    	columnCount = day.Appointments.Count / maxAppts;
	                    if (day.Appointments.Count % maxAppts >0)
	                    {
	                    	columnCount++;
	                    }
                    }
                    int currentColumn=0;
                    int columnWidth = day.TitleBounds.Width;
                    if (columnCount>0)
                    columnWidth = day.TitleBounds.Width /columnCount;
                       
                    //paint the appointments
                    int yPosition = day.BodyBounds.Y;
                      int xPosition = day.BodyBounds.X;
                  AppointmentRegion paintSelected=null;
                    foreach (AppointmentRegion app in day.Appointments)
                    {                       
                        if (yPosition + apptHeight > day.BodyBounds.Y + day.BodyBounds.Height)
                        {
                        	currentColumn++;   
                        	xPosition = xPosition+columnWidth;
                        	yPosition= day.BodyBounds.Y;
                        }
                        
                        //if (yPosition + apptHeight < day.BodyBounds.Y + day.BodyBounds.Height)
                        //{
                        	app.Bounds = new Rectangle(xPosition, yPosition, columnWidth, apptHeight);
                        	
                        	if (app.Appointment == SelectedAppointment)
                        	{
                           		paintSelected = app;
                        	}
                        	else
                        	{
                        		RendererCache.Current.Appointment.DrawBox(e.Graphics, Font, app.BodyBounds, app.FormattedSubject);
                        		if (app.ColourBlockBounds!=Rectangle.Empty)
                        		{
                        			RendererCache.Current.Appointment.DrawBox(e.Graphics, Font, app.ColourBlockBounds, app.Appointment.ColorBlockBrush);
                        		}
                        	}
                        	yPosition += apptHeight;
                        //}
                    }
                    
                    // repaint just the selected appointment - to get the border onto it even with overlap
                    if (paintSelected!=null)
                    {
                    	RendererCache.Current.AppointmentSelected.DrawBox(e.Graphics, Font, paintSelected.BodyBounds, paintSelected.FormattedSubject);
                    	if (paintSelected.ColourBlockBounds!=Rectangle.Empty)
                    	{
                    		RendererCache.Current.AppointmentSelected.DrawBox(e.Graphics, Font, paintSelected.ColourBlockBounds, paintSelected.Appointment.ColorBlockBrush);
                    		
                    		
                    		//draw top and bottom blocks
                    		RendererCache.Current.AppointmentSelected.DrawBox(e.Graphics, Font, paintSelected.SelectTopBounds, paintSelected.Appointment.ColorBlockBrush);
                    		RendererCache.Current.AppointmentSelected.DrawBox(e.Graphics, Font, paintSelected.SelectBottomBounds, paintSelected.Appointment.ColorBlockBrush);
                    	}
                    }               
                }
            }
        }
    }
}