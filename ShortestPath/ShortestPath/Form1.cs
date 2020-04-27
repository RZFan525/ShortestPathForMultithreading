using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ShortestPath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbBufferSize.Text = Util.BufferSize.ToString();
            lbNumThread.Text = Util.NumThreads.ToString();
        }
        delegate void SetItemCallback(ListViewItem item); //其他线程更新UI的委托
        private void tsbStart_Click(object sender, EventArgs e)
        {
            lstQueries.Items.Clear();
            lstThread.Items.Clear();
            lstResult.Items.Clear();
            lbTime.Text = "0ms";
            
            //读取地图信息
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "map.data";//获取地图信息文件路径   
            if (!File.Exists(path)) //若此文件不存在
            {
                MessageBox.Show("无地图信息文件", "错误", MessageBoxButtons.OK);
                return;
            }
            int numPoint, numAdj;
            int [,]map;
            using (StreamReader sr = new StreamReader(path))//从文件读取地图信息
            {
                string num = sr.ReadLine();
                bool isSuccPoint = int.TryParse(num.Split(' ')[0], out numPoint);
                bool isSuccAjd = int.TryParse(num.Split(' ')[1], out numAdj);
                if(!isSuccPoint || !isSuccAjd || numPoint<=0 || numAdj <= 0)
                {
                    MessageBox.Show("地图信息文件错误", "错误", MessageBoxButtons.OK);
                    return;
                }
                map = new int[numAdj, 3];
                for(int i=0; i<numAdj; i++)
                {
                    string adj = sr.ReadLine(); //读取1个边
                    string[] temp = adj.Split(' '); //分解出起点、终点、权值
                    if(temp.Length != 3)
                    {
                        MessageBox.Show("边的信息错误", "错误", MessageBoxButtons.OK);
                        return;
                    }
                    //正确性检查
                    bool isSuccStart = int.TryParse(temp[0], out map[i, 0]);
                    bool isSuccEnd = int.TryParse(temp[1], out map[i, 1]);
                    bool isSuccWeight = int.TryParse(temp[2], out map[i, 2]);
                    if(!isSuccStart || !isSuccEnd || !isSuccWeight || map[i,0]<0 || map[i,0] >=numPoint || map[i,1] < 0 || map[i,1] >= numPoint || map[i,2] <= 0 || map[i,2] > Util.INFINITE)
                    {
                        MessageBox.Show("边的信息错误", "错误", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            //读取需要查询的起点终点信息
            path = System.AppDomain.CurrentDomain.BaseDirectory + "query.data"; //获取query文件路径
            if (!File.Exists(path)) //若此文件不存在
            {
                MessageBox.Show("无查询信息文件", "错误", MessageBoxButtons.OK);
                return;
            }
            int numQuery;  //需要做的任务数
            int[,] data;   //保存起点和终点
            using (StreamReader sr = new StreamReader(path))    //从文件读取query信息
            {
                string num = sr.ReadLine();
                bool isSuccNum = int.TryParse(num, out numQuery);
                if (!isSuccNum || numQuery <= 0)
                {
                    MessageBox.Show("Query文件有误", "错误", MessageBoxButtons.OK);
                    return;
                }
                data = new int[numQuery, 2];
                for(int i=0; i<numQuery; i++)
                {
                    string task = sr.ReadLine();
                    bool isSuccStart = int.TryParse(task.Split(' ')[0], out data[i, 0]);
                    bool isSuccEnd = int.TryParse(task.Split(' ')[1], out data[i, 1]);
                    if(!isSuccStart || !isSuccEnd || data[i,0] <0 || data[i,0] >= numPoint || data[i,1] <0 || data[i,1] >= numPoint)
                    {
                        MessageBox.Show("Query文件有误", "错误", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            /******************************用读入的信息创建Graph和Query**************************************/
            Graph graph = new Graph();   //创建图
            for(int i=0; i<numPoint; i++)     //把节点加进去
            {
                int isSuccessful = graph.AddVertex(i);  
                if(isSuccessful == 1)    //若添加失败
                {
                    MessageBox.Show("节点数量过大", "错误", MessageBoxButtons.OK);
                    return;
                }
            }
            for(int i =0; i<numAdj; i++) // 把边添加进去
            {
                int isSuccessful = graph.AddEdge(map[i, 0], map[i, 1], map[i, 2]);
                if(isSuccessful == 1)    // 添加失败
                {
                    MessageBox.Show("添加了重复边", "错误", MessageBoxButtons.OK);
                    return;
                }
            }

            // 创建query类
            Query[] query = new Query[numQuery];
            for(int i=0; i<numQuery; i++)
            {
                query[i] = new Query(data[i, 0], data[i, 1]);
                ListViewItem item = new ListViewItem();
                item.Text = data[i, 0].ToString();
                item.SubItems.Add(data[i, 1].ToString());
                //lstQueries.Items.Add(data[i, 0].ToString() + "  " + data[i, 1].ToString());
                lstQueries.Items.Add(item);
            }
            DateTime beforeDT = System.DateTime.Now;  //开始计时
            //求最短路径
            for (int i=0; i<numQuery; i++)
            {
                string pathi;
                int cost = graph.Dijkstra(query[i].Start, query[i].End, out pathi);
                query[i].Finish(cost, pathi);
                ListViewItem item = new ListViewItem();
                if(cost == Util.INFINITE)
                {
                    item.Text = "∞";
                }
                else
                {
                    item.Text = cost.ToString();
                    item.SubItems.Add(pathi);
                }
                lstResult.Items.Add(item);
            }
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforeDT);
            lbTime.Text = Math.Round(ts.TotalMilliseconds).ToString() + "ms";
            Util.StoreResult(query);
        }

        private void tsbMulStart_Click(object sender, EventArgs e)
        {
            lstQueries.Items.Clear();
            lstThread.Items.Clear();
            lstResult.Items.Clear();
            lbTime.Text = "0ms";
            
            //读取地图信息
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "map.data";//获取地图信息文件路径   
            if (!File.Exists(path)) //若此文件不存在
            {
                MessageBox.Show("无地图信息文件", "错误", MessageBoxButtons.OK);
                return;
            }
            int numPoint, numAdj;
            int[,] map;
            using (StreamReader sr = new StreamReader(path))//从文件读取地图信息
            {
                string num = sr.ReadLine();
                bool isSuccPoint = int.TryParse(num.Split(' ')[0], out numPoint);
                bool isSuccAjd = int.TryParse(num.Split(' ')[1], out numAdj);
                if (!isSuccPoint || !isSuccAjd || numPoint <= 0 || numAdj <= 0)
                {
                    MessageBox.Show("地图信息文件错误", "错误", MessageBoxButtons.OK);
                    return;
                }
                map = new int[numAdj, 3];
                for (int i = 0; i < numAdj; i++)
                {
                    string adj = sr.ReadLine(); //读取1个边
                    string[] temp = adj.Split(' '); //分解出起点、终点、权值
                    if (temp.Length != 3)
                    {
                        MessageBox.Show("边的信息错误", "错误", MessageBoxButtons.OK);
                        return;
                    }
                    //正确性检查
                    bool isSuccStart = int.TryParse(temp[0], out map[i, 0]);
                    bool isSuccEnd = int.TryParse(temp[1], out map[i, 1]);
                    bool isSuccWeight = int.TryParse(temp[2], out map[i, 2]);
                    if (!isSuccStart || !isSuccEnd || !isSuccWeight || map[i, 0] < 0 || map[i, 0] >= numPoint || map[i, 1] < 0 || map[i, 1] >= numPoint || map[i, 2] <= 0 || map[i, 2] > Util.INFINITE)
                    {
                        MessageBox.Show("边的信息错误", "错误", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            //读取需要查询的起点终点信息
            path = System.AppDomain.CurrentDomain.BaseDirectory + "query.data"; //获取query文件路径
            if (!File.Exists(path)) //若此文件不存在
            {
                MessageBox.Show("无查询信息文件", "错误", MessageBoxButtons.OK);
                return;
            }
            int numQuery;  //需要做的任务数
            int[,] data;   //保存起点和终点
            using (StreamReader sr = new StreamReader(path))    //从文件读取query信息
            {
                string num = sr.ReadLine();
                bool isSuccNum = int.TryParse(num, out numQuery);
                if (!isSuccNum || numQuery <= 0)
                {
                    MessageBox.Show("Query文件有误", "错误", MessageBoxButtons.OK);
                    return;
                }
                data = new int[numQuery, 2];
                for (int i = 0; i < numQuery; i++)
                {
                    string task = sr.ReadLine();
                    bool isSuccStart = int.TryParse(task.Split(' ')[0], out data[i, 0]);
                    bool isSuccEnd = int.TryParse(task.Split(' ')[1], out data[i, 1]);
                    if (!isSuccStart || !isSuccEnd || data[i, 0] < 0 || data[i, 0] >= numPoint || data[i, 1] < 0 || data[i, 1] >= numPoint)
                    {
                        MessageBox.Show("Query文件有误", "错误", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            //创建Graph
            Graph graph = new Graph();   //创建图
            for (int i = 0; i < numPoint; i++)     //把节点加进去
            {
                int isSuccessful = graph.AddVertex(i);
                if (isSuccessful == 1)    //若添加失败
                {
                    MessageBox.Show("节点数量过大", "错误", MessageBoxButtons.OK);
                    return;
                }
            }
            for (int i = 0; i < numAdj; i++) // 把边添加进去
            {
                int isSuccessful = graph.AddEdge(map[i, 0], map[i, 1], map[i, 2]);
                if (isSuccessful == 1)    // 添加失败
                {
                    MessageBox.Show("添加了重复边", "错误", MessageBoxButtons.OK);
                    return;
                }
            }
            // 创建query类
            Query[] query = new Query[numQuery];
            for (int i = 0; i < numQuery; i++)
            {
                query[i] = new Query(data[i, 0], data[i, 1]);
                ListViewItem item = new ListViewItem();
                item.Text = data[i, 0].ToString();
                item.SubItems.Add(data[i, 1].ToString());
                //lstQueries.Items.Add(data[i, 0].ToString() + "  " + data[i, 1].ToString());
                lstQueries.Items.Add(item);
            }
            DateTime beforeDT = System.DateTime.Now;
            //生产者消费者模型
            MulModel mulModel = new MulModel(graph, Util.BufferSize, this);
            Thread[] ComsumerThreads = new Thread[Util.NumThreads];
            for(int i=0; i<ComsumerThreads.Length; i++)      //创建消费者线程
            {
                ComsumerThreads[i] = new Thread(mulModel.consumer);
                ListViewItem item = new ListViewItem();
                item.Text = "Thread " + i.ToString();
                lstThread.Items.Add(item);
                //lstThread.Items.Add("Thread " + i.ToString());
            }
            foreach(var thread in ComsumerThreads)      //启动消费者线程
            {
                thread.Start();
            }
            for(int i=0; i<numQuery; i++)              //生产者生产数据
            {
                mulModel.proceduce(query[i]);
            }
            while (true)                                //检查是否任务完成
            {
                bool isFinished = true;
                foreach(var q in query)
                {
                    if (!q.isFinished)
                    {
                        isFinished = false;
                        break;
                    }
                }
                if (isFinished)
                {
                    break;
                }
                this.Refresh();
            }
            foreach (Thread thread in ComsumerThreads)         //退出所有线程
            {
                thread.Abort();
            }
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforeDT);
            lbTime.Text = Math.Round(ts.TotalMilliseconds).ToString() + "ms";
            Util.StoreResult(query);
        }
        public void SetResultLst(ListViewItem item)
        {
            if (lstResult.InvokeRequired)
            {
                // 解决窗体关闭时出现“访问已释放句柄”异常
                /*while (lstResult.IsHandleCreated == false)
                {
                    if (lstResult.Disposing || lstResult.IsDisposed) return;
                }*/

                SetItemCallback d = new SetItemCallback(setResult);
                lstResult.BeginInvoke(d, new object[] { item });
                //lstResult.Invoke(d, new object[] { str});
            }
            else
            {
                lstResult.Items.Add(item);
            }
        }
        private void setResult(ListViewItem item)
        {
            lstResult.Items.Add(item);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void tsbSetting_Click(object sender, EventArgs e)
        {
            Setting settingform = new Setting();
            settingform.ShowDialog();
            lbBufferSize.Text = Util.BufferSize.ToString();
            lbNumThread.Text = Util.NumThreads.ToString();
        }
    }
}
