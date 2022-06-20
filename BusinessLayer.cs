using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Utah_Resort_Watch
{
    /// <summary>
    /// class for the users that are pulled out of the local DB
    /// </summary>
    class People
    {
        public string user_name { get; set; }
        public string pass_word { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int age { get; set; }
        public string skill_level { get; set; }

    }

    /// <summary>
    /// class for the reports that are pulled out of the local DB
    /// </summary>
    class Reports
    {
        public static BindingList<Reports> reportList = new BindingList<Reports>();

        public string Report { get; set; }
        public string Date { get; set; }
        public string User { get; set; }
        public string Season { get; set; }

        /// <summary>
        /// constructor for reports
        /// </summary>
        /// <param name="report"></param>
        /// <param name="date"></param>
        /// <param name="user_name"></param>
        /// <param name="season"></param>
        public Reports(string report, string date, string user, string season)
        {
            this.Report = report;
            this.Date = date;
            this.User = user;
            this.Season = season;
        }

        
        /// <summary>
        /// overide the toString for reports so it shows up in the tools
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return User + " : " + Report;
        }
        
    }

    internal class BusinessLayer
    {
        /// <summary>
        /// get reports based on the button that was clicked
        /// </summary>
        /// <param name="buttonName"></param>
        public void getReports(string buttonName)
        {
            try
            {
                buttonName = buttonName.Replace("_", " ");   //replace underscores in names because of XAML space limitation
                DataAccess dataAccess = new DataAccess();

                DataSet ds = new DataSet();
                ds = dataAccess.GetReports(buttonName);

                Reports.reportList.Clear();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)   //itterate through our results table
                {
                    Reports newReport = new Reports(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][3].ToString());

                    Reports.reportList.Add(newReport);  //add the passenger from the database to their flight

                    ResortViewer.resortTable.ItemsSource = Reports.reportList;   //bind new list to the dataGrid

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
 
}
