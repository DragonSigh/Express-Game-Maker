//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using EGMGame.Library;

namespace EGMGame
{
    /// <summary>
    /// Helper for reading input from keyboard and gamepad. This class tracks both
    /// the current and previous state of both input devices.
    /// </summary>
    public class InputState
    {
        #region Fields

        public const int HeldAmount = 30; // Frames
        public const int MaxInputs = 4;
        public static int LastPlayer = 0;

        public static readonly KeyboardState[] CurrentKeyboardStates = new KeyboardState[MaxInputs];
        public static readonly GamePadState[] CurrentGamePadStates = new GamePadState[MaxInputs];

        public static readonly KeyboardState[] LastKeyboardStates = new KeyboardState[MaxInputs];
        public static readonly GamePadState[] LastGamePadStates = new GamePadState[MaxInputs];

        public static readonly bool[] GamePadWasConnected = new bool[MaxInputs];

        public static GamePadDeadZone DeadZone = GamePadDeadZone.IndependentAxes;

        public static PlayerIndex?[] Players = new PlayerIndex?[MaxInputs];
        public static PlayerIndex?[] TempPlayers = new PlayerIndex?[MaxInputs];

        public static int LastMouseScrollValue = 0;
        public static int MouseScrollValue = 0;

        public static MouseState LastMouseState;

        public static Dictionary<Keys, int>[] HeldKeys = new Dictionary<Keys, int>[]
            {
                new Dictionary<Keys,int>(),
                new Dictionary<Keys,int>(),
                new Dictionary<Keys,int>(),
                new Dictionary<Keys,int>()
            };
        public static Dictionary<Buttons, int>[] HeldButtons = new Dictionary<Buttons, int>[]
            {
                new Dictionary<Buttons,int>(),
                new Dictionary<Buttons,int>(),
                new Dictionary<Buttons,int>(),
                new Dictionary<Buttons,int>()
            };
        public static Dictionary<string, int> HeldMouseButtons = new Dictionary<string, int>()
        {
            {"Left",0},
            {"Middle",0},
            {"Right",0},
            {"X1",0},
            {"X2",0}
        };

        public static AnyButtonEnum[] AnyButtonPressed = new AnyButtonEnum[] { AnyButtonEnum.Reset, AnyButtonEnum.Reset, AnyButtonEnum.Reset, AnyButtonEnum.Reset };
        public static AnyButtonEnum[] AnyButtonReleased = new AnyButtonEnum[] { AnyButtonEnum.Reset, AnyButtonEnum.Reset, AnyButtonEnum.Reset, AnyButtonEnum.Reset };
        public static AnyButtonEnum[] AnyButtonDown = new AnyButtonEnum[] { AnyButtonEnum.Reset, AnyButtonEnum.Reset, AnyButtonEnum.Reset, AnyButtonEnum.Reset };
        public enum AnyButtonEnum
        {
            Reset,
            Active,
            NotActive
        }
        #endregion

        #region Keys and Buttons - Quick compatibility between engine and editor.

