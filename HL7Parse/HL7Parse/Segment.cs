using System;
using System.Collections.Generic;

namespace HL7Parse
{
    public class Segment
    {
        private readonly string _Value;
        private readonly List<Field> _FieldList;

        /// <summary>
        /// Parses a HL7 Segment into Fields and adds them to the _FieldList.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Delimiters"></param>
        public Segment(string Value, Delimiters Delimiters)
        {
            _Value = Value;

            //First field in MSH is the field encoding char, which is dropped by the .split, so we add it here
            if (Value.StartsWith("MSH"))
            {
                _FieldList.Add(new Field(Delimiters.Field.ToString(), Delimiters));
            }

            string[] FieldArray = Value.Split(Delimiters.Field);

            //Start at 1, as the Segment name is not a Field
            for (int i = 1; i < FieldArray.Length; i++)
            {
                _FieldList.Add(new Field(FieldArray[i], Delimiters));
            }
        }

        /// <summary>
        /// Retrieves the entire Segment in String format.
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
        /// Retrieves a Field from the _FieldList using the provided Integer as the index.
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Field GetField(int Index)
        {
            Index = Index - 1;

            try
            {
                return _FieldList[Index];
            }
            catch (Exception e)
            {
                return null;
                throw new Exception("Field is not available - Error: " + e.Message);
            }
        }
    }
}