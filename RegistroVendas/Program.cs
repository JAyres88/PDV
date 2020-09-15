using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using BLL;
using Model;

namespace RegistroVendas
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginBLL logBll = new LoginBLL();
            FormLogin flogin = new FormLogin();

            flogin.DialogResult = DialogResult.Ignore;

            while(flogin.DialogResult == DialogResult.Ignore)
            {
                flogin.toolStripStatusLabel1.Text = logBll.Base();
                flogin.ShowDialog();             

                if (flogin.DialogResult == DialogResult.Abort)
                {
                    flogin.Close();
                    Application.Exit();

                }else if(flogin.DialogResult==DialogResult.OK){
                    Application.Run(new FormMain());
                }                       
            }                                    
        }
    }
}
