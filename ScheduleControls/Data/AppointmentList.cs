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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Syd.ScheduleControls.Data
{
    /// <summary>
    /// A list of appointments.
    /// </summary>
    public class AppointmentList : List<Appointment>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentList"/> class.
        /// </summary>
        public AppointmentList()
        {
        }

        /// <summary>
        /// Sorts the appointments.
        /// </summary>
        public void SortAppointments()
        {
            var sortedApps =
                from a in this.ToList<Appointment>()
                orderby a.DateStart
                select a;

            base.Clear();
            foreach (var app in sortedApps.ToList())
            {
                base.Add(app);
            }

        }

    }
}