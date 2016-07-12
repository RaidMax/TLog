using System.Collections.Generic;
using System.IO;

namespace TLog.Manager
{
    class CSV
    {
        public static List<Users.User> getStudents()
        {
            CsvHelper.CsvReader reader;
            List<Users.User> userList = new List<Users.User>();

            reader = new CsvHelper.CsvReader(File.OpenText("student_accounts.csv"));

            while (reader.Read())
            {
                string TNumber = reader.GetField<string>("T_NUMBER");
                string firstName = reader.GetField<string>("FIRSTNAME");
                string lastName = reader.GetField<string>("LAST_NAME");
                string userName = reader.GetField<string>("USERNAME");
                string Email = reader.GetField<string>("EMAILADDRESS");
                long secretKey = reader.GetField<long>("CHECK-N ID");

                userList.Add(new Users.StudentWorker(firstName, lastName, TNumber, secretKey, userName, Email, 110));
            }

            return userList;
        }
    }
}
