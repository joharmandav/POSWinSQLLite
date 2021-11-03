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

namespace Syd.ScheduleControls.Region
{
    /// <summary>
    /// A region on the screen that will be painted.
    /// </summary>
    internal abstract class BaseRegion : IRegion
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Rectangle Bounds { get; set; }
        public Rectangle TitleBounds { get; set; }
        public Rectangle BodyBounds { get; set; }
        public List<AppointmentRegion> Appointments = new List<AppointmentRegion>();
    }
}