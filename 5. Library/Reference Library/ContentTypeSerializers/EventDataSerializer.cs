//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
//using EGMGame.Library;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework;
//using EGMGame.GameLibrary;

//namespace EGMGame
//{
//    [ContentTypeSerializer]
//    class EventPageClassSerializer : ContentTypeSerializer<EventPageData>
//    {
//        protected override void Serialize(IntermediateWriter output, EventPageData value, ContentSerializerAttribute format)
//        {
//            ContentSerializerAttribute a;
//            a = new ContentSerializerAttribute() { ElementName = "Name" };
//            output.WriteObject<string>(value.Name, a); a.ElementName = "ID";
//            output.WriteObject<int>(value.ID, a); a.ElementName = "Category";
//            output.WriteObject<int>(value.Category, a); a.ElementName = "Programs";
//            output.WriteObject<List<EventProgramData>>(value.Programs, a); a.ElementName = "ProgramCategory";

//            output.WriteObject<ProgramCategory>(value.ProgramCategory, a); a.ElementName = "Enabled";
//            output.WriteObject<bool>(value.Enabled, a); a.ElementName = "Code";
//            output.WriteObject<int>(value.Code, a); a.ElementName = "AnimationID";

//            output.WriteObject<int>(value.AnimationID, a); a.ElementName = "ActionID";

//            output.WriteObject<int>(value.ActionID, a); a.ElementName = "Direction";

//            output.WriteObject<int>(value.Direction, a); a.ElementName = "SwitchCondition";

//            output.WriteObject<bool>(value.SwitchCondition, a); a.ElementName = "VariableCondition";
//            output.WriteObject<bool>(value.VariableCondition, a); a.ElementName = "LocalSwitchCondition";
//            output.WriteObject<bool>(value.LocalSwitchCondition, a); a.ElementName = "LocalVariableCondition";
//            output.WriteObject<bool>(value.LocalVariableCondition, a); a.ElementName = "TriggerConditions";
//            output.WriteObject<TriggerConditions>(value.TriggerConditions, a); a.ElementName = "InputTriggerProgram";

//            output.WriteObject<EventProgramData>(value.InputTriggerProgram, a); a.ElementName = "MouseTriggerProgram";
//            output.WriteObject<EventProgramData>(value.MouseTriggerProgram, a); a.ElementName = "MapCollisionTrigger";
//            output.WriteObject<bool>(value.MapCollisionTrigger, a); a.ElementName = "GlobalMouseTrigger";

//            output.WriteObject<bool>(value.GlobalMouseTrigger, a); a.ElementName = "TouchEventIDs";

//            output.WriteObject<List<int>>(value.TouchEventIDs, a); a.ElementName = "VariableConditions";

//            output.WriteObject<List<VariableCondition>>(value.VariableConditions, a); a.ElementName = "SwitchConditions";

//            output.WriteObject<List<SwitchCondition>>(value.SwitchConditions, a); a.ElementName = "LocalVariableConditions";

//            output.WriteObject<List<LocalVariableCondition>>(value.LocalVariableConditions, a); a.ElementName = "LocalSwitchConditions";

//            output.WriteObject<List<LocalSwitchCondition>>(value.LocalSwitchConditions, a); a.ElementName = "EventSwitchConditions";
//            output.WriteObject<int[]>(value.EventSwitchConditions, a); a.ElementName = "EventSwitchCondition";
//            output.WriteObject<bool>(value.EventSwitchCondition, a); a.ElementName = "MovementPrograms";
//            output.WriteObject<List<EventProgramData>>(value.MovementPrograms, a); a.ElementName = "RepeatMovement";
//            output.WriteObject<bool>(value.RepeatMovement, a); a.ElementName = "SkipImpassable";
//            output.WriteObject<bool>(value.SkipImpassable, a); a.ElementName = "IgnoreHills";
//            output.WriteObject<bool>(value.IgnoreHills, a); a.ElementName = "EnableFrequency";
//            output.WriteObject<bool>(value.EnableFrequency, a); a.ElementName = "Frequency";
//            output.WriteObject<int>(value.Frequency, a); a.ElementName = "Enemy";
//            output.WriteObject<int>(value.Enemy, a); a.ElementName = "AttackCondition";

//            output.WriteObject<AttackCondition>(value.AttackCondition, a); a.ElementName = "SeeRang";
//            output.WriteObject<int>(value.SeeRange, a); a.ElementName = "HearRange";

