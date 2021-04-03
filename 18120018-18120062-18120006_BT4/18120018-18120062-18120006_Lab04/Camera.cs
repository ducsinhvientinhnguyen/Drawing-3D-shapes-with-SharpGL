using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//Class xây dựng Camera view nhìn của người dùng
namespace _18120018_18120062_18120006_Lab04
{
    public class Camera
    {

        public Vertex _eye = new Vertex();// Biến lưu giữ tọa độ của camera     
        public Vertex _model= new Vertex();//Biến lưu giữ vị trí tọa độ điểm nhìn
        public double alpha ; // Góc theo phương ngang  
        public double beta ; // Góc theo phương dọc 
        public double Distance; // Khoảng cách từ điểm nhìn đến camera

        public Camera()
        { // Hàm khởi tạo camera

            _eye.x = 8;
            _eye.y = 4;
            _eye.z = 8;

            _model.x = 0;
            _model.y = 0;
            _model.z = 0;
            Calc_Distance();
            Calc_alpha();
            Calc_beta();


        }

        private void Calc_Distance()
        { // Hàm tính khoảng cách từ điểm nhìn đén camera
            Distance = Math.Sqrt(Math.Pow(_eye.x - _model.x, 2)
                     + Math.Pow(_eye.y - _model.y, 2)
                     + Math.Pow(_eye.z - _model.z, 2));
        }

        private void Calc_alpha()
        { // Hàm tính góc alpha
           alpha = Math.Atan((_eye.x - _model.x) / (_eye.z - _model.z));
        }

        public void Calc_beta()
        {//Hàm tính góc beta
           beta = Math.Asin((_eye.y - _model.y) / Distance);   
        }
        public void ZoomIn()
        {//Hàm tính lại các thuộc tính của Camera sau khi thực hiện thu nhỏ 
            _eye.x += -0.017f * _eye.x;
            _eye.y += -0.017f * _eye.y;
            _eye.z += -0.017f * _eye.z;

            // Khi di chuyển vị trí camera thì bán kính hình cầu sẽ thay đổi nên cần cập nhật lại
            Calc_Distance();
            Calc_alpha();
            Calc_beta();
        }
        public void ZoomOut()
        {//Hàm tính lại các thuộc tính của Camera sau khi thực hiện phóng to
            _eye.x += 0.017f * _eye.x;
            _eye.y += 0.017f * _eye.y;
            _eye.z += 0.017f * _eye.z;

            // Khi di chuyển vị trí camera thì bán kính hình cầu sẽ thay đổi nên cần cập nhật lại
            Calc_Distance();
            Calc_alpha();
            Calc_beta();
        }
        // Di chuyển camera quay .xung quanh điểm nhìn .xuống dưới
        public void RotateRight()
        {//Hàm tính lại các thuộc tính của Camera sau khi thực hiện xoay camera qua phải
            alpha += 0.02;
            _eye.x = _model.x + Distance * Math.Cos(beta) * Math.Sin(alpha);
            _eye.z = _model.z + Distance * Math.Cos(beta) * Math.Cos(alpha);
                
        }

        // Di chuyển camera quay .xung quanh điểm nhìn sang trái 
        public void RotateLeft()
        {//Hàm tính lại các thuộc tính của Camera sau khi thực hiện xoay camera qua trái
            alpha -= 0.02;
            _eye.x = _model.x + Distance * Math.Cos(beta) * Math.Sin(alpha);
            _eye.z = _model.z + Distance * Math.Cos(beta) * Math.Cos(alpha);
        }

        // Di chuyển camera quay .xung quanh điểm nhìn lên trên
        public void RotateUp()
        {//Hàm tính lại các thuộc tính của Camera sau khi thực hiện xoay camera lên trên
            beta += 0.017;
            _eye.y = _model.y + Distance * Math.Sin(beta);
            _eye.z = _model.z + Distance * Math.Cos(beta) * Math.Cos(alpha);
            _eye.x = _model.x + Distance * Math.Cos(beta) * Math.Sin(alpha);
        }

        
        public void RotateDown()
        {//Hàm tính lại các thuộc tính của Camera sau khi thực hiện xoay camera xuống dưới 
            beta -= 0.017;

            _eye.y = _model.y + Distance * Math.Sin(beta);
            _eye.z = _model.z + Distance * Math.Cos(beta) * Math.Cos(alpha);
            _eye.x = _model.x + Distance * Math.Cos(beta) * Math.Sin(alpha);

        }
    }
}
