using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Query
    {
        private int start, end; //起点和重点
        public int Start  //只读
        {
            get { return start; }
        }

        public int End
        {
            get { return end; }
        }
        private bool isfinished;  //是否处理完毕
        public bool isFinished  //只读
        {
            get { return isfinished; }
        }
        private string path;    //路径
        public string Path
        {
            get
            {
                return path;
            }
        }
        private int cost;     // 此路径的消耗
        public int Cost
        {
            get { return cost; }
        }
        public Query(int start, int end)  //构造函数 初始化
        {
            this.start = start;
            this.end = end;
            isfinished = false;
            cost = 0;
            path = "";
        }
        /// <summary>
        /// 完成此任务
        /// </summary>
        /// <param name="cost">此路径的消耗</param>
        /// <param name="path">路径</param>
        /// <returns>false：出错，未完成； true:完成</returns>
        public bool Finish(int cost, string path)
        {
            if (isfinished || path == "" || cost < 0)    //如果已经完成了或参数异常，则错误
            {
                return false;
            }
            isfinished = true;
            if(cost == Util.INFINITE)
            {
                this.path = "";
            }
            else
            {
                this.path = path;
            }
            this.cost = cost;
            return true;
        }
    }
}
