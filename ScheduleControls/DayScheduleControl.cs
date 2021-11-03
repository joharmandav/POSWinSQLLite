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
using Syd.ScheduleControls.Events;

namespace Syd.ScheduleControls
{
    /// <summary>
    /// Shows a number of days worth of appointments.
    /// </summary>
    public class DayScheduleControl : BaseScheduleControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DayScheduleControl"/> class.
        /// </summary>
        public DayScheduleControl()
        {
            RenderWorkingHoursOnly = true;
            singleDay = true;
        }

        private readonly List<HeaderRegion> hourHeaders = new List<HeaderRegion>();

        /// <summary>
        /// Override the default hit-test-day behaviour with one that goes down to the hour.
        /// </summary>
        /// <param name="x">The x coordinate for the hit test.</param>
        /// <param name="y">The y coordinate for the hit test.</param>
        /// <returns>The datetime that the mouse click hit.</returns>
        protected override DateTime? HitTestDateTime(int x, int y)
        {
            foreach (DayWithHourRegion day in this.DayRegions)
            {
                if (day.Bounds.Contains(x, y))
                {
                    foreach (var hour in day.Hours)
                    {
                        //calculate the right hour and minute, since this control shows hours
                        if (hour.Bounds.Contains(x, y))
                        {
                            int minute = 0;
                            if (hour.Bounds15.Contains(x, y))
                                minute = 15;
                            if (hour.Bounds30.Contains(x, y))
                                minute = 30;
                            if (hour.Bounds45.Contains(x, y))
                                minute = 45;
                            return new DateTime(day.Date.Year, day.Date.Month, day.Date.Day, hour.Hour, minute, 0);

                        }

                    }
                    return day.Date;
                }
            }

            //TODO: check the hour headers as well

            return null;
        }

