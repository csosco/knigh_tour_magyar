using System;
using System.Windows.Forms;

namespace Csikó
{
    static class start
    {
        // Program belépési pont!!!!
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();  //Vizualizáció engedélyezése  -->Automatikusan generálva Csiko_Form-hoz
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Csiko_Form());
        }
    }
}
