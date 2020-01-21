namespace HL7Parse
{
    public class Subcomponent
    {
        private readonly string _Value;

        /// <summary>
        /// Subcomponent constructor.
        /// </summary>
        /// <param name="Value"></param>
        public Subcomponent(string Value)
        {
            _Value = Value;
        }

        /// <summary>
        /// Retrieves the entire Subcomponent in String format.
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
    }
}