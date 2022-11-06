using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace Gabriela_Casandra_3131A
{
    class Window3D : GameWindow
    {
        private KeyboardState previousKeyboard;
        private CoordsSettings coord;
        private Triangle3D firstTriangle;

        public Window3D() : base(1280, 768, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            coord = new CoordsSettings();
            firstTriangle = new Triangle3D(coord);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // setare fundal
            GL.ClearColor(Color4.LightSteelBlue);

            //setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            //setare proiecte/ com vizualizare
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            //setare ochi
            Matrix4 ochi = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref ochi);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            //LOGIC CODER
            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();

            //OPTIUNEA ESCAPE
            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }

            //OPTIUNEA AFISARE MENIU
            if (currentKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                DisplayHelp();
            }

            //OPTIUNEA RESETARE CULOARE TRIUNGHI
            if (currentKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                firstTriangle.ResetTriangleColor();
            }

            //OPTIUNEA AFISARE/ASCUNDERE TRIUNGHI
            if (currentKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
                firstTriangle.ToggleVisibility();
            }

            //OPTIUNEA SETARE CULOARE NEGRU
            if (currentKeyboard[Key.B] && !previousKeyboard[Key.X])
            {
                firstTriangle.SetBlack();
            }

            //OPTIUNEA SETARE CULOARE MOV
            if (currentKeyboard[Key.P] && !previousKeyboard[Key.P])
            {
                firstTriangle.SetPurple();
            }

            //OPTIUNEA SETARE CULOARE ORANGE
            if (currentKeyboard[Key.O] && !previousKeyboard[Key.O])
            {
                firstTriangle.SetOrange();
            }

            //OPTIUNEA TRIUNGHI NOU
            if (currentKeyboard[Key.N] && !previousKeyboard[Key.N])
            {
                firstTriangle.newTriangle();
            }

            //OPTIUNEA MOD TRANSAPRENT
            if (currentKeyboard[Key.T] && !previousKeyboard[Key.T])
            {
                firstTriangle.SetTransparent();
            }            

            previousKeyboard = currentKeyboard;
            //END LOGIC CODE
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            //RENDER CODE
            firstTriangle.Draw();
            //END RENDER CODE
            SwapBuffers();
        }

        private void DisplayHelp()
        {
            Console.WriteLine("\n     MENU");
            Console.WriteLine("H - meniu ajutor");
            Console.WriteLine("ESCAPE - parasire aplicatie");
            Console.WriteLine("R - resetare culoare triunghi");
            Console.WriteLine("V - afiseaza/ascunde triunghiurile");
            Console.WriteLine("B - setare culoare negru pentru triunghi");
            Console.WriteLine("P - setare culoare mov pentru triunghi");
            Console.WriteLine("O - setare culoare portocaliu pentru triunghi");
            Console.WriteLine("T - mod transparent pentru triunghi");       
            Console.WriteLine("N - triunghi nou");
          
        }
    }
}