        public static readonly Keys[] KeysList = new Keys[] {Keys.Up,
                                                                    Keys.Down ,      
                                                                    Keys.Left,
                                                                    Keys.Right,
                                                                    Keys.Back,
                                                                    Keys.Tab,
                                                                    Keys.Enter,
                                                                    Keys.Escape,
                                                                    Keys.Space,
                                                                    Keys.PageUp,
                                                                    Keys.PageDown,
                                                                    Keys.End,
                                                                    Keys.Home,
                                                                    Keys.PrintScreen,
                                                                    Keys.Insert,
                                                                    Keys.Delete,
                                                                    Keys.D0,
                                                                    Keys.D1,
                                                                    Keys.D2,
                                                                    Keys.D3,
                                                                    Keys.D4,
                                                                    Keys.D5,
                                                                    Keys.D6,
                                                                    Keys.D7,
                                                                    Keys.D8,
                                                                    Keys.D9,
                                                                    Keys.A,
                                                                    Keys.B,
                                                                    Keys.C,
                                                                    Keys.D,
                                                                    Keys.E,
                                                                    Keys.F,
                                                                    Keys.G,
                                                                    Keys.H,
                                                                    Keys.I,
                                                                    Keys.J,
                                                                    Keys.K,
                                                                    Keys.L,
                                                                    Keys.M,
                                                                    Keys.N,
                                                                    Keys.O,
                                                                    Keys.P,
                                                                    Keys.Q,
                                                                    Keys.R,
                                                                    Keys.S,
                                                                    Keys.T,
                                                                    Keys.U,
                                                                    Keys.V,
                                                                    Keys.W,
                                                                    Keys.X,
                                                                    Keys.Y,
                                                                    Keys.Z,
                                                                    Keys.NumPad0,
                                                                    Keys.NumPad1,
                                                                    Keys.NumPad2,
                                                                    Keys.NumPad3,
                                                                    Keys.NumPad4,
                                                                    Keys.NumPad5,
                                                                    Keys.NumPad6,
                                                                    Keys.NumPad7,
                                                                    Keys.NumPad8,
                                                                    Keys.NumPad9,
                                                                    Keys.Multiply,
                                                                    Keys.Add,
                                                                    Keys.Separator,
                                                                    Keys.Subtract,
                                                                    Keys.Decimal,
                                                                    Keys.Divide,
                                                                    Keys.F1,
                                                                    Keys.F2,
                                                                    Keys.F3,
                                                                    Keys.F4,
                                                                    Keys.F5,
                                                                    Keys.F6,
                                                                    Keys.F7,
                                                                    Keys.F8,
                                                                    Keys.F9,
                                                                    Keys.F10,
                                                                    Keys.F11,
                                                                    Keys.F12,
                                                                    Keys.F13,
                                                                    Keys.F14,
                                                                    Keys.F15,
                                                                    Keys.F16,
                                                                    Keys.F17,
                                                                    Keys.F18,
                                                                    Keys.F19,
                                                                    Keys.F20,
                                                                    Keys.F21,
                                                                    Keys.F22,
                                                                    Keys.F23,
                                                                    Keys.F24,
                                                                    Keys.NumLock,
                                                                    Keys.Scroll,
                                                                    Keys.LeftShift,
                                                                    Keys.RightShift ,
                                                                    Keys.LeftControl,
                                                                    Keys.RightControl,
                                                                    Keys.LeftAlt,
                                                                    Keys.RightAlt,
                                                                    Keys.OemSemicolon,
                                                                    Keys.OemPlus,
                                                                    Keys.OemComma,
                                                                    Keys.OemMinus ,
                                                                    Keys.OemPeriod ,
                                                                    Keys.OemQuestion ,
                                                                    Keys.OemTilde,
                                                                    Keys.OemOpenBrackets,
                                                                    Keys.OemPipe,
                                                                    Keys.OemCloseBrackets,
                                                                    Keys.OemQuotes,
                                                                    Keys.OemBackslash};


        public static readonly Buttons[] ButtonsList = new Buttons[] {Buttons.LeftStick,
                                                                        Buttons.RightStick,
                                                                        Buttons.DPadUp,
                                                                        Buttons.DPadDown,
                                                                        Buttons.DPadLeft,
                                                                        Buttons.DPadRight,
                                                                        Buttons.X,
                                                                        Buttons.A,
                                                                        Buttons.B,
                                                                        Buttons.Y,
                                                                        Buttons.LeftTrigger,
                                                                        Buttons.RightTrigger,
                                                                        Buttons.LeftShoulder,
                                                                        Buttons.RightShoulder,
                                                                        Buttons.Back,
                                                                        Buttons.Start };
        #endregion

        #region Public Methods
        /// <summary>
        /// Reads the latest state of the keyboard and gamepad.
        /// </summary>
        public static void Update()
        {
            // Last Mouse State
            LastMouseState = Mouse.GetState();

            for (int i = 0; i < MaxInputs; i++)
            {
                AnyButtonPressed[i] = AnyButtonEnum.Reset;
                AnyButtonReleased[i] = AnyButtonEnum.Reset;
                AnyButtonDown[i] = AnyButtonEnum.Reset;

                LastKeyboardStates[i] = CurrentKeyboardStates[i];
                LastGamePadStates[i] = CurrentGamePadStates[i];

#if !SILVERLIGHT
                CurrentKeyboardStates[i] = Keyboard.GetState((PlayerIndex)i);
                CurrentGamePadStates[i] = GamePad.GetState((PlayerIndex)i, DeadZone);
#else
                if (i == 0)
                {
                    CurrentKeyboardStates[0] = Keyboard.GetState();
                }
                else

                    CurrentKeyboardStates[i] = CurrentKeyboardStates[0];
                CurrentGamePadStates[i] = GamePad.GetState((PlayerIndex)i);
#endif
                // Held Keys
                Keys[] keys = CurrentKeyboardStates[i].GetPressedKeys();
                Dictionary<Keys, int> keysD = new Dictionary<Keys, int>();
                for (int keyIndex = 0; keyIndex < keys.Length; keyIndex++)
                {
                    if (HeldKeys[i].ContainsKey(keys[keyIndex]))
                    {
                        keysD.Add(keys[keyIndex], HeldKeys[i][keys[keyIndex]] + 1);
                    }
                    else
                    {
                        keysD.Add(keys[keyIndex], 1);
                    }
                }
                HeldKeys[i] = keysD;
                // Held Buttons
                CheckGamePadHeldButtons((PlayerIndex)i);

                // Keep track of whether a gamepad has ever been
                // connected, so we can detect if it is unplugged.
                if (CurrentGamePadStates[i].IsConnected)
                {
                    GamePadWasConnected[i] = true;
                }
            }
            // Held Mouse
            CheckMouseHeldButtons();
        }
        /// <summary>
        /// Checks for buttons being held
        /// </summary>
        /// <param name="i"></param>
        private static void CheckGamePadHeldButtons(PlayerIndex index)
        {
            for (int i = 0; i < ButtonsList.Length; i++)
            {
                if (IsButtonPress(ButtonsList[i], index, out index))
                {
                    if (HeldButtons[(int)index].ContainsKey(ButtonsList[i]))
                        HeldButtons[(int)index][ButtonsList[i]]++;
                    else
                        HeldButtons[(int)index].Add(ButtonsList[i], 1);
                }
                else
                {
                    HeldButtons[(int)index].Remove(ButtonsList[i]);
                }
            }
        }
        /// <summary>
        /// Checks mouse held buttons
        /// </summary>
        private static void CheckMouseHeldButtons()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                HeldMouseButtons["Left"]++;
            }
            else if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                HeldMouseButtons["Left"] = 0;
            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                HeldMouseButtons["Right"]++;
            }
            else if (Mouse.GetState().RightButton == ButtonState.Released)
            {
                HeldMouseButtons["Right"] = 0;
            }

