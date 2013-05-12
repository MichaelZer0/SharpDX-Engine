﻿using NekuSoul.SharpDX_Engine.Objects;
using NekuSoul.SharpDX_Engine.Utitities;
using System;
using System.Collections.Generic;

namespace NekuSoul.SharpDX_Engine_Tutorial.Objects.Ingame
{
    class Unit : DrawableObject
    {
        public DrawableObject Target;

        public Unit(DrawableObject Target)
        {
            Texture = "Unit";
            Position = new Coordinate(Helper.Random.Next((int)Programm.Size.width - 8), Helper.Random.Next((int)Programm.Size.height - 16));
            Offset = new Coordinate(4, 16);
            Size = new Size(8, 16);
            this.Target = Target;
        }

        public void MoveToTarget()
        {
            if (Math.Sqrt(Math.Pow(((Target.Position.X + Target.Offset.X) - (Position.X + Target.Offset.X)), 2) + Math.Pow(((Target.Position.Y + Target.Offset.Y) - (Position.Y + Target.Offset.Y)), 2)) > 10)
            {
                Position.X += 2 * (float)Math.Sin((Math.Atan2(((Target.Position.X + Target.Offset.X) - (Position.X + Target.Offset.X)), ((Target.Position.Y + Target.Offset.Y) - (Position.Y + Target.Offset.Y)))));
                Position.Y += 2 * (float)Math.Cos((Math.Atan2(((Target.Position.X + Target.Offset.X) - (Position.X + Target.Offset.X)), ((Target.Position.Y + Target.Offset.Y) - (Position.Y + Target.Offset.Y)))));
            }
        }

        public void MoveFromSppecific(DrawableObject Target, int Distance)
        {
            if (Math.Sqrt(Math.Pow(((Target.Position.X + Target.Offset.X) - (Position.X + Target.Offset.X)), 2) + Math.Pow(((Target.Position.Y + Target.Offset.Y) - (Position.Y + Target.Offset.Y)), 2)) < Distance)
            {
                Position.X -= 2 * (float)Math.Sin((Math.Atan2(((Target.Position.X + Target.Offset.X) - (Position.X + Target.Offset.X)), ((Target.Position.Y + Target.Offset.Y) - (Position.Y + Target.Offset.Y)))));
                Position.Y -= 2 * (float)Math.Cos((Math.Atan2(((Target.Position.X + Target.Offset.X) - (Position.X + Target.Offset.X)), ((Target.Position.Y + Target.Offset.Y) - (Position.Y + Target.Offset.Y)))));
            }
        }
    }
}