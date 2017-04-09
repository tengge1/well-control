using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WellControl
{
    /// <summary>
    /// 计算压井数据
    /// </summary>
    class WellDataCalc
    {
        //通过输入数据，计算输出数据
        public static WellDataOutput Calc(WellDataInput wdi)
        {
            WellDataOutput wdo = new WellDataOutput();
            //钻铤
            wdo.ZTCD = wdi.ZTCD;
            wdo.ZTNRJ = CalcNRJ(wdi.ZTNJ);
            wdo.ZTZNRJ = CalcZNRJ(wdo.ZTNRJ, wdo.ZTCD);
            wdo.ZTSJ=CalcSJ(wdo.ZTZNRJ,wdi.YJBPL);
            //钻杆
            wdo.ZGCD = wdi.YLCS-wdi.ZTCD;
            wdo.ZGNRJ = CalcNRJ(wdi.ZGNJ);
            wdo.ZGZNRJ = CalcZNRJ(wdo.ZGNRJ, wdo.ZGCD);
            wdo.ZGSJ = CalcSJ(wdo.ZGZNRJ, wdi.YJBPL);
            //钻柱
            wdo.ZZCD = wdi.YLCS;
            wdo.ZZNRJ = 0;
            wdo.ZZZNRJ = wdo.ZTZNRJ+wdo.ZGZNRJ;
            wdo.ZZSJ = wdo.ZTSJ+wdo.ZGSJ;
            //钻铤裸眼
            wdo.ZTLYCD = wdo.ZTCD;
            wdo.ZTLYWRJ = CalcWRJ(wdi.JYZJ,wdi.ZTWJ);
            wdo.ZTLYZWRJ = CalcZWRJ(wdo.ZTLYWRJ,wdo.ZTLYCD);
            wdo.ZTLYSJ = CalcSJ(wdo.ZTLYZWRJ, wdi.YJBPL);
            //钻杆裸眼
            wdo.ZGLYCD = wdi.YLCS-wdo.ZTCD-wdi.JSTGXS;
            wdo.ZGLYWRJ = CalcWRJ(wdi.JYZJ, wdi.ZGWJ);
            wdo.ZGLYZWRJ = CalcZWRJ(wdo.ZGLYWRJ, wdo.ZGLYCD);
            wdo.ZGLYSJ = CalcSJ(wdo.ZGLYZWRJ, wdi.YJBPL);
            //钻杆套管
            wdo.ZGTGCD = wdi.JSTGXS;
            wdo.ZGTGWRJ = CalcWRJ(wdi.JSTGNJ, wdi.ZGWJ);
            wdo.ZGTGZWRJ = CalcZWRJ(wdo.ZGTGWRJ, wdo.ZGTGCD);
            wdo.ZGTGSJ = CalcSJ(wdo.ZGTGZWRJ, wdi.YJBPL);
            //环空
            wdo.HKCD = wdi.YLCS;
            wdo.HKWRJ = 0;
            wdo.HKZWRJ = wdo.ZTLYZWRJ + wdo.ZGLYZWRJ + wdo.ZGTGZWRJ;
            wdo.HKSJ = wdo.ZTLYSJ + wdo.ZGLYSJ + wdo.ZGTGSJ;
            //井眼系
            wdo.JYXZRJ = wdo.ZZZNRJ + wdo.HKZWRJ;
            wdo.YJYTJ = 1.5 * wdo.JYXZRJ;
            wdo.DCYL = 0.00981 * wdi.ZJYMD * wdi.YLSD + wdi.GJLY;
            wdo.YJYMD = 102 * wdo.DCYL / wdi.YLSD + wdi.FJMD;
            wdo.XHZSJ = wdo.ZZSJ + wdo.HKSJ;
            //溢流数据
            if (wdi.ZJYZL<wdo.ZTLYZWRJ)
            {
                wdo.YLGD = wdi.ZJYZL / wdo.ZTLYWRJ;
            } 
            else if(wdi.ZJYZL>wdo.ZTLYZWRJ&&wdi.ZJYZL<wdo.ZTLYZWRJ+wdo.ZGLYZWRJ)
            {
                wdo.YLGD=(wdi.ZJYZL-wdo.ZTLYZWRJ)/wdo.ZGLYWRJ;
            }
            else
            {
                wdo.YLGD=(wdi.ZJYZL-wdo.ZTLYZWRJ-wdo.ZGLYZWRJ)/wdo.ZGTGWRJ;
            }
            wdo.YLMD = wdi.ZJYMD - (wdi.GJTY - wdi.GJLY) / 0.00981 / wdo.YLGD;
            if (wdo.YLMD < 0.36) wdo.JYLX = "天然气溢流";
            else if (wdo.YLMD > 1.07) wdo.JYLX = "盐水溢流";
            else wdo.JYLX = "油溢流";
            //立管压力
            wdo.LGCSYL = wdi.GJLY + wdi.XHYL;
            wdo.LGZZYL = wdi.XHYL * wdo.YJYMD / wdi.ZJYMD;
            //套压
            wdo.ZDTY = wdi.GXPLYL - 0.00981 * wdi.ZJYMD * wdi.YLSD;
            return wdo;
        }

        //计算内容积
        //参数：内径（mm）
        //返回值：内容积（L/m）
        public static double CalcNRJ(double NJ)
        {
            return 0.25*3.1416*(NJ*0.01)*(NJ*0.01)*10;
        }

        //计算总内容积
        //参数：内容积（L/m），长度（m）
        //返回值：总内容积（L）
        public static double CalcZNRJ(double NRJ,double L)
        {
            return NRJ*L;
        }

        //计算时间
        //参数：总内容积（L），排量（L/s）
        //返回值：时间（分）
        public static double CalcSJ(double ZNRJ,double PL)
        {
            return ZNRJ/PL/60;
        }

        //计算外容积
        //参数：外圆柱内径（mm），内圆柱外径（mm）
        //返回值：外容积（L/m）
        public static double CalcWRJ(double NJ,double WJ)
        {
            return 0.25*3.1416*((NJ*0.01)*(NJ*0.01)-(WJ*0.01)*(WJ*0.01))*10;
        }

        /// <summary>
        /// 计算总外容积
        /// </summary>
        /// <param name="WRJ">外容积（L/m）</param>
        /// <param name="L">长度（m）</param>
        /// <returns>总外容积（L）</returns>
        public static double CalcZWRJ(double WRJ,double L)
        {
            return WRJ*L;
        }
    }
}
