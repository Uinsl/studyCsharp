using System;
using System.Collections;
using System.Collections.Generic;
//
using System.Data.SqlTypes;
//
using MySql.Data.MySqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//  特性反射 

//OK :  委托事件 task信号源  泛型数组 类get&&set(方法重载)
//OK :  继承->多态&&接口&&抽象（比较基础，部分截图在外）
//OK：LINQ 连接数据操作

// 命名空间 - 大范围上区别类名，防止类名重复
// 同一命名空间 比如 myFanXingClass.cs 文件里 namespace myAppTest2
// 可以直接用 该命名空间的类
// 不同命名空间，例如，dog.cs 的 namespace mySpaceTest 
//  要像这样使用 mingMingTest.student myStudent = new mingMingTest.student();
// mySpaceTest.Dog t21= new mySpaceTest.Dog(); 
// 很麻烦 ==》 using mySpaceTest

using mingMingTest;
// 如果 class 同名，命名空间不同名呢？
// 优先使用同命名空间下的calss
namespace mingMingTest
{
    class student  {
        public student()
        {
            Console.WriteLine("namespace mingMingTest");
        }
        public int id { get; set; }

    }
}

namespace myAppTest2
{
    // 委托
    public delegate void myHi(string content);
    internal class Program
    {

        // 事件 不能像委托 那样 (string content); 随意填形参
        public static event myHi myEventHi;
        //
        static void Main(string[] args)
        {
            Console.WriteLine("myFristApp");
            Console.WriteLine($"Now Time is : {DateTime.Now.ToLongTimeString()}\n");
            //getsetTest();

            //myTask11();
            //myTask10();
            //myTask3();
            //myTask5();
            // myTask22();
            //myTask8();

            // myStatic();
            // myDelegate();
            // arrList();
            // myArray();
            // myStackTest();

            //jichengTest();
            //linqTest();
            mysql1();
            // CMD 按键结束
            Console.ReadKey();
        }

