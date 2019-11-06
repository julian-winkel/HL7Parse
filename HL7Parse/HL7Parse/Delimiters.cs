using System;
using System.IO;

namespace HL7Parse
{
    public class Delimiters
    {
        public char Field;
        public char Component;
        public char Repeat;
        public char Escape;
        public char Subcomponent;

        public Delimiters(string hl7message)
        {
            try
            {
                using (StringReader reader = new StringReader(hl7message))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("MSH"))
                        {
                            //MSH-1 Field separator
                            this.Field = line[3];
                            //MSH-2 Encoding characters
                            this.Component = line[4];
                            this.Repeat = line[5];
                            this.Escape = line[6];
                            this.Subcomponent = line[7];
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving message delimiters: " + e.Message);
            }
        }
    }
}