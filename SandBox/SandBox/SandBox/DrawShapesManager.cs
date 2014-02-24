using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PhysicsSandbox.Shapes;
using PhysicsSandbox.Physics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SandBox
{
    class DrawShapesManager
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ContentManager Content;
        Texture2D rectTexture;
        Texture2D circTexture;
        Texture2D triTexture;

        public DrawShapesManager(ref SpriteBatch batch, ref GraphicsDeviceManager guiGraphics, ContentManager content)
        {
            spriteBatch = batch;
            this.graphics = guiGraphics;
            Content = content;
            rectTexture = Content.Load<Texture2D>("rectangle");
            circTexture = Content.Load<Texture2D>("circle");
            triTexture = Content.Load<Texture2D>("triangle");
        }

        //a container of all rectangles
        List<PhysicsSandbox.Shapes.Rectangle> rectangleList = new List<PhysicsSandbox.Shapes.Rectangle>();

        //a container of all triangles
        List<Triangle> triangleList = new List<Triangle>();

        //a container of all circles
        List<Circle> circleList = new List<Circle>();

        //a method: addShapes(shape object, shape type);

        private void DrawRectangle(PhysicsSandbox.Shapes.Rectangle rect, int width, int height, Vector3 pos, float mass, float momentum)
        {
            rect.Width = width;
            rect.Height = height;
            rect.Position = pos;
            rect.Mass = mass;
            rect.Momentum = momentum;



            Vector2 newVector = new Vector2(rect.Position.X, rect.Position.Y);
            spriteBatch.Draw(rectTexture, newVector, Color.Black);
        }
        private void DrawRectangle(PhysicsSandbox.Shapes.Rectangle rect, int width, int height, Vector3 pos)
        {
            rect.Width = width;
            rect.Height = height;
            rect.Position = pos;
        }

        private void DrawCircle(Circle circ, float mass, float momentum, int radius, Vector3 pos)
        {
            circ.Radius = radius;
            circ.Mass = mass;
            circ.Momentum = momentum;
            circ.Position = pos;
        }
        private void DrawCircle(Circle circ, int radius, Vector3 pos)
        {
            circ.Radius = radius;
            circ.Position = pos;
        }

        private void DrawTriangle(Triangle tri, int width, int height, Vector3 pos, float mass, float momentum)
        {
            tri.Width = width;
            tri.Height = height;
            tri.Position = pos;
            tri.Mass = mass;
            tri.Momentum = momentum;
        }
        private void DrawTriangle(Triangle tri, int width, int height, Vector3 pos)
        {
            tri.Width = width;
            tri.Height = height;
            tri.Position = pos;
        }

        public void UpdatePhysics(Physics p)
        {
            //iterate all list elemtns
            //foreach (var item in rectangles)
            //{
            //    DrawRectangle(....);
            //}

            // foreach (var item in rectangles)
            //{
            //    DrawRectangle(....);
            //}
            //}

            // foreach (var item in rectangles)
            //    {
            //        DrawRectangle(....);
            //    }
            //}
        }

        public void DrawShapes()
        {
            foreach (var rect in rectangleList)
            {
                Vector2 newVector = new Vector2(rect.Position.X, rect.Position.Y);
                spriteBatch.Draw(rectTexture, newVector, Color.Black);
            }

            foreach (var circ in circleList)
            {
                Vector2 newVector = new Vector2(circ.Position.X, circ.Position.Y);
                spriteBatch.Draw(circTexture, newVector, Color.Black);
            }

            foreach (var tri in triangleList)
            {
                Vector2 newVector = new Vector2(tri.Position.X, tri.Position.Y);
                spriteBatch.Draw(triTexture, newVector, Color.Black);
            }
        }
    }
}
