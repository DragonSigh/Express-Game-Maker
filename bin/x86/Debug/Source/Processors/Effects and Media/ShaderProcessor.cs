//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace EGMGame
{
    
    public class ShaderProcessor
    {
#if !SILVERLIGHT
        [XmlIgnore, DoNotSerialize]
        public Effect Effect
        {
            get
            {
                if (effect != null) return effect;
                return effect = Content.Effect(MaterialID);
            }
        } Effect effect;
#endif
        public int MaterialID = -1;
        public bool IsNull { get { return (MaterialID == -1); } }
        // Parameters
        public List<EffectParam> Parameters = new List<EffectParam>();
        /// <summary>
        /// Constructor
        /// </summary>
        public ShaderProcessor() { }
        /// <summary>
        /// Setup
        /// </summary>
        /// <param name="effectId"></param>
        /// <param name="parameters"></param>
        public void Setup(int effectId, List<EffectParam> parameters)
        {
            MaterialID = effectId;
            Parameters = parameters;
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public void Process()
        {
#if !SILVERLIGHT
            for (int i = 0; i < Parameters.Count; i++)
            {
                switch (Parameters[i].ParamType)
                {
                    case 0: // Integer
                        Effect.Parameters[Parameters[i].Name].SetValue((int)Parameters[i].GetValue());
                        break;
                    case 1: // String
                        Effect.Parameters[Parameters[i].Name].SetValue((string)Parameters[i].GetValue());
                        break;
                    case 2: // Bool
                        Effect.Parameters[Parameters[i].Name].SetValue((bool)Parameters[i].GetValue());
                        break;
                    case 3: // Float
                        Effect.Parameters[Parameters[i].Name].SetValue((float)Parameters[i].GetValue());
                        break;
                    case 4: // Vector2
                        Effect.Parameters[Parameters[i].Name].SetValue((Vector2)Parameters[i].GetValue());
                        break;
                    case 5: // Vector3
                        Effect.Parameters[Parameters[i].Name].SetValue((Vector3)Parameters[i].GetValue());
                        break;
                    case 6: // Vector4
                        Effect.Parameters[Parameters[i].Name].SetValue((Vector4)Parameters[i].GetValue());
                        break;
                    case 7: // List (Integer)
                        Effect.Parameters[Parameters[i].Name].SetValue((int[])Parameters[i].GetValue());
                        break;
                    case 8: // Texture
                        Effect.Parameters[Parameters[i].Name].SetValue((Texture2D)Parameters[i].GetValue());
                        break;
                    case 9: // Other
                        switch ((int)Parameters[i].Value)
                        {
                            case 0:
                                Effect.Parameters[Parameters[i].Name].SetValue((Global.Instance.ActiveCamera.ViewTransformationMatrix()));
                                break;
                        }
                        break;
                }
            }
#endif
        }
    }

    public class EffectParam
    {
        public string Name;
        public int ParamType;
        public int ValueType; // 0-constant; 1-variable
        public object Value;

        public object GetValue()
        {
            switch (ParamType)
            {
                case 0: // Integer
                    if (ValueType == 0) return (int)Value;
                    return Global.Variable((int)Value);
                case 1: // String
                    if (ValueType == 0) return (string)Value;
                    return Global.String((int)Value);
                case 2: // Bool
                    if (ValueType == 0) return (bool)Value;
                    return Global.Instance.Switches.GetData((int)Value).State;
                case 3: // Float
                    if (ValueType == 0) return (float)Value;
                    return (float)Global.Variable((int)Value);
                case 4: // Vector2
                    if (ValueType == 0) return (Vector2)Value;
                    return new Vector2((float)Global.Variable((int)((Vector2)Value).X), (float)Global.Variable((int)((Vector2)Value).Y));
                case 5: // Vector3
                    if (ValueType == 0) return (Vector3)Value;
                    return new Vector3((float)Global.Variable((int)((Vector3)Value).X), (float)Global.Variable((int)((Vector3)Value).Y), (float)Global.Variable((int)((Vector3)Value).Z));
                case 6: // Vector4
                    if (ValueType == 0) return (Vector4)Value;
                    return new Vector4((float)Global.Variable((int)((Vector4)Value).X), (float)Global.Variable((int)((Vector4)Value).Y), (float)Global.Variable((int)((Vector4)Value).Z), (float)Global.Variable((int)((Vector4)Value).W));
                case 7: // List (Integer)
                    return Global.Instance.Lists.GetData((int)Value).Values.ToArray();
                case 8: // Texture
                    return Content.Texture2D((int)Value);
            }
            return null;
        }
    }

}
