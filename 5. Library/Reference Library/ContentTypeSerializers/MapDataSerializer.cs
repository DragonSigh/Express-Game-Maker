using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using EGMGame.Library;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using EGMGame.GameLibrary;

namespace EGMGame
{
    [ContentTypeSerializer]
    class TestClassSerializer : ContentTypeSerializer<LayerData>
    {
        protected override void Serialize(IntermediateWriter output, LayerData value, ContentSerializerAttribute format)
        {
            ContentSerializerAttribute a;
            a = new ContentSerializerAttribute() { ElementName = "Name" };
            output.WriteObject<string>(value.Name, a);
            a.ElementName = "ID";
            output.WriteObject<int>(value.ID, a);
            a.ElementName = "Category";
            output.WriteObject<int>(value.Category, a); a.ElementName = "IsVisible";
            output.WriteObject<bool>(value.IsVisible, a); a.ElementName = "Tiles";
            output.WriteObject<List<TileData>>(value.Tiles, a); a.ElementName = "Backgrounds";
            output.WriteObject<List<LayerBackground>>(value.Backgrounds, a); a.ElementName = "MoveSpeed";
            output.WriteObject<Vector2>(value.MoveSpeed, a); a.ElementName = "Tint";
            output.WriteObject<ColorRGBA>(value.Tint, a); a.ElementName = "Events";
            output.WriteObject<Dictionary<int, EventData>>(value.Events, a); a.ElementName = "ScrollType";
            output.WriteObject<int>(value.ScrollType, a); a.ElementName = "CollisionData";
            output.WriteObject<List<CollisionData>>(value.CollisionData, a);
        }

        protected override LayerData Deserialize(IntermediateReader input, ContentSerializerAttribute format, LayerData existingInstance)
        {
            if (existingInstance == null) existingInstance = new LayerData();

            ContentSerializerAttribute a;

            switch (Global.Project.Version)
            {
                case "1":
                    a = new ContentSerializerAttribute() { ElementName = "Name" };
                    existingInstance.Name = input.ReadRawObject<string>(a);
                    a.ElementName = "ID";
                    existingInstance.ID = input.ReadRawObject<int>(a);
                    a.ElementName = "Category";
                    existingInstance.Category = input.ReadRawObject<int>(a); a.ElementName = "IsVisible";
                    existingInstance.IsVisible = input.ReadRawObject<bool>(a); a.ElementName = "Tiles";
                    existingInstance.Tiles = input.ReadRawObject<List<TileData>>(a); a.ElementName = "Backgrounds";
                    existingInstance.Backgrounds = input.ReadRawObject<List<LayerBackground>>(a); a.ElementName = "MoveSpeed";
                    existingInstance.MoveSpeed = input.ReadRawObject<Microsoft.Xna.Framework.Vector2>(a); a.ElementName = "Tint";
                    existingInstance.Tint = input.ReadRawObject<ColorRGBA>(a); a.ElementName = "Events";
                    existingInstance.Events = input.ReadRawObject<Dictionary<int, EventData>>(a); a.ElementName = "ScrollType";
                    existingInstance.ScrollType = input.ReadRawObject<int>(a);
                    break;
                case "2":
                    a = new ContentSerializerAttribute() { ElementName = "Name" };
                    existingInstance.Name = input.ReadRawObject<string>(a);
                    a.ElementName = "ID";
                    existingInstance.ID = input.ReadRawObject<int>(a);
                    a.ElementName = "Category";
                    existingInstance.Category = input.ReadRawObject<int>(a); a.ElementName = "IsVisible";
                    existingInstance.IsVisible = input.ReadRawObject<bool>(a); a.ElementName = "Tiles";
                    existingInstance.Tiles = input.ReadRawObject<List<TileData>>(a); a.ElementName = "Backgrounds";
                    existingInstance.Backgrounds = input.ReadRawObject<List<LayerBackground>>(a); a.ElementName = "MoveSpeed";
                    existingInstance.MoveSpeed = input.ReadRawObject<Microsoft.Xna.Framework.Vector2>(a); a.ElementName = "Tint";
                    existingInstance.Tint = input.ReadRawObject<ColorRGBA>(a); a.ElementName = "Events";
                    existingInstance.Events = input.ReadRawObject<Dictionary<int, EventData>>(a); a.ElementName = "ScrollType";
                    existingInstance.ScrollType = input.ReadRawObject<int>(a); a.ElementName = "CollisionData";
                    existingInstance.CollisionData = input.ReadRawObject<List<CollisionData>>(a);
                    break;
                case "3":
                    a = new ContentSerializerAttribute() { ElementName = "Name" };
                    existingInstance.Name = input.ReadRawObject<string>(a);
                    a.ElementName = "ID";
                    existingInstance.ID = input.ReadRawObject<int>(a);
                    a.ElementName = "Category";
                    existingInstance.Category = input.ReadRawObject<int>(a); a.ElementName = "IsVisible";
                    existingInstance.IsVisible = input.ReadRawObject<bool>(a); a.ElementName = "Tiles";
                    existingInstance.Tiles = input.ReadRawObject<List<TileData>>(a); a.ElementName = "Backgrounds";
                    existingInstance.Backgrounds = input.ReadRawObject<List<LayerBackground>>(a); a.ElementName = "MoveSpeed";
                    existingInstance.MoveSpeed = input.ReadRawObject<Microsoft.Xna.Framework.Vector2>(a); a.ElementName = "Tint";
                    existingInstance.Tint = input.ReadRawObject<ColorRGBA>(a); a.ElementName = "Events";
                    existingInstance.Events = input.ReadRawObject<Dictionary<int, EventData>>(a); a.ElementName = "ScrollType";
                    existingInstance.ScrollType = input.ReadRawObject<int>(a); a.ElementName = "CollisionData";
                    existingInstance.CollisionData = input.ReadRawObject<List<CollisionData>>(a);
                    break;
            }

            return existingInstance;
        }
    }
}
