using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using XNA = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DrawingStuff;
using FarseerGames.FarseerPhysics.Factories;
using FarseerGames.FarseerPhysics.Collisions;
using FarseerGames.SimpleSamplesXNA.DrawingSystem;
using XNAForms.Objects;
using XNAForms;
using FarseerGames.FarseerPhysics.Dynamics.Springs;

namespace XNAForm
{
    public partial class PlayingForm : XNAForm
    {
        Vector2 oldMouseLocation, newMouseLocation;

        #region Outline Vars
        Boolean drawOutline = false;
        Vector2 cirCenter;

        Vertices polyPath;
        Vector2[] polyPathVects;
        List<Vector2> polyPathVectList = new List<Vector2>();

        int oldX, newX, oldY, newY;
        float radius;
        #endregion

        #region Screen Vars
        private float rotation = 0f;
        private Matrix _viewingMatrix, _morldMatrix, _matrix;
        private PrimitiveBatch drawer; 
        #endregion

        #region Object manipulation Stuff
        Geom selectedGeom;
        PolygonBrush selectedBrush;
        bool moveObj, rotateObj, moveObjSpring;
        FixedLinearSpring movingSpring;
        #endregion

        #region Objects Stuff
        XNA.Graphics.Color fillingColor = new XNA.Graphics.Color(0, 0, 255);
        List<PhysicsRectangle> rects = new List<PhysicsRectangle>();
        List<PhysicsCircle> circles = new List<PhysicsCircle>();
        List<PhysicsPolygon> polys = new List<PhysicsPolygon>();
        PhysicsPlane floor; 
        #endregion

        private void PlayingForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        bool updateSimulator = true;

        #region Blah Stuff(playingForm(), PlayingForm_OnFrameMove(), Frame_Loaded(), DeviceReset(), DeviceResetting())
        public PlayingForm()
        {
            InitializeComponent();

            this.Device_Resetting += new XNAForm.EmptyEventHandler(DeviceResetting);
            this.Device_Reset += new XNAForm.GraphicsDeviceDelegate(DeviceReset);
            this.On_Frame_Render += new XNAForm.GraphicsDeviceDelegate(OnFrameRender);
            this.On_Frame_Moved += new GraphicsDeviceDelegate(PlayingForm_OnFrameMove);
            this.On_Frame_Load += new GraphicsDeviceDelegate(Frame_Loaded);

            _viewingMatrix = _morldMatrix = _matrix = Matrix.Identity;
        }

        void PlayingForm_OnFrameMove(Microsoft.Xna.Framework.Graphics.GraphicsDevice pDevice)
        {
            rotation += 0.1f;
            this._morldMatrix = Matrix.CreateRotationY(rotation);
        }

        void Frame_Loaded(GraphicsDevice pDevice)
        {
            drawer = new PrimitiveBatch(pDevice);
            floor = new PhysicsPlane(Device, XNA.Graphics.Color.Green, new Vector2(viewingPanel.Width / 2, viewingPanel.Bottom - 10), viewingPanel.Width * 2, 50);
        } 

        void DeviceReset(GraphicsDevice pDevice)
        {
            // Configure
            pDevice.VertexDeclaration = new VertexDeclaration(pDevice, VertexPositionColor.VertexElements);
            pDevice.RenderState.CullMode = CullMode.None;

            // Create camera and matrix
            _morldMatrix = Matrix.Identity;
            _viewingMatrix = Matrix.CreateLookAt(Vector3.Backward * 10, Vector3.Zero, Vector3.Up);
            _matrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.Pi / 4.0f,
                    (float)pDevice.PresentationParameters.BackBufferWidth / (float)pDevice.PresentationParameters.BackBufferHeight,
                    1.0f, 100.0f);

        }
        
        void DeviceResetting()
        {
        }
        #endregion

