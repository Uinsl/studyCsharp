using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAppTest2
{
    internal class myDynamicClass
    {
        public string name= "Lmim8ui myDynamicClass ! ";

        //
        public static string reName(string sName)
        {
            return sName;
        }

        // name 没有实例化也能用吗，为什么可以用？
        // 但是name 不能用于 static函数里
        public string reNameDyn()
        {
            return name;
        }
    }
}
