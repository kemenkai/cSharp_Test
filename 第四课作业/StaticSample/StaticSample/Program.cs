﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaticSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!!");
            Form form = new Form();
            form.Text = "hello!";
            form.ShowDialog();
        }
    }
}
