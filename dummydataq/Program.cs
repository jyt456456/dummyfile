/*
DirectoryInfo di = new DirectoryInfo("C:\\Users\\taeya\\OneDrive\\바탕 화면\\2번안\\1번줄_2");
List<string> fullpath = new List<string>();
List<string> Thickless = new List<string>();

foreach(FileInfo file in di.GetFiles())
{
    fullpath.Add(file.FullName);

}

for(int j=0; j<fullpath.Count; ++j)
{
    string[] textvalue = System.IO.File.ReadAllLines(fullpath[j]);
    if (textvalue.Length > 0)
    {
        Thickless.Add(textvalue[2]);
    }
}



for(int i = 0; i<Thickless.Count; ++i)
{
    Console.WriteLine(Thickless[i]);
}
*/
using dummydataq;
using System.ComponentModel.Design;

postsql postsql = new postsql();
randomFunc rand = new randomFunc();
List<string> listLot = new List<string>();
List<string> listType = new List<string>();

listLot.Add("LOTAAA");
listLot.Add("LOTAAB");
listLot.Add("LOTAAC");
listLot.Add("LOTAAD");
listLot.Add("LOTAAE");
listLot.Add("LOTAAF");
listLot.Add("LOTABA");
listLot.Add("LOTABB");
listLot.Add("LOTABC");
listLot.Add("LOTABD");
listLot.Add("LOTABE");
listLot.Add("LOTABF");
listType.Add("one");
listType.Add("two");
listType.Add("three");
listType.Add("four");
listType.Add("five");
listType.Add("six");

IniClass.IniC cini = new IniClass.IniC("setting.ini");
int max = int.Parse(cini.GetIni("Thread", "MAX"));
int Lot = int.Parse(cini.GetIni("Random", "LOT"));
int frame = int.Parse(cini.GetIni("Random", "Frame"));

int temp = 16;
if((0x16 & temp) == 0x16)
{
    int asdb;
    Console.WriteLine("12");
}

while (false)
{

    //LOT종류 LIst담기
    ///defecttype구조체
    ///frameindex - 1~5 범위
    /// type, frame 정해지면 maxcnt 가져와서 +1
    /// 없으면 index 1
    /// pos_x, posy -> 0~41사이 random double
    /// 
    int lotindex = 0;
    if (Lot <0)
    {
         lotindex = rand.randint(0, listLot.Count - 1);
    }
    else
    {
        lotindex = Lot;
    }
    int frameindex = 0;
    if(frame < 1)
    {
        frameindex = rand.randint(1, 5);
    }
    else
    {
        frameindex = frame;
    }
    
    
    int type = rand.randint(0,6);
    int wait = rand.randint(1, max);

    global.im_defect def = new global.im_defect();
    def.Lot_name = listLot[lotindex];
    def.Defect_type = listType[type];
    def.Module_index = 1;
    def.Frame_index = frameindex;
    def.Pos_x = Math.Round(rand.randouble(),2);
    def.Pos_y = Math.Round(rand.randouble(),2);
    
    // type,frame-> maxcnt +1
    //def.Defect_index = 
    ///
    def.Defect_index = postsql.getMaxcntr(def.Lot_name, def.Frame_index) + 1;
    Console.Write(def.Defect_type);
    Console.WriteLine(def.Defect_index.ToString());
    
    postsql.CreateDefect(def);
    //  postsql.CreateDefect()



    Thread.Sleep(wait);
    //   

}


