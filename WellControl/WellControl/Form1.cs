using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WellControl
{
    /// <summary>
    /// 用来控制对话框界面
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 计算菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuCalc1_Click(object sender, EventArgs e)
        {
            WellDataInput wdi=ReadData();
            WellDataOutput wdo = WellDataCalc.Calc(wdi);
            WriteData(wdo);
        }

        /// <summary>
        /// 从用户界面读取数据
        /// </summary>
        /// <returns></returns>
        private WellDataInput ReadData()
        {
            WellDataInput wdi = new WellDataInput();
            wdi.FJMD = Convert.ToDouble(textBox12.Text);//附加密度
            wdi.GJLY = Convert.ToDouble(textBox9.Text);//关井立压
            wdi.GJTY = Convert.ToDouble(textBox8.Text);//关井套压
            wdi.GXPLYL = Convert.ToDouble(textBox5.Text);//套管鞋破裂压力
            wdi.JSTGXS = Convert.ToDouble(textBox3.Text);//技术套管下深
            wdi.JSTGNJ = Convert.ToDouble(textBox4.Text);//技术套管内径
            wdi.JYZJ = Convert.ToDouble(textBox2.Text);//井眼直径
            wdi.XHYL = Convert.ToDouble(textBox10.Text);//循环压力
            wdi.YJBPL = Convert.ToDouble(textBox11.Text);//压井泵排量
            wdi.YLCS = Convert.ToDouble(textBox1.Text);//溢流测深
            wdi.ZGNJ = Convert.ToDouble(listView1.Items[1].SubItems[2].Text);//钻杆内径
            wdi.ZGWJ = Convert.ToDouble(listView1.Items[1].SubItems[1].Text);//钻杆外径
            wdi.ZJYMD = Convert.ToDouble(textBox7.Text);//钻井液密度
            wdi.ZJYZL = Convert.ToDouble(textBox6.Text);//钻井液增量
            wdi.ZTCD = Convert.ToDouble(listView1.Items[0].SubItems[3].Text);//钻铤长度
            wdi.ZTNJ = Convert.ToDouble(listView1.Items[0].SubItems[2].Text);//钻铤内径
            wdi.ZTWJ = Convert.ToDouble(listView1.Items[0].SubItems[1].Text);//钻铤外径
            wdi.YLSD = Convert.ToDouble(textBox27.Text);//溢流垂深
            return wdi;
        }

        /// <summary>
        /// 向用户界面填写数据
        /// </summary>
        /// <param name="wdo"></param>
        public void WriteData(WellDataOutput wdo)
        {
            //钻铤
            listView2.Items[0].SubItems[1].Text = Convert.ToString(wdo.ZTCD);
            listView2.Items[0].SubItems[2].Text = Convert.ToString(wdo.ZTNRJ);
            listView2.Items[0].SubItems[3].Text = Convert.ToString(wdo.ZTZNRJ);
            listView2.Items[0].SubItems[4].Text = Convert.ToString(wdo.ZTSJ);
            //钻杆
            listView2.Items[1].SubItems[1].Text = Convert.ToString(wdo.ZGCD);
            listView2.Items[1].SubItems[2].Text = Convert.ToString(wdo.ZGNRJ);
            listView2.Items[1].SubItems[3].Text = Convert.ToString(wdo.ZGZNRJ);
            listView2.Items[1].SubItems[4].Text = Convert.ToString(wdo.ZGSJ);
            //钻柱
            listView2.Items[2].SubItems[1].Text = Convert.ToString(wdo.ZZCD);
            //listView2.Items[2].SubItems[2].Text = Convert.ToString(wdo.ZZNRJ);//无效
            listView2.Items[2].SubItems[3].Text = Convert.ToString(wdo.ZZZNRJ);
            listView2.Items[2].SubItems[4].Text = Convert.ToString(wdo.ZZSJ);
            //钻铤裸眼
            listView3.Items[0].SubItems[1].Text = Convert.ToString(wdo.ZTLYCD);
            listView3.Items[0].SubItems[2].Text = Convert.ToString(wdo.ZTLYWRJ);
            listView3.Items[0].SubItems[3].Text = Convert.ToString(wdo.ZTLYZWRJ);
            listView3.Items[0].SubItems[4].Text = Convert.ToString(wdo.ZTLYSJ);
            //钻杆裸眼
            listView3.Items[1].SubItems[1].Text = Convert.ToString(wdo.ZGLYCD);
            listView3.Items[1].SubItems[2].Text = Convert.ToString(wdo.ZGLYWRJ);
            listView3.Items[1].SubItems[3].Text = Convert.ToString(wdo.ZGLYZWRJ);
            listView3.Items[1].SubItems[4].Text = Convert.ToString(wdo.ZGLYSJ);
            //钻杆套管
            listView3.Items[2].SubItems[1].Text = Convert.ToString(wdo.ZGTGCD);
            listView3.Items[2].SubItems[2].Text = Convert.ToString(wdo.ZGTGWRJ);
            listView3.Items[2].SubItems[3].Text = Convert.ToString(wdo.ZGTGZWRJ);
            listView3.Items[2].SubItems[4].Text = Convert.ToString(wdo.ZGTGSJ);
            //环空
            listView3.Items[3].SubItems[1].Text = Convert.ToString(wdo.HKCD);
            //listView3.Items[3].SubItems[2].Text = Convert.ToString(wdo.HKWRJ);//无效
            listView3.Items[3].SubItems[3].Text = Convert.ToString(wdo.HKZWRJ);
            listView3.Items[3].SubItems[4].Text = Convert.ToString(wdo.HKSJ);
            //井眼系
            textBox13.Text = Convert.ToString(wdo.JYXZRJ);
            textBox14.Text = Convert.ToString(wdo.YJYTJ);
            textBox16.Text = Convert.ToString(wdo.YJYMD);
            textBox25.Text = Convert.ToString(wdo.XHZSJ);
            //井涌数据
            textBox15.Text = wdo.JYLX;
            textBox26.Text = Convert.ToString(wdo.DCYL);
            textBox17.Text = Convert.ToString(wdo.YJYMD);
            textBox18.Text = Convert.ToString(wdo.YJYTJ);
            textBox19.Text = Convert.ToString(wdo.ZZSJ);
            textBox20.Text = Convert.ToString(wdo.HKSJ);
            textBox21.Text = Convert.ToString(wdo.XHZSJ);
            textBox22.Text = Convert.ToString(wdo.LGCSYL);
            textBox23.Text = Convert.ToString(wdo.LGZZYL);
            textBox24.Text = Convert.ToString(wdo.ZDTY);
            //绘制压井曲线示意图
            //图表区
            chart2.ChartAreas.Clear();
            ChartArea area2 = new ChartArea("ChartArea2");
            area2.AxisX.Title = "时间（分）";
            area2.AxisX.Minimum = 0;
            area2.AxisY.Title = "立管压力（MPa）";
            area2.AxisY.Minimum = 0;
            chart2.ChartAreas.Add(area2);
            //图标图例
            chart2.Legends.Clear();
            Legend legend2 = new Legend("Legend2");
            chart2.Legends.Add(legend2);
            //图表系列
            chart2.Series.Clear();
            Series item2 = new Series("立压变化");
            item2.ChartType = SeriesChartType.Line;
            item2.ChartArea = "ChartArea2";
            item2.Legend = "Legend2";
            item2.IsValueShownAsLabel = true;
            DataPoint dp21 = new DataPoint(0, wdo.LGCSYL);
            item2.Points.Add(dp21);
            DataPoint dp22 = new DataPoint(wdo.ZZSJ, wdo.LGZZYL);
            item2.Points.Add(dp22);
            DataPoint dp23 = new DataPoint(wdo.XHZSJ, wdo.LGZZYL);
            item2.Points.Add(dp23);
            chart2.Series.Add(item2);
            //司钻法施工工序
            string szf = "司钻法施工工序：\n";
            szf += "  （1）根据关井录取到的资料计算压井所需数据，填写压井施工单，绘制出立管压力控制进度曲线，作为压井施工的依据。\n";
            szf += "  （2）用原钻井液循环排出溢流。\n";
            szf += "  ①缓慢开泵，迅速打开节流阀，调节节流阀使套管压力保持关井套管压力不变，一直保持到达到压井排量。\n";
            szf += "  ②排量达到压井排量时保持不变，调节节流阀使立管压力等于初始循环立管总压力，并在整个循环周保持不变。调节节流阀时，注意压力传递的迟滞现象。液柱压力传递速度大约为300m/s，3000m深的井需要20s才能把节流变化的压力传递到立管压力表上。\n";
            szf += "  ③溢流排完停泵关井，则套管压力等于立管压力。在排溢流的过程中，应配置加重钻井液，准备压井。\n";
            szf += "  （3）用加重钻井液压井，重建井内压力平衡。\n";
            szf += "  ①缓慢开泵，迅速打开节流阀，调节节流阀使套管压力保持关井套管压力不变，直到达到压井排量。\n";
            szf += "  ②排量逐渐达到压井排量保持不变。在加重钻井液从井口到钻头这段时间内，调节节流阀，使控制套压等于关井套压并保持不变，立管压力由初始立管压力逐渐下降到终了立管压力。\n";
            szf += "  ③加重钻井液出钻头返至环空，调节节流阀，控制立管压力等于终了循环立管总压力并保持不变。待加重钻井液返出地面，停泵，关井，此时若套压和立压都为0，则说明压井成功。开井循环，调节钻井液性能，恢复生产。\n";
            szf+="  注意：为保证压井作业的安全，须计算压井过程中最大套压和套管鞋处所能承受的最大压力值，以避免井口压力超过最大允许套压值和压漏地层。";
            richTextBox1.Text = szf;
            //工程师法施工工序
            string gcs = "工程师法施工工序：\n";
            gcs += "  （1）根据关井录取到的资料计算压井所需数据，并填入压井施工单。绘制出立管压力控制进度曲线，配置压井钻井液。加重时要定量测量钻井液的密度，使加重钻井液密度均匀。\n";
            gcs += "  (2)压井操作步骤。\n";
            gcs += "  ①缓慢开泵，迅速打开节流阀，调节节流阀使套压保持关井套压。当泵速达到压井排量时，调节节流阀，使立管压力接近初始循环立管总压力。\n";
            gcs += "  ②在加重钻井液从地面达到钻头的这段时间里，调节节流阀，按立管压力进度曲线来控制立管压力，即由初始立管压力下降到终了立管压力。\n";
            gcs += "  ③继续循环，压井钻井液由钻头水眼返至环形空间。钻井液在环空上返过程中，调节节流阀，使立管压力一直保持终了立管压力不变，直到压井钻井液返出井口。这时停泵关井，立压套压都等于零，说明压井成功。开井循环，附加钻井液密度附加值，恢复正常作业。\n";
            richTextBox2.Text = gcs;
            //提示用户计算完成
            tabControl1.SelectTab(1);
            toolStripStatusLabel1.Text = "计算完成";
        }
        /// <summary>
        /// 关于菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuHelp2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("胜利软件中心", "压井施工工程师");
        }

        /// <summary>
        /// 帮助菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuHelp1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("未找到相关帮助。","压井施工工程师");
        }

        /// <summary>
        /// 设置菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuTool1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂时没有相关设置信息。", "压井施工工程师");
        }

        /// <summary>
        /// 退出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
