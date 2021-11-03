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
using Syd.ScheduleControls.Data;
using Syd.ScheduleControls.Region;
using Syd.ScheduleControls.Renderer;
using System.Linq;

namespace Syd.ScheduleControls
{
    /// <summary>
    /// Shows a month of appointments.
    /// </summary>
    public class MonthScheduleControl : BaseScheduleControl
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="MonthScheduleControl"/> class.
        /// </summary>
        public MonthScheduleControl()
        {
        }
        HeaderRegion monthHeader;
        private readonly List<HeaderRegion> headers = new List<HeaderRegion>();

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
            if (Width == 0 || Height == 0)
                return;

            //TODO: use a bigger font for month name header
            int monthNameHeight = (int)(RendererCache.Current.Header.GetTextInfo(g, Font).Height * 1.3);

            int dayNameHeight = (int)(RendererCache.Current.Header.GetTextInfo(g, Font).Height * 1.3);
            int itemHeight = (int)(RendererCache.Current.Item.GetTextInfo(g, Font).Height * 1.2);
            int dayHeight = (Height - 1 - dayNameHeight - monthNameHeight) / 6; //take out borders - days will paint right and bottom border themselves
            int xCurrent = 0;
            int yCurrent = monthNameHeight+ dayNameHeight;
            int dayWidth = (Width - 1) / 6;
            int saturdayHeight = (dayHeight) / 2;
            int sundayHeight = dayHeight  - saturdayHeight;
          //  paintBorderWidth = dayWidth * 6 ;
          //  paintBorderHeight = dayHeight * 6 + dayNameHeight ;

            //clear previous days
            this.days.Clear();
            this.headers.Clear();

            //find a monday to start on
            DateTime currentDay = new DateTime(Date.Year,Date.Month,1) ;
            while (currentDay.DayOfWeek != DayOfWeek.Monday)
            {
                currentDay = currentDay.AddDays(-1);
            }

            monthHeader = new HeaderRegion();
            monthHeader.Name = Date.ToString("MMMM");
            monthHeader.Bounds = new Rectangle(xCurrent, 0, dayWidth * 6, monthNameHeight);

            //set up the day titles
            int xHeaderCurrent = xCurrent;
            DateTime headerCurrentDay = currentDay;
            for (int i = 0; i < 6; i++)
            {
                HeaderRegion header = new HeaderRegion();
                if (headerCurrentDay.DayOfWeek == DayOfWeek.Saturday || headerCurrentDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    header.Name = "Saturday/Sunday";
                }
                else
                {
                    header.Name = headerCurrentDay.DayOfWeek.ToString();
                }

                header.Bounds = new Rectangle(xHeaderCurrent, monthNameHeight, dayWidth, dayNameHeight);
                headers.Add(header);
                xHeaderCurrent += dayWidth;
                headerCurrentDay = headerCurrentDay.AddDays(1);
            }

