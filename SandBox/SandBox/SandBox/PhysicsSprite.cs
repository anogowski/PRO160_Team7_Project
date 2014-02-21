using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PhysicsSandbox.Shapes;
using Microsoft.Xna.Framework.Input;


namespace SandBox
{
    class PhysicsSprite : Sandbox.Sprite
    {
        public Shape shape { get; set; }
        public PhysicsSprite(int SelectedShape, Vector3 position, int width, int height)
        {
            if (SelectedShape == 1)
            {
                shape = new PhysicsSandbox.Shapes.Rectangle(new Vector3(Mouse.GetState().X, Mouse.GetState().Y, 0));
            }
            else if (SelectedShape == 2)
            {
                shape = new PhysicsSandbox.Shapes.Circle(new Vector3(Mouse.GetState().X, Mouse.GetState().Y, 0));
            }
            else if (SelectedShape == 3)
            {
                shape = new PhysicsSandbox.Shapes.Triangle(new Vector3(Mouse.GetState().X, Mouse.GetState().Y, 0));
            }
        }
    }
}