//            output.WriteObject<int>(value.HearRange, a); a.ElementName = "BattleSpeed";
//            output.WriteObject<int>(value.BattleSpeed, a); a.ElementName = "Respawn";

//            output.WriteObject<int>(value.Respawn, a); a.ElementName = "LockOnTarget";
//            output.WriteObject<bool>(value.LockOnTarget, a); a.ElementName = "BattleDirections";

//            output.WriteObject<List<int>>(value.BattleDirections, a); a.ElementName = "Hostiles";

//            output.WriteObject<List<int>>(value.Hostiles, a); a.ElementName = "DeathTrigger";

//            output.WriteObject<int[]>(value.DeathTrigger, a); a.ElementName = "AttackSpeed";

//            output.WriteObject<int>(value.AttackSpeed, a); a.ElementName = "BattleMoveDist";
//            output.WriteObject<int>(value.BattleMoveDist, a); a.ElementName = "ParticleID";

//            output.WriteObject<int>(value.ParticleID, a); a.ElementName = "Speed";

//            output.WriteObject<int>(value.Speed, a); a.ElementName = "IsStatic";

//            output.WriteObject<bool>(value.IsStatic, a); a.ElementName = "IgnoreGravity";
//            output.WriteObject<bool>(value.IgnoreGravity, a); a.ElementName = "CustomMass";
//            output.WriteObject<bool>(value.CustomMass, a); a.ElementName = "CustomForce";
//            output.WriteObject<bool>(value.CustomForce, a); a.ElementName = "CustomLinearDrag";
//            output.WriteObject<bool>(value.CustomLinearDrag, a); a.ElementName = "CustomRotationalDrag";
//            output.WriteObject<bool>(value.CustomRotationalDrag, a); a.ElementName = "CustomFriction";
//            output.WriteObject<bool>(value.CustomFriction, a); a.ElementName = "CustomBounce";
//            output.WriteObject<bool>(value.CustomBounce, a); a.ElementName = "CustomImpulse";
//            output.WriteObject<bool>(value.CustomImpulse, a); a.ElementName = "CustomMOI";
//            output.WriteObject<bool>(value.CustomMOI, a); a.ElementName = "Mass";

//            output.WriteObject<float>(value.Mass, a); a.ElementName = "Force";
//            output.WriteObject<float>(value.Force, a); a.ElementName = "LinearDrag";
//            output.WriteObject<float>(value.LinearDrag, a); a.ElementName = "RotationalDrag";
//            output.WriteObject<float>(value.RotationalDrag, a); a.ElementName = "Friction";
//            output.WriteObject<float>(value.Friction, a); a.ElementName = "Bounce";
//            output.WriteObject<float>(value.Bounce, a); a.ElementName = "Impulse";
//            output.WriteObject<float>(value.Impulse, a); a.ElementName = "MomentOfInertia";
//            output.WriteObject<float>(value.MomentOfInertia, a); a.ElementName = "SyncAngleToRotation";

//            output.WriteObject<bool>(value.SyncAngleToRotation, a); a.ElementName = "RushTarget";

//            output.WriteObject<bool>(value.RushTarget, a); a.ElementName = "DontErase";

//            output.WriteObject<bool>(value.DontErase, a); a.ElementName = "PassThrough";

//            output.WriteObject<bool>(value.PassThrough, a); a.ElementName = "Cursor";

//            output.WriteObject<int>(value.Cursor, a); a.ElementName = "IsMovingPlatform";

//            output.WriteObject<bool>(value.IsMovingPlatform, a); a.ElementName = "IsFixedRotation";

//            output.WriteObject<bool>(value.IsFixedRotation, a); a.ElementName = "CustomGravity";

//            output.WriteObject<bool>(value.CustomGravity, a); a.ElementName = "Gravity";
//            output.WriteObject<Vector2>(value.Gravity, a); a.ElementName = "Attachments";

//            output.WriteObject<List<AttachmentJoint>>(value.Attachments, a); a.ElementName = "TouchTemplateEventIDs";

//            output.WriteObject<List<int>>(value.TouchTemplateEventIDs, a);
//        }


//        protected override EventPageData Deserialize(IntermediateReader input, ContentSerializerAttribute format, EventPageData instance)
//        {
//            if (instance == null) instance = new EventPageData();

//            ContentSerializerAttribute a;

