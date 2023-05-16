using System;

namespace ElectronicNotebook_Coursework
{
    public class Entry
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public Entry (string name, int phoneNumber, DateTime dob)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            DOB = dob;
        }
    }
}
