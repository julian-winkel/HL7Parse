using System;
using System.Collections.Generic;

namespace HL7Parse
{
    public class Field
    {
        private readonly string _Value;
        private readonly List<Repeat> _RepeatList;

        public Field(string Value, Delimiters Delimiters)
        {
            _Value = Value;
            string[] RepeatArray = Value.Split(Delimiters.Repeat);
            foreach (var repeat in RepeatArray)
            {
                _RepeatList.Add(new Repeat(repeat, Delimiters));
            }
        }

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