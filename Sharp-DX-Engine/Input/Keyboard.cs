﻿using NekuSoul.SharpDX_Engine.Utitities;
using NekuSoul.SharpDX_Engine;
using SharpDX.DirectInput;
using System.Collections.Generic;
using System;
using SharpDXKey = SharpDX.DirectInput.Key;

namespace NekuSoul.SharpDX_Engine.Input
{
    public class Keyboard
    {
        SharpDX.DirectInput.Keyboard _Keyboard;
        List<SharpDXKey> CurrentState;
        List<SharpDXKey> LastState;

        public Keyboard(DirectInput DirectInput)
        {
            _Keyboard = new SharpDX.DirectInput.Keyboard(DirectInput);
            _Keyboard.Acquire();
            UpdateKeyboardState();
            UpdateKeyboardState();
        }

        public void UpdateKeyboardState()
        {
            LastState = CurrentState;
            CurrentState = _Keyboard.GetCurrentState().PressedKeys;
        }

        public bool IsKeyDown(Key Key)
        {
            if (CurrentState.Contains((SharpDXKey)Key))
            {
                return true;
            }
            return false;
        }

    }

    public enum Key
    {
        Unknown = 0,
        Escape = 1,
        D1 = 2,
        D2 = 3,
        D3 = 4,
        D4 = 5,
        D5 = 6,
        D6 = 7,
        D7 = 8,
        D8 = 9,
        D9 = 10,
        D0 = 11,
        Minus = 12,
        Equals = 13,
        Back = 14,
        Tab = 15,
        Q = 16,
        W = 17,
        E = 18,
        R = 19,
        T = 20,
        Y = 21,
        U = 22,
        I = 23,
        O = 24,
        P = 25,
        LeftBracket = 26,
        RightBracket = 27,
        Return = 28,
        LeftControl = 29,
        A = 30,
        S = 31,
        D = 32,
        F = 33,
        G = 34,
        H = 35,
        J = 36,
        K = 37,
        L = 38,
        Semicolon = 39,
        Apostrophe = 40,
        Grave = 41,
        LeftShift = 42,
        Backslash = 43,
        Z = 44,
        X = 45,
        C = 46,
        V = 47,
        B = 48,
        N = 49,
        M = 50,
        Comma = 51,
        Period = 52,
        Slash = 53,
        RightShift = 54,
        Multiply = 55,
        LeftAlt = 56,
        Space = 57,
        Capital = 58,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        NumberLock = 69,
        ScrollLock = 70,
        NumberPad7 = 71,
        NumberPad8 = 72,
        NumberPad9 = 73,
        Subtract = 74,
        NumberPad4 = 75,
        NumberPad5 = 76,
        NumberPad6 = 77,
        Add = 78,
        NumberPad1 = 79,
        NumberPad2 = 80,
        NumberPad3 = 81,
        NumberPad0 = 82,
        Decimal = 83,
        Oem102 = 86,
        F11 = 87,
        F12 = 88,
        F13 = 100,
        F14 = 101,
        F15 = 102,
        Kana = 112,
        AbntC1 = 115,
        Convert = 121,
        NoConvert = 123,
        Yen = 125,
        AbntC2 = 126,
        NumberPadEquals = 141,
        PreviousTrack = 144,
        AT = 145,
        Colon = 146,
        Underline = 147,
        Kanji = 148,
        Stop = 149,
        AX = 150,
        Unlabeled = 151,
        NextTrack = 153,
        NumberPadEnter = 156,
        RightControl = 157,
        Mute = 160,
        Calculator = 161,
        PlayPause = 162,
        MediaStop = 164,
        VolumeDown = 174,
        VolumeUp = 176,
        WebHome = 178,
        NumberPadComma = 179,
        Divide = 181,
        PrintScreen = 183,
        RightAlt = 184,
        Pause = 197,
        Home = 199,
        UpArrow = 200,
        PageUp = 201,
        Left = 203,
        Right = 205,
        End = 207,
        Down = 208,
        PageDown = 209,
        Insert = 210,
        Delete = 211,
        LeftWindowsKey = 219,
        RightWindowsKey = 220,
        Applications = 221,
        Power = 222,
        Sleep = 223,
        Wake = 227,
        WebSearch = 229,
        WebFavorites = 230,
        WebRefresh = 231,
        WebStop = 232,
        WebForward = 233,
        WebBack = 234,
        MyComputer = 235,
        Mail = 236,
        MediaSelect = 237,
    }
}
