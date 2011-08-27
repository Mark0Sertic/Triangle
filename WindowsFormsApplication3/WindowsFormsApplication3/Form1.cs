using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectInput;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        private Microsoft.DirectX.Direct3D.Device device;
        private float angle = 0f;
        private CustomVertex.PositionColored[] vertices;
        private Microsoft.DirectX.DirectInput.Device keyb;
   
       
        
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
        }
        public void InstalizeDevice()
        {
            PresentParameters presentparams= new PresentParameters();
            presentparams.Windowed = true;
            presentparams.SwapEffect = SwapEffect.Discard;

            device = new Microsoft.DirectX.Direct3D.Device(0, Microsoft.DirectX.Direct3D.DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentparams);

        }

        public void InstalizingKeyboard()
        {
            keyb = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Keyboard);
            keyb.SetCooperativeLevel(this, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
            keyb.Acquire();
        }

        public void CammeraPositioning()
        {
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, this.Width / this.Height, 1f, 50f);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, -30), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            device.RenderState.Lighting = false;
            device.RenderState.CullMode = Cull.None;
        }



        public void VertexDeclaration()
        {
            vertices = new CustomVertex.PositionColored[3];
            vertices[0].Position = new Vector3(0f, 0f, 0f);
            vertices[0].Color = Color.Red.ToArgb();
            vertices[1].Position = new Vector3(10f, 0f, 0f);
            vertices[1].Color = Color.Green.ToArgb();
            vertices[2].Position = new Vector3(5f, 10f, 0f);
            vertices[2].Color = Color.Yellow.ToArgb();
        }

       
     protected  override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {



            device.Clear(ClearFlags.Target, Color.DarkSlateBlue, 1.0f, 0);

            device.BeginScene();
            device.VertexFormat = CustomVertex.PositionColored.Format;
            device.Transform.World = Matrix.Translation(-5, -10 * 1 / 3, 0) * Matrix.RotationAxis(new Vector3(angle * 4, angle * 2, angle * 3), angle);
            device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, vertices);
            device.EndScene();

            device.Present();

            this.Invalidate();

            ReadKeyboard();
      
        }

     private void ReadKeyboard()
     {
         KeyboardState keys = keyb.GetCurrentKeyboardState();
         if (keys[Key.Delete])
         {
             angle += 0.03f;
         }
         if (keys[Key.End])
         {
             angle -= 0.03f;
         }
     }
       
    }
}
