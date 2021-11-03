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

namespace Syd.ScheduleControls.Renderer
{
    internal interface IRenderer
    {    	
    	/// <summary>
    	/// draws a box and allows you to override the background colour
    	/// </summary>
    	void DrawBox(Graphics graphics, Font font, Rectangle bounds, Brush backgroundColorOverride);
        /// <summary>
        /// Draw a box with background colour, text and optional border.
        /// </summary>
        void DrawBox(Graphics graphics, Font font, Rectangle bounds);
        void DrawBox(Graphics graphics, Font font, Rectangle bounds, string text);
        void DrawBox(Graphics graphics, Font font, Rectangle bounds, string text, bool drawBackground, BorderInfo borders);
        void DrawBox(Graphics graphics, Font font, Rectangle bounds, string text, bool drawBackground, BorderInfo borders, TextAlignment textAlignment);
        void DrawBox(Graphics graphics, Font font, Rectangle bounds, string text, bool drawBackground, BorderInfo borders, TextAlignment textAlignment,bool bold);
        void DrawLine(Graphics graphics, int x1, int y1, int x2, int y2);
        TextInfo GetTextInfo(Graphics graphics, Font font);
    }
}
