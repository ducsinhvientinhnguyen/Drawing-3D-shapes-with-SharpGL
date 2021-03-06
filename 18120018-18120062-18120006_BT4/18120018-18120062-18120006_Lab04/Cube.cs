using System;
using SharpGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;
//Class định nghĩa thuộc tính khối hình hộp 
namespace _18120018_18120062_18120006_Lab04
{
    class Cube : Object
    {
        private Vertex k;//dịch tâm một tọa độ k(x,y,z)
        public Cube() //màu nền, tâm, chiều dài cạnh, check đang chọn
        {
            //if (center != null)
            //    _center = center; //tâm (mặc định (0,0,0))

            _length = 2.0f;
            _color = Color.White; //màu nền mặt phẳng
            k = new Vertex(tX - 0 - _length / 2, tY - 0 - _length / 2, tZ - 0 - _length / 2);
            //k = độ chênh lệch các tọa độ của 2 tâm để dịch các đỉnh theo k
            //k = new Vertex(0, 0, 0);
            _Solid = false; //check xem có đang thao tác trên hình này không
            //_countObjects++;
            type = 0;
            isTexture = false;
            hasTexture = false;
            fileName = "";
            texture = new Texture();

            listVertex = new List<Vertex> { new Vertex(), new Vertex(), new Vertex(), new Vertex(), new Vertex(), new Vertex(), new Vertex(), new Vertex() };
            angelX = angelY = angelZ = 0;
            tX = tY = tZ = 0;
            sX = sY = sZ = 1;

        }
        private void Save()
        {
            k.x = tX - 0 - _length / 2;
            k.y = tY - 0 - _length / 2;
            k.z = tZ - 0 - _length / 2;

            //V1 = new Vertex(0 + k.x, 0 + k.y, 0 + k.z);
            listVertex[0].x = 0 + k.x;
            listVertex[0].y = 0 + k.y;
            listVertex[0].z = 0 + k.z;
            //V2 = new Vertex(0 + k.x, _length + k.y, 0 + k.z);
            listVertex[1].x = 0 + k.x;
            listVertex[1].y = _length + k.y;
            listVertex[1].z = 0 + k.z;
            //V3 = new Vertex(_length + k.x, _length + k.y, 0 + k.z);
            listVertex[2].x = _length + k.x;
            listVertex[2].y = _length + k.y;
            listVertex[2].z = 0 + k.z;
            //V4 = new Vertex(_length + k.x, 0 + k.y, 0 + k.z);
            listVertex[3].x = _length + k.x;
            listVertex[3].y = 0 + k.y;
            listVertex[3].z = 0 + k.z;
            //V5 = new Vertex(0 + k.x, _length + k.y, _length + k.z);
            listVertex[4].x = 0 + k.x;
            listVertex[4].y = _length + k.y;
            listVertex[4].z = _length + k.z;
            //V6 = new Vertex(0 + k.x, 0 + k.y, _length + k.z);
            listVertex[5].x = 0 + k.x;
            listVertex[5].y = 0 + k.y;
            listVertex[5].z = _length + k.z;
            //V7 = new Vertex(_length + k.x, 0 + k.y, _length + k.z);
            listVertex[6].x = _length + k.x;
            listVertex[6].y = 0 + k.y;
            listVertex[6].z = _length + k.z;
            //V8 = new Vertex(_length + k.x, _length + k.y, _length + k.z);
            listVertex[7].x = _length + k.x;
            listVertex[7].y = _length + k.y;
            listVertex[7].z = _length + k.z;
        }
        //Hàm vẽ 
        public override void Draw(OpenGLControl glControl)
        {
            OpenGL gl = glControl.OpenGL;
            Save();
            gl.PushMatrix();
            gl.Rotate((float)angelX, (float)angelY, (float)angelZ);
            gl.Translate(tX, tY, tZ);
            gl.Scale(sX, sY, sZ);

            gl.Color(_color.R / 255.0, _color.G / 255.0, _color.B / 255.0, 0);
            //Vẽ khối hoặc vẽ và dán texture
            if (isTexture)
                DrawTexture(gl);
            else
                DrawRaw(gl);
            //Viền khung
            VienKhung(gl);
            gl.PopMatrix();
            gl.Flush();// Thực hiện lệnh vẽ ngay lập tức thay vì đợi sau 1 khoảng thời gian
        }
        //Hàm vẽ không có texture
        private void DrawRaw(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_QUADS);
            //Vẽ mặt phẳng
            gl.Vertex(0 + k.x, 0 + k.y, 0 + k.z);//V1
            gl.Vertex(0 + k.x, _length + k.y, 0 + k.z);//V2
            gl.Vertex(_length + k.x, _length + k.y, 0 + k.z); //V3
            gl.Vertex(_length + k.x, 0 + k.y, 0 + k.z); //V4


