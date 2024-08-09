using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game8
{
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
            var form = new AccountListF();
            form.Show();
            Application.Run();
            
        }
        static Task ViewFormAsync()
        {
            try
            {
                var form = Application.OpenForms["AccountListF"];
                Thread th = new Thread(new ThreadStart(delegate {
                    try
                    {
                        if (form == null)
                        {
                            form = new AccountListF();
                            form.Show();

                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
                    }
                }));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
            }
            return Task.CompletedTask;
        }
    }
}
