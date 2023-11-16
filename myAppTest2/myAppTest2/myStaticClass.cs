using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAppTest2
{
    // 静态类 只能包含 静态成员
    internal static class myStaticClass
    {
        public static string name = "zhangyangtong";

        public static string reName(string sName) 
        { 
            return sName;
        }

    }
}
