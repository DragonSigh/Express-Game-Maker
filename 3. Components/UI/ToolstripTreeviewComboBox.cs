//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Controls.Game;

namespace EGMGame.Controls
{
    public class ParticleComboBoxToolStrip : ToolStripControlHost
    {
       // Call the base constructor passing in a MonthCalendar instance.
        public ParticleComboBoxToolStrip() : base(new ParticleComboBox()) { }

        public ParticleComboBox ComboboxControl
        {
            get
            {
                return Control as ParticleComboBox;
            }
        }
        // Subscribe and unsubscribe the control events you wish to expose.
        protected override void OnSubscribeControlEvents(Control c)
        {
            // Call the base so the base events are connected.
            base.OnSubscribeControlEvents(c);

            // Cast the control to a MonthCalendar control.
            ParticleComboBox comboboxControl = (ParticleComboBox)c;

            // Add the event.
            comboboxControl.SelectedIndexChanged += new EventHandler(comboboxControl_SelectedIndexChanged);
        }

        protected override void OnUnsubscribeControlEvents(Control c)
        {
            // Call the base method so the basic events are unsubscribed.
            base.OnUnsubscribeControlEvents(c);

            // Cast the control to a MonthCalendar control.
            ParticleComboBox comboboxControl = (ParticleComboBox)c;

            // Remove the event.
            comboboxControl.SelectedIndexChanged -= new EventHandler(comboboxControl_SelectedIndexChanged);
      
        }

        public event EventHandler SelectedIndexChanged;

        private void comboboxControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, e);
        }

        public void RefrestList(bool memorize)
        {
            ComboboxControl.RefreshList(memorize);
        }

    }
}
