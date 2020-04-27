using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Graph
    {
        private const int NUMBER = 5000; //能包含的点的数量上限
        private int numPoints = 0;  //当前有多少点
        public int NumPoints    //只读，用于读取当前点的数量
        {
            get
            {
                return numPoints;
            }
        }
        private Point[] vertexes;  //点的集合
        private int[,] adjmatrix;  //邻接矩阵
        public Graph()   //构造函数 初始化
        {
            numPoints = 0;   //初始化点的数量为0
            vertexes = new Point[NUMBER];   
            adjmatrix = new int[NUMBER, NUMBER];
            for(int i=0; i<NUMBER; i++)   // 初始化时所有边的权值都为无穷大
            {
                for(int j=0; j<NUMBER; j++)
                {
                    adjmatrix[i, j] = Util.INFINITE;
                }
            }
        }
        /// <summary>
        /// 增加一个节点
        /// </summary>
        /// <param name="x">点的数据</param>
        /// <returns>若点的数量已满，则返回1表示添加失败；若添加成功则返回0</returns>
        public int AddVertex(int x)
        {
            if(numPoints >= NUMBER)
            {
                return 1;
            }
            vertexes[numPoints++] = new Point(x);
            return 0;
        }
        /// <summary>
        /// 增加一条边
        /// </summary>
        /// <param name="ver1">第一个点</param>
        /// <param name="ver2">第二个点</param>
        /// <param name="weight">权值</param>
        /// <returns>若此边已存在则返回1代表添加失败，若添加成功则返回0</returns>
        public int AddEdge(int ver1, int ver2, int weight)
        {
            if(adjmatrix[ver1,ver2] != Util.INFINITE)
            {
                return 1;
            }
            adjmatrix[ver1, ver2] = weight;
            return 0;
        }
        /// <summary>
        /// 求最短路径
        /// </summary>
        /// <param name="start">起点</param>
        /// <param name="end">终点</param>
        /// <param name="path">从起点到终点的路径 格式为  start->a->b->end </param>
        /// <returns>返回值为cost, -1 为出错</returns>
        public int Dijkstra(int start, int end, out string path)
        {
            path = "";
            if (numPoints <= 0 || start <0 || start >= numPoints || end <0 || end >= numPoints)  //如果当前图中无点或输入值异常，则返回-1
            {
                return -1;
            }
            if(start == end)     //若起点和终点是同一个点，则代价为0
            {
                path = start.ToString();
                return 0;
            }
            int[] distance = new int[numPoints];   // start 到 每一个点的距离
            int[] ppath = new int[numPoints];      // 从start到每个点的最短路径里，到达此点时最后一个经过的点
            bool[] visited = new bool[numPoints];   // 此点是否访问过 F表示未访问 T表示已访问
            
            for(int i=0; i<numPoints; i++)         // 初始化
            {
                distance[i] = adjmatrix[start, i]; //start到每个点的距离
                if(distance[i] < Util.INFINITE)    //默认ppath
                {
                    ppath[i] = start;
                }
                else
                {
                    ppath[i] = -1;
                }
                visited[i] = false;                //默认未访问过
            }
            visited[start] = true;
            for(int i=1; i<numPoints; i++)
            {
                int min = Util.INFINITE;   //找到离start最近的这个点
                int nowNode = 0;
                for(int j=0; j<numPoints; j++)
                {
                    if(!visited[j] && distance[j] < min)
                    {
                        min = distance[j];
                        nowNode = j;
                    }
                }
                visited[nowNode] = true;         //start 距离 j 的最短路径已找到
                if(nowNode == end)
                {
                    break;
                }
                for(int k=0; k<numPoints; k++)         //更新其他点
                {
                    if(!visited[k] && min + adjmatrix[nowNode, k] < distance[k])
                    {
                        distance[k] = min + adjmatrix[nowNode, k];
                        ppath[k] = nowNode;
                    }
                }
            }
            if(distance[end] == Util.INFINITE)
            {
                path = start.ToString();
                return Util.INFINITE;
            }
            int e = end, cost = 0;
            Stack<int> pp = new Stack<int>(); //输出其路径 与 cost
            while(e != start)
            {
                cost = cost + adjmatrix[ppath[e], e];
                pp.Push(ppath[e]);
                e = ppath[e];
            }
            while(pp.Count != 0)
            {
                path = path + pp.Pop().ToString() + "->";
            }
            path = path + end.ToString();
            return cost;
        }
    }
}
