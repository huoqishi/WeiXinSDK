/*----------------------------------------------------------------
    Copyright (C) 2015
    
    文件名：BaseButton.cs
    文件功能描述：所有菜单按钮基类
----------------------------------------------------------------*/

namespace ISC.Wei.Xin.PN.Menu
{
    public interface IBaseButton
    {
        string name { get; set; }
    }

    /// <summary>
    /// 所有按钮基类
    /// </summary>
    public class BaseButton : IBaseButton
    {
        //public ButtonType type { get; set; }
        /// <summary>
        /// 按钮描述，既按钮名字，不超过16个字节，子菜单不超过40个字节
        /// </summary>
        public string name { get; set; }
    }
}
