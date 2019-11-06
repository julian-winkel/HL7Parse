namespace HL7Parse
{
    public class Subcomponent
    {
        private readonly string _Value;

        public Subcomponent(string Value)
        {
            _Value = Value;
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
    }
}