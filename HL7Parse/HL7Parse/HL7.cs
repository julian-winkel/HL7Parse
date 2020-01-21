using System;
using System.Collections.Generic;
using System.IO;

namespace HL7Parse
{
    public class HL7
    {
        private readonly string _Value;
        private readonly Delimiters _Delimiters;
        private readonly List<Segment> _SegmentList;

        /// <summary>
        /// Parses a HL7 message into Segments and adds them to the _SegmentList.
        /// </summary>
        /// <param name="hl7message"></param>
        public HL7(string hl7message)
        {
            _Value = hl7message;
            _Delimiters = new Delimiters(hl7message);

            using (StringReader reader = new StringReader(hl7message))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _SegmentList.Add(new Segment(line, _Delimiters));
                }
            }
        }

        /// <summary>
        /// This property returns the HL7 Message as a String.
        /// </summary>
        public string Value
        {
            get
            {
                try
                {
                    return _Value;
                }
                catch (Exception e)
                {
                    throw new Exception("Error retrieving HL7 Value: " + e.Message);
                }
            }
        }

        /// <summary>
        /// This property returns the HL7 Delimiters as a Delimiter.
        /// </summary>
        public Delimiters Delimiters => _Delimiters;

        /// <summary>
        /// Retrieves a Segment from the _SegmentList using the provided Integer as the index.
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public Segment GetSegment(int Index)
        {
            try
            {
                return _SegmentList[Index];
            }
            catch (Exception e)
            {
                return null;
                throw new Exception("Segment is not available - Error: " + e.Message);
            }
        }

        /// <summary>
        /// Retrieves the first matching Segment from the _SegmentList using the provided String as the Segment Name (i.e. "MSH")
        /// </summary>
        /// <param name="SegmentName"></param>
        /// <returns></returns>
        public Segment GetSegment(string SegmentName)
        {
            try
            {
                return _SegmentList.Find(x => x.Value.StartsWith(SegmentName + _Delimiters.Field));
            }
            catch (Exception e)
            {
                return null;
                throw new Exception("Segment is not available - Error: " + e.Message);
            }
        }
    }
}