//            switch (Global.Project.Version)
//            {
//                case "1":
//                    // OLD
//                    break;
//                case "2":
//                    a = new ContentSerializerAttribute() { ElementName = "Name" };
//                    instance.Name = input.ReadRawObject<string>(a); a = new ContentSerializerAttribute() { ElementName = "ID" };
//                    instance.ID = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Category" };
//                    instance.Category = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Programs" };
//                    instance.Programs = input.ReadRawObject<List<EventProgramData>>(a); a = new ContentSerializerAttribute() { ElementName = "ProgramCategory" };
//                    instance.ProgramCategory = input.ReadRawObject<ProgramCategory>(a); a = new ContentSerializerAttribute() { ElementName = "Enabled" };
//                    instance.Enabled = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Code" };
//                    instance.Code = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "AnimationID" };
//                    instance.AnimationID = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "ActionID" };

//                    instance.ActionID = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Direction" };

//                    instance.Direction = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "SwitchCondition" };

//                    instance.SwitchCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "VariableCondition" };
//                    instance.VariableCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "LocalSwitchCondition" };
//                    instance.LocalSwitchCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "LocalVariableCondition" };

//                    instance.LocalVariableCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "TriggerConditions" };
//                    instance.TriggerConditions = input.ReadRawObject<TriggerConditions>(a); a = new ContentSerializerAttribute() { ElementName = "InputTriggerProgram" };

//                    instance.InputTriggerProgram = input.ReadRawObject<EventProgramData>(a); a = new ContentSerializerAttribute() { ElementName = "MouseTriggerProgram" };
//                    instance.MouseTriggerProgram = input.ReadRawObject<EventProgramData>(a); a = new ContentSerializerAttribute() { ElementName = "MapCollisionTrigger" };
//                    instance.MapCollisionTrigger = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "GlobalMouseTrigger" };

//                    instance.GlobalMouseTrigger = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "TouchEventIDs" };

//                    instance.TouchEventIDs = input.ReadRawObject<List<int>>(a); a = new ContentSerializerAttribute() { ElementName = "VariableConditions" };

//                    instance.VariableConditions = input.ReadRawObject<List<VariableCondition>>(a); a = new ContentSerializerAttribute() { ElementName = "SwitchConditions" };

//                    instance.SwitchConditions = input.ReadRawObject<List<SwitchCondition>>(a); a = new ContentSerializerAttribute() { ElementName = "LocalVariableConditions" };

//                    instance.LocalVariableConditions = input.ReadRawObject<List<LocalVariableCondition>>(a); a = new ContentSerializerAttribute() { ElementName = "LocalSwitchConditions" };

//                    instance.LocalSwitchConditions = input.ReadRawObject<List<LocalSwitchCondition>>(a); a = new ContentSerializerAttribute() { ElementName = "EventSwitchConditions" };
//                    instance.EventSwitchConditions = input.ReadRawObject<int[]>(a); a = new ContentSerializerAttribute() { ElementName = "EventSwitchCondition" };
//                    instance.EventSwitchCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "MovementPrograms" };
//                    instance.MovementPrograms = input.ReadRawObject<List<EventProgramData>>(a); a = new ContentSerializerAttribute() { ElementName = "RepeatMovement" };
//                    instance.RepeatMovement = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "SkipImpassable" };
//                    instance.SkipImpassable = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "IgnoreHills" };
//                    instance.IgnoreHills = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "EnableFrequency" };
//                    instance.EnableFrequency = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Frequency" };
//                    instance.Frequency = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Enemy" };
//                    instance.Enemy = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "AttackCondition" };

//                    instance.AttackCondition = input.ReadRawObject<AttackCondition>(a); a = new ContentSerializerAttribute() { ElementName = "SeeRang" };
//                    instance.SeeRange = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "HearRange" };

//                    instance.HearRange = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "BattleSpeed" };
//                    instance.BattleSpeed = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Respawn" };

//                    instance.Respawn = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "LockOnTarget" };
//                    instance.LockOnTarget = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "BattleDirections" };

//                    instance.BattleDirections = input.ReadRawObject<List<int>>(a); a = new ContentSerializerAttribute() { ElementName = "Hostiles" };

//                    instance.Hostiles = input.ReadRawObject<List<int>>(a); a = new ContentSerializerAttribute() { ElementName = "DeathTrigger" };

//                    instance.DeathTrigger = input.ReadRawObject<int[]>(a); a = new ContentSerializerAttribute() { ElementName = "AttackSpeed" };

//                    instance.AttackSpeed = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "BattleMoveDist" };
//                    instance.BattleMoveDist = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "ParticleID" };

