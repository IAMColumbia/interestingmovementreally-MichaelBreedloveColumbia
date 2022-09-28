using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MB_GameTemplate
{
    internal class Bouncer : MovingObject
    {
        public float BounceVelocityMult { get; private set; }

        public Bouncer() { }

        public Bouncer(float bounceVelocityMult, float speedBase, float speedMax, float speedMin, float acceleration, float deceleration, float turnSpeed, Texture2D sprite,
            Color renderColor, Vector2 origin, Vector2 direction, int width, int height, CollisionState collisionType)
            : base(speedBase, speedMax, speedMin, acceleration, deceleration, turnSpeed, sprite, renderColor, origin, direction, width, height, collisionType)
        {
            BounceVelocityMult = bounceVelocityMult;
        }

        public override void Move(float timeMod, GraphicsDevice GD)
        {
            ChangeOrigin(Origin + ((Direction * SpeedCurrent) * timeMod));
            CheckBounce(GD);
        }

        public override void Move(float timeMod, GraphicsDevice GD, float SpeedOverride)
        {
            ChangeOrigin(Origin + ((Direction * SpeedOverride) * timeMod));
            CheckBounce(GD);
        }

        void CheckBounce(GraphicsDevice GD)
        {
            if (Origin.X >
                    GD.Viewport.Width - Width)
            {
                //Negate X
                ChangeDirection(Direction * new Vector2(-1, 1));
                ChangeOrigin(new Vector2(GD.Viewport.Width - Width, Origin.Y));
                ChangeSpeedCurrent(SpeedCurrent * BounceVelocityMult);
            }

            //X left
            if (Origin.X < 0)
            {
                //Negate X
                ChangeDirection(Direction * new Vector2(-1, 1));
                ChangeOrigin(new Vector2(0, Origin.Y));
                ChangeSpeedCurrent(SpeedCurrent * BounceVelocityMult);
            }

            //Y top
            if (Origin.Y >
                    GD.Viewport.Height - Height)
            {
                //Negate Y
                ChangeDirection(Direction * new Vector2(1, -1));
                ChangeOrigin(new Vector2(Origin.X, GD.Viewport.Height - Height));
                ChangeSpeedCurrent(SpeedCurrent * BounceVelocityMult);
            }

            //Y bottom
            if (Origin.Y < 0)
            {
                //Negate Y
                ChangeDirection(Direction * new Vector2(1, -1));
                ChangeOrigin(new Vector2(Origin.X, 0));
                ChangeSpeedCurrent(SpeedCurrent * BounceVelocityMult);
            }
        }
    }
}
