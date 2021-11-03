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
using System.Drawing.Drawing2D;

namespace Syd.ScheduleControls.Renderer
{
    /// <summary>
    /// Renderer when visual styles are disabled.
    /// </summary>
    internal class NonVisualStyleWrapper : IRenderer
    {
    	public bool UsePartialBlend {get;set;}
    	public bool NoGradientBlend {get;set;}
        private readonly Color backColour;
        private readonly Brush backColourBrush;
        private readonly Color backColour2; //for gradients
        private Brush backColourBrush2; //for gradients
        private Color foreColour;
        private readonly Brush foreColourBrush;
        private readonly Pen borderPen;

        /// <summary>
        /// Initializes a new instance of the <see cref="NonVisualStyleWrapper"/> class.
        /// </summary>
        /// <param name="foreColour">The fore colour.</param>
        /// <param name="foreColourBrush">The fore colour brush.</param>
        /// <param name="backColour">The back colour.</param>
        /// <param name="backColourBrush">The back colour brush.</param>
        /// <param name="borderPen">The border pen.</param>
        public NonVisualStyleWrapper(Color foreColour, Brush foreColourBrush, Color backColour, Brush backColourBrush, Pen borderPen)
        {
            this.backColour = backColour;
            this.backColourBrush = backColourBrush;
            this.foreColour = foreColour;
            this.foreColourBrush = foreColourBrush;
            this.backColour2 = Color.Empty;
            this.backColourBrush2 = null;
            this.borderPen = borderPen;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NonVisualStyleWrapper"/> class.
        /// </summary>
        /// <param name="foreColour">The fore colour.</param>
        /// <param name="foreColourBrush">The fore colour brush.</param>
        /// <param name="backColour">The back colour.</param>
        /// <param name="backColourBrush">The back colour brush.</param>
        /// <param name="backColour2">The back colour2.</param>
        /// <param name="backColourBrush2">The back colour brush2.</param>
        /// <param name="borderPen">The border pen.</param>
        public NonVisualStyleWrapper(Color foreColour, Brush foreColourBrush, Color backColour, Brush backColourBrush, Color backColour2, Brush backColourBrush2, Pen borderPen)
        {
            this.backColour = backColour;
            this.backColourBrush = backColourBrush;
            this.backColour2 = backColour2;
            this.backColourBrush2 = backColourBrush2;
            this.foreColour = foreColour;
            this.foreColourBrush = foreColourBrush;
            this.borderPen = borderPen;
        }

        public void DrawLine(Graphics g, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(borderPen, x1, y1, x2, y2);
        }

        public TextInfo GetTextInfo(Graphics g,Font font)
        {
            TextInfo info = new TextInfo();
            info.Height = font.Height;
            return info;
        }
        public void DrawBox(Graphics g, Font font, Rectangle bounds, string text, bool drawBackground, BorderInfo borders)
        {
            DrawBox(g, font, bounds, text, drawBackground, borders, TextAlignment.Left);
        }
        public void DrawBox(Graphics g, Font font, Rectangle bounds, string text, bool drawBackground, BorderInfo borders, TextAlignment textAlignment)
        {
            DrawBox(g, font, bounds, text, drawBackground, borders, textAlignment, false);
        }
                public void DrawBox(Graphics g, Font font, Rectangle bounds, string text, bool drawBackground, BorderInfo borders, TextAlignment textAlignment,bool bold)
        {
            DrawBox(g, font, bounds, text, drawBackground, borders, textAlignment, bold,null);
        }
        public void DrawBox(Graphics g, Font font, Rectangle bounds, string text, bool drawBackground, BorderInfo borders, TextAlignment textAlignment, bool bold, Brush backgroundOverride)
        {
        	
            //draw the background
            if (drawBackground)
            {
            	if (backgroundOverride!=null)            		
            	{
            		g.FillRectangle(backgroundOverride, bounds);
            	}
            	else{
            		//TODO: Turn off gradients if high contrast mode is enabled
                //draw gradient if 2 back colours
                if (backColour2 != Color.Empty)
                {
                    try
                    {
                        using (
                            LinearGradientBrush linGrBrush = new LinearGradientBrush(bounds, backColour, backColour2, 270F))
                        {
                            //just put a little of one colour in
                            if (UsePartialBlend)
                            {
                                float[] factors = { 0.6f, 1.0f, 1.0f };
                                float[] positions = { 0.0f, 0.5f, 1.0f };
                                Blend blend = new Blend();
                                blend.Factors = factors;
                                blend.Positions = positions;
                                linGrBrush.Blend = blend;
                            }
                            else if (NoGradientBlend)
                            {
                                float[] factors = { 0.6f, 0.6f, 0.6f };
                                float[] positions = { 0.0f, 0.5f, 1.0f };
                                Blend blend = new Blend();
                                blend.Factors = factors;
                                blend.Positions = positions;
                                linGrBrush.Blend = blend;
                            }
                            g.FillRectangle(linGrBrush, bounds);
                        }
                    }
                    catch { }
                }
                else
                {
                    //else draw plain
                    g.FillRectangle(backColourBrush, bounds);
                }
            	}
            }

            //draw the borders
            if (borders != null)
            {
                //handle overlaps of the border - BorderInfo.OverlapLeftRightBottom
                if (borders.All && borders.OverlapBottomRight)
                {
                    //calculate border, paint with overlap
                    g.DrawRectangle(borderPen, bounds);
                }
            }

            //draw the text
            if (!string.IsNullOrEmpty(text))
            {
                if (bold)
                {
                    Font boldFont = new Font(font,FontStyle.Bold);
                    if (textAlignment == TextAlignment.Left)
                        g.DrawString(text, boldFont, foreColourBrush, bounds, StringFormats.Left);
                    else if (textAlignment == TextAlignment.Right)
                        g.DrawString(text, boldFont, foreColourBrush, bounds, StringFormats.Right);
                    else
                        g.DrawString(text, boldFont, foreColourBrush, bounds, StringFormats.Center);
                }
                else
                {
                    if (textAlignment == TextAlignment.Left)
                        g.DrawString(text, font, foreColourBrush, bounds, StringFormats.Left);
                    else if (textAlignment == TextAlignment.Right)
                        g.DrawString(text, font, foreColourBrush, bounds, StringFormats.Right);
                    else
                        g.DrawString(text, font, foreColourBrush, bounds, StringFormats.Center);
                }
            }
        }

        public void DrawBox(Graphics g, Font font, Rectangle bounds)
        {
            DrawBox(g, font, bounds, string.Empty, true, BorderInfo.Default, TextAlignment.Left);
        }
        public void DrawBox(Graphics g, Font font, Rectangle bounds, string text)
        {
            DrawBox(g, font, bounds, text, true, BorderInfo.Default, TextAlignment.Left);
        }

        
        public void DrawBox(Graphics g, Font font, Rectangle bounds,Brush backgroundColorOverride)
        {
            DrawBox(g, font, bounds, string.Empty, true, BorderInfo.Default, TextAlignment.Left,false,backgroundColorOverride);
        }
        
    }
}
