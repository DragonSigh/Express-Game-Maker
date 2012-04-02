using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame
{
    class CustomUpDown : NumericUpDown
    {
        public decimal OldValue
        {
            get { return oldValue; }
            set { oldValue = value; }
        }

        public bool OnChange
        {
            get { return change; }
            set { change = value; }
        }

        bool change = false;
        decimal oldValue = -1;
        decimal currentValue = 0;
        protected override void OnValueChanged(EventArgs e)
        {
            if (!change)
            {
                oldValue = currentValue;
                change = true;
            }

            if (change && oldValue == this.Value)
            {
                change = false;
            }

            base.OnValueChanged(e);
            currentValue = this.Value;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control || e.KeyCode == Keys.Z)
            {
                OnValidated(EventArgs.Empty);
            }
            base.OnKeyDown(e);
        }
    }
}
