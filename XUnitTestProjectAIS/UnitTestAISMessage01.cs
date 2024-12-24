using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage01 : IDisposable
    {
        private bool disposedValue;

        private const Int32 POSITIONAL_PRECISION = 5;
        private const Int32 ROT_PRECISION = 0;

        private readonly AISMessage01 _aisMessage01;

        public UnitTestAISMessage01()
        {
            _aisMessage01 = new AISMessage01();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage01.UserId = userId;
            string actual = _aisMessage01.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNavigationStatu()
        {
            AISMessage01.NavigationalStatusEnum navStatus = AISMessage01.NavigationalStatusEnum.UnderWayUsingEngine;
            AISMessage01.NavigationalStatusEnum expected = AISMessage01.NavigationalStatusEnum.UnderWayUsingEngine;

            _aisMessage01.NavigationalStatus = navStatus;
            AISMessage01.NavigationalStatusEnum actual = _aisMessage01.NavigationalStatus;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRateOfTurnPortValid()
        {
            double rateOfTurn = -362.0;
            double expected = -362.0;

            _aisMessage01.SetRateOfTurn(rateOfTurn);
            double actual = _aisMessage01.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.True(_aisMessage01.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnPortInvalid()
        {
            double rateOfTurn = -362.0;
            double expected = -10.0;

            _aisMessage01.SetRateOfTurn(rateOfTurn, false);
            double actual = _aisMessage01.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.False(_aisMessage01.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnStarboardValid()
        {
            double rateOfTurn = 362.0;
            double expected = 362.0;

            _aisMessage01.SetRateOfTurn(rateOfTurn);
            double actual = _aisMessage01.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.True(_aisMessage01.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnStarboardInvalid()
        {
            double rateOfTurn = 362.0;
            double expected = 10.0;

            _aisMessage01.SetRateOfTurn(rateOfTurn, false);
            double actual = _aisMessage01.RateOfTurnDegreesPerMinute;

            Assert.Equal(expected, actual, ROT_PRECISION);
            Assert.False(_aisMessage01.TurnIndicatorAvailable);
        }

        [Fact]
        public void TestRateOfTurnNoInformation()
        {
            bool expected = false;

            _aisMessage01.SetNoTurnInformation();
            bool actual = _aisMessage01.TurnInformationAvailable;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundValid()
        {
            decimal speedOverGround = 10.0M;
            decimal expected = 10.0M;

            _aisMessage01.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage01.SpeedOverGroundKnots;

            Assert.True(_aisMessage01.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundInvalid()
        {
            decimal speedOverGround = 102.4M;
            decimal expected = 102.3M;

            _aisMessage01.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage01.SpeedOverGroundKnots;

            Assert.False(_aisMessage01.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLongitudeValid()
        {
            decimal longitude = 103.833333M;
            decimal expected = 103.833333M;

            _aisMessage01.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage01.LongitudeDecimalDegrees;

            Assert.True(_aisMessage01.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLongitudeInvalid()
        {
            decimal longitude = 181.0M;
            decimal expected = 181.0M;

            _aisMessage01.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage01.LongitudeDecimalDegrees;

            Assert.False(_aisMessage01.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeValid()
        {
            decimal latitude = 1.283333M;
            decimal expected = 1.283333M;

            _aisMessage01.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage01.LatitudeDecimalDegrees;

            Assert.True(_aisMessage01.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeInvalid()
        {
            decimal latitude = 91.0M;
            decimal expected = 91.0M;

            _aisMessage01.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage01.LatitudeDecimalDegrees;

            Assert.False(_aisMessage01.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestCourseOverGroundValid()
        {
            decimal courseOverGround = 45.0M;
            decimal expected = 45.0M;

            _aisMessage01.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage01.CourseOverGroundDegrees;

            Assert.True(_aisMessage01.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCourseOverGroundInvalid()
        {
            decimal courseOverGround = 720.0M;
            decimal expected = 360.0M;

            _aisMessage01.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage01.CourseOverGroundDegrees;

            Assert.False(_aisMessage01.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingValid()
        {
            ushort trueHeading = 270;
            ushort expected = 270;

            _aisMessage01.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage01.TrueHeadingDegrees;

            Assert.True(_aisMessage01.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingInvalid()
        {
            ushort trueHeading = 720;
            ushort expected = 511;

            _aisMessage01.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage01.TrueHeadingDegrees;

            Assert.False(_aisMessage01.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AIS01Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,14eG;o@034o8sd>L9i:I;WF>062D,0*57\r\n"
            };
            TimeSpan excpectedUTC = new TimeSpan(16, 37, 0);

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage01 aisMessage01 = aisMessage as AISMessage01;
            aisMessage01.CommunicationState.GetUTCHourAndMinute(out UInt16 slotTimeout, out TimeSpan utcTime);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage01);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage01.SentenceFormatter);
            Assert.Equal(1, aisMessage01.MessageId);
            Assert.Equal(0, aisMessage01.RepeatIndicator);
            Assert.Equal("316001245", aisMessage01.UserId);
            Assert.Equal(AISMessage01.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage01.NavigationalStatus);
            Assert.Equal(0, aisMessage01.RateOfTurnDegreesPerMinute);
            Assert.True(aisMessage01.TurnIndicatorAvailable);
            Assert.True(aisMessage01.TurnInformationAvailable);
            Assert.Equal(19.6M, aisMessage01.SpeedOverGroundKnots);
            Assert.True(aisMessage01.SpeedOverGroundAvailable);
            Assert.True(aisMessage01.PositionAccuracy);
            Assert.Equal(-123.877748M, aisMessage01.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage01.LongitudeAvailable);
            Assert.Equal(49.200283M, aisMessage01.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage01.LatitudeAvailable);
            Assert.Equal(235.0M, aisMessage01.CourseOverGroundDegrees);
            Assert.True(aisMessage01.CourseOverGroundAvailable);
            Assert.Equal(235, aisMessage01.TrueHeadingDegrees);
            Assert.True(aisMessage01.TrueHeadingAvailable);
            Assert.Equal(7, aisMessage01.Timestamp);
            Assert.Equal(AISMessage01.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage01.SpecialManoeuvreIndicator);
            Assert.False(aisMessage01.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage01.CommunicationState.SyncState);
            Assert.Equal(1, aisMessage01.CommunicationState.SlotTimeout);
            Assert.Equal(1, slotTimeout);
            Assert.Equal(excpectedUTC, utcTime);
        }

        [Fact]
        public void AIS01Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,15RTgt0PAso;90TKcjM8h6g208CQ,0*4A\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage01 aisMessage01 = aisMessage as AISMessage01;
            aisMessage01.CommunicationState.GetSlotNumber(out UInt16 slotTimeout, out UInt16 slotNumber);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage01);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage01.SentenceFormatter);
            Assert.Equal(1, aisMessage01.MessageId);
            Assert.Equal(0, aisMessage01.RepeatIndicator);
            Assert.Equal("371798000", aisMessage01.UserId);
            Assert.Equal(AISMessage01.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage01.NavigationalStatus);
            Assert.Equal(-10, aisMessage01.RateOfTurnDegreesPerMinute);
            Assert.False(aisMessage01.TurnIndicatorAvailable);
            Assert.True(aisMessage01.TurnInformationAvailable);
            Assert.Equal(12.3M, aisMessage01.SpeedOverGroundKnots);
            Assert.True(aisMessage01.SpeedOverGroundAvailable);
            Assert.True(aisMessage01.PositionAccuracy);
            Assert.Equal(-123.395383M, aisMessage01.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage01.LongitudeAvailable);
            Assert.Equal(48.381633M, aisMessage01.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage01.LatitudeAvailable);
            Assert.Equal(224.0M, aisMessage01.CourseOverGroundDegrees);
            Assert.True(aisMessage01.CourseOverGroundAvailable);
            Assert.Equal(215, aisMessage01.TrueHeadingDegrees);
            Assert.True(aisMessage01.TrueHeadingAvailable);
            Assert.Equal(33, aisMessage01.Timestamp);
            Assert.Equal(AISMessage01.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage01.SpecialManoeuvreIndicator);
            Assert.False(aisMessage01.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage01.CommunicationState.SyncState);
            Assert.Equal(2, aisMessage01.CommunicationState.SlotTimeout);
            Assert.Equal(2, slotTimeout);
            Assert.Equal(1249, slotNumber);
        }

        [Fact]
        public void AIS01Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,A,14eG;o@034o8sd>L9i:I;WF>062D,0*57\r\n"
            };
            TimeSpan timeUTC = new TimeSpan(16, 37, 0);

            _aisMessage01.MessageId = 1;
            _aisMessage01.RepeatIndicator = 0;
            _aisMessage01.UserId = "316001245";
            _aisMessage01.NavigationalStatus = AISMessage01.NavigationalStatusEnum.UnderWayUsingEngine;
            _aisMessage01.SetRateOfTurn(0);
            _aisMessage01.SpeedOverGroundKnots = 19.6M;
            _aisMessage01.PositionAccuracy = true;
            _aisMessage01.LongitudeDecimalDegrees = -123.877748M;
            _aisMessage01.LatitudeDecimalDegrees = 49.200283M;
            _aisMessage01.CourseOverGroundDegrees = 235.0M;
            _aisMessage01.TrueHeadingDegrees = 235;
            _aisMessage01.Timestamp = 7;
            _aisMessage01.SpecialManoeuvreIndicator = AISMessage01.SpecialManoeuvreIndicatorEnum.NotAvailable;
            _aisMessage01.RAIMFlag = false;
            _aisMessage01.CommunicationState = new SOTDMACommunicationState()
            {
                SyncState = AISCommunicationState.SyncStateEnum.UTCDirect,
            };
            _aisMessage01.CommunicationState.SetUTCHourAndMinute(1, timeUTC);

            IList<String> actual = _aisMessage01.EncodeSentences();

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
        // ~UnitTestAISMessage01()
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