#if !SILVERLIGHT

            if (Mouse.GetState().MiddleButton == ButtonState.Pressed)
            {
                HeldMouseButtons["Middle"]++;
            }
            else if (Mouse.GetState().MiddleButton == ButtonState.Released)
            {
                HeldMouseButtons["Middle"] = 0;
            }
            if (Mouse.GetState().XButton1 == ButtonState.Pressed)
            {
                HeldMouseButtons["X1"]++;
            }
            else if (Mouse.GetState().XButton1 == ButtonState.Released)
            {
                HeldMouseButtons["X1"] = 0;
            }

            if (Mouse.GetState().XButton2 == ButtonState.Pressed)
            {
                HeldMouseButtons["X2"]++;
            }
            else if (Mouse.GetState().XButton2 == ButtonState.Released)
            {
                HeldMouseButtons["X2"] = 0;
            }
#endif
        }

        /// <summary>
        /// Helper for checking if a key was newly pressed during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a keypress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public static bool IsNewKeyPress(Keys key, PlayerIndex? controllingPlayer,
                                            out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return CurrentKeyboardStates[i].IsKeyDown(key) && !LastKeyboardStates[i].IsKeyDown(key);
            }
            else
            {
                // Accept input from any player.
                return (IsNewKeyPress(key, PlayerIndex.One, out playerIndex) ||
                        IsNewKeyPress(key, PlayerIndex.Two, out playerIndex) ||
                        IsNewKeyPress(key, PlayerIndex.Three, out playerIndex) ||
                        IsNewKeyPress(key, PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Helper for checking if a button was newly pressed during this update.
        /// The controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a button press
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public static bool IsNewButtonPress(Buttons button, PlayerIndex? controllingPlayer,
                                                     out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentGamePadStates[i].IsButtonDown(button) &&
                        LastGamePadStates[i].IsButtonUp(button));
            }
            else
            {
                // Accept input from any player.
                return (IsNewButtonPress(button, PlayerIndex.One, out playerIndex) ||
                        IsNewButtonPress(button, PlayerIndex.Two, out playerIndex) ||
                        IsNewButtonPress(button, PlayerIndex.Three, out playerIndex) ||
                        IsNewButtonPress(button, PlayerIndex.Four, out playerIndex));
            }
        }

        /// <summary>
        /// Helper for checking if a button was newly pressed during this update.
        /// The controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a button press
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public static bool IsNewButtonPress(Buttons button, int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool press = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    press = IsNewButtonPress(button, Players[player], out playerIndex);
                    if (press) break;
                }
            }
            else
                press = IsNewButtonPress(button, Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (press) LastPlayer = player;
            return press;
        }
        /// <summary>
        /// Helper for checking if a button was pressed during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a buttonpress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool IsButtonPress(Buttons button, int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool press = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    press = IsButtonPress(button, Players[player], out playerIndex);
                    if (press) break;
                }
            }
            else
                press = IsButtonPress(button, Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (press) LastPlayer = player;
            return press;
        }
        /// <summary>
        /// Helper for checking if a button was pressed during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a buttonpress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        private static bool IsButtonPress(Buttons button, PlayerIndex? controllingPlayer,
                                            out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentGamePadStates[i].IsButtonDown(button));
            }
            else
            {
                // Accept input from any player.
                return (IsButtonPress(button, PlayerIndex.One, out playerIndex) ||
                        IsButtonPress(button, PlayerIndex.Two, out playerIndex) ||
                        IsButtonPress(button, PlayerIndex.Three, out playerIndex) ||
                        IsButtonPress(button, PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Helper for checking if a key was newly pressed during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a keypress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public static bool IsNewKeyPress(Keys key, int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool press = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    press = IsNewKeyPress(key, Players[player], out playerIndex);
                    if (press) break;
                }
            }
            else
                press = IsNewKeyPress(key, Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (press) LastPlayer = player;
            return press;
        }
        /// <summary>
        /// Helper for checking if a key was pressed during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a keypress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public static bool IsKeyPress(Keys key, int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool press = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    press = IsKeyPress(key, Players[player], out playerIndex);
                    if (press) break;
                }
            }
            else
                press = IsKeyPress(key, Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (press) LastPlayer = player;
            return press;
        }
        /// <summary>
        /// Helper for checking if a key was pressed during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a keypress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public static bool IsKeyPress(Keys key, PlayerIndex? controllingPlayer,
                                            out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentKeyboardStates[i].IsKeyDown(key));
            }
            else
            {
                // Accept input from any player.
                return (IsKeyPress(key, PlayerIndex.One, out playerIndex) ||
                        IsKeyPress(key, PlayerIndex.Two, out playerIndex) ||
                        IsKeyPress(key, PlayerIndex.Three, out playerIndex) ||
                        IsKeyPress(key, PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Helper for checking if a key was newly released during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a keypress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public static bool IsNewKeyReleased(Keys key, int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool release = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    release = IsNewKeyRelease(key, Players[player], out playerIndex);
                    if (release) break;
                }
            }
            else
                release = IsNewKeyRelease(key, Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (release) LastPlayer = player;
            return release;
        }
        /// <summary>
        /// Helper for checking if a key was newly released during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a keypress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        private static bool IsNewKeyRelease(Keys key, PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentKeyboardStates[i].IsKeyUp(key) &&
                        LastKeyboardStates[i].IsKeyDown(key));
            }
            else
            {
                // Accept input from any player.
                return (IsNewKeyRelease(key, PlayerIndex.One, out playerIndex) ||
                        IsNewKeyRelease(key, PlayerIndex.Two, out playerIndex) ||
                        IsNewKeyRelease(key, PlayerIndex.Three, out playerIndex) ||
                        IsNewKeyRelease(key, PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Helper for checking if a button was newly released during this update.
        /// The controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a button press
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public static bool IsNewButtonReleased(Buttons button, int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool release = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    release = IsNewButtonRelease(button, Players[player], out playerIndex);
                    if (release) break;
                }
            }
            else
                release = IsNewButtonRelease(button, Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (release) LastPlayer = player;
            return release;
        }
        /// <summary>
        /// Helper for checking if a button was newly pressed during this update.
        /// The controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a button press
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        public static bool IsNewButtonRelease(Buttons button, PlayerIndex? controllingPlayer,
                                                     out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentGamePadStates[i].IsButtonUp(button) &&
                        LastGamePadStates[i].IsButtonDown(button));
            }
            else
            {
                // Accept input from any player.
                return (IsNewButtonRelease(button, PlayerIndex.One, out playerIndex) ||
                        IsNewButtonRelease(button, PlayerIndex.Two, out playerIndex) ||
                        IsNewButtonRelease(button, PlayerIndex.Three, out playerIndex) ||
                        IsNewButtonRelease(button, PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Helper method for checking if the mouse was held for atleast HELDAMOUNT.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsMouseHeld(string key)
        {
            int value;

            if (HeldMouseButtons.TryGetValue(key, out value))
            {
                if (value >= HeldAmount)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Helper method for checking if the button was held for atleast HELDAMOUNT.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsButtonHeld(Buttons button, int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool held = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    held = IsButtonHeld(button, Players[player], out playerIndex);
                    if (held) break;
                }
            }
            else
                held = IsButtonHeld(button, Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (held) LastPlayer = player;
            return held;
        }
        /// <summary>
        /// Helper method for checking if the button was held for atleast HELDAMOUNT.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsButtonHeld(Buttons button, PlayerIndex? controllingPlayer,
                                                     out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                int value;

                if (HeldButtons[i].TryGetValue(button, out value))
                {
                    if (value >= HeldAmount)
                        return true;
                }
                return false;
            }
            else
            {
                // Accept input from any player.
                return (IsButtonHeld(button, PlayerIndex.One, out playerIndex) ||
                        IsButtonHeld(button, PlayerIndex.Two, out playerIndex) ||
                        IsButtonHeld(button, PlayerIndex.Three, out playerIndex) ||
                        IsButtonHeld(button, PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Helper method for checking if the key was held for atleast HELDAMOUNT.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsKeyHeld(Keys key, int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool held = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    held = IsKeyHeld(key, Players[player], out playerIndex);
                    if (held) break;
                }
            }
            else
                held = IsKeyHeld(key, Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (held) LastPlayer = player;
            return held;
        }
        /// <summary>
        /// Helper method for checking if the key was held for atleast HELDAMOUNT.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool IsKeyHeld(Keys key, PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;


                int value;

                if (HeldKeys[i].TryGetValue(key, out value))
                {
                    if (value >= HeldAmount)
                        return true;
                }
                return false;
            }
            else
            {
                // Accept input from any player.
                return (IsNewKeyRelease(key, PlayerIndex.One, out playerIndex) ||
                        IsNewKeyRelease(key, PlayerIndex.Two, out playerIndex) ||
                        IsNewKeyRelease(key, PlayerIndex.Three, out playerIndex) ||
                        IsNewKeyRelease(key, PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Right Stick Move
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool RightStickMove(int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool press = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    press = RightStickMove(Players[player], out playerIndex);
                    if (press) break;
                }
            }
            else
                press = RightStickMove(Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (press) LastPlayer = player;
            return press;
        }
        /// <summary>
        /// Right stick move
        /// </summary>
        /// <param name="nullable"></param>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        private static bool RightStickMove(PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentGamePadStates[i].ThumbSticks.Right.X != LastGamePadStates[i].ThumbSticks.Right.X ||
                    CurrentGamePadStates[i].ThumbSticks.Right.Y != LastGamePadStates[i].ThumbSticks.Right.Y);
            }
            else
            {
                // Accept input from any player.
                return (RightStickMove(PlayerIndex.One, out playerIndex) ||
                         RightStickMove(PlayerIndex.Two, out playerIndex) ||
                         RightStickMove(PlayerIndex.Three, out playerIndex) ||
                         RightStickMove(PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Left Stick Move
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool LeftStickMove(int player)
        {
            PlayerIndex playerIndex = PlayerIndex.One;
            bool press = false;
            if (player == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    player = i;
                    press = LeftStickMove(Players[player], out playerIndex);
                    if (press) break;
                }
            }
            else
                press = LeftStickMove(Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (press) LastPlayer = player;
            return press;
        }
        /// <summary>
        /// Left stick move
        /// </summary>
        /// <param name="nullable"></param>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        private static bool LeftStickMove(PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentGamePadStates[i].ThumbSticks.Left.X != LastGamePadStates[i].ThumbSticks.Left.X ||
                    CurrentGamePadStates[i].ThumbSticks.Left.Y != LastGamePadStates[i].ThumbSticks.Left.Y);
            }
            else
            {
                // Accept input from any player.
                return (LeftStickMove(PlayerIndex.One, out playerIndex) ||
                         LeftStickMove(PlayerIndex.Two, out playerIndex) ||
                         LeftStickMove(PlayerIndex.Three, out playerIndex) ||
                         LeftStickMove(PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Helper method for getting the right stick's position.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static Vector2 GetRightStick(int player)
        {
            PlayerIndex playerIndex;
            Vector2 value;
            bool stick = GetRightStick(Players[player], out playerIndex, out value);
            TempPlayers[player] = playerIndex;
            if (stick)
                return value;
            return Vector2.Zero;
        }
        /// <summary>
        /// Helper method for getting the right stick's position.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool GetRightStick(PlayerIndex? controllingPlayer,
                                            out PlayerIndex playerIndex, out Vector2 value)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                value = CurrentGamePadStates[i].ThumbSticks.Right;
                return CurrentGamePadStates[i].IsConnected;
            }
            else
            {
                // Accept input from any player.
                return (GetRightStick(PlayerIndex.One, out playerIndex, out value) ||
                         GetRightStick(PlayerIndex.Two, out playerIndex, out value) ||
                         GetRightStick(PlayerIndex.Three, out playerIndex, out value) ||
                         GetRightStick(PlayerIndex.Four, out playerIndex, out value));
            }
        }
        /// <summary>
        /// Helper method for getting the right stick's position.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static Vector2 GetLeftStick(int player)
        {
            PlayerIndex playerIndex;
            Vector2 value;
            bool stick = GetLeftStick(Players[player], out playerIndex, out value);
            TempPlayers[player] = playerIndex;
            if (stick)
                return value;
            return Vector2.Zero;
        }
        /// <summary>
        /// Helper method for getting the right stick's position.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool GetLeftStick(PlayerIndex? controllingPlayer,
                                            out PlayerIndex playerIndex, out Vector2 value)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                value = CurrentGamePadStates[i].ThumbSticks.Left;
                return CurrentGamePadStates[i].IsConnected;
            }
            else
            {
                // Accept input from any player.
                return (GetLeftStick(PlayerIndex.One, out playerIndex, out value) ||
                         GetLeftStick(PlayerIndex.Two, out playerIndex, out value) ||
                         GetLeftStick(PlayerIndex.Three, out playerIndex, out value) ||
                         GetLeftStick(PlayerIndex.Four, out playerIndex, out value));
            }
        }
        /// <summary>
        /// Helper method for getting the right stick's position.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static Vector2 GetLastLeftStick(int player)
        {
            PlayerIndex playerIndex;
            Vector2 value;
            bool stick = GetLastLeftStick(Players[player], out playerIndex, out value);
            TempPlayers[player] = playerIndex;
            if (stick)
                return value;
            return Vector2.Zero;
        }
        /// <summary>
        /// Helper method for getting the right stick's position.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool GetLastLeftStick(PlayerIndex? controllingPlayer,
                                            out PlayerIndex playerIndex, out Vector2 value)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                value = LastGamePadStates[i].ThumbSticks.Left;
                return LastGamePadStates[i].IsConnected;
            }
            else
            {
                // Accept input from any player.
                return (GetLastLeftStick(PlayerIndex.One, out playerIndex, out value) ||
                         GetLastLeftStick(PlayerIndex.Two, out playerIndex, out value) ||
                         GetLastLeftStick(PlayerIndex.Three, out playerIndex, out value) ||
                         GetLastLeftStick(PlayerIndex.Four, out playerIndex, out value));
            }
        }
        /// <summary>
        /// Check movement keys
        /// </summary>
        /// <returns></returns>
        public static int CheckMovement()
        {
            bool leftk;
            bool rightk;
            bool downk;
            bool upk;
            bool leftb;
            bool rightb;
            bool downb;
            bool upb;

            #region Get Keys
            if (GameData.Player.Keys["Movement"] == 0)
            {
                // Arrow Keys
                leftk = InputState.IsKeyPress(Keys.Left, 0);
                rightk = InputState.IsKeyPress(Keys.Right, 0);
                downk = InputState.IsKeyPress(Keys.Down, 0);
                upk = InputState.IsKeyPress(Keys.Up, 0);
            }
            else
            {
                // ASWD
                leftk = InputState.IsKeyPress(Keys.A, 0);
                rightk = InputState.IsKeyPress(Keys.S, 0);
                downk = InputState.IsKeyPress(Keys.W, 0);
                upk = InputState.IsKeyPress(Keys.D, 0);
            }
            if (GameData.Player.Buttons["Movement"] == 0)
            {
                // Left Stick
                leftb = (GetLeftStick(0).X <= -0.5f && GetLeftStick(0).X != 0);
                rightb = (GetLeftStick(0).X >= 0.5f && GetLeftStick(0).X != 0);
                upb = (GetLeftStick(0).Y >= 0.5f && GetLeftStick(0).Y != 0);
                downb = (GetLeftStick(0).Y <= -0.5f && GetLeftStick(0).Y != 0);
            }
            else
            {
                // DPAD
                leftb = InputState.IsButtonPress(Buttons.DPadLeft, 0);
                rightb = InputState.IsButtonPress(Buttons.DPadRight, 0);
                downb = InputState.IsButtonPress(Buttons.DPadDown, 0);
                upb = InputState.IsButtonPress(Buttons.DPadUp, 0);
            }
            #endregion

            if (GameData.Player.MovementType.Contains(4) && ((upk && leftk) || (upb && leftb)))
            {
                return 4;
            }
            else if (GameData.Player.MovementType.Contains(5) && ((upk && rightk) || (upb && rightb)))
            {
                return 5;
            }
            else if (GameData.Player.MovementType.Contains(6) && ((downk && leftk) || (downb && leftb)))
            {
                return 6;
            }
            else if (GameData.Player.MovementType.Contains(7) && ((downk && rightk) || (downb && rightb)))
            {
                return 7;
            }
            else if (GameData.Player.MovementType.Contains(0) && (upk || upb))
            {
                return 0;
            }
            else if (GameData.Player.MovementType.Contains(1) && (downk || downb))
            {
                return 1;
            }
            else if (GameData.Player.MovementType.Contains(2) && (leftk || leftb))
            {
                return 2;
            }
            else if (GameData.Player.MovementType.Contains(3) && (rightk || rightb))
            {
                return 3;
            }
            return -1;
        }

        /// <summary>
        /// Gets if any key is pressed
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool AnyKeyIsPressed(int player)
        {
            PlayerIndex playerIndex;
            bool press = IsAnyKeyPress(Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (press) LastPlayer = player;
            return press;
        }
        /// <summary>
        /// Gets if any key is pressed
        /// </summary>
        /// <param name="nullable"></param>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        private static bool IsAnyKeyPress(PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return CurrentKeyboardStates[i].GetPressedKeys().Length > 0 && LastKeyboardStates[i].GetPressedKeys().Length == 0;
            }
            else
            {
                // Accept input from any player.
                return (IsAnyKeyPress(PlayerIndex.One, out playerIndex) ||
                        IsAnyKeyPress(PlayerIndex.Two, out playerIndex) ||
                        IsAnyKeyPress(PlayerIndex.Three, out playerIndex) ||
                        IsAnyKeyPress(PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Gets if any key is released.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool AnyKeyIsReleased(int player)
        {
            PlayerIndex playerIndex;
            bool release = IsAnyKeyRelease(Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (release) LastPlayer = player;
            return release;
        }
        /// <summary>
        /// Helper for checking if a key was newly released during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a keypress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        private static bool IsAnyKeyRelease(PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentKeyboardStates[i].GetPressedKeys().Length == 0 &&
                        LastKeyboardStates[i].GetPressedKeys().Length > 0);
            }
            else
            {
                // Accept input from any player.
                return (IsAnyKeyRelease(PlayerIndex.One, out playerIndex) ||
                        IsAnyKeyRelease(PlayerIndex.Two, out playerIndex) ||
                        IsAnyKeyRelease(PlayerIndex.Three, out playerIndex) ||
                        IsAnyKeyRelease(PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Gets if any key is pressed
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool AnyKeyIsDown(int player)
        {
            PlayerIndex playerIndex;
            bool press = IsAnyKeyDown(Players[player], out playerIndex);
            TempPlayers[player] = playerIndex;
            if (press) LastPlayer = player;
            return press;
        }
        /// <summary>
        /// Gets if any key is pressed
        /// </summary>
        /// <param name="nullable"></param>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        private static bool IsAnyKeyDown(PlayerIndex? controllingPlayer, out PlayerIndex playerIndex)
        {
            if (controllingPlayer.HasValue)
            {
                // Read input from the specified player.
                playerIndex = controllingPlayer.Value;

                int i = (int)playerIndex;

                return (CurrentKeyboardStates[i].GetPressedKeys().Length > 0);
            }
            else
            {
                // Accept input from any player.
                return (IsAnyKeyDown(PlayerIndex.One, out playerIndex) ||
                        IsAnyKeyDown(PlayerIndex.Two, out playerIndex) ||
                        IsAnyKeyDown(PlayerIndex.Three, out playerIndex) ||
                        IsAnyKeyDown(PlayerIndex.Four, out playerIndex));
            }
        }
        /// <summary>
        /// Get New Key Pressed
        /// </summary>
        /// <returns></returns>
        public static Keys[] GetNewKeyPressed()
        {
            Keys[] pressedKeys = CurrentKeyboardStates[0].GetPressedKeys();
            List<Keys> newKeys = new List<Keys>();
            for (int i = 0; i < pressedKeys.Length; i++)
            {
                if (LastKeyboardStates[0].IsKeyUp(pressedKeys[i]))
                    newKeys.Add(pressedKeys[i]);
            }
            return newKeys.ToArray();
        }
        /// <summary>
        /// Helper for checking if a button was pressed during this update. The
        /// controllingPlayer parameter specifies which player to read input for.
        /// If this is null, it will accept input from any player. When a buttonpress
        /// is detected, the output playerIndex reports which player pressed it.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool AnyButtonIsPressed(int player)
        {
            if (AnyButtonPressed[player] == AnyButtonEnum.Reset)
            {
                PlayerIndex playerIndex;

                for (int i = 0; i < ButtonsList.Length; i++)
                {
                    if (IsNewButtonPress(ButtonsList[i], Players[player], out playerIndex))
                    {
                        TempPlayers[player] = playerIndex;
                        LastPlayer = player;
                        AnyButtonPressed[player] = AnyButtonEnum.Active;
                        return true;
                    }
                }
                AnyButtonPressed[player] = AnyButtonEnum.NotActive;
                return false;
            }
            else
            {
                return (AnyButtonPressed[player] == AnyButtonEnum.Active);
            }
        }
        /// <summary>
        /// Gets if any button is released.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool AnyButtonIsReleased(int player)
        {
            if (AnyButtonReleased[player] == AnyButtonEnum.Reset)
            {
                PlayerIndex playerIndex;

                for (int i = 0; i < ButtonsList.Length; i++)
                {
                    if (IsNewButtonRelease(ButtonsList[i], Players[player], out playerIndex))
                    {
                        TempPlayers[player] = playerIndex;
                        LastPlayer = player;
                        AnyButtonReleased[player] = AnyButtonEnum.Active;
                        return true;
                    }
                }
                AnyButtonReleased[player] = AnyButtonEnum.NotActive;
                return false;
            }
            else
            {
                return (AnyButtonReleased[player] == AnyButtonEnum.Active);
            }
        }
        /// Gets if any button is held.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool AnyButtonIsDown(int player)
        {
            if (AnyButtonDown[player] == AnyButtonEnum.Reset)
            {
                PlayerIndex playerIndex;

                for (int i = 0; i < ButtonsList.Length; i++)
                {
                    if (IsButtonPress(ButtonsList[i], Players[player], out playerIndex))
                    {
                        TempPlayers[player] = playerIndex;
                        LastPlayer = player;
                        AnyButtonDown[player] = AnyButtonEnum.Active;
                        return true;
                    }
                }
                AnyButtonDown[player] = AnyButtonEnum.NotActive;
                return false;
            }
            else
            {
                return (AnyButtonDown[player] == AnyButtonEnum.Active);
            }
        }
        /// <summary>
        /// Checks if any of the mouse buttons are pressed down.
        /// </summary>
        /// <returns></returns>
        public static bool IsMouseDown()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                return true;
            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                return true;
#if !SILVERLIGHT
            if (Mouse.GetState().MiddleButton == ButtonState.Pressed)
                return true;
            if (Mouse.GetState().XButton1 == ButtonState.Pressed)
                return true;
            if (Mouse.GetState().XButton2 == ButtonState.Pressed)
                return true;
#endif
            return false;
        }
        /// <summary>
        /// Checks if any of the mouse buttons are released.
        /// </summary>
        /// <returns></returns>
        public static bool IsMouseUp()
        {
            if (LastMouseState.LeftButton == ButtonState.Pressed && Mouse.GetState().LeftButton == ButtonState.Released)
                return true;
            if (LastMouseState.RightButton == ButtonState.Pressed && Mouse.GetState().RightButton == ButtonState.Released)
                return true;
#if !SILVERLIGHT
            if (LastMouseState.MiddleButton == ButtonState.Pressed && Mouse.GetState().MiddleButton == ButtonState.Released)
                return true;
            if (LastMouseState.XButton1 == ButtonState.Pressed && Mouse.GetState().XButton1 == ButtonState.Released)
                return true;
            if (LastMouseState.XButton2 == ButtonState.Pressed && Mouse.GetState().XButton2 == ButtonState.Released)
                return true;
#endif
            return false;
        }
        /// <summary>
        /// Checks if the mouse is moving
        /// </summary>
        /// <returns></returns>
        public static bool IsMouseMove()
        {
            return (LastMouseState.X != Mouse.GetState().X || LastMouseState.Y != Mouse.GetState().Y);
        }
        #endregion

        internal static bool IsCapsLockOn()
        {
#if WINDOWS
            return (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
#else
            return false;
#endif
        }
#if WINDOWS
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true, CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);
#endif

        internal static bool LeftStickLeft()
        {
            return (InputState.GetLeftStick(0).X <= -0.5f && InputState.GetLeftStick(0).X != 0) && !(InputState.GetLastLeftStick(0).X <= -0.5f && InputState.GetLastLeftStick(0).X != 0);
        }
        internal static bool LeftStickRight()
        {
            return (InputState.GetLeftStick(0).X >= 0.5f && InputState.GetLeftStick(0).X != 0) && !(InputState.GetLastLeftStick(0).X >= 0.5f && InputState.GetLastLeftStick(0).X != 0);
        }
        internal static bool LeftStickUp()
        {
            return (InputState.GetLeftStick(0).Y >= 0.5f && InputState.GetLeftStick(0).Y != 0) && !(InputState.GetLastLeftStick(0).Y >= 0.5f && InputState.GetLastLeftStick(0).Y != 0);
        }
        internal static bool LeftStickDown()
        {
            return (InputState.GetLeftStick(0).Y <= -0.5f && InputState.GetLeftStick(0).Y != 0) && !(InputState.GetLastLeftStick(0).Y <= -0.5f && InputState.GetLastLeftStick(0).Y != 0);

        }

        internal static PlayerIndex? GetPlayer(int index)
        {
            if (index == 4)
                if (Players[LastPlayer].HasValue)
                    return Players[LastPlayer];
                else
                    return TempPlayers[LastPlayer];
            else
                if (Players[index].HasValue)
                    return Players[index];
                else
                    return TempPlayers[index];
        }
    }

#if SILVERLIGHT
    public enum GamePadDeadZone
    {
        None = 0,
        IndependentAxes = 1,
        Circular = 2,
    }
#endif
}
