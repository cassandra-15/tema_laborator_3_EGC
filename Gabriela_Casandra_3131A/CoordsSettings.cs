using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriela_Casandra_3131A
{
    class CoordsSettings
    {

        /// <summary>
        /// genereaza culoare random
        /// </summary>
        /// <returns></returns>

        public Vector3 SetCoords_1()
        {
            int a = 21;
            int b = 0;
            int c = 0;

            Vector3 vect = new Vector3(a, b, c);

            return vect;
        }

        public Vector3 SetCoords_2()
        {
            int a = 0;
            int b = 16;
            int c = 0;

            Vector3 vect = new Vector3(a, b, c);

            return vect;
        }

        public Vector3 SetCoords_3()
        {
            int a = 0;
            int b = 0;
            int c = 20;

            Vector3 vect = new Vector3(a, b, c);

            return vect;
        }


    }
}
