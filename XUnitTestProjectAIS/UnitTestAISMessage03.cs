using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage03 : IDisposable
    {
        private bool disposedValue;

        private const Int32 POSITIONAL_PRECISION = 5;
        private const Int32 ROT_PRECISION = 0;

        private readonly AISMessage03 _aisMessage03;

        public UnitTestAISMessage03()
        {
            _aisMessage03 = new AISMessage03();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage03.UserId = userId;
            string actual = _aisMessage03.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNavigationStatu()
        {
            AISMessage03.NavigationalStatusEnum navStatus = AISMessage03.NavigationalStatusEnum.UnderWayUsingEngine;
            AISMessage03.NavigationalStatusEnum expected = AISMessage03.NavigationalStatusEnum.UnderWayUsingEngine;

            _aisMessage03.NavigationalStatus = navStatus;
            AISMessage03.NavigationalStatusEnum actual = _aisMessage03.NavigationalStatus;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRateOfTurnPortValid()
        {
            double rateOfTurn = -362.0;
            double expected = -362.0;

            _aisMessage03.SetRateOfTurn(rateOfTurn);
            double actual = _aisMessage03.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.True(_aisMessage03.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnPortInvalid()
        {
            double rateOfTurn = -362.0;
            double expected = -10.0;

            _aisMessage03.SetRateOfTurn(rateOfTurn, false);
            double actual = _aisMessage03.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.False(_aisMessage03.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnStarboardValid()
        {
            double rateOfTurn = 362.0;
            double expected = 362.0;

            _aisMessage03.SetRateOfTurn(rateOfTurn);
            double actual = _aisMessage03.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.True(_aisMessage03.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnStarboardInvalid()
        {
            double rateOfTurn = 362.0;
            double expected = 10.0;

            _aisMessage03.SetRateOfTurn(rateOfTurn, false);
            double actual = _aisMessage03.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.False(_aisMessage03.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnNoInformation()
        {
            bool expected = false;

            _aisMessage03.SetNoTurnInformation();
            bool actual = _aisMessage03.TurnInformationAvailable;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundValid()
        {
            decimal speedOverGround = 10.0M;
            decimal expected = 10.0M;

            _aisMessage03.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage03.SpeedOverGroundKnots;

            Assert.True(_aisMessage03.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundInvalid()
        {
            decimal speedOverGround = 102.4M;
            decimal expected = 102.3M;

            _aisMessage03.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage03.SpeedOverGroundKnots;

            Assert.False(_aisMessage03.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLongitudeValid()
        {
            decimal longitude = 103.833333M;
            decimal expected = 103.833333M;

            _aisMessage03.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage03.LongitudeDecimalDegrees;

            Assert.True(_aisMessage03.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLongitudeInvalid()
        {
            decimal longitude = 181.0M;
            decimal expected = 181.0M;

            _aisMessage03.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage03.LongitudeDecimalDegrees;

            Assert.False(_aisMessage03.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeValid()
        {
            decimal latitude = 1.283333M;
            decimal expected = 1.283333M;

            _aisMessage03.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage03.LatitudeDecimalDegrees;

            Assert.True(_aisMessage03.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeInvalid()
        {
            decimal latitude = 91.0M;
            decimal expected = 91.0M;

            _aisMessage03.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage03.LatitudeDecimalDegrees;

            Assert.False(_aisMessage03.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestCourseOverGroundValid()
        {
            decimal courseOverGround = 45.0M;
            decimal expected = 45.0M;

            _aisMessage03.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage03.CourseOverGroundDegrees;

            Assert.True(_aisMessage03.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCourseOverGroundInvalid()
        {
            decimal courseOverGround = 720.0M;
            decimal expected = 360.0M;

            _aisMessage03.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage03.CourseOverGroundDegrees;

            Assert.False(_aisMessage03.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingValid()
        {
            ushort trueHeading = 270;
            ushort expected = 270;

            _aisMessage03.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage03.TrueHeadingDegrees;

            Assert.True(_aisMessage03.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingInvalid()
        {
            ushort trueHeading = 720;
            ushort expected = 511;

            _aisMessage03.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage03.TrueHeadingDegrees;

            Assert.False(_aisMessage03.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AIS03Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,35MC>W@01EIAn5VA4I`N2;>0015@,0*27\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage03 aisMessage03 = aisMessage as AISMessage03;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage03);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage03.SentenceFormatter);
            Assert.Equal(3, aisMessage03.MessageId);
            Assert.Equal(0, aisMessage03.RepeatIndicator);
            Assert.Equal("366268061", aisMessage03.UserId);
            Assert.Equal(AISMessage03.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage03.NavigationalStatus);
            Assert.Equal(0, aisMessage03.RateOfTurnDegreesPerMinute);
            Assert.True(aisMessage03.TurnIndicatorAvailable);
            Assert.True(aisMessage03.TurnInformationAvailable);
            Assert.Equal(8.5M, aisMessage03.SpeedOverGroundKnots);
            Assert.True(aisMessage03.SpeedOverGroundAvailable);
            Assert.False(aisMessage03.PositionAccuracy);
            Assert.Equal(-93.9687666666667M, aisMessage03.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage03.LongitudeAvailable);
            Assert.Equal(29.829815M, aisMessage03.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage03.LatitudeAvailable);
            Assert.Equal(359.2M, aisMessage03.CourseOverGroundDegrees);
            Assert.True(aisMessage03.CourseOverGroundAvailable);
            Assert.Equal(359, aisMessage03.TrueHeadingDegrees);
            Assert.True(aisMessage03.TrueHeadingAvailable);
            Assert.Equal(0, aisMessage03.Timestamp);
            Assert.Equal(AISMessage03.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage03.SpecialManoeuvreIndicator);
            Assert.False(aisMessage03.RAIMFlag);
            Assert.Equal(ITDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage03.CommunicationState.SyncState);
            Assert.Equal(277, aisMessage03.CommunicationState.SlotIncrement);
            Assert.Equal(0, aisMessage03.CommunicationState.NumberOfSlots);
            Assert.False(aisMessage03.CommunicationState.KeepFlag);
        }

        [Fact]
        public void AIS03Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,38Id705000rRVJhE7cl9n;160000,0*40\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage03 aisMessage03 = aisMessage as AISMessage03;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage03);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage03.SentenceFormatter);
            Assert.Equal(3, aisMessage03.MessageId);
            Assert.Equal(0, aisMessage03.RepeatIndicator);
            Assert.Equal("563808000", aisMessage03.UserId);
            Assert.Equal(AISMessage03.NavigationalStatusEnum.Moored, aisMessage03.NavigationalStatus);
            Assert.Equal(0, aisMessage03.RateOfTurnDegreesPerMinute);
            Assert.True(aisMessage03.TurnIndicatorAvailable);
            Assert.True(aisMessage03.TurnInformationAvailable);
            Assert.Equal(0M, aisMessage03.SpeedOverGroundKnots);
            Assert.True(aisMessage03.SpeedOverGroundAvailable);
            Assert.True(aisMessage03.PositionAccuracy);
            Assert.Equal(-76.32753M, aisMessage03.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage03.LongitudeAvailable);
            Assert.Equal(36.91M, aisMessage03.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage03.LatitudeAvailable);
            Assert.Equal(252M, aisMessage03.CourseOverGroundDegrees);
            Assert.True(aisMessage03.CourseOverGroundAvailable);
            Assert.Equal(352, aisMessage03.TrueHeadingDegrees);
            Assert.True(aisMessage03.TrueHeadingAvailable);
            Assert.Equal(35, aisMessage03.Timestamp);
            Assert.Equal(AISMessage03.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage03.SpecialManoeuvreIndicator);
            Assert.False(aisMessage03.RAIMFlag);
            Assert.Equal(ITDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage03.CommunicationState.SyncState);
            Assert.Equal(0, aisMessage03.CommunicationState.SlotIncrement);
            Assert.Equal(0, aisMessage03.CommunicationState.NumberOfSlots);
            Assert.False(aisMessage03.CommunicationState.KeepFlag);
        }

        [Fact]
        public void AIS03Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,A,35MC>W@01EIAn5VA4I`N2;>0015@,0*27\r\n"
            };

            _aisMessage03.MessageId = 3;
            _aisMessage03.RepeatIndicator = 0;
            _aisMessage03.UserId = "366268061";
            _aisMessage03.NavigationalStatus = AISMessage03.NavigationalStatusEnum.UnderWayUsingEngine;
            _aisMessage03.SetRateOfTurn(0);
            _aisMessage03.SpeedOverGroundKnots = 8.5M;
            _aisMessage03.PositionAccuracy = false;
            _aisMessage03.LongitudeDecimalDegrees = -93.9687666666667M;
            _aisMessage03.LatitudeDecimalDegrees = 29.829815M;
            _aisMessage03.CourseOverGroundDegrees = 359.2M;
            _aisMessage03.TrueHeadingDegrees = 359;
            _aisMessage03.Timestamp = 0;
            _aisMessage03.SpecialManoeuvreIndicator = AISMessage03.SpecialManoeuvreIndicatorEnum.NotAvailable;
            _aisMessage03.RAIMFlag = false;
            _aisMessage03.CommunicationState = new ITDMACommunicationState()
            {
                SyncState = AISCommunicationState.SyncStateEnum.UTCDirect,
                SlotIncrement = 277,
                NumberOfSlots = 0,
                KeepFlag = false,
            };

            IList<String> actual = _aisMessage03.EncodeSentences();

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
        // ~UnitTestAISMessage03()
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
