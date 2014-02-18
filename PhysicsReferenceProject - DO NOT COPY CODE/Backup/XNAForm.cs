using System;
using System.Windows.Forms;
using XNAShort = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAForm
{
   
    public partial class XNAForm : Form
    {
        private RefreshType _refreshType = RefreshType.Always;
        private GraphicsDevice _graphicsDevice;

        public enum RefreshType
        {
            Always,
            WhenPanelPaints,        
        }

        #region Properties
        public GraphicsDevice Device
        {
            get { return _graphicsDevice; }
        }

        public RefreshType Refresh_Type
        {
            get { return _refreshType; }
            set { _refreshType = value; }
        } 
        #endregion

        private XNAShort.Graphics.Color mBackColor = XNAShort.Graphics.Color.Azure;

        #region Events

        public delegate void GraphicsDeviceDelegate(GraphicsDevice pDevice);
        public delegate void EmptyEventHandler();
        public event GraphicsDeviceDelegate On_Frame_Render = null;
        public event GraphicsDeviceDelegate On_Frame_Moved = null;
        public event EmptyEventHandler Device_Resetting = null;
        public event GraphicsDeviceDelegate Device_Reset = null;
        public event GraphicsDeviceDelegate On_Frame_Load = null;
        #endregion

        public XNAForm()
        {
            InitializeComponent();

            // Foce color resfresh. (if panel has default backcolor, BackColorChanged won´t be called)
            this.ViewingPanel_BackColor_Changed(null, EventArgs.Empty);
        }

        #region XNA methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            createGraphicsDevice();

            resetGraphicsDevice();
        }
        
        private void createGraphicsDevice()
        {
            // Create Presentation Parameters
            PresentationParameters pp = new PresentationParameters();
            pp.BackBufferCount = 1;
            pp.IsFullScreen = false;
            pp.SwapEffect = SwapEffect.Discard;
            pp.BackBufferWidth = viewingPanel.Width;
            pp.BackBufferHeight = viewingPanel.Height;
            pp.AutoDepthStencilFormat = DepthFormat.Depth24Stencil8;
            pp.EnableAutoDepthStencil = true;
            pp.PresentationInterval = PresentInterval.Default;
            pp.BackBufferFormat = SurfaceFormat.Unknown;
            pp.MultiSampleType = MultiSampleType.None;

            // Create device
            _graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, DeviceType.Hardware, viewingPanel.Handle,
                pp);

            if (this.On_Frame_Load != null && this.Device != null)
                this.On_Frame_Load(this.Device);
        }

        private void resetGraphicsDevice()
        {       
            // Stop unless panelViewport and device are both created
            if (_graphicsDevice== null || viewingPanel.Width == 0 || viewingPanel.Height == 0)
                return;

            if (this.Device_Resetting != null)
                this.Device_Resetting();

            // Reset device
            _graphicsDevice.PresentationParameters.BackBufferWidth = viewingPanel.Width;
            _graphicsDevice.PresentationParameters.BackBufferHeight = viewingPanel.Height;
            _graphicsDevice.Reset();

            if (this.Device_Reset != null)
                this.Device_Reset(this._graphicsDevice);
        }  
     
        public void render()
        {
            if (this.On_Frame_Moved != null)
                this.On_Frame_Moved(this._graphicsDevice);

            _graphicsDevice.Clear(this.mBackColor);

            if (this.On_Frame_Render != null)
                this.On_Frame_Render(this._graphicsDevice);
          
            _graphicsDevice.Present();
        }

        private void On_viewingPanel_Resize(object sender, EventArgs e)
        {
            resetGraphicsDevice();

            if (this.On_Frame_Load != null && this.Device != null)
                this.On_Frame_Load(this.Device);

        }

        private void On_viewingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this._refreshType != RefreshType.Always)
                this.render();
        }

        private void ViewingPanel_BackColor_Changed(object sender, EventArgs e)
        {
            this.mBackColor = new XNAShort.Graphics.Color(viewingPanel.BackColor.R, viewingPanel.BackColor.G, viewingPanel.BackColor.B);
        }

        #endregion
    }

}