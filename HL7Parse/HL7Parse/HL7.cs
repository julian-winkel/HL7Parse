using System;
using System.Collections.Generic;
using System.IO;

namespace HL7Parse
{
    public class HL7
    {
        private readonly List<Segment> _SegmentList;
        private readonly Delimiters _Delimiters;

        public HL7(string hl7message)
        {
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

        public Segment GetSegment(int Index)
        {
            Index = Index - 1;

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

        public Segment GetSegment(string SegmentName)
        {
            try
            {
                return _SegmentList.Find(x => x.Value.StartsWith(SegmentName));
            }
            catch (Exception e)
            {
                return null;
                throw new Exception("Segment is not available - Error: " + e.Message);
            }
        }

        public Delimiters Delimiters => _Delimiters;
    }
}