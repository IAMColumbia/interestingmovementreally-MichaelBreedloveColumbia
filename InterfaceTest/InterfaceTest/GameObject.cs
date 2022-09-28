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
    public enum CollisionState { COLLISION_ALL, COLLISION_TERRAIN, COLLISION_ENTITIES }

    public class GameObject
    {
        public Texture2D Sprite { get; private set; }
        public Color RenderColor { get; private set; }
        public Vector2 Origin { get; private set; }
        public Vector2 Direction { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Rectangle Rect { get; private set; }

        protected CollisionState _collisionState;
        public CollisionState collisionState
        {
            get { return _collisionState; }
            set
            {
                if (value != _collisionState) { _collisionState = value; }
            }
        }

        public GameObject() { }
        
        public GameObject(Texture2D sprite, Color renderColor, Vector2 origin, Vector2 direction, int width, int height, CollisionState collisionType)
        {
            Sprite = sprite;
            RenderColor = renderColor;
            Origin = origin;
            Direction = direction;
            Width = width;
            Height = height;
            _collisionState = collisionType;
        }

        public void ChangeOrigin(Vector2 NewOrigin) { Origin = NewOrigin; }
        public void ChangeDirection(Vector2 NewDirection) { Direction = NewDirection; }
        public void ChangeWidth(int NewWidth) { Width = NewWidth; }
        public void ChangeHeight(int NewHeight) { Height = NewHeight; }
        public void ChangeColor(Color NewColor) { RenderColor = NewColor; }
        public void ChangeSprite(Texture2D NewSprite) { Sprite = NewSprite; }

        public void UpdateRectangle()
        {
            Rect = new Rectangle((int)Origin.X, (int)Origin.Y, Width, Height);
        }
    }
}