using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace myAppTest2
{
    //编写一个出入栈的泛型类
    // class 名字跟文件名字 可以 不一样。
    internal class myFristFanXingClass<T>
    {
        // 该数组
        // private obj[] arrayA1;
        private T[] stack;

        // 该数组元素的位置
        private int stackPoint;

        // 该数据？的容量，数组的大小
        private int size;

        // 这是什么用法？myFristFanXingClass 函数名字跟类名一样
        // 构造函数，无返回值，不可return;
        // 
        public myFristFanXingClass(int size)   
        {
            this.size = size;
            this.stack = new T[size]; // 泛型不是可以add吗，所以 T[]  是指 比如 int[10]， 是静态的
            Console.WriteLine("fangxingclass T[] 长度"+this.stack.Length);
            this.stackPoint = -1; // 0开始
        }

        // 入栈
        public void Push(T item) 
        {
            Console.WriteLine($"The Point is {stackPoint}");
            if (stackPoint >= (size-1)) 
            {
                Console.WriteLine("栈 空间 满！");
            }
            else 
            {
                stackPoint++;
                this.stack[stackPoint] = item;
                Console.WriteLine($"The Point++ is {stackPoint}");
            }
        }

        // 这个出栈，数据其实没有出去
        public T Pop()
        {
            T data = this.stack[stackPoint];
            stackPoint--;
            return data;
        }

        // 展示当前数据 
        public void showStack()
        {
            foreach (var item in this.stack)
            {
                Console.WriteLine($"show this stack {item}");
            }
        }

    }
}