//                    instance.ParticleID = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Speed" };

//                    instance.Speed = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "IsStatic" };

//                    instance.IsStatic = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "IgnoreGravity" };
//                    instance.IgnoreGravity = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomMass" };
//                    instance.CustomMass = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomForce" };
//                    instance.CustomForce = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomLinearDrag" };
//                    instance.CustomLinearDrag = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomRotationalDrag" };
//                    instance.CustomRotationalDrag = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomFriction" };
//                    instance.CustomFriction = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomBounce" };
//                    instance.CustomBounce = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomImpulse" };
//                    instance.CustomImpulse = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomMOI" };
//                    instance.CustomMOI = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Mass" };

//                    instance.Mass = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "Force" };
//                    instance.Force = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "LinearDrag" };
//                    instance.LinearDrag = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "RotationalDrag" };
//                    instance.RotationalDrag = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "Friction" };
//                    instance.Friction = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "Bounce" };
//                    instance.Bounce = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "Impulse" };
//                    instance.Impulse = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "MomentOfInertia" };
//                    instance.MomentOfInertia = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "SyncAngleToRotation" };

//                    instance.SyncAngleToRotation = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "RushTarget" };

//                    instance.RushTarget = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "DontErase" };

//                    instance.DontErase = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "PassThrough" };

//                    instance.PassThrough = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Cursor" };

//                    instance.Cursor = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "IsMovingPlatform" };

//                    instance.IsMovingPlatform = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "IsFixedRotation" };

//                    instance.IsFixedRotation = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomGravity" };

//                    instance.CustomGravity = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Gravity" };
//                    instance.Gravity = input.ReadRawObject<Vector2>(a); a = new ContentSerializerAttribute() { ElementName = "Attachments" };

//                    instance.Attachments = input.ReadRawObject<List<AttachmentJoint>>(a);// a = new ContentSerializerAttribute() { ElementName = ""};

//                    //TouchTemplateEventIDs= input.ReadRawObject<List<int>>(a);
//                    break;
//                case "3":
//                    a = new ContentSerializerAttribute() { ElementName = "Name" };
//                    instance.Name = input.ReadRawObject<string>(a); a = new ContentSerializerAttribute() { ElementName = "ID" };
//                    instance.ID = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Category" };
//                    instance.Category = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Programs" };
//                    instance.Programs = input.ReadRawObject<List<EventProgramData>>(a); a = new ContentSerializerAttribute() { ElementName = "ProgramCategory" };
//                    instance.ProgramCategory = input.ReadRawObject<ProgramCategory>(a); a = new ContentSerializerAttribute() { ElementName = "Enabled" };
//                    instance.Enabled = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Code" };
//                    instance.Code = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "AnimationID" };
//                    instance.AnimationID = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "ActionID" };

//                    instance.ActionID = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Direction" };

//                    instance.Direction = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "SwitchCondition" };

//                    instance.SwitchCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "VariableCondition" };
//                    instance.VariableCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "LocalSwitchCondition" };
//                    instance.LocalSwitchCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "LocalVariableCondition" };

//                    instance.LocalVariableCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "TriggerConditions" };
//                    instance.TriggerConditions = input.ReadRawObject<TriggerConditions>(a); a = new ContentSerializerAttribute() { ElementName = "InputTriggerProgram" };
//                    instance.InputTriggerProgram = input.ReadRawObject<EventProgramData>(a); a = new ContentSerializerAttribute() { ElementName = "MouseTriggerProgram" };
//                    instance.MouseTriggerProgram = input.ReadRawObject<EventProgramData>(a); a = new ContentSerializerAttribute() { ElementName = "MapCollisionTrigger" };
//                    instance.MapCollisionTrigger = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "GlobalMouseTrigger" };

//                    instance.GlobalMouseTrigger = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "TouchEventIDs" };

//                    instance.TouchEventIDs = input.ReadRawObject<List<int>>(a); a = new ContentSerializerAttribute() { ElementName = "VariableConditions" };

//                    instance.VariableConditions = input.ReadRawObject<List<VariableCondition>>(a); a = new ContentSerializerAttribute() { ElementName = "SwitchConditions" };

//                    instance.SwitchConditions = input.ReadRawObject<List<SwitchCondition>>(a); a = new ContentSerializerAttribute() { ElementName = "LocalVariableConditions" };

//                    instance.LocalVariableConditions = input.ReadRawObject<List<LocalVariableCondition>>(a); a = new ContentSerializerAttribute() { ElementName = "LocalSwitchConditions" };

