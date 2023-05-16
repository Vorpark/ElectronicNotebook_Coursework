using System;

namespace ElectronicNotebook_Coursework
{
    public class Entry
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string DOB { get; set; }
        public Entry (string name, int phoneNumber, string dob)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            DOB = dob;
        }
    }
}
