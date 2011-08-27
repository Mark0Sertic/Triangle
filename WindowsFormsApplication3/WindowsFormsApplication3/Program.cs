using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;



namespace WindowsFormsApplication3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Form1 our_dx_form = new Form1())
            {
                our_dx_form.InstalizeDevice();
                our_dx_form.CammeraPositioning();
                our_dx_form.InstalizingKeyboard();
                our_dx_form.VertexDeclaration();
        
                Application.Run(our_dx_form);
            }
        }
    }
}
