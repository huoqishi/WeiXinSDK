﻿/*----------------------------------------------------------------
    Copyright (C) 2015 
    
    文件名：SubButton.cs
    文件功能描述：子菜单按钮
    
    修改描述：整理接口
----------------------------------------------------------------*/

using System.Collections.Generic;

namespace ISC.Wei.Xin.PN.Menu
{
    /// <summary>
    /// 子菜单
    /// </summary>
    public class SubButton : BaseButton, IBaseButton
    {
        /// <summary>
        /// 子按钮数组，按钮个数应为2~5个
        /// </summary>
        public List<SingleButton> sub_button { get; set; }

        public SubButton()
        {
            sub_button = new List<SingleButton>();
        }

        public SubButton(string name):this()
        {
            base.name = name;
        }
    }
}
