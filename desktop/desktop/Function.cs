using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop
{
    class Function
    {
        MemoryStream ms;

        public byte[] saveImage(PictureBox pb)
        {
            ms = new MemoryStream();
            pb.Image.Save(ms, pb.Image.RawFormat);
            byte[] data = ms.ToArray();
            return data;
        }

        public Image byteToImage(byte[] data)
        {
            ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }
    }
}
