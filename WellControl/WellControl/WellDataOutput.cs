using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WellControl
{
    /// <summary>
    /// 用来输出未知数据
    /// </summary>
    public class WellDataOutput
    {
        //钻柱数据
        public double ZTCD=0;//钻铤长度（m）
        public double ZTNRJ = 0;//钻铤内容积（L/m）
        public double ZTZNRJ = 0;//钻铤总内容积(L)
        public double ZTSJ = 0;//钻铤时间（min）
        public double ZGCD = 0;//钻杆长度（m）
        public double ZGNRJ = 0;//钻杆内容积（L/m）
        public double ZGZNRJ = 0;//钻杆总内容积（L）
        public double ZGSJ = 0;//钻杆时间（min）
        public double ZZCD = 0;//钻柱长度（m）
        public double ZZNRJ = 0;//钻柱内容积（L/m）（无效）
        public double ZZZNRJ = 0;//钻柱总内容积（L）
        public double ZZSJ = 0;//钻柱时间（min）
        //环空数据
        public double ZTLYCD = 0;//钻铤裸眼长度（m）
        public double ZTLYWRJ = 0;//钻铤裸眼外容积（L/m）
        public double ZTLYZWRJ = 0;//钻铤裸眼总外容积（L）
        public double ZTLYSJ = 0;//钻铤裸眼时间（min）
        public double ZGLYCD = 0;//钻杆裸眼长度（m）
        public double ZGLYWRJ = 0;//钻杆裸眼外容积（L/m）
        public double ZGLYZWRJ = 0;//钻杆裸眼总外容积（L）
        public double ZGLYSJ = 0;//钻杆裸眼时间（min）
        public double ZGTGCD = 0;//钻杆套管长度（m）
        public double ZGTGWRJ = 0;//钻杆套管外容积（L/m）
        public double ZGTGZWRJ = 0;//钻杆套管总外容积（L）
        public double ZGTGSJ = 0;//钻杆套管时间（min）
        public double HKCD = 0;//环空长度（m）
        public double HKWRJ = 0;//环空外容积（L/m）
        public double HKZWRJ = 0;//环空总外容积（L）
        public double HKSJ = 0;//环空时间（min）
        //井眼系数据
        public double JYXZRJ = 0;//井眼系总容积（L）
        public double YJYTJ = 0;//钻井液体积（L）
        public double YJYMD = 0;//压井液密度（g/cm^3）
        public double XHZSJ = 0;//一个循环周时间（min）
        //井涌数据
        public double YLGD = 0;//溢流高度（m）
        public double YLMD = 0;//溢流密度（g/cm^3）
        public string JYLX = "";//井涌类型
        public double DCYL = 0;//地层压力（MPa）
        //立管压力数据
        public double LGCSYL = 0;//立管初始压力（MPa）
        public double LGZZYL = 0;//立管终止压力（MPa）
        //最大套压
        public double ZDTY = 0;//最大套压（MPa）
    }
}
