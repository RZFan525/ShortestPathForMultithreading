using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPath
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            tbNumThread.Text = Util.NumThreads.ToString();
            tbBufferSize.Text = Util.BufferSize.ToString();
        }

        private void tbNumThread_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.KeyChar = (char)0;
            }
        }

        private void tbBufferSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.KeyChar = (char)0;
            }
        }

        private void btConfirm_Click(object sender, EventArgs e) 
        {
            int numThread = int.Parse(tbNumThread.Text);//线程数
            int bufferSize = int.Parse(tbBufferSize.Text); //缓冲区大小
            if(numThread <=0 || bufferSize <= 0)
            {
                MessageBox.Show("线程数与缓冲区大小必须大于0", "错误", MessageBoxButtons.OK);
                return;
            }
            Util.BufferSize = bufferSize;
            Util.NumThreads = numThread;
            MessageBox.Show("修改成功", "成功", MessageBoxButtons.OK);
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
