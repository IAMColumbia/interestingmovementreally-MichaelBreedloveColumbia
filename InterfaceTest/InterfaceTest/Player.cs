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
    internal class Player : MovingObject
    {
        //TODO: Add things pertaining to variables the player would need.

        public Player() { }

        public Player(float speedCurrent, float speedMax, float speedMin, float acceleration, float deceleration, float turnSpeed, Texture2D sprite,
            Color renderColor, Vector2 origin, Vector2 direction, int width, int height, CollisionState collisionType)
            : base(speedCurrent, speedMax, speedMin, acceleration, deceleration, turnSpeed, sprite, renderColor, origin, direction, width, height, collisionType)
        {
        }

        public override void Move(float timeMod, GraphicsDevice GD)
        {
            float newSpeed = SpeedCurrent;

            if (!KeyboardHandler.KB.IsKeyDown(Keys.S) && !KeyboardHandler.KB.IsKeyDown(Keys.W) && !KeyboardHandler.KB.IsKeyDown(Keys.A) && !KeyboardHandler.KB.IsKeyDown(Keys.D))
            {
                newSpeed -= Deceleration;

                if (newSpeed < 0f)
                {
                    newSpeed = 0f;
                }
            }
            else
            {
                newSpeed += Acceleration;

                if (newSpeed > SpeedMax)
                {
                    newSpeed = SpeedMax;
                }

                Vector2 newDirection = Direction;

                if (KeyboardHandler.KB.IsKeyDown(Keys.S) && !KeyboardHandler.KB.IsKeyDown(Keys.W))
                {
                    newDirection.Y += TurnSpeed;
                    if (newDirection.Y > 1)
                    {
                        newDirection.Y = 1;
                    }
                }
                else if (KeyboardHandler.KB.IsKeyDown(Keys.W) && !KeyboardHandler.KB.IsKeyDown(Keys.S))
                {
                    newDirection.Y -= TurnSpeed;
                    if (newDirection.Y < -1)
                    {
                        newDirection.Y = -1;
                    }
                }
                else
                {
                    if (newDirection.Y < 0)
                    {
                        newDirection.Y += TurnSpeed;
                        if (newDirection.Y > 0)
                        {
                            newDirection.Y = 0;
                        }
                    }
                    else if (newDirection.Y > 0)
                    {
                        newDirection.Y -= TurnSpeed;
                        if (newDirection.Y < 0)
                        {
                            newDirection.Y = 0;
                        }
                    }
                }

                if (KeyboardHandler.KB.IsKeyDown(Keys.D) && !KeyboardHandler.KB.IsKeyDown(Keys.A))
                {
                    newDirection.X += TurnSpeed;
                    if (newDirection.X > 1)
                    {
                        newDirection.X = 1;
                    }
                }
                else if (KeyboardHandler.KB.IsKeyDown(Keys.A) && !KeyboardHandler.KB.IsKeyDown(Keys.D))
                {
                    newDirection.X -= TurnSpeed;
                    if (newDirection.X < -1)
                    {
                        newDirection.X = -1;
                    }
                }
                else
                {
                    if (newDirection.X < 0)
                    {
                        newDirection.X += TurnSpeed;
                        if (newDirection.X > 0)
                        {
                            newDirection.X = 0;
                        }
                    }
                    else if (newDirection.X > 0)
                    {
                        newDirection.X -= TurnSpeed;
                        if (newDirection.X < 0)
                        {
                            newDirection.X = 0;
                        }
                    }
                }

                ChangeDirection(newDirection);
            }

            ChangeSpeedCurrent(newSpeed);
            ChangeOrigin(Origin + ((Direction * SpeedCurrent) * timeMod));
            Player_StayOnScreen(GD);
        }

        void Player_StayOnScreen(GraphicsDevice GD)
        {
            Vector2 newOrigin = Origin;
            if (Origin.X > GD.Viewport.Width)
            {
                newOrigin.X = 0 - Width;
            }
            else if (Origin.X < 0 - Width)
            {
                newOrigin.X = GD.Viewport.Width;
            }

            if (Origin.Y > GD.Viewport.Height)
            {
                newOrigin.Y = 0 - Height;
            }
            else if (Origin.Y < 0 - Height)
            {
                newOrigin.Y = GD.Viewport.Height;
            }

            ChangeOrigin(newOrigin);
        }
    }
}
