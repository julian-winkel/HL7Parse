using System;
using System.IO;

namespace HL7Parse
{
    public class Delimiters
    {
        /// <summary>
        /// This property returns the Field Delimiter char.
        /// </summary>
        public readonly char Field;

        /// <summary>
        /// This property returns the Component Delimiter char.
        /// </summary>
        public readonly char Component;

        /// <summary>
        /// This property returns the Repeat Delimiter char.
        /// </summary>
        public readonly char Repeat;

        /// <summary>
        /// This property returns the Escape Delimiter char.
        /// </summary>
        public readonly char Escape;

        /// <summary>
        /// This property returns the Subcomponent Delimiter char.
        /// </summary>
        public readonly char Subcomponent;

        /// <summary>
        /// Parses a HL7 message and retrieves the HL7 Delimiter fields.
        /// </summary>
        /// <param name="hl7message"></param>
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