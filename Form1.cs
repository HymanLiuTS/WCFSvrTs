using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        MyClass mc = new MyClass();
        public Form1()
        {
            InitializeComponent();
            mc.MyEvent += new MyDelegate(OnTimeOut);
        }

        private void OnTimeOut(object sender, EventArgs e)
        {
            this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " TimeOut");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(mc.MonitorTime);
            thread.Start();
        }
    }

    public delegate void MyDelegate(object sender,EventArgs e);

    class MyClass
    {
        /// <summary>
        /// 属性
        /// </summary>
        public string Age { get; set; }

        public char[] Name = new char[10];
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char this[int index]
        {
            get { return Name[index]; }
            set
            {
                Name[index] = value;
            }
        }

        /// <summary>
        /// 事件
        /// </summary>
        public event MyDelegate MyEvent;

        public void MonitorTime()
        {
            while (true)
            {
                //this.MyEvent(this, EventArgs.Empty);//性能好点
                this.MyEvent.Invoke(this, EventArgs.Empty);//性能差点
                Thread.Sleep(5000);
            }
        }


    }
}
