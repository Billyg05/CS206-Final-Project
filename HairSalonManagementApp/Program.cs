namespace HairSalonManagementApp
{
    internal static class Program
    {
        // app start
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                SalonDB.Initialize();
                Application.Run(new frmLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The program could not start.\r\n\r\n" + ex.Message, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
