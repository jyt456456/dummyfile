using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;

namespace dummydataq
{
    internal class postsql
    {
        private string m_constring;


        public postsql()
        {
            //m_constring = "Server=192.168.1.15:5435;username=postgres;password=masterkey;database=UniScan";
             m_constring = "Server=127.0.0.1:5435;username=postgres;password=masterkey;database=UniScan";
        }

        public bool CreateDefect(global.im_defect _deff)
        {
            string dt = DateTime.Now.ToString("yyyy-MM-dd");
            bool suc = false;
            bool skip = false;
            //CM_LOT 시간,모델이름,lot이름
            global.im_defect pre = new global.im_defect();
            pre = _deff;
            string que = "insert into \"IM_Defect\" (lot_name, frame_index, module_index,defect_index, defect_type, skip, pos_x, pos_y) values("
                + operstr(pre.Lot_name) + "," + pre.Frame_index.ToString() + "," +  pre.Module_index.ToString() + ","  + pre.Defect_index.ToString() + "," + operstr(pre.Defect_type) + "," + skip.ToString() + ","
                + pre.Pos_x.ToString() + "," + pre.Pos_y.ToString() +")";

            suc = NonQuery(que);

            /*
            Thread.Sleep(5);
            //lot이름, frame인덱스,module인덱스, 
            que = "insert into public.CM_Frame values(" + operstr(pre.Lot_name) + "," + pre.Frame_index.ToString() + "," + pre.Module_name.ToString() + ")";

            NonQuery(que);

            Thread.Sleep(5);

            //lot이름, frame인덱스, module인덱스, defect인덱스, defect타입, skip, posx,posy
            
            que = "insert into public.CM_Defect values(" + operstr(pre.Lot_name) + "," + pre.Frame_index.ToString() + "," + pre.Model.ToString() + ","
                + pre.Defect_index.ToString() + "," + operstr(pre.Defect_type) + "," + pre.Skip.ToString() + "," + pre.Pos_x.ToString() + "," + pre.Pos_y.ToString() + ")";
            
            NonQuery(que);
            */
            return suc;


        }


        private string operstr(string _str)
        {
            _str = "'" + _str + "'";
            return _str;
        }

        public int getMaxcntr(string _lot, int _iframe)
        {
            string str = "select MAX(defect_index) from \"IM_Defect\" where lot_name = " + operstr(_lot) + "and frame_index = " + _iframe.ToString();

            int icnt = 0;
            using (var conn = new NpgsqlConnection(m_constring))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = str;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                icnt = Convert.ToInt32(reader["MAX"]);
                                //count(defect_index)
                            }
                            reader.Close();

                            conn.Close();
                            return icnt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                 //   MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex.ToString());
                    return 0;
                }
            }
            return 0;
        }



        private bool NonQuery(string _str)
        {

            using (var conn = new NpgsqlConnection(m_constring))
            {


                try
                {
                    conn.Open();

                    // DB INSERT 구문
                    using (var command = new NpgsqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandText = _str;
                        command.ExecuteNonQuery();

                    }
                    conn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }






    }
}
