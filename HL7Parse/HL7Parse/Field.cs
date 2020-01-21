using System;
using System.Collections.Generic;

namespace HL7Parse
{
    public class Field
    {
        private readonly string _Value;
        private readonly List<Repeat> _RepeatList;

        /// <summary>
        /// Parses a HL7 Segment into Repeats and adds them to the _RepeatList.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Delimiters"></param>
        public Field(string Value, Delimiters Delimiters)
        {
            _Value = Value;
            string[] RepeatArray = Value.Split(Delimiters.Repeat);
            foreach (var repeat in RepeatArray)
            {
                _RepeatList.Add(new Repeat(repeat, Delimiters));
            }
        }

        /// <summary>
        /// Retrieves the entire Field in String format.
        /// </summary>
        public string Value
        {
            get
            {
                if (_Value == null)
                {
                    return string.Empty;
                }
                else
                {
                    return _Value;
                }
            }
        }

        /// <summary>
        /// Retrieves a Repeat from the _RepeatList using the provided Integer as the index.
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Repeat GetRepeat(int Index)
        {
            Index = Index - 1;

            try
            {
                return _RepeatList[Index];
            }
            catch (Exception e)
            {
                return null;
                throw new Exception("Repeat is not available - Error: " + e.Message);
            }
        }
    }
}