            //set up the days themselves
            for (int i = 0; i < 42; i++)
            {
                DayRegion day = new DayRegion();
                day.Date = currentDay;
                day.IsInCurrentMonth = (currentDay.Month == Date.Month);

                //if we're up to end of slot, reset it
                if (day.Date.DayOfWeek == DayOfWeek.Monday)
                {
                    xCurrent = 0;
                }

                //Combine saturday and sunday with split bounds
                if (currentDay.DayOfWeek == DayOfWeek.Saturday)
                {
                    day.Bounds = new Rectangle(xCurrent, yCurrent, dayWidth, saturdayHeight);
                    day.TitleBounds = new Rectangle(xCurrent + 1, yCurrent + 1, dayWidth - 2, itemHeight);
                    day.BodyBounds = new Rectangle(day.Bounds.X, day.Bounds.Y + day.TitleBounds.Height, day.Bounds.Width, day.Bounds.Height - day.TitleBounds.Height);// day.Bounds;
                }
                else if (currentDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    day.Bounds = new Rectangle(xCurrent, yCurrent + saturdayHeight, dayWidth, sundayHeight);
                    day.TitleBounds = new Rectangle(xCurrent + 1, yCurrent + saturdayHeight+1, dayWidth - 2, itemHeight);
                    day.BodyBounds = new Rectangle(day.Bounds.X, day.Bounds.Y + day.TitleBounds.Height, day.Bounds.Width, day.Bounds.Height - day.TitleBounds.Height);// day.Bounds;
                }
                else
                {
                    day.Bounds = new Rectangle(xCurrent, yCurrent, dayWidth, dayHeight);
                    day.TitleBounds = new Rectangle(xCurrent + 1, yCurrent + 1, dayWidth - 2, itemHeight);
                    day.BodyBounds = new Rectangle(day.Bounds.X, day.Bounds.Y + day.TitleBounds.Height, day.Bounds.Width, day.Bounds.Height - day.TitleBounds.Height);// day.Bounds;
                    xCurrent += dayWidth;
                }

                if (day.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    yCurrent += dayHeight;
                }
                days.Add(day);

                currentDay = currentDay.AddDays(1);
            }

            BoundsValidTimeSlot = true;
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
            if (Width == 0 || Height == 0)
                return;
            
            //recalculate the appointments
            foreach (DayRegion day in this.days)
            {
                day.Appointments.Clear();

                if (Appointments != null)
                {
                  	//sort appts by date
	                var sortedApps =
	                from a in Appointments
	                orderby a.DateStart
	                select a;
	                
                    //reallocate appointments to days
                    foreach (Appointment app in sortedApps.ToList())
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


        private List<BaseRegion> days { get { return base.DayRegions; } }

        private DateTime date;
        /// <summary>
        /// Gets or sets the date to display.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                BoundsValidTimeSlot = false;
                BoundsValidAppointment = false;
            }
        }


        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //paint month name header
            RendererCache.Current.BigHeader.DrawBox(e.Graphics, Font, monthHeader.Bounds, monthHeader.Name,true,BorderInfo.Default,TextAlignment.Center,true);

            //calculate the appointment heights
            int apptHeight = RendererCache.Current.Appointment.GetTextInfo(e.Graphics, Font).Height + 2;

            foreach (HeaderRegion head in this.headers)
            {
                RendererCache.Current.Header.DrawBox(e.Graphics, Font, head.Bounds, head.Name);
            }
            foreach (DayRegion day in this.days)
            {
                if (day.IsInCurrentMonth)
                {
                    //paint day box
                    RendererCache.Current.Item.DrawBox(e.Graphics, Font, day.Bounds);
                    //paint day box header
                    RendererCache.Current.Item.DrawBox(e.Graphics, Font, day.TitleBounds, string.Format("{0}", day.Date.Day),true,BorderInfo.None);

                    //TODO: Move the appointment bounds calc to CalculateAppointmentBounds
                    
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
                    int yPosition = day.Bounds.Y + day.TitleBounds.Height;
                    int xPosition = day.Bounds.X;
                    AppointmentRegion paintSelected=null;
                    foreach (AppointmentRegion app in day.Appointments)
                    {
                    	//render next column
                    	if (yPosition + apptHeight > day.BodyBounds.Y + day.BodyBounds.Height)
                        {
                        	currentColumn++;   
                        	xPosition = xPosition+columnWidth;
                        	yPosition= day.BodyBounds.Y;
                        }

                        //if any of these fit on the screen
                        if (yPosition + apptHeight < day.Bounds.Y + day.Bounds.Height)
                        {
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
                        }
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
                else
                {
                    //non working days are dark
                    RendererCache.Current.Control.DrawBox(e.Graphics, Font, day.Bounds);
                    //paint day box header
                    RendererCache.Current.Control.DrawBox(e.Graphics, Font, day.TitleBounds, string.Format("{0}", day.Date.Day), true, BorderInfo.None);
                }
            }

            //TODO: scrolling

        }
    }
}