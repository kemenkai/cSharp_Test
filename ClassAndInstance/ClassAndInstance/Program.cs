using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassAndInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            //form form1 = new form();
            //form1.text = "helloworld!";
            //form1.showdialog();

            //有实例，没有引用变量
            //new form();

            //有引用变量，没有引用任何实例
            //form myform;

            //多个引用变量，引用同一个实例
            Form myform1;
            Form myform2;
            myform1 = new Form();
            myform2 = myform1;
            myform1.Text = "HelloWorld2!";
            myform2.ShowDialog();

        }
    }
}
