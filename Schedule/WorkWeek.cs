using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TLog.Schedule
{
    [Serializable]
    class WorkWeek
    {
        private Dictionary<DayOfWeek, List<Shift>> dateTimeWorked;
        public string weekID { get; private set; }

        public WorkWeek()
        {
            dateTimeWorked = new Dictionary<DayOfWeek, List<Shift>>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                dateTimeWorked.Add(day, new List<Shift>());

            weekID = todaysWorkID();
        }

        public WorkWeek(DateTime workTime)
        {
            dateTimeWorked = new Dictionary<DayOfWeek, List<Shift>>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                dateTimeWorked.Add(day, new List<Shift>());

            weekID = workWeekID(workTime);
        }

        public void addHours(DayOfWeek Day, params Shift[] hoursWorked)
        {
            if (hoursWorked != null)
                foreach (Shift S in hoursWorked)
                    dateTimeWorked[Day].Add(S);
        }

        public void removeHours(Shift existingHours)
        {
            if (dateTimeWorked[existingHours.shiftStart.DayOfWeek].RemoveAll(x => x.shiftEnd == existingHours.shiftEnd && x.shiftStart == existingHours.shiftStart) == 0)
                Debug.Log(Debug.MessageType.Warning, "Deleting hours resulted in 0 deletions");               
        }

        public double hoursWorked()
        {
            double hours = 0;
            foreach (var D in dateTimeWorked.Keys)
                foreach (var S in dateTimeWorked[D])
                    hours += S.getTotalHours();
            return hours;
        }

        public double dailyHoursWorked(DayOfWeek Day)
        {
            double hours = 0;
            foreach (Shift S in dateTimeWorked[Day])
                hours += S.getTotalHours();
            return hours;
        }

        public List<Shift> totalShifts()
        {
            var shifts = new List<Shift>();
            foreach (var s in dateTimeWorked.Keys)
                foreach (var ss in dateTimeWorked[s])
                    shifts.Add(ss);

            return shifts;
        }

        public List<Shift> shiftsOnDay(DayOfWeek Day)
        {
            return dateTimeWorked[Day];
        }

        public static string workWeekID(DateTime workDate)
        {
            return GetFirstDayOfWeek(workDate).Month + "/" + GetFirstDayOfWeek(workDate).Day +  "/" + workDate.Year.ToString();
        }

        public static string todaysWorkID()
        {
            return workWeekID(DateTime.Now);
        }

        public override string ToString()
        {
            if (weekID == null)
                return "Error!";
            return weekID;
        }

        public static DateTime GetDateTimeOfDayInWeek(DayOfWeek Day, string workWeekID)
        {
            var selectedWeek = DateTime.Parse(workWeekID);
            selectedWeek = selectedWeek.AddDays((double)Day);
            return selectedWeek;
        }

        // from http://joelabrahamsson.com/getting-the-first-day-in-a-week-with-c/

        /// <summary>
        /// Returns the first day of the week that the specified
        /// date is in using the current culture. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

    }
}
