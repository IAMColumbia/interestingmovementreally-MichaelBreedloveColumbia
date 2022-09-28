using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MB_GameTemplate
{
    internal class Enemy : MovingObject
    {
        //TODO: Add things pertaining to variables an enemy would need.

        public Enemy() { }

        public Enemy(float speedBase, float speedMax, float speedMin, float acceleration, float deceleration, float turnSpeed, Texture2D sprite,
            Color renderColor, Vector2 origin, Vector2 direction, int width, int height, CollisionState collisionType)
            : base(speedBase, speedMax, speedMin, acceleration, deceleration, turnSpeed, sprite, renderColor, origin, direction, width, height, collisionType)
        {

        }

        public override void Move(float timeMod, GraphicsDevice GD)
        {
            ChangeOrigin(Origin + ((Direction * SpeedCurrent) * timeMod));
        }

        public override void Move(float timeMod, GraphicsDevice GD, float SpeedOverride)
        {
            ChangeOrigin(Origin + ((Direction * SpeedOverride) * timeMod));
        }
    }
}