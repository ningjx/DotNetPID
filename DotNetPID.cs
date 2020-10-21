using System;
using System.Timers;

namespace DotNetPID
{
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

        public float Kp;//比例系数Proportional
        public float Ki;//积分系数Integral
        public float Kd;//微分系数Derivative

        protected float Ek;//当前误差
        protected float Ek1;//前一次误差 e(k-1)
        protected float Ek2;//再前一次误差 e(k-2)

        public float MaxInc;
        public float TargetValue;
        public float ActualValue;

        internal Timer Timer = new Timer { AutoReset = true };

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
        /// 每次计算后触发，别忘了返回反馈值
        /// </summary>
        public event PIDHandller StepEvent;

        protected PID(float kp, float ki, float kd, float maxIncLimit, int freq_ms = 20)
        {
            if (kp <= 0 || ki <= 0 || kd <= 0 || maxIncLimit <= 0 || freq_ms <= 0)
                throw new Exception("参数不能小于等于0");

            Kp = kp; Ki = ki; Kd = kd; MaxInc = maxIncLimit;
            Timer.Interval = freq_ms;
            Timer.Elapsed += PID_Caculate;
        }

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

        internal void ResetErr()
        {
            Ek = Ek1 = Ek2 = 0;
        }

        internal void SetParams(float actual, float target)
        {
            TargetValue = target; ActualValue = actual;
        }

        protected virtual void PID_Caculate(object sender, ElapsedEventArgs e)
        {

        }

        protected float? InvokeTargetAttachEvent(float inc, float inc_per)
        {
            return TargetAttachEvent?.Invoke(inc, inc_per);
        }

        protected float? InvokeStepEvent(float inc, float inc_per)
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

        protected override void PID_Caculate(object sender, ElapsedEventArgs e)
        {
            if (Math.Abs(TargetValue - ActualValue) < 0.01f)
                InvokeTargetAttachEvent(0, 0);

            Ek = TargetValue - ActualValue;

            float pIDInc = Kp * (Ek - Ek1) + Ki * Ek + Kd * (Ek - 2 * Ek1 + Ek2);

            Ek2 = Ek1;
            Ek1 = Ek;

            if (Math.Abs(pIDInc) > MaxInc)
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

        protected override void PID_Caculate(object sender, ElapsedEventArgs e)
        {
            if (Math.Abs(TargetValue - ActualValue) < 0.01f)
                InvokeTargetAttachEvent(0, 0);

            Ek = TargetValue - ActualValue;

            float pIDInc = Kp * (Ek - Ek1) + Ki * Ek + Kd * (Ek - 2 * Ek1 + Ek2);

            Ek2 = Ek1;
            Ek1 = Ek;

            if (Math.Abs(pIDInc) > MaxInc)
                pIDInc = pIDInc < 0 ? -MaxInc : MaxInc;

            ActualValue += pIDInc;

            InvokeStepEvent(ActualValue, 0);
        }
    }

    /// <summary>
    /// 扩展静态类
    /// </summary>
    public static class PID_Ext
    {
        /// <summary>
        /// 启动PID计算
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="actual">实际值</param>
        /// <param name="target">目标值</param>
        public static void Start(this PID pid, float actual, float target)
        {
            pid.SetParams(actual, target);
            pid.Timer.Start();
        }

        /// <summary>
        /// 停止PID计算
        /// </summary>
        /// <param name="pid"></param>
        public static void Stop(this PID pid)
        {
            pid.Timer.Stop();
        }

        /// <summary>
        /// 重启PID计算
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="actual">实际值</param>
        /// <param name="target">目标值</param>
        public static void Restart(this PID pid, float actual, float target)
        {
            pid.Timer.Stop();
            pid.ResetErr();
            pid.SetParams(actual, target);
            pid.Timer.Start();
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
