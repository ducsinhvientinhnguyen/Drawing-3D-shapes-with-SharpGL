using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Class xây dựng trục tọa độ cho khung nhìn
namespace _18120018_18120062_18120006_Lab04
{
    class Background
    {
        public void Draw(OpenGLControl openGLControl, int size)
        {
            OpenGL gl = openGLControl.OpenGL;

            //Vẽ trục tọa độ tại gốc 0,0,0
            gl.LineWidth(3);
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(1f, 255, 255, 255); // Chọn màu Red
            gl.Vertex(-size, 0, 0); gl.Vertex(size, 0, 0);

            gl.Color(1f, 255, 255, 255); // Chọn màu Green
            gl.Vertex(0, -size, 0); gl.Vertex(0, size, 0);

            gl.Color(1f, 255, 255, 255); // Chọn màu Blue
            gl.Vertex(0, 0, -size); gl.Vertex(0, 0, size);
            gl.End();

            //Vẽ lưới tọa độ
            gl.LineWidth(1);
            gl.Begin(OpenGL.GL_LINES);
            gl.LineWidth(0.1f);
            gl.Color(180.0 / 255.0, 180.0 / 255.0, 180.0 / 255.0, 0);

            for (float i = -size * 2; i <= size * 2; i += 0.5f)
                if (i != 0)
                {
                    gl.Vertex(-size * 2, 0, i); gl.Vertex(size * 2, 0, i);
                    gl.Vertex(i, 0, -size * 2); gl.Vertex(i, 0, size * 2);
                }
            gl.End();
        }
    }
}