        /// <summary>
        /// Override drag drop end so we can handle appointment moves to different hours in the same day.
        /// </summary>
        /// <param name="appointment">The dragged appointment</param>
        /// <param name="x">The x coordinate it was dropped on.</param>
        /// <param name="y">The y coordinate it was dropped on.</param>
        protected override void DragDropEnd(Appointment appointment, int x, int y)
        {
            var day = HitTestDateTime(x, y);
            if (day != null)// && day.Date.DayOfYear!=appointment.DateStart.DayOfYear)
            {
                // handle dragging to a different hour in dayview mode
                //MessageBox.Show(string.Format("Dragged appointment {0} to {1}", appointment.Subject, day.Name));
                FireAppointmentMove(appointment, day.Value);
            }
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
            if (Width == 0 || Height == 0)
                return;

            DayRegions.Clear();
            hourHeaders.Clear();

            int numberOfDays = 1;

            //set up the start day
            if (!SingleDay)
            {
                //five days
                numberOfDays = 5;
                if (Date.DayOfWeek != DayOfWeek.Monday)
                {
                    //handle sunday being set - go forwards in that case
                    if (Date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Date = Date.AddDays(1);
                    }
                    else if (Date.DayOfWeek == DayOfWeek.Saturday)
                    {
                        Date = Date.AddDays(2);
                    }
                    else
                    {
                        DateTime temp = Date;
                        while (temp.DayOfWeek != DayOfWeek.Monday)
                        {
                            temp = temp.AddDays(-1);
                        }
                        Date = temp;
                    }
                }
            }

            //set up days
            for (int i = 0; i < numberOfDays; i++)
            {
                DayWithHourRegion day = new DayWithHourRegion();
                day.Date = Date.AddDays(i);
                day.IsInCurrentMonth = true;
                this.DayRegions.Add(day);
            }

            int hourCount = 0;

            //set up hours
            for (int j = 0; j < DayRegions.Count; j++)
            {
                DayWithHourRegion day = DayRegions[j] as DayWithHourRegion;
                if (day != null)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        if (RenderWorkingHoursOnly)
                        {
                            if (i >= (WorkStartHour - 1) && i < (WorkEndHour + 1))
                            {
                                HourRegion hour = new HourRegion();
                                hour.IsWorkingHour = (i >= WorkStartHour && i < WorkEndHour);
                                hour.Hour = i;
                                day.Hours.Add(hour);
                            }
                        }
                        else
                        {
                            HourRegion hour = new HourRegion();
                            hour.IsWorkingHour = (i >= WorkStartHour && i < WorkEndHour);
                            hour.Hour = i;
                            day.Hours.Add(hour);
                        }
                    }
                    if (j == 0)
                    {
                        hourCount = day.Hours.Count;
                    }
                }

            }

            int timeMarkerWidth = 0;
            if (this.Width > 120)
            {
                timeMarkerWidth = 80;
            }

            int dayHeaderHeight = (int)(RendererCache.Current.Header.GetTextInfo(g, this.Font).Height * 1.2);

            int hourHeight = ((Height - 1 - dayHeaderHeight) / hourCount);
            int xCurrent = timeMarkerWidth;
            int hourWidth = (Width - timeMarkerWidth - 1) / numberOfDays;

            int bounds15height = (hourHeight) / 4;

            //set up day and hour bounds
            for (int j = 0; j < DayRegions.Count; j++)
            {
                DayWithHourRegion day = DayRegions[j] as DayWithHourRegion;

                if (day != null)
                {
                    int yCurrent = dayHeaderHeight;
                    //set up day bounds
                    day.Bounds = new Rectangle(xCurrent, 0, hourWidth, hourHeight * day.Hours.Count);
                    day.Name = day.Date.DayOfWeek.ToString();
                    day.TitleBounds = new Rectangle(xCurrent, 0, hourWidth, dayHeaderHeight);
                    day.BodyBounds = new Rectangle(day.Bounds.X, day.Bounds.Y, day.Bounds.Width, day.Bounds.Height);


                    foreach (HourRegion hour in day.Hours)
                    {
                        //work out the hour bounds
                        hour.Bounds = new Rectangle(xCurrent, yCurrent, hourWidth, hourHeight);

                        //work out the 15 minute divisions
                        hour.Bounds00 = new Rectangle(xCurrent, yCurrent, hourWidth, bounds15height);
                        hour.Bounds15 = new Rectangle(xCurrent, yCurrent + hour.Bounds00.Height, hourWidth,
                                                      bounds15height);
                        hour.Bounds30 = new Rectangle(xCurrent, yCurrent + hour.Bounds00.Height + hour.Bounds15.Height,
                                                      hourWidth, bounds15height);
                        hour.Bounds45 = new Rectangle(xCurrent,
                                                      yCurrent + hour.Bounds00.Height + hour.Bounds15.Height +
                                                      hour.Bounds30.Height, hourWidth,
                                                      bounds15height);

                        if (j == 0)
                        {
                            HeaderRegion header = new HeaderRegion();
                            header.Bounds = new Rectangle(0, yCurrent, timeMarkerWidth, hourHeight);
                            header.Name = string.Format("{0}:00", hour.Hour);
                            hourHeaders.Add(header);
                        }
                        yCurrent += hourHeight;
                    }
                }
                xCurrent += hourWidth;
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
        protected override void CalculateAppointmentBounds(Graphics graphics)
        {
            //int appSeparator = 3;
            //recalculate the appointments
            foreach (DayWithHourRegion day in this.DayRegions)
            {
                //clear day and hour appointment regions
                day.Appointments.Clear();
                foreach (HourRegion hour in day.Hours)
                {
                    hour.Appointments.Clear();
                }

                //TODO: cater for overlapping multiple timeslots
                foreach (Appointment app in Appointments)
                {

                    if (app.DateStart.Year == day.Date.Year && app.DateStart.DayOfYear == day.Date.DayOfYear)
                    {
                        AppointmentWithHourRegion appRegion = new AppointmentWithHourRegion(app);
                        day.Appointments.Add(appRegion);
                        foreach (HourRegion hour in day.Hours)
                        {
                            if (app.DateStart.Hour == hour.Hour) // && app.DateStart.Hour <= hour.Hour)
                            {
                                hour.Appointments.Add(appRegion);
                            }
                        }
                    }
                }
                foreach (AppointmentWithHourRegion appt1 in day.Appointments)
                {
                    foreach (AppointmentWithHourRegion appt2 in day.Appointments)
                    {
                        if (appt1 != appt2
                            &&
                            appt1.Appointment.DateEnd != appt2.Appointment.DateStart
                            &&
                            appt1.Appointment.DateStart != appt2.Appointment.DateEnd
                        &&
                            (
                                appt2.Appointment.DateStart == appt1.Appointment.DateStart
                                ||
                                appt2.Appointment.DateEnd == appt1.Appointment.DateEnd
                                ||
                            (appt2.Appointment.DateStart < appt1.Appointment.DateEnd
                             && appt2.Appointment.DateStart > appt1.Appointment.DateStart)
                                ||
                            (appt2.Appointment.DateEnd < appt1.Appointment.DateEnd
                             && appt2.Appointment.DateEnd > appt1.Appointment.DateStart)
                                ||
                            (appt1.Appointment.DateEnd < appt2.Appointment.DateEnd
                             && appt1.Appointment.DateEnd > appt2.Appointment.DateStart)

                            )
                           )
                        {
                            appt1.HasOverlaps = true;
                            appt2.HasOverlaps = true;
                            if (!appt1.OverlappingAppointments.Contains(appt2))
                                appt1.OverlappingAppointments.Add(appt2);
                            if (!appt2.OverlappingAppointments.Contains(appt1))
                                appt2.OverlappingAppointments.Add(appt1);
                        }
                    }
                }
                //roughly work out appt bounds and starting slot
                for (int i = 0; i < day.Hours.Count; i++)
                {
                    HourRegion hour = day.Hours[i];
                    int apptY = hour.Bounds.Y;
                    if (hour.Appointments.Count > 0)
                    {
                        int hourX = hour.Bounds.X;

                        int apptX = hourX;
                        for (int j = 0; j < hour.Appointments.Count; j++)
                        {
                            AppointmentWithHourRegion app = hour.Appointments[j];

                            //work out starting slot
                            int startMinute = app.Appointment.DateStart.Minute;
                            if (startMinute >= 0 && startMinute < 15)
                            {
                                app.StartingSlot = 0;
                            }
                            else if (startMinute >= 15 && startMinute < 30)
                            {
                                app.StartingSlot = 1;
                            }
                            else if (startMinute >= 30 && startMinute < 45)
                            {
                                app.StartingSlot = 2;
                            }
                            else if (startMinute >= 45 && startMinute < 60)
                            {
                                app.StartingSlot = 3;
                            }

                            //work out duration and therefore height
                            TimeSpan span = app.Appointment.DateEnd.Subtract(app.Appointment.DateStart);
                            int tempApptHeight = ((span.Hours * 60 + span.Minutes) / 15) * hour.Bounds00.Height;
                            int tempApptY = apptY + (app.StartingSlot * hour.Bounds00.Height);

                            int apptWidth = hour.Bounds.Width;

                            //if we have overlaps, things get nasty
                            if (app.HasOverlaps)
                            {
                                int hourAppWidth = apptWidth / hour.Appointments.Count;
                                apptWidth = hourAppWidth;
                            }
                            app.Bounds = new Rectangle(apptX, tempApptY, apptWidth, tempApptHeight);

                            //set the bounds
                            apptX += apptWidth;
                        }
                    }
                }

                //go over again a few times to resolve overlaps
                for (int i = 0; i < 5; i++)
                {
                    handleOverlaps(day);
                }
            }
            BoundsValidAppointment = true;
        }

        /// <summary>
        /// Handles the appoinment overlaps badly.
        /// </summary>
        /// <param name="day">The day.</param>
        private static void handleOverlaps(DayWithHourRegion day)
        {
            //TODO: work out overlaps through a better process
            if (day.Appointments.Count > 0)
            {
                for (int j = 0; j < day.Appointments.Count; j++)
                {
                    AppointmentWithHourRegion app = day.Appointments[j] as AppointmentWithHourRegion;

                    //if we have overlaps, things get nasty
                    if (app.HasOverlaps)
                    {
                        foreach (AppointmentWithHourRegion overlapApp in app.OverlappingAppointments)
                        {
                            //if another appointment overlaps
                            if (!overlapApp.Bounds.IsEmpty &&
                                overlapApp.Bounds.IntersectsWith(new Rectangle(app.Bounds.X,
                                                                               app.Bounds.Y,
                                                                               app.Bounds.Width,
                                                                               app.Bounds.Height))
                                )
                            {
                                //if the app width is bigger, trim it
                                if (app.Bounds.Width >= overlapApp.Bounds.Width)
                                {
                                    //if current app x starts after the other app x
                                    if (app.Bounds.X >= overlapApp.Bounds.X)
                                    {
                                        app.Bounds = new Rectangle(
                                           app.Bounds.X + app.Bounds.Width / 4,
                                           app.Bounds.Y,
                                           app.Bounds.Width - app.Bounds.Width / 4,
                                           app.Bounds.Height);
                                    }
                                    else
                                    {
                                        app.Bounds = new Rectangle(
                                           app.Bounds.X,
                                           app.Bounds.Y,
                                           app.Bounds.Width - app.Bounds.Width / 4,
                                           app.Bounds.Height);
                                    }
                                }

                            }


                            if (app.Bounds.X + app.Bounds.Width > day.Bounds.X + day.Bounds.Width)
                            {
                                Rectangle rect = app.Bounds;
                                rect.Width = day.Bounds.X + day.Bounds.Width - app.Bounds.X;
                                app.Bounds = rect;
                            }
                        }
                    }
                }
            }
        }




        private DateTime date;
        /// <summary>
        /// Gets or sets the date to display.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                BoundsValidAppointment = false;
                BoundsValidTimeSlot = false;
            }
        }

        /// <summary>
        /// Gets or sets the work start hour.
        /// </summary>
        /// <value>
        /// The work start hour.
        /// </value>
        public int WorkStartHour { get; set; }
        /// <summary>
        /// Gets or sets the work end hour.
        /// </summary>
        /// <value>
        /// The work end hour.
        /// </value>
        public int WorkEndHour { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to only render working hours.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if only render working hours; otherwise, <c>false</c>.
        /// </value>
        public bool RenderWorkingHoursOnly { get; set; }
        private bool singleDay;
        /// <summary>
        /// Gets or sets a value indicating whether to show only a single day.
        /// </summary>
        /// <value>
        ///   <c>true</c> if showing only a single day; otherwise, <c>false</c>.
        /// </value>
        public bool SingleDay
        {
            get
            {
                return singleDay;
            }
            set
            {
                singleDay = value;
                BoundsValidAppointment = false;
                BoundsValidTimeSlot = false;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //paint hour headers
            foreach (HeaderRegion header in hourHeaders)
            {
                RendererCache.Current.Header.DrawBox(e.Graphics, Font, header.Bounds, header.Name, true, BorderInfo.Default, TextAlignment.Right);
            }

            for (int j = 0; j < DayRegions.Count; j++)
            {
                DayWithHourRegion day = DayRegions[j] as DayWithHourRegion;
                if (day != null)
                {
                    //paint header
                    RendererCache.Current.Header.DrawBox(e.Graphics, Font, day.TitleBounds, day.Name +" "+ day.Date.ToShortDateString());

                    foreach (HourRegion hour in day.Hours)
                    {
                        if (hour.IsWorkingHour)
                        {
                            RendererCache.Current.Item.DrawBox(e.Graphics, Font, hour.Bounds);
                            RendererCache.Current.ItemLight.DrawLine(e.Graphics, hour.Bounds30.X + 1, hour.Bounds30.Y,
                                                                     hour.Bounds30.X + hour.Bounds30.Width - 2,
                                                                     hour.Bounds30.Y);
                        }
                        else
                        {
                            //non working hours are dark
                            RendererCache.Current.Control.DrawBox(e.Graphics, Font, hour.Bounds);
                        }
                    }
                    foreach (HourRegion hour in day.Hours)
                    {
                        AppointmentRegion paintSelected = null;
                        // int yPosition = hour.Bounds.Y;
                        foreach (AppointmentWithHourRegion app in hour.Appointments)
                        {
                            if (app.Appointment == SelectedAppointment)
                            {
                                paintSelected = app;

                            }
                            else
                            {
                                RendererCache.Current.Appointment.DrawBox(e.Graphics, Font, app.BodyBounds, app.FormattedSubject);
                                if (app.ColourBlockBounds != Rectangle.Empty)
                                {
                                    RendererCache.Current.Appointment.DrawBox(e.Graphics, Font, app.ColourBlockBounds, app.Appointment.ColorBlockBrush);

                                }

                            }
                        }

                        // repaint just the selected appointment - to get the border onto it even with overlap
                        if (paintSelected != null)
                        {
                            RendererCache.Current.AppointmentSelected.DrawBox(e.Graphics, Font, paintSelected.BodyBounds, paintSelected.FormattedSubject);
                            if (paintSelected.ColourBlockBounds != Rectangle.Empty)
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
}