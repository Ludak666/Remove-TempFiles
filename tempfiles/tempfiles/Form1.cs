namespace tempfiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempfiles = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string username = Environment.UserName;

            string temp = Path.Combine(tempfiles, "Temp");

            string[] files = Directory.GetFiles(temp);
            string[] subfolders = Directory.GetDirectories(temp);

            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Skipped file: " + file + ". Reason: " + ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {

                    Console.WriteLine("Skipped file (Unauthorized Access): " + file + ". Reason: " + ex.Message);
                }
            }

            foreach (string subfolder in subfolders)
            {
                try
                {
                    Directory.Delete(subfolder, true);
                }
                catch (IOException ex)
                {

                    Console.WriteLine("Skipped folder: " + subfolder + ". Reason: " + ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {

                    Console.WriteLine("Skipped folder (Unauthorized Access): " + subfolder + ". Reason: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}