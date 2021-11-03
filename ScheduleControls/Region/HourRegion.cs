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
using System.Collections.Generic;
using System.Drawing;

namespace Syd.ScheduleControls.Region
{
    /// <summary>
    /// A region on the screen that displays an hour.
    /// </summary>
    internal class HourRegion : IRegion
    {
        /// <summary>
        /// Gets or sets the hour.
        /// </summary>
        /// <value>
        /// The hour.
        /// </value>
        public int Hour { get; set; }
        /// <summary>
        /// Gets or sets the bounds of this region.
        /// </summary>
        /// <value>
        /// The bounds.
        /// </value>
        public Rectangle Bounds { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is a working hour.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is a working hour; otherwise, <c>false</c>.
        /// </value>
        public bool IsWorkingHour { get; set; }
        /// <summary>
        /// Gets or sets the bounds of 0 minute area.
        /// </summary>
        /// <value>
        /// The bounds of 0 minute area.
        /// </value>
        public Rectangle Bounds00 { get; set; }
        /// <summary>
        /// Gets or sets the bounds of 15 minute area.
        /// </summary>
        /// <value>
        /// The bounds of 15 minute area.
        /// </value>
        public Rectangle Bounds15 { get; set; }
        /// <summary>
        /// Gets or sets the bounds of 30 minute area.
        /// </summary>
        /// <value>
        /// The bounds of 30 minute area.
        /// </value>
        public Rectangle Bounds30 { get; set; }
        /// <summary>
        /// Gets or sets the bounds of 45 minute area.
        /// </summary>
        /// <value>
        /// The bounds of 45 minute area.
        /// </value>
        public Rectangle Bounds45 { get; set; }
        /// <summary>
        /// The list of appointment regions.
        /// </summary>
        public List<AppointmentWithHourRegion> Appointments = new List<AppointmentWithHourRegion>();
    }
}