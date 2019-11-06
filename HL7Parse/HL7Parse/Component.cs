using System;
using System.Collections.Generic;

namespace HL7Parse
{
    public class Component
    {
        private readonly string _Value;
        private readonly List<Subcomponent> _SubcomponentList;

        public Component(string Value, Delimiters Delimiters)
        {
            _Value = Value;
            string[] SubcomponentArray = Value.Split(Delimiters.Subcomponent);
            foreach (var subcomponent in SubcomponentArray)
            {
                _SubcomponentList.Add(new Subcomponent(subcomponent));
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