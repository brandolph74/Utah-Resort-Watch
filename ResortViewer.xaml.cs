using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Utah_Resort_Watch
{
    /// <summary>
    /// Interaction logic for ResortViewer.xaml
    /// </summary>
    public partial class ResortViewer : Window
    {
        public ResortViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// go back to the previous window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Button button = (Button)sender; //get the name of the button
                //selectedResort = button.Name.ToString();  //save the contents to the static variable
                //RV.Top = this.Top;
                //RV.Left = this.Left;
                this.Hide();
                //RV.ShowDialog();

                //testing
                DataAccess db = new DataAccess();
                string username = "indigowd";
                string query = $"SELECT user_name FROM People";
                int returnVal = 0;
                db.ExecuteSQLStatement(query, ref returnVal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
