using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummydataq
{
    public class global
    {

        public struct im_defect
        {
            private string lot_name;
            private string module_name;
            private int frame_index;
            private int defect_index;
            private string defect_type;
            private bool skip;
            private double pos_x;
            private double pos_y;
            private int module_index;

            public string Lot_name { get => lot_name; set => lot_name = value; }
            public int Frame_index { get => frame_index; set => frame_index = value; }
            public int Defect_index { get => defect_index; set => defect_index = value; }
            public string Defect_type { get => defect_type; set => defect_type = value; }
            public bool Skip { get => skip; set => skip = value; }
            public double Pos_x { get => pos_x; set => pos_x = value; }
            public double Pos_y { get => pos_y; set => pos_y = value; }
            
            public string Module_name { get => module_name; set => module_name = value; }
            public int Module_index { get => module_index; set => module_index = value; }
        }





    }

}
