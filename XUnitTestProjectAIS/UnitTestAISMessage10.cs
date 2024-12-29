using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage10 : IDisposable
    {
        private bool disposedValue;

        private readonly AISMessage10 _aisMessage10;

        public UnitTestAISMessage10()
        {
            _aisMessage10 = new AISMessage10();
        }

        [Fact]
        public void TestSourceId()
        {
            string source = "123456789";
            string expected = "123456789";

            _aisMessage10.SourceId = source;
            string actual = _aisMessage10.SourceId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDestinationId()
        {
            string destination = "123456789";
            string expected = "123456789";

            _aisMessage10.DestinationId = destination;
            string actual = _aisMessage10.DestinationId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AIS10Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,:5MlU41GMK6@,0*6C\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage10 aisMessage10 = aisMessage as AISMessage10;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage10);
            Assert.Equal(10, aisMessage10.MessageId);
            Assert.Equal(0, aisMessage10.RepeatIndicator);
            Assert.Equal("366814480", aisMessage10.SourceId);
            Assert.Equal("366832740", aisMessage10.DestinationId);
        }

        [Fact]
        public void AIS10Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,:6TMCD1GOS60,0*5B\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage10 aisMessage10 = aisMessage as AISMessage10;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage10);
            Assert.Equal(10, aisMessage10.MessageId);
            Assert.Equal(0, aisMessage10.RepeatIndicator);
            Assert.Equal("440882000", aisMessage10.SourceId);
            Assert.Equal("366972000", aisMessage10.DestinationId);
        }

        [Fact]
        public void AIS10Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,A,:5MlU41GMK6@,0*6F\r\n"
            };

            _aisMessage10.MessageId = 10;
            _aisMessage10.RepeatIndicator = 0;
            _aisMessage10.SourceId = "366814480";
            _aisMessage10.DestinationId = "366832740";

            IList<String> actual = _aisMessage10.EncodeSentences();

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
        // ~UnitTestAISMessage10()
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
