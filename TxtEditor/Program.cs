using System;
using System.Windows.Forms;
using TxtEditorBL;
using MessageService;

namespace TxtEditor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();
            FileManager fileManager = new FileManager();
            MessageServicecl messageServicecl = new MessageServicecl();

            MainPresenter mainPresenter = new MainPresenter(mainForm, fileManager, messageServicecl);

            Application.Run(mainForm);
        }
    }
}
