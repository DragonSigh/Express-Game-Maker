//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using EGMGame.Library;

namespace EGMGame.Controls
{
    [Serializable]
    public class Scene
    {
        public MapData Data;

        public List<LayerData> Layers
        {
            get { return Data.Layers; }
        }

        public Vector2 Size
        {
            get { return Data.Size; }
        }

        public Scene(MapData d)
        {
            Data = d;
        }

        public LayerData GetLayer(int zIndex)
        {
            return Layers[zIndex];
        }
        public LayerData GetLayer(string name)
        {
            return Layers.Find(delegate(LayerData l) { return l.Name == name; });
        }

        public void NewLayer(string name)
        {
            LayerData layer = new LayerData();
            layer.Tiles = new List<TileData>();
            layer.IsVisible = true;
            layer.Name = name;
            Layers.Add(layer);
        }
        public void NewLayer(LayerData layer)
        {
            Layers.Add(layer);
        }

        public void DeleteLayer(int i)
        {
            Layers.RemoveAt(i);
        }

        internal void AddEvent(EventData ev, Vector2 location, LayerData layer)
        {
            if (ev is PlayerData)
            {
                GameData.Player.MapID = Data.ID;
                GameData.Player.Position = location;
                GameData.Player.LayerIndex = Data.Layers.IndexOf(layer);
            }
            else
            {
                EventData e = CloneTemplateEvent(ev, Data);
                e.Position = location;
                layer.Events.Add(e.ID, e);
            }
            MainForm.SelectedMap = Data;
        }

        private EventData CloneTemplateEvent(EventData ev, MapData map)
        {
            EventData e = Global.Duplicate<EventData>(ev);
            e.Name = ev.Name;
            e.LinkToParent = true;
            e.MapID = Data.ID;
            e.TemplateID = ev.ID;
            e.ID = Global.GetID(Global.GetMapEventList(Data));
            return e;
        }

        private void AddChildPrograms(EventProgramData page, EventProgramData n)
        {
            foreach (EventProgramData a in page.Programs)
            {
                EventProgramData na = new EventProgramData();
                na.Branch = a.Branch;
                na.ProgramCategory = a.ProgramCategory;
                na.Code = a.Code;
                na.Enabled = a.Enabled;
                na.Expand = a.Expand;
                na.ID = a.ID;
                na.Name = a.Name;
                na.Value = (object[])a.Value.Clone();
                n.Programs.Add(na);

                AddChildPrograms(a, na);
            }
        }
    }

    public class TileEventArgs : EventArgs
    {
        public Vector2 Position = new Vector2();
        public List<TileData> SelectedTiles = new List<TileData>();

        public TileEventArgs(List<TileData> selectedTiles)
        {
            SelectedTiles = selectedTiles;
        }
    }
}
