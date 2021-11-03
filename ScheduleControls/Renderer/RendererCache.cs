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
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.Drawing;

namespace Syd.ScheduleControls.Renderer
{
    /// <summary>
    /// Class to hold renderers for visual styles and non visual styles.
    /// </summary>
    internal class RendererCache
    {
        //TODO: use SystemInformation.HighContrast property, and pretty up styles some more for regular theme users

        private readonly VisualStyleRenderer bigHeaderRender = null;
        private readonly VisualStyleElement bigHeaderElement = VisualStyleElement.ExplorerBar.SpecialGroupHead.Normal;

        private readonly VisualStyleRenderer headerRender = null;
        private readonly VisualStyleElement headerElement = VisualStyleElement.ExplorerBar.NormalGroupHead.Normal;

        private readonly VisualStyleRenderer headerRenderSel = null;
        private readonly VisualStyleElement headerElementSel = VisualStyleElement.ExplorerBar.SpecialGroupHead.Normal;

        //private readonly VisualStyleRenderer appointmentRender = null;
        private readonly VisualStyleElement appointmentElement = VisualStyleElement.ExplorerBar.NormalGroupBackground.Normal;

        //private readonly VisualStyleRenderer appointmentRenderSel = null;
        private readonly VisualStyleElement appointmentElementSel = VisualStyleElement.ExplorerBar.SpecialGroupHead.Normal;

        private readonly IRenderer bigHeaderRenderWrap = null;
        private readonly IRenderer headerRenderWrap = null;
        private readonly IRenderer headerRenderSelWrap = null;
        private readonly IRenderer appointmentRenderWrap = null;
        private readonly IRenderer appointmentRenderSelWrap = null;
        private readonly IRenderer controlRenderWrap = null;
        private readonly IRenderer bodyRenderWrap = null;
        private readonly IRenderer bodyLightRenderWrap = null;

