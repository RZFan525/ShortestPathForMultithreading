using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ShortestPath
{
    class MulModel
    {
        private Graph graph;           //图
        private Queue<Query> Buffer;          //缓冲区
        private int BufferSize;            //缓冲区大小
        private Semaphore Full;             //表示有数据的缓冲区信号量
        private Semaphore Empty;            //表示空缓冲区信号量
        private Mutex BufferMutex;          //缓冲区锁
        private Mutex FormMutex;            //更新界面锁
        private Form1 MainForm; 
        public MulModel(Graph graph, int BufferSize, Form1 form)
        {
            this.graph = graph;
            this.BufferSize = BufferSize;
            Full = new Semaphore(0, BufferSize);
            Empty = new Semaphore(BufferSize, BufferSize);
            Buffer = new Queue<Query>();
            BufferMutex = new Mutex();
            MainForm = form;
            FormMutex = new Mutex();
        }

        public void proceduce(Query query)
        {
            Empty.WaitOne();    //请求空缓冲区
            BufferMutex.WaitOne();    //请求缓冲区锁
            Buffer.Enqueue(query);   //把数据加入到缓冲区
            BufferMutex.ReleaseMutex();  //释放缓冲区锁
            Full.Release();     //释放一个缓冲区数据
        }

        public void consumer()
        {
            while (true)
            {
                Full.WaitOne();   //请求缓冲区数据
                BufferMutex.WaitOne();  //请求缓冲区锁
                Query q = Buffer.Dequeue();   //从缓冲区拿出数据
                BufferMutex.ReleaseMutex();          //释放缓冲区锁
                Empty.Release();           //释放一个空缓冲区单元
                string path;
                int cost;
                cost = graph.Dijkstra(q.Start, q.End, out path);    //用拿出来的数据求最短路径
                ListViewItem item = new ListViewItem();
                if (cost == Util.INFINITE)
                {
                    item.Text = "∞";
                }
                else
                {
                    item.Text = cost.ToString();
                    item.SubItems.Add(path);
                }
                FormMutex.WaitOne();
                MainForm.SetResultLst(item);
                FormMutex.ReleaseMutex();
                q.Finish(cost, path);
            }
        }
    }
}
