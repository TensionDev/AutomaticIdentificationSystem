using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage07 : IDisposable
    {
        private bool disposedValue;

        private readonly AISMessage07 _aisMessage07;

        public UnitTestAISMessage07()
        {
            _aisMessage07 = new AISMessage07();
        }

        [Fact]
        public void TestSourceId()
        {
            string source = "123456789";
            string expected = "123456789";

            _aisMessage07.SourceId = source;
            string actual = _aisMessage07.SourceId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDestinationId1()
        {
            string destination = "123456789";
            string expected = "123456789";

            _aisMessage07.DestinationId1 = destination;
            string actual = _aisMessage07.DestinationId1;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSequenceNumber1()
        {
            ushort seqNo = 3;
            ushort expected = 3;

            _aisMessage07.SequenceNumber1 = seqNo;
            ushort actual = _aisMessage07.SequenceNumber1;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSetDestination2()
        {
            string expectedDestination = "234567891";
            ushort expectedSeqNo = 2;

            _aisMessage07.SetDestination2(expectedDestination, expectedSeqNo);
            bool actual = _aisMessage07.GetDestination2(out string destination, out ushort seqNo);

            Assert.True(actual);
            Assert.Equal(expectedDestination, destination);
            Assert.Equal(expectedSeqNo, seqNo);
        }

        [Fact]
        public void TestClearDestination2()
        {
            _aisMessage07.ClearDestination2();
            bool actual = _aisMessage07.GetDestination2(out string destination, out ushort seqNo);

            Assert.False(actual);
        }

        [Fact]
        public void TestSetDestination3()
        {
            string expectedDestination = "345678912";
            ushort expectedSeqNo = 1;

            _aisMessage07.SetDestination3(expectedDestination, expectedSeqNo);
            bool actual = _aisMessage07.GetDestination3(out string destination, out ushort seqNo);

            Assert.True(actual);
            Assert.Equal(expectedDestination, destination);
            Assert.Equal(expectedSeqNo, seqNo);
        }

        [Fact]
        public void TestClearDestination3()
        {
            _aisMessage07.ClearDestination3();
            bool actual = _aisMessage07.GetDestination3(out string destination, out ushort seqNo);

            Assert.False(actual);
        }

        [Fact]
        public void TestSetDestination4()
        {
            string expectedDestination = "456789123";
            ushort expectedSeqNo = 0;

            _aisMessage07.SetDestination4(expectedDestination, expectedSeqNo);
            bool actual = _aisMessage07.GetDestination4(out string destination, out ushort seqNo);

            Assert.True(actual);
            Assert.Equal(expectedDestination, destination);
            Assert.Equal(expectedSeqNo, seqNo);
        }

        [Fact]
        public void TestClearDestination4()
        {
            _aisMessage07.ClearDestination4();
            bool actual = _aisMessage07.GetDestination4(out string destination, out ushort seqNo);

            Assert.False(actual);
        }

        [Fact]
        public void AIS07Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,702R5`hwCjq8,0*6B\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage07 aisMessage07 = aisMessage as AISMessage07;
            Boolean destination2 = aisMessage07.GetDestination2(out string destinationId2, out ushort sequenceNumber2);
            Boolean destination3 = aisMessage07.GetDestination3(out string destinationId3, out ushort sequenceNumber3);
            Boolean destination4 = aisMessage07.GetDestination4(out string destinationId4, out ushort sequenceNumber4);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage07);
            Assert.Equal(7, aisMessage07.MessageId);
            Assert.Equal(0, aisMessage07.RepeatIndicator);
            Assert.Equal("002655651", aisMessage07.SourceId);
            Assert.Equal("265538450", aisMessage07.DestinationId1);
            Assert.Equal(0, aisMessage07.SequenceNumber1);
            Assert.False(destination2);
            Assert.False(destination3);
            Assert.False(destination4);
        }

        [Fact]
        public void AIS07Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,7`0Pv1@:Ac8rbgPKH@,4*52\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage07 aisMessage07 = aisMessage as AISMessage07;
            Boolean destination2 = aisMessage07.GetDestination2(out string destinationId2, out ushort sequenceNumber2);
            Boolean destination3 = aisMessage07.GetDestination3(out string destinationId3, out ushort sequenceNumber3);
            Boolean destination4 = aisMessage07.GetDestination4(out string destinationId4, out ushort sequenceNumber4);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage07);
            Assert.Equal(7, aisMessage07.MessageId);
            Assert.Equal(2, aisMessage07.RepeatIndicator);
            Assert.Equal("537411077", aisMessage07.SourceId);
            Assert.Equal("043101326", aisMessage07.DestinationId1);
            Assert.Equal(2, aisMessage07.SequenceNumber1);
            Assert.Equal("717096664", aisMessage07.DestinationId2);
            Assert.Equal(1, aisMessage07.SequenceNumber2);
            Assert.True(destination2);
            Assert.Equal("717096664", destinationId2);
            Assert.Equal(1, sequenceNumber2);
            Assert.False(destination3);
            Assert.False(destination4);
        }

        [Fact]
        public void AIS07Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,A,702R5`hwCjq8,0*6B\r\n"
            };

            _aisMessage07.MessageId = 7;
            _aisMessage07.RepeatIndicator = 0;
            _aisMessage07.SourceId = "002655651";
            _aisMessage07.DestinationId1 = "265538450";
            _aisMessage07.SequenceNumber1 = 0;
            _aisMessage07.ClearDestination2();
            _aisMessage07.ClearDestination3();
            _aisMessage07.ClearDestination4();

            IList<String> actual = _aisMessage07.EncodeSentences();

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
        // ~UnitTestAISMessage07()
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
