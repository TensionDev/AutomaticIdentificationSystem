using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage18 : IDisposable
    {
        private bool disposedValue;

        private const Int32 POSITIONAL_PRECISION = 5;
        private const Int32 ROT_PRECISION = 0;

        private readonly AISMessage18 _aisMessage18;

        public UnitTestAISMessage18()
        {
            _aisMessage18 = new AISMessage18();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage18.UserId = userId;
            string actual = _aisMessage18.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundValid()
        {
            decimal speedOverGround = 10.0M;
            decimal expected = 10.0M;

            _aisMessage18.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage18.SpeedOverGroundKnots;

            Assert.True(_aisMessage18.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundInvalid()
        {
            decimal speedOverGround = 102.4M;
            decimal expected = 0M;

            _aisMessage18.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage18.SpeedOverGroundKnots;

            Assert.False(_aisMessage18.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLongitudeValid()
        {
            decimal longitude = 103.833333M;
            decimal expected = 103.833333M;

            _aisMessage18.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage18.LongitudeDecimalDegrees;

            Assert.True(_aisMessage18.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLongitudeInvalid()
        {
            decimal longitude = 181.0M;
            decimal expected = 181.0M;

            _aisMessage18.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage18.LongitudeDecimalDegrees;

            Assert.False(_aisMessage18.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeValid()
        {
            decimal latitude = 1.283333M;
            decimal expected = 1.283333M;

            _aisMessage18.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage18.LatitudeDecimalDegrees;

            Assert.True(_aisMessage18.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeInvalid()
        {
            decimal latitude = 91.0M;
            decimal expected = 91.0M;

            _aisMessage18.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage18.LatitudeDecimalDegrees;

            Assert.False(_aisMessage18.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestCourseOverGroundValid()
        {
            decimal courseOverGround = 45.0M;
            decimal expected = 45.0M;

            _aisMessage18.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage18.CourseOverGroundDegrees;

            Assert.True(_aisMessage18.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCourseOverGroundInvalid()
        {
            decimal courseOverGround = 720.0M;
            decimal expected = 360.0M;

            _aisMessage18.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage18.CourseOverGroundDegrees;

            Assert.False(_aisMessage18.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingValid()
        {
            ushort trueHeading = 270;
            ushort expected = 270;

            _aisMessage18.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage18.TrueHeadingDegrees;

            Assert.True(_aisMessage18.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingInvalid()
        {
            ushort trueHeading = 720;
            ushort expected = 511;

            _aisMessage18.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage18.TrueHeadingDegrees;

            Assert.False(_aisMessage18.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AIS18Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,B52K>;h00Fc>jpUlNV@ikwpUoP06,0*4F\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage18 aisMessage18 = aisMessage as AISMessage18;
            ITDMACommunicationState communicationState = aisMessage18.CommunicationState as ITDMACommunicationState;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage18);
            Assert.NotNull(communicationState);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage18.SentenceFormatter);
            Assert.Equal(18, aisMessage18.MessageId);
            Assert.Equal(0, aisMessage18.RepeatIndicator);
            Assert.Equal("338087471", aisMessage18.UserId);
            Assert.Equal(0, aisMessage18.ReservedForRegionalOrLocalApplications);
            Assert.Equal(0.1M, aisMessage18.SpeedOverGroundKnots);
            Assert.True(aisMessage18.SpeedOverGroundAvailable);
            Assert.False(aisMessage18.PositionAccuracy);
            Assert.Equal(-74.072132M, aisMessage18.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage18.LongitudeAvailable);
            Assert.Equal(40.684540M, aisMessage18.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage18.LatitudeAvailable);
            Assert.Equal(79.6M, aisMessage18.CourseOverGroundDegrees);
            Assert.True(aisMessage18.CourseOverGroundAvailable);
            Assert.Equal(511, aisMessage18.TrueHeadingDegrees);
            Assert.False(aisMessage18.TrueHeadingAvailable);
            Assert.Equal(49, aisMessage18.Timestamp);
            Assert.True(aisMessage18.RAIMFlag);
            Assert.True(aisMessage18.CommunicationStateSelectorFlag);
            Assert.Equal(AISCommunicationState.SyncStateEnum.SyncToAnotherStation, communicationState.SyncState);
            Assert.Equal(0, communicationState.SlotIncrement);
            Assert.Equal(3, communicationState.NumberOfSlots);
            Assert.False(communicationState.KeepFlag);
        }

        [Fact]
        public void AIS18Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,B5O6hr00<veEKmUaMFdEow`UWP06,0*4F\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage18 aisMessage18 = aisMessage as AISMessage18;
            ITDMACommunicationState communicationState = aisMessage18.CommunicationState as ITDMACommunicationState;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage18);
            Assert.NotNull(communicationState);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage18.SentenceFormatter);
            Assert.Equal(18, aisMessage18.MessageId);
            Assert.Equal(0, aisMessage18.RepeatIndicator);
            Assert.Equal("368161000", aisMessage18.UserId);
            Assert.Equal(0, aisMessage18.ReservedForRegionalOrLocalApplications);
            Assert.Equal(5.1M, aisMessage18.SpeedOverGroundKnots);
            Assert.True(aisMessage18.SpeedOverGroundAvailable);
            Assert.True(aisMessage18.PositionAccuracy);
            Assert.Equal(-72.2338466666667M, aisMessage18.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage18.LongitudeAvailable);
            Assert.Equal(39.480925M, aisMessage18.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage18.LatitudeAvailable);
            Assert.Equal(34.9M, aisMessage18.CourseOverGroundDegrees);
            Assert.True(aisMessage18.CourseOverGroundAvailable);
            Assert.Equal(511, aisMessage18.TrueHeadingDegrees);
            Assert.False(aisMessage18.TrueHeadingAvailable);
            Assert.Equal(17, aisMessage18.Timestamp);
            Assert.True(aisMessage18.RAIMFlag);
            Assert.True(aisMessage18.CommunicationStateSelectorFlag);
            Assert.Equal(AISCommunicationState.SyncStateEnum.SyncToAnotherStation, communicationState.SyncState);
            Assert.Equal(0, communicationState.SlotIncrement);
            Assert.Equal(3, communicationState.NumberOfSlots);
            Assert.False(communicationState.KeepFlag);
        }

        [Fact]
        public void AIS18Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,B,B52K>;h00Fc>jpUlNV@ikwpP7P06,0*12\r\n"
            };

            _aisMessage18.MessageId = 18;
            _aisMessage18.RepeatIndicator = 0;
            _aisMessage18.UserId = "338087471";
            _aisMessage18.SpeedOverGroundKnots = 0.1M;
            _aisMessage18.PositionAccuracy = false;
            _aisMessage18.LongitudeDecimalDegrees = -74.0721316M;
            _aisMessage18.LatitudeDecimalDegrees = 40.684540M;
            _aisMessage18.CourseOverGroundDegrees = 79.6M;
            _aisMessage18.TrueHeadingDegrees = 511;
            _aisMessage18.Timestamp = 49;
            _aisMessage18.RAIMFlag = true;
            _aisMessage18.CommunicationStateSelectorFlag = true;
            _aisMessage18.CommunicationState = new ITDMACommunicationState()
            {
                SyncState = AISCommunicationState.SyncStateEnum.SyncToAnotherStation,
                SlotIncrement = 0,
                NumberOfSlots = 3,
                KeepFlag = false,
            };

            IList<String> actual = _aisMessage18.EncodeSentences();

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
        // ~UnitTestAISMessage18()
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
