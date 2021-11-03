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

namespace Syd.ScheduleControls.Events
{
	public class AppointmentCreateEventArgs : EventArgs
	{
        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>
        /// The control.
        /// </value>
		public BaseScheduleControl Control{get;set;}
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
		public DateTime? Date {get;set;}
        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentCreateEventArgs"/> class.
        /// </summary>
		public AppointmentCreateEventArgs()
		{
			Date=null;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentCreateEventArgs"/> class.
        /// </summary>
        /// <param name="date">The date.</param>
		public AppointmentCreateEventArgs(DateTime date)
		{
			Date=date;
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentCreateEventArgs"/> class.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="control">The control.</param>
		public AppointmentCreateEventArgs(DateTime date, BaseScheduleControl control)
		{
			Date=date;
			Control=control;
		}
	}
}