        // mysql数据库
        public static void mysql1()
        {
            var builder = new MySqlConnectionStringBuilder();
            builder.Server = "127.0.0.1"; //ip地址
            builder.Port = 3306;
            builder.UserID = "root";
            builder.Password = "root";
            builder.Database = "test"; //数据库名字

            var connect = new MySqlConnection(builder.ConnectionString);

            connect.Open();

            //var cmd = "Show Databases";
            var cmd = "select * from student";

            var reader = new MySqlCommand(cmd, connect).ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]},{reader[1]}" );
            }   

            reader.Close();
        }

        // LINQ 运算符 太多了
        public static void linqTest()
        {
            List<myStudent> studentList = new List<myStudent>()
            {
                new myStudent() {ID=1,Name="Tom",Age=10},
                new myStudent() {ID=2,Name="Sun",Age=24},
                new myStudent() {ID=3,Name="Cop",Age=19},
                new myStudent() {ID=4,Name="004",Age=42},
                new myStudent() {ID=5,Name="005",Age=16},
                new myStudent() {ID=6,Name="006",Age=13},
                new myStudent() {ID=7,Name="006",Age=35}
            };

            // 限定{ }之内局部变量的作用域，getHours只能在{ }内被访问
            {
                foreach (var item in studentList)
                {
                    if (item.Age <= 20) 
                    {
                        Console.WriteLine($"ID= {item.ID} , MINGZI = {item.Name} , AGE = {item.Age} ");
                    }
                }
            }

            {
                Console.WriteLine("---------------------LINQ LANMUDA----------------");
                var list = studentList
                                .Where(a => (a.Age <= 20))
                                .OrderBy(a => a.Age);
                foreach (var item in list)
                {
                    Console.WriteLine($"ID= {item.ID} , MINGZI = {item.Name} , AGE = {item.Age} ");
                }

            }

            {
                Console.WriteLine("---------------------LINQ----------------");
                var list = from s in studentList
                           where s.Age <= 20
                           orderby s.Age //orderby 排序 
                           select s;
                foreach (var item in list)
                {
                    Console.WriteLine($"ID= {item.ID} , MINGZI = {item.Name} , AGE = {item.Age} ");
                }
            }

        }
        //LINQ query
        public static void linqQuery()
        {

        }




        // 继承->多态&&接口&&抽象
        // 继承里，实例化子类，先调用父类的构造，然后调用子类构造
        // pet 
        class Pet
        {
            public string name;
            public int age = 30;
            // 不想让外界修改 maofa 值，让继承可以访问
            // private-》protected
            // private int maofa = 99;
            protected int maofa = 99;

            public void speak()
            {
                Console.WriteLine($"{this.name} mao jiao;");
            }

            public Pet(int age) { 
            
            }
        }

        class Cat:Pet 
        { 
            // 继承构造函数
            public Cat() : base(30) { 
            
            }
            public int Maofa { get; set; }
            // 覆盖父类
            new public int age = 10;
            // 覆盖父类方法，同理还有方法重载
            new public void speak() {
                // 调用父类同名方法
                base.speak();
                Console.WriteLine($"{this.name} mao jiao;");
            }

            public void showAge()
            {
                Console.WriteLine($"new zilei age is {this.age}");
                // 访问父类
                Console.WriteLine($"new fulei age is {base.age}");

            }
        }

        public static void jichengTest()
        { 
            Cat c = new Cat();
            c.name = "Test";
            c.speak();

            //Pet t1 = new Pet();
            // t1.maofa = 999;
            Cat t2 = new Cat();
            t2.Maofa = 999;

            Console.WriteLine($"new zilei  private Maofa is {t2.Maofa}");
        }





        // 类get&&set -》 方法重载
        // get && set https://www.bilibili.com/video/BV1Ph4y1W7Ge

        class student
        {
            //
           // mingMingTest.student myStudent = new mingMingTest.student();

            public int id;
            public string name;
            public int age;
            private string cosName;

            // get set 服务与 private 
            public string cosNameQQQ
            {
                get { return cosName; }
                //set { name = value; }
                set { 
                    if(value == null)
                    {
                        Console.WriteLine("cosName 不能 为空 ");
                        return;
                    }
                    cosName = value; 
                }
            }

            // get 
            public string getcosName1()
            {
                return cosName;
            }
            //set 不用static吗???
            public void setcosName1(string ool)
            {
                this.cosName = ool;
            }

            // 构造函数，无返回值，不可return;
            // only自动调用，每次生成对象都会被调用
            // 构造函数跟泛型里的    internal class myFristFanXingClass<T> 的 <t> 区别
            public student() {
                Console.WriteLine("namespace myAppTest2");
            }

            // 方法重载
            // student s = new student("Tomas",99); OK
            // student s = new student("Tomas",99);
            public student(string name,int age1)
            {
                
                this.name = name;
                this.age = age1;
                Console.WriteLine($"构造函数 Create Student ,name = {this.name}, age = {this.age}");
            }

            //方法重载
            public static int add(int a, int b) { return a + b;  }
            public static double add(double a, double b) { return a + b; }
            public static int add(int a, int b,int c) { return a + b + c; }
        }


        public static void getsetTest()
        {
            //
            //student s = new student();
            //student s = new student("Tomas", 99);
            //s.setcosName1("Cluys");
            //s.cosNameQQQ = "CCCP";
            //Console.WriteLine($"s cosNmae = {s.cosNameQQQ}");

            // namespace 的 test
            //
            student s11 = new student();
        }





        private static void Program_myEventHi(string content)
        {
            Console.WriteLine($"nihao hellll ！ Element={content}");
            //throw new NotImplementedException();
        }


        //委托&&& 事件-×
        public static void myDelegate() {
            //
           //  myHi sty =new myHi(sayHi);

            myHi sty = sayHi;
            // 委托链条
            sty += sayBye;
            sty -= sayBye;

            sty("myDelegate Test *****************");

            //事件
            // += 注册事件 按tab键
            myEventHi += Program_myEventHi;

            if (myEventHi != null) 
            {
                myEventHi("LAO WANG");
            }

            
        }

        public static void sayHi(string str1) 
        {

            Console.WriteLine($"nihao hellll ！ Element={str1}");
        }


        public static void sayBye(string str1)
        {
            Console.WriteLine($"sayBye ！ Element={str1}");
        }



        //CMD 命令
        public static void cmdCommand() 
        {
            // CMD 输入
            string input = Console.ReadLine();
             int sum = mySum(2, 5);
            // CMD 输出
            Console.WriteLine("input 内容:{0},sum : {1}",input, sum);

            // CMD 按键结束
            // Console.ReadKey();
        }

        // public string _name;//类字段
        // public int[] myArrTe = { 12, 13, 14, 15, 46, 17 }; //属性-成员
        // public string name = "Lmim8ui myDynamicClass ! ";
        /* C# 基础 set get 要看看
        private int _age;
        public int Age
        {
            get{return _age;}
            set{_age = value;}
        }
         */

        // 静态 非静态
        // myArrTe name 不能用于 static 函数中
        public static void myStatic() 
        {
            // 
            Console.WriteLine(myStaticClass.reName("Lisay myStaticClass"));
            //
            Console.WriteLine(myDynamicClass.reName("Lisay myDynamicClass"));
            //
            myDynamicClass t1 = new myDynamicClass();
            Console.WriteLine(t1.reNameDyn());
            /*
            // Console.WriteLine(name);
            // 猜想 
            foreach (int j in myArrTe)
            {
                //Console.WriteLine($"Element={j}");
            }
            */
        }

        //int[] arrya List<T> 
        // list<t> 的诞生，因为arrayList不安全，可以Add(1); .Add("老油条"); 数据类型不同
        public static void arrList()
        {
            ArrayList listA = new ArrayList();
            listA.Add(1);
            listA.Add("老油条");

            List<int> ageListf = new List<int>() {9,0,50,8 };
            ageListf.Add(1);
            // ageListf.Add("6054656");
            foreach (int j in ageListf)
            {
                Console.WriteLine($"Element={j}");
            }

        }

        public static void myStackTest()
        {
            //
            myFristFanXingClass<string> stack2 = new myFristFanXingClass<string>(4);
            stack2.Push("mxxopp 0");
            stack2.Push("mxxopp 1");
            stack2.Push("mxxopp 2");
            stack2.Push("mxxopp 3");

            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Pop());
       
            //怎么展示这个类里面的数据
            stack2.showStack();


        }


        // 静态数组 范式
        public static void myArray()
        {

            // n 是一个带有 10 个整数的数组
            int[] na = new int[10]; 
            na[1] = 5929; //n1赋值

            int[] ba = { 90, 8, 2, 6, 346, 86, 674, 43, 788, 66 };

            //ba.Intersect(0,88888);
            // 不能插入，因为是静态，只能只能读取和修改元素
            /*
            // 如果想实现，可以add，del，请用List<string> listArr = new List<string>(); 也就是范式
            // 静态，从程序开始，分配内存，一直存在
            */

            /*
            double[] balance = new double[10];
            balance[0] = 4500.0;

            double[] balance = { 2340.0, 4523.69, 3421.0};

            int [] marks = new int[5]  { 99,  98, 92, 97, 95};

            int [] marks = new int[]  { 99,  98, 92, 97, 95};

             */
            int[] n = new int[5];
            n[4] = 9999;

            foreach (int j in n)
            {
                Console.WriteLine($"Element={j}");
            }

        }

        // static 帮忙把这个方法实例化
        public static int  mySum(int a,int b)
        {
            return a + b;
        }

        //Thread
        public static void myThread1()
        {
            //Task.Run(p1,p2);
            Thread t1 = new Thread(pl);
            t1.Name = "Thread 1_1";
            t1.Start();

            Thread t2 = new Thread(pl);
            t2.Name = "Thread 2_2";
            t2.Start();

            Console.Read();
        }

        // Task使用
        public static void myTask10()
        {
            Task t1 = new Task(p1);
            t1.Start();

            //
            Task t2 = new Task(p2);
            t2.Start();
            // 1、 阻塞 等待 ，结果：t1 t2 同时开始，t1 && t2 结束 继续主程序
            // t1.Wait();
            // t2.Wait();

            // 2、结果：t1 t2 同时开始，t1 && t2 结束 继续主程序
            Task.WaitAll(t1, t2);

            // 3、Task.WhenAll(tList).ContinueWith();
            Console.WriteLine($"Now myTask10 Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");

        }

        public static void myTask11()
        {
            Task t1 = Task.Run(p2);

            //
            Task t2 = Task.Run(p1);
            Task.WhenAll().ContinueWith(task3 => {
                Console.WriteLine($"Now 11task3 Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
            });
        }

        public static void myTask12()
        {
            // ThreadPool
            Task t1 = Task.Factory.StartNew(p1);
        }


        public static void myTask2()
        {

            // Console.WriteLine($"Now Time is : {DateTime.Now.ToLongTimeString()}");
            // 等待p1 然后
            //await Task.Run(p1);
            //await Task.Run(p2);

            // 缺少C# 数组 泛式 用法 熟练度
            // 个人想法， t1= Task.Run(p1); t2=Task.Run(p2); List ts = {t1,t2}; List<Task> ts = {t1,t2 }; 
            // List<Task> ts =new List<Task> { Task.Run(p1) , Task.Run(p2) };
            Task t1 = Task.Run(p1);
            Task t2 = Task.Run(p2);
            List<Task> tList = new List<Task> { t1 };
            tList.Add(t2);

            // Task.WaitAll(tList);// 等待tlist执行完毕

            // tList 里同时执行，然后完毕后执行 conwit里的线程 task3 
            Task.WhenAll(tList).ContinueWith(task3 => {
                Console.WriteLine($"Now Task Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
            });
        }

        public static void myTask22()
        {
            Task t1 = new Task(p1);
            Task t2 = new Task(p2);
            List<Task> tList = new List<Task> { t1 };
            tList.Add(t2);

            // Task.WaitAll(tList);// 等待tlist执行完毕

            // tList 里同时执行，然后完毕后执行 conwit里的线程 task3 
            Task.WhenAll(tList).ContinueWith(task3 => {
                Console.WriteLine($"Now Task Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
            });

            // CMD 不动，代码没问题，，细节有问题
        }

        // 大线程里包括小线程
        public static void myTask3() 
        { 
            Task pTask = new Task(() => {
                Task t1 = new Task(p1,TaskCreationOptions.AttachedToParent);
                Task t2 = new Task(p2, TaskCreationOptions.AttachedToParent);
                t1.Start() ;
                t2.Start();
            });
            pTask.Start();
            pTask.Wait();
            Console.WriteLine($"Now pTask Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
        }

        //长时间
        public static void myTask4() 
        {
            Task t1 = new Task(p1, TaskCreationOptions.LongRunning);
            t1.Start();

        }

        //信号源取消，信号源怎么跨代码处理
        public static void myTask5()
        {
            // Factory  pool和普通 Task 有什么区别
            CancellationTokenSource sts = new CancellationTokenSource();
            Task t1 = Task.Factory.StartNew(() => {
                while (!sts.IsCancellationRequested) {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Now Factory Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
                }
            },sts.Token);

            //委托是什么玩意
            // sts.Token 触发时候 ，执行
            sts.Token.Register(() => {
                Console.WriteLine($"1 Register Now pTask Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
                Thread.Sleep(2000);
                Console.WriteLine($"2 Register Now pTask Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
            });

            Thread.Sleep(5000);
            sts.Cancel();

            // 
        }

        //Task 延时自带取消，例子，请求一个远程接口，长时间不返回数据，取消
        public static void myTask6() {

            CancellationTokenSource sts = new CancellationTokenSource();
            Task t1 = Task.Factory.StartNew(() => {
                while (!sts.IsCancellationRequested)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Now Factory Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
                }
            }, sts.Token);

            sts.Token.Register(() => {
                Console.WriteLine($"1 Register Now pTask Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
                Thread.Sleep(2000);
                Console.WriteLine($"2 Register Now pTask Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
            });

            // 3s 后自带取消
            sts.CancelAfter(3000);
            //  CancellationTokenSource sts = new CancellationTokenSource(3000);
        }

        //Task 异常 处理
        public static void myTask7()
        {

        }

        // lock
        public static int nums = 0;
        private static object myLock = new object();
        public static void myTask8() {
            for (int i = 0; i < 5; i++) {
                Task.Run(testP3);
            }
        }

        public static void testP3() {
            for (int i = 0; i < 50 ; i++) {
                lock (myLock) {
                    nums++;
                    //Console.WriteLine($"Now testP3 Id ={Thread.CurrentThread.ManagedThreadId} , Now Num is : {nums}");
                }
                // 数字顺序是乱的 但是没有重复 也就说确实锁了nums 
               Console.WriteLine($"Now testP3 Id ={Thread.CurrentThread.ManagedThreadId} , Now Num is : {nums}");
            }
        }

            public static void p1()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Now p1 Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
        }

        public static void p2()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"Now p2 Id ={Thread.CurrentThread.ManagedThreadId} , Now Time is : {DateTime.Now.ToLongTimeString()}");
        }

        public static void pl()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " : " + i);
            }
        }

    }
}
