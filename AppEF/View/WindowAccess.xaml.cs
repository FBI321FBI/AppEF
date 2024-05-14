using AppEF.View;
using EFProject.Context;
using System.Linq;
using System.Windows;

namespace AppEF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WindowAccess : Window
    {
        public WindowAccess()
        {
            InitializeComponent();
        }

        private void bAccess_Click(object sender, RoutedEventArgs e)
        {
            if (AccessUser())
            {
                MessageBox.Show("Access granted");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            } 
            else
                MessageBox.Show("Not found");
        }

        public bool AccessUser()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var users = db.Users.ToList();
                foreach (var user in users)
                    if (user.Name == textBoxLog.Text)
                        if (user.Password == textBoxPass.Text)
                            return true;
                        else
                            return false;
            }
            return false;
        }
    }
}
