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
using Syd.ScheduleControls.Data;

namespace Syd.ScheduleControls.Events
{
    public class AppointmentMoveEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the control.
        /// </summary>
        /// <value>
        /// The control.
        /// </value>
        public BaseScheduleControl Control { get; set; }
        /// <summary>
        /// Gets or sets the appointment.
        /// </summary>
        /// <value>
        /// The appointment.
        /// </value>
        public Appointment Appointment { get; set; }
        /// <summary>
        /// Gets or sets the new date.
        /// </summary>
        /// <value>
        /// The new date.
        /// </value>
        public DateTime NewDate { get; set; }
        /// <summary>
        /// Prevents a default instance of the <see cref="AppointmentMoveEventArgs"/> class from being created.
        /// </summary>
        private AppointmentMoveEventArgs()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentMoveEventArgs"/> class.
        /// </summary>
        /// <param name="appointment">The appointment.</param>
        /// <param name="newDate">The new date.</param>
        /// <param name="control">The control.</param>
        public AppointmentMoveEventArgs(Appointment appointment, DateTime newDate, BaseScheduleControl control)
        {
            Appointment = appointment;
            NewDate = newDate;
            Control = control;
        }
    }
}