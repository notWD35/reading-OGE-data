using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace reading_OGE_data;

class Program
{
    public struct UserRecord
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkEmail { get; set; }
        public bool CloudLifecycleState { get; set; }
        public string IdentityId { get; set; }
        public bool IsManager { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Uid { get; set; }
        public string AccessType { get; }
        public string AccessSourceName { get; }
        public string AccessDisplayName { get; }
        public string AccessDescription { get; }
        public UserRecord(string[] values)
        {
            DisplayName = values[0];
            FirstName = values[1];
            LastName = values[2];
            WorkEmail = values[3];
            CloudLifecycleState = string.Equals(values[4], "active");
            IdentityId = values[5];
            IsManager = string.Equals(values[6], "TRUE");
            Department = values[7];
            JobTitle = values[8];
            Uid = values[9];
            AccessType = values[10];
            AccessSourceName = values[11];
            AccessDisplayName = values[12];
            AccessDescription = values[13];
        }
    }
    public static List<UserRecord> read()
    {
        List<UserRecord> recordList = new List<UserRecord>();
        using StreamReader s = new StreamReader("Francis Tuttle Identities_Basic.csv");
        s.ReadLine();
        string? line = s.ReadLine();
        while (line != null)
        {
            recordList.Add(new UserRecord(line.Split(",")));
            line = s.ReadLine();
        }
        Console.WriteLine(recordList[0].Uid);
        return recordList;
    }
    static void Main(string[] args)
    {
        read();
    }
}
