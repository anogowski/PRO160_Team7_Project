using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XNAForm
{
    /// <summary>
    /// Author: Iñaki Ayucar (http://graphicdna.blogspot.com)
    /// Date: 14/11/2007
    /// 
    /// This software is distributed "for free" for any non-commercial usage. The software is provided “as-is.” 
    /// You bear the risk of using it. The contributors give no express warranties, guarantees or conditions.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create window and show it
            PlayingForm form = new PlayingForm();
            form.Show();

            // Loop while created
            while (form.Created)
            {
                // If RefreshMode is "always" explicitly call the Render method each pass
                if (form.Refresh_Type == XNAForm.RefreshType.Always)
                    form.render();

                // Let windows do it´s magic
                Application.DoEvents();
            }
        }
    }
}