        void OnFrameRender(GraphicsDevice pDevice) //DRAW HERE!!!
        {
            if (updateSimulator)
                Engine.PhysicsSimulator.Update((.02f));

            #region Draw the Circles
            foreach (PhysicsCircle current in circles)
            {
                if (current.Geometry.IsDisposed)
                {
                    circles.Remove(current);
                    break;
                }
                else
                    current.draw();
            } 
            #endregion

            #region Draw the Polygons
            foreach (PhysicsPolygon current in polys)
            {
                if (current.Geometry.IsDisposed)
                {
                    polys.Remove(current);
                    break;
                }
                else
                    current.draw();
            } 
            #endregion

            #region Draw the Rectangles
            foreach (PhysicsRectangle current in rects)
            {
                if (current.Geometry.IsDisposed)
                {
                    rects.Remove(current);
                    break;
                }
                else
                    current.draw();
            } 
            #endregion

            if (drawOutline)
            {
                #region Draw Outline
                if (drawOutline)
                {
                    oldX = (int)oldMouseLocation.X;
                    newX = (int)newMouseLocation.X;
                    oldY = (int)oldMouseLocation.Y;
                    newY = (int)newMouseLocation.Y;

                    if (rectAdd_radioButton.Checked)
                    {
                        drawer.Begin(PrimitiveType.LineList);
                        #region Draw Rectangle

                        objectInfo_richTextbox.Text = "Rectangle size: (Width: " + Math.Abs(oldX - newX) +
                                                    ", Length: " + Math.Abs(oldY - newY) + ")";

                        #region Top
                        drawer.AddVertex(new Vector2(oldX, oldY), XNA.Graphics.Color.White);
                        drawer.AddVertex(new Vector2(newX, oldY), XNA.Graphics.Color.White);
                        #endregion

                        #region Right
                        drawer.AddVertex(new Vector2(newX, newY), XNA.Graphics.Color.White);
                        drawer.AddVertex(new Vector2(newX, oldY), XNA.Graphics.Color.White);
                        #endregion

                        #region Bottom
                        drawer.AddVertex(new Vector2(oldX, newY), XNA.Graphics.Color.White);
                        drawer.AddVertex(new Vector2(newX, newY), XNA.Graphics.Color.White);
                        #endregion

                        #region Left
                        drawer.AddVertex(new Vector2(oldX, oldY), XNA.Graphics.Color.White);
                        drawer.AddVertex(new Vector2(oldX, newY), XNA.Graphics.Color.White);
                        #endregion

                        #endregion
                        drawer.End();
                    }
                    else if (circleAdd_radioButton.Checked)
                    {
                        
                        drawer.Begin(PrimitiveType.LineList);
                        #region Draw Circle
                        radius = (oldMouseLocation - newMouseLocation).Length();
                        objectInfo_richTextbox.Text = "Circle radius: " + radius;
                        if (radius == 0)
                            radius = .01f;
                        float inverseRadius = Math.Min(1 / radius, (float)Math.PI / 8);

                        for (float i = 0; i < 2 * Math.PI; i += inverseRadius)
                        {
                            drawer.AddVertex(cirCenter + new Vector2((float)(Math.Cos(i) * radius), (float)(Math.Sin(i) * radius))
                                , XNA.Graphics.Color.White);
                            drawer.AddVertex(cirCenter + new Vector2((float)(Math.Cos(i + inverseRadius) * radius), (float)(Math.Sin(i + inverseRadius) * radius))
                                , XNA.Graphics.Color.White);
                        } 
                        #endregion
                        drawer.End();
                    }
                    else if (polyAdd_radioButton.Checked)
                    {
                        drawer.Begin(PrimitiveType.LineList);
                        #region Draw Poly
                        for (int c = 1; c < polyPathVectList.Count; c++)
                        {
                            drawer.AddVertex(polyPathVectList[c - 1], XNA.Graphics.Color.Black);
                            drawer.AddVertex(polyPathVectList[c], XNA.Graphics.Color.Black);
                        }
                        objectInfo_richTextbox.Text = "Point count: " + polyPathVectList.Count;
                        #endregion
                        drawer.End();

                    }
                }
                #endregion
            }

            #region Draw Line
            if (moveObj)
            {
                drawer.Begin(PrimitiveType.LineList);
                drawer.AddVertex(oldMouseLocation, XNA.Graphics.Color.Black);
                drawer.AddVertex(selectedGeom.Body.Position, XNA.Graphics.Color.Black);
                drawer.End();
            }

            if (rotateObj)
            {
                drawer.Begin(PrimitiveType.LineList);
                drawer.AddVertex(selectedGeom.Body.Position, XNA.Graphics.Color.Black);
                drawer.AddVertex(newMouseLocation, XNA.Graphics.Color.Black);
                drawer.End();
            }

            if (moveObjSpring)
            {
                drawer.Begin(PrimitiveType.LineList);
                drawer.AddVertex(movingSpring.Body.GetWorldPosition(movingSpring.BodyAttachPoint), XNA.Graphics.Color.Black);
                drawer.AddVertex(movingSpring.WorldAttachPoint, XNA.Graphics.Color.Black);
                drawer.End();
            } 
            #endregion

            if (!floor.Geometry.IsDisposed)
                floor.draw();

            if (selectedGeom != null)
                selectedBrush.Draw(selectedGeom.Matrix);
        }

