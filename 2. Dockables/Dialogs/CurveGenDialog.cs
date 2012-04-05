//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace EGMGame.Docking.Database
{
    public partial class CurveGenDialog : Form
    {
        internal List<int> curveList;

        public CurveGenDialog()
        {
            InitializeComponent();
            curveList = new List<int>();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                experience(curveList.Count);
            }
            else
            {
                AdvancedExperience(curveList.Count);
            }
            this.Tag = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                experience(curveList.Count);
            }
            else
            {
                AdvancedExperience(curveList.Count);
            }
            ((DatasetListDialog)this.Tag).SetupCurveList(curveList);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Tag = null;
            this.Close();
        }

        private void nudGrowth1_ValueChanged(object sender, EventArgs e)
        {
            experience(curveList.Count);
            ((DatasetListDialog)this.Tag).SetupCurveList(curveList);
        }

        public void experience(int lvl)
        {
            curveList.Clear();
            long a = 0;
            int x = 0;
            int growth = (int)nudGrowth1.Value;
            for (x = 1; x <= lvl; x++)
            {
                a = a + (int)(x + growth * (Math.Pow(2, (x / 7))));
                curveList.Add((int)Math.Min(9999, Math.Floor((decimal)(a / 4))));
            }
        }

        private void nudBase_ValueChanged(object sender, EventArgs e)
        {
            AdvancedExperience(curveList.Count);
            ((DatasetListDialog)this.Tag).SetupCurveList(curveList);
        }

        private void nudLast_ValueChanged(object sender, EventArgs e)
        {
            AdvancedExperience(curveList.Count);
            ((DatasetListDialog)this.Tag).SetupCurveList(curveList);
        }

        private void nudGrowthEnd_ValueChanged(object sender, EventArgs e)
        {
            AdvancedExperience(curveList.Count);
            ((DatasetListDialog)this.Tag).SetupCurveList(curveList);
        }
        private void AdvancedExperience(int lvl)
        {
            curveList.Clear();

            int st, gr, en;
            st = (int)nudBase.Value;
            gr = (int)nudGrowthEnd.Value;
            en = (int)nudLast.Value;

            Vector2 startVector = new Vector2(0, st);
            Vector2 endVector = new Vector2(lvl, en);
            float midy = GetExpMidPoint(startVector, endVector, lvl / 2);
            Vector2 growthVector = new Vector2(lvl / 2, midy);
            growthVector = new Vector2(growthVector.X, growthVector.Y += gr);
            
            float a,b,c,d,e,f;
            a = startVector.X;
            b = startVector.Y;
            c = growthVector.X;
            d = growthVector.Y;
            e = endVector.X;
            f = endVector.Y;

            int x;            

            for (x = 1; x <= lvl; x++)
            {
                float part1 = f/((float)(Math.Pow(e,2))-(e*a)-(e*c)+(c*a));            
                float part2 = b/((float)(Math.Pow(a,2))-(a*c)-(a*e)+(c*e));
                float part3 = d/((float)(Math.Pow(c,2))-(c*a)-(c*e)+(a*e));

                part1 *= (x - a) * (x - c);
                part2 *= (x - c) * (x - e);
                part3 *= (x - a) * (x - e);

                float final = part1 + part2 + part3;

                curveList.Add((int)Math.Min(9999, Math.Floor((decimal)final)));
            }
            
        }

        private float GetExpMidPoint(Vector2 start,Vector2 end, int pos)
        {
            // y = mx+c
            float m = (int)((end.Y - start.Y) / (end.X - start.X));
            float c = (int)start.Y;
            
            return (pos * m) + c;
        }
    }
}
