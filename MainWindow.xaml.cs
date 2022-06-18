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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Utah_Resort_Watch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ResortViewer RV;
        public static string selectedResort;
        public MainWindow()
        {
            InitializeComponent();
            RV = new ResortViewer();  //initialize the new window
        }
        
        /// <summary>
        /// Opens up the new window that shows the reviews for the resort. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void powderButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender; //get the name of the button
                selectedResort = button.Name.ToString();  //save the contents to the static variable
                RV.Top = this.Top;
                RV.Left = this.Left;
                this.Hide();
                RV.ShowDialog();
                this.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                       
                    
        }
    }
}
