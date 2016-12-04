using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons.Model;

namespace ConsumerWinFormsApp
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
            Application.Run(new Form1());
        }
    }

    public static class Constants
    {
        public static string UserName { get; set; }

        public static void SetCommonValues(this Entity entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.Created = DateTime.Now;
            entity.Modified = DateTime.Now;
            entity.CreatedBy = Constants.UserName;
            entity.ModifiedBy = Constants.UserName;
        }
    }
}
