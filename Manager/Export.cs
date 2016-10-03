using System;
using System.IO;
using System.Globalization;
using System.Text;

namespace TLog.Manager
{
    class ExportException : Exception
    {
        public ExportException(string msg) : base (msg) { }
    }

    class Export
    {
        private static string TEMPLATE_FOLDER = "templates";

        public static string exportHours(Users.StudentWorker Student, Schedule.Shift payPeriod)
        {
            if (!File.Exists(TEMPLATE_FOLDER + "\\" + "monthly_sheet.html"))
                throw new ExportException("Monthly template file does not exist!");

            string[] templateLines;
            try
            {
                templateLines = File.ReadAllLines(TEMPLATE_FOLDER + "\\" + "monthly_sheet.html");
            }

            catch (Exception E)
            {
                throw new ExportException("Could not open template file - " + E.Message);
            }

            var sb = new StringBuilder(String.Join(Environment.NewLine, templateLines));

            // YAY FUN HARDCODED PEDANTIC STUFF!
            sb.Replace("{STUDENT_NAME}", Student.ToString());
            sb.Replace("{STUDENT_ID}", Student.ID.ToString());
            sb.Replace("{PAY_PERIOD}", payPeriod.shiftStart.ToString("MM/dd/yy") + " - " + payPeriod.shiftEnd.ToString("MM/dd/yy"));
            sb.Replace("{DEPARTMENT}", "Career Services - Student Worker");

            DateTime weekLabel = new DateTime(payPeriod.shiftStart.Year, payPeriod.shiftStart.Month, payPeriod.shiftStart.Day, 0, 0, 0);
            DateTime shiftEnd = new DateTime(payPeriod.shiftEnd.Year, payPeriod.shiftEnd.Month, payPeriod.shiftEnd.Day, 23, 59, 59);
            DateTime weekStart = new DateTime(payPeriod.shiftStart.Year, payPeriod.shiftStart.Month, 1, 0, 0, 0);
            weekStart = weekStart.AddDays(((int)DayOfWeek.Monday - (int)weekStart.DayOfWeek));

            double payPeriodTotalHours = 0;
            double weeklyHours = 0;

            for (int i = 1; i < 6; i++)
            {
             
                sb.Replace("{WEEK_" + i + "}", weekStart.Month + "/" + weekStart.Day);
                weekStart = weekStart.AddDays(7);
               
                Schedule.WorkWeek curWeek = null;
                Student.weeksWorked.TryGetValue(Schedule.WorkWeek.workWeekID(weekLabel), out curWeek);
                weekLabel = weekLabel.AddDays(7);

                int j = 1;
                if ((int)weekLabel.DayOfWeek != 1 && i == 1)
                    j = (int)weekLabel.DayOfWeek;

                if (j > 1)
                    for (int k = 1; k < j; k++)
                        sb.Replace(String.Format("{{{0}_{1}}}", ((DayOfWeek)(k)).ToString().ToUpper(), i), "");
  
                for (; j < 6; j++)
                {
                    if (curWeek == null)
                    {
                        var test = (String.Format("{{{0}_{1}}}", ((DayOfWeek)(j)).ToString().ToUpper(), i));
                        sb.Replace(test, "");
                    }
                    else
                    {
                        var curDay = curWeek.shiftsOnDay((DayOfWeek)j);
                        if (curDay.Count == 0 || curDay[0].shiftStart > shiftEnd /* weekLabel.AddDays(-7).AddDays(j) > shiftEnd*/)
                            sb.Replace(String.Format("{{{0}_{1}}}", ((DayOfWeek)(j)).ToString().ToUpper(), i), "");
                        else
                        {
                            StringBuilder dayBuild = new StringBuilder();
                            foreach (Schedule.Shift s in curDay)
                            {
                                dayBuild.Append(s.shiftStart.ToString("h:mmt").ToLower() + " - " + s.shiftEnd.ToString("h:mmt").ToLower() + "<br/>");
                                weeklyHours += s.timeWorked.TotalHours;
                            }
                            sb.Replace(String.Format("{{{0}_{1}}}", ((DayOfWeek)(j)).ToString().ToUpper(), i), dayBuild.ToString());
                        }
                    }
                }

                if (curWeek != null)
                {
                    sb.Replace("{TOTAL_" + i + "}", Math.Round(weeklyHours, 1).ToString());
                    payPeriodTotalHours += weeklyHours;
                    weeklyHours = 0;
                }
                else
                    sb.Replace("{TOTAL_" + i + "}", "0");
            }
            sb.Replace("{TOT_HRS}", Math.Round(payPeriodTotalHours, 2).ToString());

            string fileName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(payPeriod.shiftStart.Month) + "_" + payPeriod.shiftStart.Year;
            return saveExport(fileName, Student.userName, sb.ToString());
        }

        private static string saveExport(string fileName, string userName, string timeSheet)
        {
            try
            {
                if (!Directory.Exists("exports"))
                    Directory.CreateDirectory("exports");

                if (!Directory.Exists("exports\\" + userName))
                    Directory.CreateDirectory("exports\\" + userName);

                string _fileName = "exports\\" + userName + "\\" + fileName + ".html";
                File.WriteAllLines(_fileName, timeSheet.Split(new char[] { '\r', '\n' }));

                return _fileName;
            }

            catch (Exception E)
            {
                throw new ExportException("Could not save timesheet - " + E.Message);
            }
        }
    }
}
