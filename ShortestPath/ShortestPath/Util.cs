using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShortestPath
{
    static class Util
    {
        public const int INFINITE = 10000;
        public static void StoreResult(Query[] query)   //将结果写入result.txt文件
        {
            int n = query.Length;
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "result.txt";//获取result信息文件路径
            FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);//创建可以覆盖文件
            fs.Seek(0, SeekOrigin.Begin);  
            fs.SetLength(0);    //清空此文件
            StreamWriter sw = new StreamWriter(fs);
            for(int i=0; i<n; i++)
            {
                sw.WriteLine("******************************************************************************");
                string cost = query[i].Cost.ToString();
                if (query[i].Cost == INFINITE)
                {
                    cost = "∞";
                }
                sw.WriteLine("source:{0}   destination:{1}     shortest path cost:{2}", query[i].Start, query[i].End, cost);
                sw.WriteLine(query[i].Path);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public static int NumThreads = 5;
        public static int BufferSize = 5;
    }
}