        #region Mouse Stuff
        private void viewingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            newMouseLocation = new Vector2(e.X, e.Y);

            if (moveObj)
            {
                selectedGeom.Body.Position = newMouseLocation;
            }
            else if(moveObjSpring)
            {
                movingSpring.WorldAttachPoint = newMouseLocation;
            }
            else if (rotateObj)
            {
                selectedGeom.Body.Rotation = (float)Math.Atan2((double)(selectedGeom.Body.Position.Y - newMouseLocation.Y),
                           (double)(selectedGeom.Body.Position.X - newMouseLocation.X)) - MathHelper.ToRadians(90);
            }
            else if (polyAdd_radioButton.Checked)
            {
                polyPathVectList.Add(newMouseLocation);
            }

        }

        private void viewingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            oldMouseLocation = new Vector2(e.X, e.Y);
            newMouseLocation = oldMouseLocation;
            cirCenter = oldMouseLocation;

            selectedGeom = Engine.PhysicsSimulator.Collide(oldMouseLocation);

            if (selectedGeom != null)
            {
                selectedBrush = new PolygonBrush(selectedGeom.LocalVertices, XNA.Graphics.Color.Black, XNA.Graphics.Color.White, 3, 3);
                selectedBrush.Load(Device);
                updateObjectInfo();

                if (e.Button == MouseButtons.Left && updateSimulator)
                {
                    movingSpring = SpringFactory.Instance.CreateFixedLinearSpring(Engine.PhysicsSimulator,
                        selectedGeom.Body, selectedGeom.Body.GetLocalPosition(oldMouseLocation), oldMouseLocation, 10, 5);
                    moveObjSpring = true;
                }
                else if ((e.Button == MouseButtons.Middle) || (e.Button == MouseButtons.Left && !updateSimulator))
                    moveObj = true;
                else
                    rotateObj = e.Button == MouseButtons.Right;
            }
            else
            {
                drawOutline = (tabControl1.SelectedIndex == 0 && e.Button == MouseButtons.Left);
                polyPathVectList.Clear();
            }
        }

        private void viewingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            moveObj = false;
            rotateObj = false;
            moveObjSpring = false;

            if (movingSpring != null)
            {
                movingSpring.Dispose();
                movingSpring = null;
            }

            if (drawOutline)
            {
                drawOutline = false;
                if (rectAdd_radioButton.Checked)
                {
                    #region Add Rect
                    int width = (int)(oldMouseLocation.X - newMouseLocation.X);
                    int height = (int)(oldMouseLocation.Y - newMouseLocation.Y);
                    Vector2 location;

                    location = new Vector2(oldMouseLocation.X - width * .5f, oldMouseLocation.Y - height * .5f);

                    if (Math.Abs(width) == 0)
                        width = 1;

                    if (Math.Abs(height) == 0)
                        height = 1;

                    rects.Add(new PhysicsRectangle(Device, fillingColor, location,
                        Math.Abs(width), Math.Abs(height), startFrozen_Checkbox.Checked));


                    #endregion
                }
                else if (circleAdd_radioButton.Checked)
                {
                    #region Add Circle
                    int radius = (int)(oldMouseLocation - newMouseLocation).Length();
                    circles.Add(new PhysicsCircle(Device, fillingColor, oldMouseLocation, radius, startFrozen_Checkbox.Checked));
                    #endregion
                }
                else if (polyAdd_radioButton.Checked)
                {
                    #region Add Poly
                    if (polyPathVectList.Count >= 3)
                    {
                        polyPathVects = new Vector2[polyPathVectList.Count];
                        for (int c = 0; c < polyPathVectList.Count; c++)
                        {
                            polyPathVects[c] = polyPathVectList[c];
                        }
                        polyPath = new Vertices(polyPathVects);
                        polys.Add(new PhysicsPolygon(Device, fillingColor, oldMouseLocation, polyPath, startFrozen_Checkbox.Checked));
                        polyPathVectList.Clear();
                    }
                    #endregion
                }
                Engine.PhysicsSimulator.Update((.02f));
            }

        } 
        #endregion

        #region GUI Tool Events

        private void play_stop_button_Click(object sender, EventArgs e)
        {
            updateSimulator = !updateSimulator;
            if (updateSimulator)
            {
                play_stop_button.Text = "Stop";
                play_stop_button.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                play_stop_button.Text = "Play";
                play_stop_button.BackColor = System.Drawing.Color.YellowGreen;
            }
        }

        private void gravity_trackBar_Scroll(object sender, EventArgs e)
        {
            gravity_label.Text = ((double)gravity_trackBar.Value / 10).ToString();
            Engine.PhysicsSimulator.Gravity = new Vector2(0, (float)(gravity_trackBar.Value / 10) * 30f);
        }

        private void tool_Mass_numUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selectedGeom != null)
            {
                selectedGeom.Body.Mass = (float)tool_Mass_numUpDown.Value;
            }
        }

        private void tool_Friction_numUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selectedGeom != null)
            {
                selectedGeom.FrictionCoefficient = (float)tool_Friction_numUpDown.Value;
            }
        }

        private void tool_Bounce_numUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (selectedGeom != null)
            {
                selectedGeom.RestitutionCoefficient = (float)tool_Bounce_numUpDown.Value;
            }
        }

        private void tool_Frozen_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedGeom != null)
            {
                selectedGeom.Body.IsStatic = tool_Frozen_Checkbox.Checked;
            }
        }

        private void updateObjectInfo()
        {
            tool_Mass_numUpDown.Value = (decimal)selectedGeom.Body.Mass;
            tool_Friction_numUpDown.Value = (decimal)selectedGeom.FrictionCoefficient;
            tool_Bounce_numUpDown.Value = (decimal)selectedGeom.RestitutionCoefficient;
            tool_Frozen_Checkbox.Checked = selectedGeom.Body.IsStatic;
        }

        private void tool_delete_button_Click(object sender, EventArgs e)
        {
            if (selectedGeom != null)
            {
                selectedGeom.Body.Dispose();
                selectedGeom.Dispose();
                selectedGeom = null;
            }
        }

        private void colorFill_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult res = fillColorChoser_colorDialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                colorFill_link.Text = fillColorChoser_colorDialog.Color.ToString();
                colorFill_link.LinkColor = fillColorChoser_colorDialog.Color;
                fillingColor = new XNA.Graphics.Color(colorFill_link.LinkColor.R, colorFill_link.LinkColor.G, colorFill_link.LinkColor.B);
            }
        }

        private void clearAll_button_Click(object sender, EventArgs e)
        {
            foreach (PhysicsRectangle current in rects)
                current.Geometry.Dispose();
            rects.Clear();

            foreach (PhysicsCircle current in circles)
                current.Geometry.Dispose();
            circles.Clear();

            foreach (PhysicsPolygon current in polys)
                current.Geometry.Dispose();
            polys.Clear();
        }

        private void clearRects_Click(object sender, EventArgs e)
        {
            foreach (PhysicsRectangle current in rects)
                current.Geometry.Dispose();
            rects.Clear();
        }

        private void clearCircles_button_Click(object sender, EventArgs e)
        {
            foreach (PhysicsCircle current in circles)
                current.Geometry.Dispose();
            circles.Clear();
        }

        private void clearPoly_button_Click(object sender, EventArgs e)
        {
            foreach (PhysicsPolygon current in polys)
                current.Geometry.Dispose();
            polys.Clear();
        }
        
        #endregion        

        
    }
}