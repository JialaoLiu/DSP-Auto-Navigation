using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ModTranslate
{
    static Dictionary<string, string> enusDict = new Dictionary<string, string>
    {
    //AutoNavigation
        { "驱动引擎等级过低","Thruster Level Too Low" },
        { "机甲能量过低","Mecha Energy Too Low" },
        { "星际自动导航","Auto Navigation" },
        { "星系自动导航","Galaxy Auto Navigation" },
        { "导航模式结束","Navigation Mode Ended" },
    };

    public static string LocalText(this string text)
    {
        return text;
    }
}