        /// <summary>
        /// Prevents a default instance of the <see cref="RendererCache"/> class from being created.
        /// </summary>
        private RendererCache()
        {
            //if visual styles is turned on
            if (Application.RenderWithVisualStyles
                && VisualStyleRenderer.IsSupported
                && VisualStyleRenderer.IsElementDefined(headerElement)
                && VisualStyleRenderer.IsElementDefined(headerElementSel)
                && VisualStyleRenderer.IsElementDefined(appointmentElement)
                && VisualStyleRenderer.IsElementDefined(appointmentElementSel)
                && VisualStyleRenderer.IsElementDefined(bigHeaderElement)
            )
            {
                useVisualStyles = true;
                headerRender = new VisualStyleRenderer(headerElement);
                headerRenderWrap = new VisualStyleWrapper(headerRender, SystemPens.ControlDarkDark);
                bigHeaderRender = new VisualStyleRenderer(bigHeaderElement);
                bigHeaderRenderWrap = new VisualStyleWrapper(bigHeaderRender, SystemPens.ControlDarkDark);
                headerRenderSel = new VisualStyleRenderer(headerElementSel);
                headerRenderSelWrap = new VisualStyleWrapper(headerRenderSel, SystemPens.ControlDarkDark);
                //appointmentRender = new VisualStyleRenderer(appointmentElement);
                //appointmentRenderWrap = new VisualStyleWrapper(appointmentRender, SystemPens.ControlDarkDark);
                //appointmentRenderSel = new VisualStyleRenderer(appointmentElementSel);
                //appointmentRenderSelWrap = new VisualStyleWrapper(appointmentRenderSel, SystemPens.ControlDarkDark);

                    appointmentRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText,
                                                                    SystemBrushes.ControlText,
                                                               SystemColors.ControlDark,
                                                               SystemBrushes.ControlDark,
                                                                    SystemColors.ControlLightLight,
                                                                    SystemBrushes.ControlLightLight,
                                                                    SystemPens.ControlText);
                ((NonVisualStyleWrapper)appointmentRenderWrap).UsePartialBlend = true;
                appointmentRenderSelWrap = new NonVisualStyleWrapper(SystemColors.HighlightText,
                                                                     SystemBrushes.HighlightText,
                                                                     SystemColors.HighlightText,
                                                                     SystemBrushes.HighlightText,
                                                                     SystemColors.Highlight,
                                                                     SystemBrushes.Highlight,
                                                                     SystemPens.ControlText);
                ((NonVisualStyleWrapper)appointmentRenderSelWrap).UsePartialBlend = true;
              
                
                
                controlRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText, SystemBrushes.ControlText, SystemColors.Control, SystemBrushes.Control, SystemPens.ControlText);
                bodyRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText, SystemBrushes.ControlText, SystemColors.ControlLightLight, SystemBrushes.ControlLightLight, SystemPens.ControlText);
                bodyLightRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText, SystemBrushes.ControlText, SystemColors.ControlLightLight, SystemBrushes.ControlLightLight, SystemPens.Control);
            }
            else
            {
                //else non-visual style 'boring' mode
                bigHeaderRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText, SystemBrushes.ControlText, SystemColors.Control, SystemBrushes.Control, SystemPens.ControlText);
                headerRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText, 
                                                             SystemBrushes.ControlText, 
                                                             SystemColors.Control, 
                                                             SystemBrushes.Control, 
                                                             SystemColors.ControlLightLight, 
                                                             SystemBrushes.ControlLightLight, 
                                                             SystemPens.ControlText);
                ((NonVisualStyleWrapper)headerRenderWrap).NoGradientBlend=true;
                headerRenderSelWrap = new NonVisualStyleWrapper(SystemColors.HighlightText, 
                                                                SystemBrushes.HighlightText, 
                                                                SystemColors.Highlight, 
                                                                SystemBrushes.Highlight, 
                                                                SystemPens.ControlText);
                appointmentRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText, 
                                                                  SystemBrushes.ControlText,
                                                             SystemColors.Control,
                                                             SystemBrushes.Control, 
                                                                  SystemColors.ControlLightLight, 
                                                                  SystemBrushes.ControlLightLight,
                                                                  SystemPens.ControlText);
                ((NonVisualStyleWrapper)appointmentRenderWrap).UsePartialBlend=true;
                appointmentRenderSelWrap = new NonVisualStyleWrapper(SystemColors.HighlightText, 
                                                                     SystemBrushes.HighlightText,
                                                                     SystemColors.HighlightText,
                                                                     SystemBrushes.HighlightText,
                                                                     SystemColors.Highlight, 
                                                                     SystemBrushes.Highlight,
                                                                     SystemPens.ControlText);
                ((NonVisualStyleWrapper)appointmentRenderSelWrap).UsePartialBlend=true;
                controlRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText, SystemBrushes.ControlText, SystemColors.Control, SystemBrushes.Control, SystemPens.ControlText);
                bodyRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText, SystemBrushes.ControlText, SystemColors.ControlLightLight, SystemBrushes.ControlLightLight, SystemPens.ControlText);
                bodyLightRenderWrap = new NonVisualStyleWrapper(SystemColors.ControlText, SystemBrushes.ControlText, SystemColors.ControlLightLight, SystemBrushes.ControlLightLight, SystemPens.Control);
            }
        }

        private readonly bool useVisualStyles = false;
        public bool UseVisualStyles
        {
            get
            {
                return Application.RenderWithVisualStyles && useVisualStyles;
            }
        }

        private static RendererCache current = null;
        /// <summary>
        /// Gets the current renderer cache instance.
        /// </summary>
        public static RendererCache Current
        {
            get
            {
                if (current == null)
                {
                    current = new RendererCache();
                }
                return current;
            }
        }

        /// <summary>
        /// Run when visual styles changed.
        /// </summary>
        public void VisualStylesChanged()
        {
            current = new RendererCache();
        }

        /// <summary>
        /// Gets the light item renderer.
        /// </summary>
        public IRenderer ItemLight { get { return bodyLightRenderWrap; } }
        /// <summary>
        /// Gets the item renderer.
        /// </summary>
        public IRenderer Item { get { return bodyRenderWrap; } }
        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        public IRenderer Control { get { return controlRenderWrap; } }
        /// <summary>
        /// Gets the big header renderer.
        /// </summary>
        public IRenderer BigHeader { get { return bigHeaderRenderWrap; } }
        /// <summary>
        /// Gets the header renderer.
        /// </summary>
        public IRenderer Header { get { return headerRenderWrap; } }
        /// <summary>
        /// Gets the selected header renderer.
        /// </summary>
        public IRenderer HeaderSelected { get { return headerRenderSelWrap; } }
        /// <summary>
        /// Gets the appointment renderer.
        /// </summary>
        public IRenderer Appointment { get { return appointmentRenderWrap; } }
        /// <summary>
        /// Gets the selected appointment renderer.
        /// </summary>
        public IRenderer AppointmentSelected { get { return appointmentRenderSelWrap; } }
    }
}