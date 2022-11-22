using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuyoPuyo {
    internal class DoubleBufferdPanel : System.Windows.Forms.Panel {
        internal DoubleBufferdPanel() {
            DoubleBuffered = true;
        }
    }
}
