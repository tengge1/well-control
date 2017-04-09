using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WellControl
{
    /// <summary>
    /// 用来传递已知数据
    /// </summary>
    public class WellDataInput
    {
        public double YLSD = 3200;//溢流深度（m）
        public double YLCS = 3200;//溢流测深（m）
        public double JYZJ = 215.9;//井眼直径（mm）
        public double JSTGXS = 2400;//技术套管下深（m）
        public double JSTGNJ = 224.4;//技术套管内径（mm）
        public double GXPLYL = 40.58;//套管鞋处地层破裂压力（MPa）
        public double ZJYMD = 1.25;//钻井液密度（g/cm^3）
        public double ZJYZL = 2.5;//钻井液增量（m^3）
        public double ZTWJ = 177.8;//钻铤外径（mm）
        public double ZTNJ = 71.44;//钻铤内径（mm）
        public double ZTCD = 100;//钻铤长度（m）
        public double ZGWJ = 127;//钻杆外径（mm）
        public double ZGNJ = 108.6;//钻杆内径（mm）
        public double GJTY = 6.5;//关井套压（MPa）
        public double GJLY = 5;//关井立压（MPa）
        public double XHYL = 3.8;//循环压力（MPa）
        public double YJBPL = 10;//压井泵排量（L/s）
        public double CS = 70;//钻井液泵冲数（冲/分）
        public double FJMD = 0.1;//附加密度（g/cm^3)
    }
}
