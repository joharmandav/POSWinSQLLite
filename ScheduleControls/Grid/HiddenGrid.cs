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
using System.Windows.Forms;

namespace Syd.ScheduleControls.Grid
{
    /// <summary>
    /// Used as a hidden control to handle keyboard access.
    /// </summary>
    internal class HiddenGrid : DataGridView
    {
        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains information about the control to paint.</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //Don't paint anything
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        /// <exception cref="T:System.Exception">
        /// Any exceptions that occur during this method are ignored unless they are one of the following:
        ///   <see cref="T:System.NullReferenceException"/><see cref="T:System.StackOverflowException"/><see cref="T:System.OutOfMemoryException"/><see cref="T:System.Threading.ThreadAbortException"/><see cref="T:System.ExecutionEngineException"/><see cref="T:System.IndexOutOfRangeException"/><see cref="T:System.AccessViolationException"/></exception>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Don't paint anything
        }
    }
}
