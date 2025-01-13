using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjektProgram
{
    static class Program
    {
        
        //uygulama için ana giriş noktası

        public static Form1 Form;// Form1 nesnesi burada tanımlanıyor, böylece programın genelinde erişilebilir.

        static void Main()
        {
            Form = new Form1();
            Application.Run(Form);// Uygulamayı çalıştırır ve Form1'i ana form olarak açar.
        }

    }


}
