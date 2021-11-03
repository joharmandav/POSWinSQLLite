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

namespace Syd.ScheduleControls.Data
{
    /// <summary>
    /// Holds appointment data.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject { get; set; }

        //TODO: put in some validation
        private DateTime dateStart;
        /// <summary>
        /// Gets or sets the start date of the appointment.
        /// </summary>
        /// <value>
        /// The start date of the appointment.
        /// </value>
        public DateTime DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }

        private DateTime dateEnd;
        /// <summary>
        /// Gets or sets the end date of the appointment.
        /// </summary>
        /// <value>
        /// The end date of the appointment.
        /// </value>
        public DateTime DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }

        /// <summary>
        /// Gets or sets the color block brush for the appointment border.
        /// </summary>
        /// <value>
        /// The color block brush.
        /// </value>
        public Brush ColorBlockBrush { get; set; }
        public string AppointNo
        { get; set; }
    }
}
