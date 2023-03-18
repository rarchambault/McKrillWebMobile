using System;
namespace McKrill.io.Backend.Model
{
    public class SOSSignal
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public SOSSignal(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}

