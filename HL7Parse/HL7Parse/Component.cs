using System;
using System.Collections.Generic;

namespace HL7Parse
{
    public class Component
    {
        private readonly string _Value;
        private readonly List<Subcomponent> _SubcomponentList;

        /// <summary>
        /// Parses a HL7 Component into Subcomponent and adds them to the _SubcomponentList.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Delimiters"></param>
        public Component(string Value, Delimiters Delimiters)
        {
            _Value = Value;
            string[] SubcomponentArray = Value.Split(Delimiters.Subcomponent);
            foreach (var subcomponent in SubcomponentArray)
            {
                _SubcomponentList.Add(new Subcomponent(subcomponent));
            }
        }

        /// <summary>
        /// Retrieves the entire Component in String format.
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
        /// Retrieves a Subcomponent from the _SubcomponentList using the provided Integer as the index.
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Subcomponent GetSubcomponent(int Index)
        {
            Index = Index - 1;

            try
            {
                return _SubcomponentList[Index];
            }
            catch (Exception e)
            {
                return null;
                throw new Exception("Subcomponent is not available - Error: " + e.Message);
            }
        }
    }
}