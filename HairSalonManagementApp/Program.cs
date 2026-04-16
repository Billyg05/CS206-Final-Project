namespace HairSalonManagementApp
{
    internal static class Program
    {
        // Main startup: initialize WinForms, load saved data, and open the login form.
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
