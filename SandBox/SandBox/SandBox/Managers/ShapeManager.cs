using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PhysicsSandbox.Shapes;

namespace SandBox.ListOfShapes
{
    class ShapeManager
    {

        private List<PhysicsSprite> PhysicsSpriteList = new List<PhysicsSprite>();
        PhysicsSprite tempSprite;
        public void AddShape(int selectedShape, Vector3 position, int width, int height)
        {
            tempSprite = new PhysicsSprite(selectedShape, position, width, height);
            PhysicsSpriteList.Add(tempSprite);
        }

        public void DrawSprite(SpriteBatch spriteBatch, Texture2D pixel)
        {

            spriteBatch.Begin();
            tempSprite.Draw(spriteBatch);
            spriteBatch.End();

        }
        public void RemoveShape()
        {

        }
    }
}
