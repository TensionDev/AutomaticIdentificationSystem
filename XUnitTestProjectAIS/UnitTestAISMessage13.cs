using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage13 : IDisposable
    {
        private bool disposedValue;

        private readonly AISMessage13 _aisMessage13;

        public UnitTestAISMessage13()
        {
            _aisMessage13 = new AISMessage13();
        }

        [Fact]
        public void TestSourceId()
        {
            string source = "123456789";
            string expected = "123456789";

            _aisMessage13.SourceId = source;
            string actual = _aisMessage13.SourceId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDestinationId1()
        {
            string destination = "123456789";
            string expected = "123456789";

            _aisMessage13.DestinationId1 = destination;
            string actual = _aisMessage13.DestinationId1;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSequenceNumber1()
        {
            ushort seqNo = 3;
            ushort expected = 3;

            _aisMessage13.SequenceNumber1 = seqNo;
            ushort actual = _aisMessage13.SequenceNumber1;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSetDestination2()
        {
            string expectedDestination = "234567891";
            ushort expectedSeqNo = 2;

            _aisMessage13.SetDestination2(expectedDestination, expectedSeqNo);
            bool actual = _aisMessage13.GetDestination2(out string destination, out ushort seqNo);

            Assert.True(actual);
            Assert.Equal(expectedDestination, destination);
            Assert.Equal(expectedSeqNo, seqNo);
        }

        [Fact]
        public void TestClearDestination2()
        {
            _aisMessage13.ClearDestination2();
            bool actual = _aisMessage13.GetDestination2(out string destination, out ushort seqNo);

            Assert.False(actual);
        }

        [Fact]
        public void TestSetDestination3()
        {
            string expectedDestination = "345678912";
            ushort expectedSeqNo = 1;

            _aisMessage13.SetDestination3(expectedDestination, expectedSeqNo);
            bool actual = _aisMessage13.GetDestination3(out string destination, out ushort seqNo);

            Assert.True(actual);
            Assert.Equal(expectedDestination, destination);
            Assert.Equal(expectedSeqNo, seqNo);
        }

        [Fact]
        public void TestClearDestination3()
        {
            _aisMessage13.ClearDestination3();
            bool actual = _aisMessage13.GetDestination3(out string destination, out ushort seqNo);

            Assert.False(actual);
        }

        [Fact]
        public void TestSetDestination4()
        {
            string expectedDestination = "456789123";
            ushort expectedSeqNo = 0;

            _aisMessage13.SetDestination4(expectedDestination, expectedSeqNo);
            bool actual = _aisMessage13.GetDestination4(out string destination, out ushort seqNo);

            Assert.True(actual);
            Assert.Equal(expectedDestination, destination);
            Assert.Equal(expectedSeqNo, seqNo);
        }

        [Fact]
        public void TestClearDestination4()
        {
            _aisMessage13.ClearDestination4();
            bool actual = _aisMessage13.GetDestination4(out string destination, out ushort seqNo);

            Assert.False(actual);
        }

        [Fact]
        public void AIS13Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,=39UOj0jFs9R,0*65\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage13 aisMessage13 = aisMessage as AISMessage13;
            Boolean destination2 = aisMessage13.GetDestination2(out string destinationId2, out ushort sequenceNumber2);
            Boolean destination3 = aisMessage13.GetDestination3(out string destinationId3, out ushort sequenceNumber3);
            Boolean destination4 = aisMessage13.GetDestination4(out string destinationId4, out ushort sequenceNumber4);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage13);
            Assert.Equal(13, aisMessage13.MessageId);
            Assert.Equal(0, aisMessage13.RepeatIndicator);
            Assert.Equal("211378120", aisMessage13.SourceId);
            Assert.Equal("211217560", aisMessage13.DestinationId1);
            Assert.Equal(2, aisMessage13.SequenceNumber1);
            Assert.False(destination2);
            Assert.False(destination3);
            Assert.False(destination4);
        }

        [Fact]
        public void AIS13Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,=`0Pv1@:Ac8rbgPKHC9KdV<,2*27\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage13 aisMessage13 = aisMessage as AISMessage13;
            Boolean destination2 = aisMessage13.GetDestination2(out string destinationId2, out ushort sequenceNumber2);
            Boolean destination3 = aisMessage13.GetDestination3(out string destinationId3, out ushort sequenceNumber3);
            Boolean destination4 = aisMessage13.GetDestination4(out string destinationId4, out ushort sequenceNumber4);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage13);
            Assert.Equal(13, aisMessage13.MessageId);
            Assert.Equal(2, aisMessage13.RepeatIndicator);
            Assert.Equal("537411077", aisMessage13.SourceId);
            Assert.Equal("043101326", aisMessage13.DestinationId1);
            Assert.Equal(2, aisMessage13.SequenceNumber1);
            Assert.Equal("717096664", aisMessage13.DestinationId2);
            Assert.Equal(1, aisMessage13.SequenceNumber2);
            Assert.True(destination2);
            Assert.Equal("717096664", destinationId2);
            Assert.Equal(1, sequenceNumber2);
            Assert.Equal("211217560", aisMessage13.DestinationId3);
            Assert.Equal(3, aisMessage13.SequenceNumber3);
            Assert.True(destination3);
            Assert.Equal("211217560", destinationId3);
            Assert.Equal(3, sequenceNumber3);
            Assert.False(destination4);
        }

        [Fact]
        public void AIS13Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,A,=39UOj0jFs9R,0*65\r\n"
            };

            _aisMessage13.MessageId = 13;
            _aisMessage13.RepeatIndicator = 0;
            _aisMessage13.SourceId = "211378120";
            _aisMessage13.DestinationId1 = "211217560";
            _aisMessage13.SequenceNumber1 = 2;
            _aisMessage13.ClearDestination2();
            _aisMessage13.ClearDestination3();
            _aisMessage13.ClearDestination4();

            IList<String> actual = _aisMessage13.EncodeSentences();

            Assert.Equivalent(expected, actual);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitTestAISMessage13()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
