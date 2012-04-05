//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using EGMGame.Library;

namespace EGMGame.Controls
{
    public interface IAddRemoveList
    {
        void SetupList(IEnumerable list, Type type);
        int Count { get; }
        bool Enabled { get; set; }
        bool Master { get; set; }
        void ForceIndexChange();
    }
}