            gl.Vertex(0 + k.x, 0 + k.y, 0 + k.z); //V1
            gl.Vertex(0 + k.x, _length + k.y, 0 + k.z); //V2
            gl.Vertex(0 + k.x, _length + k.y, _length + k.z);//V5
            gl.Vertex(0 + k.x, 0 + k.y, _length + k.z);//V6


            gl.Vertex(0 + k.x, 0 + k.y, 0 + k.z); //V1
            gl.Vertex(0 + k.x, 0 + k.y, _length + k.z);//V6
            gl.Vertex(_length + k.x, 0 + k.y, _length + k.z);//V7
            gl.Vertex(_length + k.x, 0 + k.y, 0 + k.z);//V4

            gl.Vertex(0 + k.x, 0 + k.y, _length + k.z);//V6
            gl.Vertex(0 + k.x, _length + k.y, _length + k.z);//V5
            gl.Vertex(_length + k.x, _length + k.y, _length + k.z);//V8
            gl.Vertex(_length + k.x, 0 + k.y, _length + k.z);//V7


            gl.Vertex(0 + k.x, _length + k.y, 0 + k.z);//V2
            gl.Vertex(0 + k.x, _length + k.y, _length + k.z);//V5
            gl.Vertex(_length + k.x, _length + k.y, _length + k.z);//V8
            gl.Vertex(_length + k.x, _length + k.y, 0 + k.z);//V3


            gl.Vertex(_length + k.x, _length + k.y, 0 + k.z);//V3
            gl.Vertex(_length + k.x, 0 + k.y, 0 + k.z);//V4
            gl.Vertex(_length + k.x, 0 + k.y, _length + k.z);//V7
            gl.Vertex(_length + k.x, _length + k.y, _length + k.z);//V8

