using System;
using System.Collections.Generic;

namespace HL7Parse
{
    public class Repeat
    {
        private readonly string _Value;
        private readonly List<Component> _ComponentList;

        public Repeat(string Value, Delimiters Delimiters)
        {
            _Value = Value;
            string[] ComponentArray = Value.Split(Delimiters.Component);
            foreach (var component in ComponentArray)
            {
                _ComponentList.Add(new Component(component, Delimiters));
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