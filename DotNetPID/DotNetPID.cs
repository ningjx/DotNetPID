using System;
using System.Timers;

namespace DotNetPID
{
    /// <summary>
    /// PID For DotNet
    /// </summary>
    public abstract class PID
    {
        /************************************************
        函数名称 ： PID_Inc
        功    能 ： PID增量(Increment)计算
        参    数 ： SetValue ------ 设置值(期望值)
                    ActualValue --- 实际值(反馈值)
        返 回 值 ： PIDInc -------- 本次PID增量(+/-)
        *************************************************/
        /************************************************
        函数名称 ： PID_Pos
        功    能 ： PID位置(Positional)计算
        参    数 ： SetValue ------ 设置值(期望值)
                    ActualValue --- 实际值(反馈值)
        返 回 值 ： PIDInc -------- 本次PID增量(+/-)
        *************************************************/

        /// <summary>
        /// 比例系数Proportional
        /// </summary>
        public float Kp;
        /// <summary>
        /// 积分系数Integral
        /// </summary>
        public float Ki;
        /// <summary>
        ///微分系数Derivative
        /// </summary>
        public float Kd;

        /// <summary>
        /// 最大增量限制
        /// </summary>
        public float MaxInc;
        /// <summary>
        /// 目标值
        /// </summary>
        public float TargetValue;
        /// <summary>
        /// 实际值
        /// </summary>
        public float ActualValue;

        internal float Ek;//当前误差
        internal float Ek1;//前一次误差 e(k-1)
        internal float Ek2;//再前一次误差 e(k-2)
        internal Timer Timer = new Timer { AutoReset = true };//计时器

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">增量值/位置值</param>
        /// <param name="inc_per">增量百分比</param>
        /// <returns></returns>
        public delegate float PIDHandller(float value, float inc_per);

        /// <summary>
        /// 到达目标值触发，返回值无意义
        /// </summary>
        public event PIDHandller TargetAttachEvent;

        /// <summary>
        /// 每次计算后触发，请在函数结尾返回实际值<see cref="ActualValue"/>
        /// </summary>
        public event PIDHandller StepEvent;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="kp">比例系数</param>
        /// <param name="ki">积分系数</param>
        /// <param name="kd">微分系数</param>
        /// <param name="maxIncLimit">增量限制</param>
        /// <param name="freq_ms">计算频率（毫秒）</param>
        internal PID(float kp, float ki, float kd, float maxIncLimit, int freq_ms = 20)
        {
            if (kp <= 0 || ki <= 0 || kd <= 0 || freq_ms <= 0)
                throw new Exception("参数不能小于等于0");

            Kp = kp; Ki = ki; Kd = kd; MaxInc = maxIncLimit;
            Timer.Interval = freq_ms;
            Timer.Elapsed += PID_Caculate;
        }

        /// <summary>
        /// 在不调用<see cref="PID_Ext.Start(PID, float, float)"/>或<see cref="PID_Ext.Restart(PID, float, float)"/>的情况下
        /// 调用该函数，只执行一次PID计算
        /// </summary>
        public void PID_CaculateOnce()
        {
            PID_Caculate(null, null);
        }

        /// <summary>
        /// 创建PID实例
        /// </summary>
        /// <param name="kp">比例</param>
        /// <param name="ki">积分</param>
        /// <param name="kd">微分</param>
        /// <param name="maxIncLimit">单次最大增量限制</param>
        /// <param name="type">PID类型</param>
        /// <param name="freq_ms">计算频率</param>
        public static PID Create(double kp, double ki, double kd, double maxIncLimit, PIDType type, int freq_ms = 20)
        {
            switch (type)
            {
                case PIDType.Increment:
                    return new PID_Inc((float)kp, (float)ki, (float)kd, (float)maxIncLimit, freq_ms);
                case PIDType.Positional:
                    return new PID_Pos((float)kp, (float)ki, (float)kd, (float)maxIncLimit, freq_ms);
            }
            return null;
        }

        /// <summary>
        /// 启动PID计算
        /// </summary>
        /// <param name="actual">实际值</param>
        /// <param name="target">目标值</param>
        public void Start(double actual, double target)
        {
            Timer.Stop();
            Ek = Ek1 = Ek2 = 0;
            TargetValue = (float)target;
            ActualValue = (float)actual;
            Timer.Start();
        }

        /// <summary>
        /// 停止PID计算
        /// </summary>
        public void Stop()
        {
            Timer.Stop();
        }

        /// <summary>
        /// 计算函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal virtual void PID_Caculate(object sender, ElapsedEventArgs e)
        {

        }

        internal float? InvokeTargetAttachEvent(float inc, float inc_per)
        {
            return TargetAttachEvent?.Invoke(inc, inc_per);
        }

        internal float? InvokeStepEvent(float inc, float inc_per)
        {
            return StepEvent?.Invoke(inc, inc_per);
        }
    }

    /// <summary>
    /// 增量型PID
    /// </summary>
    internal class PID_Inc : PID
    {
        internal PID_Inc(float kp, float ki, float kd, float maxIncLimit, int freq_ms) : base(kp, ki, kd, maxIncLimit, freq_ms)
        {

        }

        internal override void PID_Caculate(object sender, ElapsedEventArgs e)
        {
            if (Math.Abs(TargetValue - ActualValue) < 0.00001f)
                InvokeTargetAttachEvent(0, 0);

            Ek = TargetValue - ActualValue;

            float pIDInc = Kp * (Ek - Ek1) + Ki * Ek + Kd * (Ek - 2 * Ek1 + Ek2);

            Ek2 = Ek1;
            Ek1 = Ek;

            if (Math.Abs(pIDInc) > MaxInc && MaxInc != 0)
                pIDInc = pIDInc < 0 ? -MaxInc : MaxInc;

            ActualValue = InvokeStepEvent(pIDInc, pIDInc / MaxInc) ?? TargetValue;
        }
    }

    /// <summary>
    /// 位置型PID
    /// </summary>
    internal class PID_Pos : PID
    {
        internal PID_Pos(float kp, float ki, float kd, float maxIncLimit, int freq_ms = 20) : base(kp, ki, kd, maxIncLimit, freq_ms)
        {

        }

        internal override void PID_Caculate(object sender, ElapsedEventArgs e)
        {
            if (Math.Abs(TargetValue - ActualValue) < 0.00001f)
                InvokeTargetAttachEvent(0, 0);

            Ek = TargetValue - ActualValue;

            float pIDInc = Kp * (Ek - Ek1) + Ki * Ek + Kd * (Ek - 2 * Ek1 + Ek2);

            Ek2 = Ek1;
            Ek1 = Ek;

            if (Math.Abs(pIDInc) > MaxInc && MaxInc != 0)
                pIDInc = pIDInc < 0 ? -MaxInc : MaxInc;

            ActualValue += pIDInc;

            InvokeStepEvent(ActualValue, 0);
        }
    }

    /// <summary>
    /// PID类型
    /// </summary>
    public enum PIDType
    {
        /// <summary>
        /// 增量型
        /// </summary>
        Increment,
        /// <summary>
        /// 位置型
        /// </summary>
        Positional
    }
}
