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
using Syd.ScheduleControls.Data;

namespace Syd.ScheduleControls.Region
{
	internal class AppointmentRegion : IRegion
	{
		public Appointment Appointment { get; set; }
		public string FormattedSubject
		{
			get { return string.Format("{0} - {1}", Appointment.DateStart.ToString("h:mm tt"), Appointment.Subject); }
		}
		public AppointmentRegion(Appointment appointment)
		{
			Appointment = appointment;
			ColourBlockBounds=Rectangle.Empty;
		}
		private	Rectangle bounds;
		public Rectangle Bounds {
			get{return bounds;} set{bounds=value;
				if (bounds.Width>5 &&value!=Rectangle.Empty)
				{
					BodyBounds=new Rectangle(){Width=value.Width-3,Height=value.Height,X=value.X+3,Y=value.Y};
					ColourBlockBounds = new Rectangle(){Width=3,Height=value.Height,X=value.X,Y=value.Y};
					SelectTopBounds = new Rectangle(){Width=value.Width,Height=3,X=value.X,Y=value.Y-3};
					SelectBottomBounds = new Rectangle(){Width=value.Width,Height=3,X=value.X,Y=value.Y+value.Height};
				}
				else
				{
					BodyBounds=bounds;
					ColourBlockBounds = Rectangle.Empty;
				}
			} }
		public Rectangle ColourBlockBounds { get; set; }
		public Rectangle BodyBounds { get; set; }
		public Rectangle SelectTopBounds { get; set; }
		public Rectangle SelectBottomBounds { get; set; }
	}
}