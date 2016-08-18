using System;
using System.Collections.Generic;

namespace TLog.Users
{
    [Serializable]
    class StudentWorker : User
    {
        public Dictionary<string, Schedule.WorkWeek> weeksWorked { get; private set;  }
        public int maxHoursPerSemester;
        public int maxHoursPerWeek;
        public bool hoursIssue;

        public StudentWorker(string fName, string lName, string TNum, long sKey, string Un, string Em,  int maxHours) : base (fName, lName, TNum, Un, Em, sKey)
        {
            maxHoursPerSemester = maxHours;
            weeksWorked = new Dictionary<string, Schedule.WorkWeek>();
            Class = Type.Student_Worker;
            Activated = false;
            maxHoursPerWeek = 28;
            hoursIssue = false;
        }

        public override void Update(string fName, string lName, string TNum, long sKey, string Un, string Em, Type classification, int maxHours)
        {
            base.Update(fName, lName, TNum, sKey, Un, Em, classification);
            maxHoursPerSemester = maxHours;
            if (weeksWorked == null)
                weeksWorked = new Dictionary<string, Schedule.WorkWeek>();
        }

        public double semesterHours()
        {
            bool springSemester = DateTime.Now.Month < 7;
            double hours = 0;

            if (springSemester)
                for (DateTime start = Schedule.WorkWeek.GetFirstDayOfWeek(new DateTime(DateTime.Now.Year, 1, 1)); start < Schedule.WorkWeek.GetFirstDayOfWeek(new DateTime(DateTime.Now.Year, 7, 1)); start = start.AddDays(7))
                    hours += weeklyHours(Schedule.WorkWeek.workWeekID(start));
            else
                for (DateTime start = Schedule.WorkWeek.GetFirstDayOfWeek(new DateTime(DateTime.Now.Year, 7, 1)); start <= Schedule.WorkWeek.GetFirstDayOfWeek(new DateTime(DateTime.Now.Year, 12, 31)); start = start.AddDays(7))
                    hours += weeklyHours(Schedule.WorkWeek.workWeekID(start));

            return Math.Round(hours, 2);
        }

        public double totalHours()
        {
            double hours = 0;
            foreach (var h in weeksWorked.Keys)
                foreach (var s in weeksWorked[h].totalShifts())
                    hours += s.timeWorked.TotalHours;
            return Math.Round(hours, 2);
        }

        public double weeklyHours()
        {
            try
            {
                return Math.Round(weeksWorked[Schedule.WorkWeek.todaysWorkID()].hoursWorked(), 2);
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        public double weeklyHours(string workID)
        {
            try
            {
                return Math.Round(weeksWorked[workID].hoursWorked(), 1);
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        public double dailyHours()
        {
            try
            {
                return Math.Round(weeksWorked[Schedule.WorkWeek.todaysWorkID()].dailyHoursWorked(DateTime.Now.DayOfWeek), 1);
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        public double dailyHours(string weekID, DayOfWeek Day)
        {
            try
            {
                return Math.Round(weeksWorked[weekID].dailyHoursWorked(Day), 1);
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        public void updateShift(Schedule.Shift oldShift, Schedule.Shift newShift)
        {
            Schedule.WorkWeek existingWeek = null;
            try
            {
                existingWeek = weeksWorked[Schedule.WorkWeek.workWeekID(newShift.shiftStart)];
            }
            catch (KeyNotFoundException)
            {
                weeksWorked.Add(Schedule.WorkWeek.workWeekID(newShift.shiftStart), new Schedule.WorkWeek(newShift.shiftStart));
            }

            weeksWorked[Schedule.WorkWeek.workWeekID(oldShift.shiftStart)].removeHours(oldShift);
            weeksWorked[Schedule.WorkWeek.workWeekID(newShift.shiftStart)].addHours(newShift.shiftStart.DayOfWeek, newShift);
            lastModified = DateTime.Now;
        }

        public void addShift(Schedule.Shift newShift)
        {
            Schedule.WorkWeek existingWeek = null;
            try
            {
                existingWeek = weeksWorked[Schedule.WorkWeek.workWeekID(newShift.shiftStart)];
            }
            catch (KeyNotFoundException)
            {
                weeksWorked.Add(Schedule.WorkWeek.workWeekID(newShift.shiftStart), new Schedule.WorkWeek(newShift.shiftStart));
            }
            weeksWorked[Schedule.WorkWeek.workWeekID(newShift.shiftStart)].addHours(newShift.shiftStart.DayOfWeek, newShift);
            lastModified = DateTime.Now;
        }

        public override void logOn()
        {
            base.logOn();
            checkWeek();
            loggedIn = true;
        }

        private void checkWeek()
        {
            // add their work week if it does not exist
            Schedule.WorkWeek currentWeek = null;

            // if we switch types?

            var test = Schedule.WorkWeek.workWeekID(lastLogon);
            weeksWorked.TryGetValue(test, out currentWeek);

            if (currentWeek == null)
            {
                Debug.Log("It is {0}'s first time logging in this week, creating new work week...", ID);
                weeksWorked.Add(Schedule.WorkWeek.workWeekID(lastLogon), new Schedule.WorkWeek());
            }
        }

        public override void logOff()
        {
            base.logOff();

            weeksWorked[Schedule.WorkWeek.workWeekID(lastLogon)].addHours(lastLogon.DayOfWeek, new Schedule.Shift(lastLogon, lastLogoff));
            loggedIn = false;
        }
    }
}