//                    instance.LocalSwitchConditions = input.ReadRawObject<List<LocalSwitchCondition>>(a); a = new ContentSerializerAttribute() { ElementName = "EventSwitchConditions" };
//                    instance.EventSwitchConditions = input.ReadRawObject<int[]>(a); a = new ContentSerializerAttribute() { ElementName = "EventSwitchCondition" };
//                    instance.EventSwitchCondition = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "MovementPrograms" };
//                    instance.MovementPrograms = input.ReadRawObject<List<EventProgramData>>(a); a = new ContentSerializerAttribute() { ElementName = "RepeatMovement" };
//                    instance.RepeatMovement = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "SkipImpassable" };
//                    instance.SkipImpassable = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "IgnoreHills" };
//                    instance.IgnoreHills = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "EnableFrequency" };
//                    instance.EnableFrequency = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Frequency" };
//                    instance.Frequency = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Enemy" };
//                    instance.Enemy = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "AttackCondition" };

//                    instance.AttackCondition = input.ReadRawObject<AttackCondition>(a); a = new ContentSerializerAttribute() { ElementName = "SeeRang" };
//                    instance.SeeRange = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "HearRange" };

//                    instance.HearRange = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "BattleSpeed" };
//                    instance.BattleSpeed = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Respawn" };

//                    instance.Respawn = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "LockOnTarget" };
//                    instance.LockOnTarget = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "BattleDirections" };

//                    instance.BattleDirections = input.ReadRawObject<List<int>>(a); a = new ContentSerializerAttribute() { ElementName = "Hostiles" };

//                    instance.Hostiles = input.ReadRawObject<List<int>>(a); a = new ContentSerializerAttribute() { ElementName = "DeathTrigger" };

//                    instance.DeathTrigger = input.ReadRawObject<int[]>(a); a = new ContentSerializerAttribute() { ElementName = "AttackSpeed" };

//                    instance.AttackSpeed = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "BattleMoveDist" };
//                    instance.BattleMoveDist = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "ParticleID" };

//                    instance.ParticleID = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "Speed" };

//                    instance.Speed = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "IsStatic" };

//                    instance.IsStatic = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "IgnoreGravity" };
//                    instance.IgnoreGravity = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomMass" };
//                    instance.CustomMass = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomForce" };
//                    instance.CustomForce = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomLinearDrag" };
//                    instance.CustomLinearDrag = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomRotationalDrag" };
//                    instance.CustomRotationalDrag = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomFriction" };
//                    instance.CustomFriction = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomBounce" };
//                    instance.CustomBounce = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomImpulse" };
//                    instance.CustomImpulse = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomMOI" };
//                    instance.CustomMOI = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Mass" };

//                    instance.Mass = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "Force" };
//                    instance.Force = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "LinearDrag" };
//                    instance.LinearDrag = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "RotationalDrag" };
//                    instance.RotationalDrag = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "Friction" };
//                    instance.Friction = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "Bounce" };
//                    instance.Bounce = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "Impulse" };
//                    instance.Impulse = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "MomentOfInertia" };
//                    instance.MomentOfInertia = input.ReadRawObject<float>(a); a = new ContentSerializerAttribute() { ElementName = "SyncAngleToRotation" };

//                    instance.SyncAngleToRotation = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "RushTarget" };

//                    instance.RushTarget = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "DontErase" };

//                    instance.DontErase = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "PassThrough" };

//                    instance.PassThrough = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Cursor" };

//                    instance.Cursor = input.ReadRawObject<int>(a); a = new ContentSerializerAttribute() { ElementName = "IsMovingPlatform" };

//                    instance.IsMovingPlatform = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "IsFixedRotation" };

//                    instance.IsFixedRotation = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "CustomGravity" };

//                    instance.CustomGravity = input.ReadRawObject<bool>(a); a = new ContentSerializerAttribute() { ElementName = "Gravity" };
//                    instance.Gravity = input.ReadRawObject<Vector2>(a); a = new ContentSerializerAttribute() { ElementName = "Attachments" };

//                    instance.Attachments = input.ReadRawObject<List<AttachmentJoint>>(a); a = new ContentSerializerAttribute() { ElementName = "TouchTemplateEventIDs" };

//                    instance.TouchTemplateEventIDs = input.ReadRawObject<List<int>>(a);
//                    break;
//            }

//            return instance;
//        }
//    }
//}
