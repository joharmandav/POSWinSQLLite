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
using System.Drawing;

namespace Syd.ScheduleControls.Region
{
    /// <summary>
    /// Interface defining the properties of a region on the screen of something that is painted in 
    /// the OnPaint event.
    /// </summary>
    internal interface IRegion
    {
        /// <summary>
        /// Gets or sets the bounds of this region.
        /// </summary>
        /// <value>
        /// The bounds.
        /// </value>
        Rectangle Bounds { get; set; }
    }
}
