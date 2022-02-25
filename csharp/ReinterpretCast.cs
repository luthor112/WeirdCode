using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A(3);
            Console.WriteLine(a.getNum());

            B b = new ReinterpretCast(a).b;
            b.setNum(9);

            Console.WriteLine(a.getNum());

            Console.ReadKey();
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    struct ReinterpretCast
    {
        public ReinterpretCast(A _a)
        {
            b = null;
            a = _a;
        }

        [FieldOffset(0)]
        public A a;

        [FieldOffset(0)]
        public B b;
    }

    class A
    {
        private int num;

        public A(int startNum)
        {
            num = startNum;
        }

        private void setNum(int newNum)
        {
            num = newNum;
        }

        public int getNum()
        {
            return num;
        }
    }

    class B
    {
        private int num;

        public B(int startNum)
        {
            num = startNum;
        }

        public void setNum(int newNum)
        {
            num = newNum;
        }

        public int getNum()
        {
            return num;
        }
    }
}
