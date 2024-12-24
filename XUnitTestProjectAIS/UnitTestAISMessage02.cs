using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage02 : IDisposable
    {
        private bool disposedValue;

        private const Int32 POSITIONAL_PRECISION = 5;
        private const Int32 ROT_PRECISION = 0;

        private readonly AISMessage02 _aisMessage02;

        public UnitTestAISMessage02()
        {
            _aisMessage02 = new AISMessage02();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage02.UserId = userId;
            string actual = _aisMessage02.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNavigationStatu()
        {
            AISMessage02.NavigationalStatusEnum navStatus = AISMessage02.NavigationalStatusEnum.UnderWayUsingEngine;
            AISMessage02.NavigationalStatusEnum expected = AISMessage02.NavigationalStatusEnum.UnderWayUsingEngine;

            _aisMessage02.NavigationalStatus = navStatus;
            AISMessage02.NavigationalStatusEnum actual = _aisMessage02.NavigationalStatus;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRateOfTurnPortValid()
        {
            double rateOfTurn = -362.0;
            double expected = -362.0;

            _aisMessage02.SetRateOfTurn(rateOfTurn);
            double actual = _aisMessage02.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.True(_aisMessage02.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnPortInvalid()
        {
            double rateOfTurn = -362.0;
            double expected = -10.0;

            _aisMessage02.SetRateOfTurn(rateOfTurn, false);
            double actual = _aisMessage02.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.False(_aisMessage02.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnStarboardValid()
        {
            double rateOfTurn = 362.0;
            double expected = 362.0;

            _aisMessage02.SetRateOfTurn(rateOfTurn);
            double actual = _aisMessage02.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.True(_aisMessage02.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnStarboardInvalid()
        {
            double rateOfTurn = 362.0;
            double expected = 10.0;

            _aisMessage02.SetRateOfTurn(rateOfTurn, false);
            double actual = _aisMessage02.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.False(_aisMessage02.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnNoInformation()
        {
            bool expected = false;

            _aisMessage02.SetNoTurnInformation();
            bool actual = _aisMessage02.TurnInformationAvailable;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundValid()
        {
            decimal speedOverGround = 10.0M;
            decimal expected = 10.0M;

            _aisMessage02.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage02.SpeedOverGroundKnots;

            Assert.True(_aisMessage02.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundInvalid()
        {
            decimal speedOverGround = 102.4M;
            decimal expected = 102.3M;

            _aisMessage02.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage02.SpeedOverGroundKnots;

            Assert.False(_aisMessage02.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLongitudeValid()
        {
            decimal longitude = 103.833333M;
            decimal expected = 103.833333M;

            _aisMessage02.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage02.LongitudeDecimalDegrees;

            Assert.True(_aisMessage02.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLongitudeInvalid()
        {
            decimal longitude = 181.0M;
            decimal expected = 181.0M;

            _aisMessage02.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage02.LongitudeDecimalDegrees;

            Assert.False(_aisMessage02.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeValid()
        {
            decimal latitude = 1.283333M;
            decimal expected = 1.283333M;

            _aisMessage02.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage02.LatitudeDecimalDegrees;

            Assert.True(_aisMessage02.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeInvalid()
        {
            decimal latitude = 91.0M;
            decimal expected = 91.0M;

            _aisMessage02.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage02.LatitudeDecimalDegrees;

            Assert.False(_aisMessage02.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestCourseOverGroundValid()
        {
            decimal courseOverGround = 45.0M;
            decimal expected = 45.0M;

            _aisMessage02.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage02.CourseOverGroundDegrees;

            Assert.True(_aisMessage02.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCourseOverGroundInvalid()
        {
            decimal courseOverGround = 720.0M;
            decimal expected = 360.0M;

            _aisMessage02.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage02.CourseOverGroundDegrees;

            Assert.False(_aisMessage02.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingValid()
        {
            ushort trueHeading = 270;
            ushort expected = 270;

            _aisMessage02.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage02.TrueHeadingDegrees;

            Assert.True(_aisMessage02.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingInvalid()
        {
            ushort trueHeading = 720;
            ushort expected = 511;

            _aisMessage02.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage02.TrueHeadingDegrees;

            Assert.False(_aisMessage02.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AIS02Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,25Mw@DP000qR9bFA:6KI;QV@0000,0*72\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage02 aisMessage02 = aisMessage as AISMessage02;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage02);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage02.SentenceFormatter);
            Assert.Equal(2, aisMessage02.MessageId);
            Assert.Equal(0, aisMessage02.RepeatIndicator);
            Assert.Equal("366989394", aisMessage02.UserId);
            Assert.Equal(AISMessage02.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage02.NavigationalStatus);
            Assert.Equal(0, aisMessage02.RateOfTurnDegreesPerMinute);
            Assert.True(aisMessage02.TurnIndicatorAvailable);
            Assert.True(aisMessage02.TurnInformationAvailable);
            Assert.Equal(0, aisMessage02.SpeedOverGroundKnots);
            Assert.True(aisMessage02.SpeedOverGroundAvailable);
            Assert.True(aisMessage02.PositionAccuracy);
            Assert.Equal(-90.4067M, aisMessage02.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage02.LongitudeAvailable);
            Assert.Equal(29.9854616666667M, aisMessage02.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage02.LatitudeAvailable);
            Assert.Equal(235.0M, aisMessage02.CourseOverGroundDegrees);
            Assert.True(aisMessage02.CourseOverGroundAvailable);
            Assert.Equal(51, aisMessage02.TrueHeadingDegrees);
            Assert.True(aisMessage02.TrueHeadingAvailable);
            Assert.Equal(8, aisMessage02.Timestamp);
            Assert.Equal(AISMessage02.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage02.SpecialManoeuvreIndicator);
            Assert.False(aisMessage02.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage02.CommunicationState.SyncState);
            Assert.Equal(0, aisMessage02.CommunicationState.SlotTimeout);
        }

        [Fact]
        public void AIS02Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,25Cjtd0Oj;Jp7ilG7=UkKBoB0<06,0*60\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage02 aisMessage02 = aisMessage as AISMessage02;
            SOTDMACommunicationState communicationState = aisMessage02.CommunicationState;
            communicationState.GetReceivedStations(out UInt16 slotTimeout, out UInt16 receivedStations);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage02);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage02.SentenceFormatter);
            Assert.Equal(2, aisMessage02.MessageId);
            Assert.Equal(0, aisMessage02.RepeatIndicator);
            Assert.Equal("356302000", aisMessage02.UserId);
            Assert.Equal(AISMessage02.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage02.NavigationalStatus);
            Assert.Equal(10, aisMessage02.RateOfTurnDegreesPerMinute);
            Assert.False(aisMessage02.TurnIndicatorAvailable);
            Assert.True(aisMessage02.TurnInformationAvailable);
            Assert.Equal(13.9M, aisMessage02.SpeedOverGroundKnots);
            Assert.True(aisMessage02.SpeedOverGroundAvailable);
            Assert.False(aisMessage02.PositionAccuracy);
            Assert.Equal(-71.626144M, aisMessage02.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage02.LongitudeAvailable);
            Assert.Equal(40.39236M, aisMessage02.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage02.LatitudeAvailable);
            Assert.Equal(87.7M, aisMessage02.CourseOverGroundDegrees);
            Assert.True(aisMessage02.CourseOverGroundAvailable);
            Assert.Equal(91, aisMessage02.TrueHeadingDegrees);
            Assert.True(aisMessage02.TrueHeadingAvailable);
            Assert.Equal(41, aisMessage02.Timestamp);
            Assert.Equal(AISMessage02.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage02.SpecialManoeuvreIndicator);
            Assert.False(aisMessage02.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage02.CommunicationState.SyncState);
            Assert.Equal(3, aisMessage02.CommunicationState.SlotTimeout);
            Assert.Equal(3, slotTimeout);
            Assert.Equal(6, receivedStations);
        }

        [Fact]
        public void AIS02Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,A,25Mw@DP000qR9bFA:6KI;QV@0000,0*72\r\n"
            };

            _aisMessage02.MessageId = 2;
            _aisMessage02.RepeatIndicator = 0;
            _aisMessage02.UserId = "366989394";
            _aisMessage02.NavigationalStatus = AISMessage02.NavigationalStatusEnum.UnderWayUsingEngine;
            _aisMessage02.SetRateOfTurn(0);
            _aisMessage02.SpeedOverGroundKnots = 0.0M;
            _aisMessage02.PositionAccuracy = true;
            _aisMessage02.LongitudeDecimalDegrees = -90.4067M;
            _aisMessage02.LatitudeDecimalDegrees = 29.9854616666667M;
            _aisMessage02.CourseOverGroundDegrees = 235.0M;
            _aisMessage02.TrueHeadingDegrees = 51;
            _aisMessage02.Timestamp = 8;
            _aisMessage02.SpecialManoeuvreIndicator = AISMessage02.SpecialManoeuvreIndicatorEnum.NotAvailable;
            _aisMessage02.RAIMFlag = false;
            _aisMessage02.CommunicationState = new SOTDMACommunicationState()
            {
                SyncState = AISCommunicationState.SyncStateEnum.UTCDirect,
            };

            IList<String> actual = _aisMessage02.EncodeSentences();

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
        // ~UnitTestAISMessage02()
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
