using System;

namespace HBFrameWork
{
    #region Global Delegate
    public  delegate  void  StateChangeEvent(Object ui, EnumObjectState newState,EnumObjectState oldState);
#endregion
    #region 全局枚举对象
    public enum EnumObjectState
    {
        None,
        Initial,
        Loading,
        Ready,
        Disabled,
        Closing
    }

    public enum EnumUIType
    {
        None = -1,
        ButtonOne = 0,
        ButtonTwo = 1
    }
    #endregion

    public class Defines
    {
        public Defines()
        {

        }
    }
}
