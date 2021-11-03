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
namespace Syd.ScheduleControls.Region
{
    /// <summary>
    /// A region on the screen that displays a day.
    /// </summary>
    internal class DayRegion : BaseRegion
    {
        public DayRegion()
        {
        }
        public DayRegion(string name)
        {
            this.Name = name;
        }
        public bool IsInCurrentMonth { get; set; }
        public string FormattedName { get { return string.Format("{0}  {1}", Name, Date.ToShortDateString()); } }
    }
}