            gl.End();
        }
        // Hàm vẽ có texture
        private void DrawTexture(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            //Bind the texture.
            texture.Bind(gl);
            gl.Color(1f, 1f, 1f, 0);
            gl.Begin(OpenGL.GL_QUADS);
            //Vẽ mặt phẳng
            //Right face
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0 + k.x, 0 + k.y, 0 + k.z);//V1
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0 + k.x, _length + k.y, 0 + k.z);//V2
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(_length + k.x, _length + k.y, 0 + k.z); //V3
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(_length + k.x, 0 + k.y, 0 + k.z); //V4

            // Behind face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0 + k.x, 0 + k.y, 0 + k.z); //V1
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0 + k.x, _length + k.y, 0 + k.z); //V2
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(0 + k.x, _length + k.y, _length + k.z);//V5
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(0 + k.x, 0 + k.y, _length + k.z);//V6

            //Down face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0 + k.x, 0 + k.y, 0 + k.z); //V1
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0 + k.x, 0 + k.y, _length + k.z);//V6
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(_length + k.x, 0 + k.y, _length + k.z);//V7
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(_length + k.x, 0 + k.y, 0 + k.z);//V4

            //Left face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0 + k.x, 0 + k.y, _length + k.z);//V6
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0 + k.x, _length + k.y, _length + k.z);//V5
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(_length + k.x, _length + k.y, _length + k.z);//V8
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(_length + k.x, 0 + k.y, _length + k.z);//V7

            // Up face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(0 + k.x, _length + k.y, 0 + k.z);//V2
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(0 + k.x, _length + k.y, _length + k.z);//V5
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(_length + k.x, _length + k.y, _length + k.z);//V8
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(_length + k.x, _length + k.y, 0 + k.z);//V3

            //Front face
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(_length + k.x, _length + k.y, 0 + k.z);//V3
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(_length + k.x, 0 + k.y, 0 + k.z);//V4
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(_length + k.x, 0 + k.y, _length + k.z);//V7
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(_length + k.x, _length + k.y, _length + k.z);//V8

            gl.End();
            gl.Disable(OpenGL.GL_TEXTURE_2D);
        }

        //Hàm viền khung hình
        private void VienKhung(OpenGL gl)
        {
            if (_Solid) //nếu đang thao tác trên hình
            {
                //viền cam đậm
                gl.Color(236 / 255.0, 135 / 255.0, 14 / 255.0);
                //tăng kích cỡ viền
                gl.LineWidth((float)2);
            }
            else // nếu không thao tác
            {
                //viền đen nhạt
                gl.Color(255 / 255.0, 255 / 255.0, 255 / 255.0);
                //tăng kích cỡ viền
                gl.LineWidth((float)2);
            }

            gl.Begin(OpenGL.GL_LINES);
            //Vẽ các cạnh
            gl.Vertex(listVertex[0].x, listVertex[0].y, listVertex[0].z);
            gl.Vertex(listVertex[1].x, listVertex[1].y, listVertex[1].z);

            gl.Vertex(listVertex[1].x, listVertex[1].y, listVertex[1].z);
            gl.Vertex(listVertex[2].x, listVertex[2].y, listVertex[2].z);


            gl.Vertex(listVertex[2].x, listVertex[2].y, listVertex[2].z);
            gl.Vertex(listVertex[3].x, listVertex[3].y, listVertex[3].z);


            gl.Vertex(listVertex[0].x, listVertex[0].y, listVertex[0].z);
            gl.Vertex(listVertex[3].x, listVertex[3].y, listVertex[3].z);


            gl.Vertex(listVertex[1].x, listVertex[1].y, listVertex[1].z);
            gl.Vertex(listVertex[4].x, listVertex[4].y, listVertex[4].z);


            gl.Vertex(listVertex[5].x, listVertex[5].y, listVertex[5].z);
            gl.Vertex(listVertex[4].x, listVertex[4].y, listVertex[4].z);


            gl.Vertex(listVertex[5].x, listVertex[5].y, listVertex[5].z);
            gl.Vertex(listVertex[0].x, listVertex[0].y, listVertex[0].z);


            gl.Vertex(listVertex[5].x, listVertex[5].y, listVertex[5].z);
            gl.Vertex(listVertex[6].x, listVertex[6].y, listVertex[6].z);


            gl.Vertex(listVertex[3].x, listVertex[3].y, listVertex[3].z);
            gl.Vertex(listVertex[6].x, listVertex[6].y, listVertex[6].z);


            gl.Vertex(listVertex[4].x, listVertex[4].y, listVertex[4].z);
            gl.Vertex(listVertex[7].x, listVertex[7].y, listVertex[7].z);


            gl.Vertex(listVertex[6].x, listVertex[6].y, listVertex[6].z);
            gl.Vertex(listVertex[7].x, listVertex[7].y, listVertex[7].z);



            gl.Vertex(listVertex[2].x, listVertex[2].y, listVertex[2].z);
            gl.Vertex(listVertex[7].x, listVertex[7].y, listVertex[7].z);
            gl.End();

        }

        ~Cube()
        {
        }
    }
}
