using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriela_Casandra_3131A
{
    class Triangle3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private Color color;
        private bool visibility;
        private float linewidth;
        private CoordsSettings localRandom;

        public Triangle3D(CoordsSettings r)
        {
            pointA = r.SetCoords_1();
            pointB = r.SetCoords_2();
            pointC = r.SetCoords_3();
            color = Color.Red;
            visibility = true;
            linewidth = 1.0f;
            localRandom = r;
        }


        public void Draw()
        {
            if (visibility)
            {
                //REZOLVARE CERINTA 1
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(color);
                GL.Vertex3(pointA);
                GL.Vertex3(pointB);
                GL.Vertex3(pointC);
                GL.End();
            }
        }
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void SetBlack()
        {
            color = Color.Black;
        }

        public void SetPurple()
        {
            color = Color.Purple;
        }
        public void SetOrange()
        {
            color = Color.Orange;
        }
        public void SetTransparent()
        {
            color = Color.Transparent;
        }

        public void ResetTriangleColor()
        {
            color = Color.Red;
        }


        public void newTriangle()
        {
            Vector3 tmp1 = new Vector3(4, 0, 0);
            Vector3 tmp2 = new Vector3(0, 15, 0);
            Vector3 tmp3 = new Vector3(0, 0, 10);
            pointA = tmp1;
            pointB = tmp2;
            pointC = tmp3;
        }

    }

}
