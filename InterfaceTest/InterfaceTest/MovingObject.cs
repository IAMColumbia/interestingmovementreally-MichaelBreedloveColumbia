using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_GameTemplate
{
    internal class MovingObject : GameObject
    {
        public float SpeedCurrent { get; private set; }
        public float SpeedMax { get; private set; }
        public float SpeedMin { get; private set; }
        public float Acceleration { get; private set; }
        public float Deceleration { get; private set; }
        public float TurnSpeed { get; private set; }

        public MovingObject() { }

        public MovingObject(float speedCurrent, float speedMax, float speedMin, float acceleration, float deceleration, float turnSpeed, Texture2D sprite, 
            Color renderColor, Vector2 origin, Vector2 direction, int width, int height, CollisionState collisionType)
            : base(sprite, renderColor, origin, direction, width, height, collisionType)
        {
            SpeedCurrent = speedCurrent;
            SpeedMax = speedMax;
            SpeedMin = speedMin;
            Acceleration = acceleration;
            Deceleration = deceleration;
            TurnSpeed = turnSpeed;
        }

        public void ChangeSpeedCurrent(float NewSpeedCurrent) { SpeedCurrent = NewSpeedCurrent; }
        public void ChangeSpeedMax(float NewSpeedMax) { SpeedMax = NewSpeedMax; }
        public void ChangeSpeedMin(float NewSpeedMin) { SpeedMin = NewSpeedMin; }

        public virtual void Move(float timeMod, GraphicsDevice GD)
        {
            ChangeOrigin(Origin + ((Direction * SpeedCurrent) * timeMod));
        }

        public virtual void Move(float timeMod, GraphicsDevice GD, float SpeedOverride)
        {
            ChangeOrigin(Origin + ((Direction * SpeedOverride) * timeMod));
        }
    }
}