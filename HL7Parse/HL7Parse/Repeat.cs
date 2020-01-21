using System;
using System.Collections.Generic;

namespace HL7Parse
{
    public class Repeat
    {
        private readonly string _Value;
        private readonly List<Component> _ComponentList;

        /// <summary>
        /// Parses a HL7 Field into Components and adds them to the _ComponentList.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Delimiters"></param>
        public Repeat(string Value, Delimiters Delimiters)
        {
            _Value = Value;
            string[] ComponentArray = Value.Split(Delimiters.Component);
            foreach (var component in ComponentArray)
            {
                _ComponentList.Add(new Component(component, Delimiters));
            }
        }

        /// <summary>
        /// Retrieves the entire Repeat in String format.
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
        /// Retrieves a Component from the _ComponentList using the provided Integer as the index.
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Component GetComponent(int Index)
        {
            Index = Index - 1;

            try
            {
                return _ComponentList[Index];
            }
            catch (Exception e)
            {
                return null;
                throw new Exception("Component is not available - Error: " + e.Message);
            }
        }
    }
}