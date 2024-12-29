using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage09 : IDisposable
    {
        private bool disposedValue;

        private const Int32 POSITIONAL_PRECISION = 5;

        private readonly AISMessage09 _aisMessage09;

        public UnitTestAISMessage09()
        {
            _aisMessage09 = new AISMessage09();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage09.UserId = userId;
            string actual = _aisMessage09.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAltitudeValid()
        {
            ushort rateOfTurn = 1000;
            ushort expected = 1000;

            _aisMessage09.Altitude = rateOfTurn;
            ushort actual = _aisMessage09.Altitude;

            Assert.Equal(expected, actual);
            Assert.True(_aisMessage09.AltitudeAvailable);
        }

        [Fact]
        public void TestAltitudeInvalid()
        {
            ushort rateOfTurn = 10000;
            ushort expected = 4095;

            _aisMessage09.Altitude = rateOfTurn;
            ushort actual = _aisMessage09.Altitude;

            Assert.Equal(expected, actual);
            Assert.False(_aisMessage09.AltitudeAvailable);
        }

        [Fact]
        public void TestSpeedOverGroundValid()
        {
            decimal speedOverGround = 100M;
            decimal expected = 100M;

            _aisMessage09.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage09.SpeedOverGroundKnots;

            Assert.True(_aisMessage09.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundInvalid()
        {
            decimal speedOverGround = 1024M;
            decimal expected = 1023M;

            _aisMessage09.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage09.SpeedOverGroundKnots;

            Assert.False(_aisMessage09.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLongitudeValid()
        {
            decimal longitude = 103.833333M;
            decimal expected = 103.833333M;

            _aisMessage09.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage09.LongitudeDecimalDegrees;

            Assert.True(_aisMessage09.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLongitudeInvalid()
        {
            decimal longitude = 181.0M;
            decimal expected = 181.0M;

            _aisMessage09.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage09.LongitudeDecimalDegrees;

            Assert.False(_aisMessage09.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeValid()
        {
            decimal latitude = 1.283333M;
            decimal expected = 1.283333M;

            _aisMessage09.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage09.LatitudeDecimalDegrees;

            Assert.True(_aisMessage09.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeInvalid()
        {
            decimal latitude = 91.0M;
            decimal expected = 91.0M;

            _aisMessage09.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage09.LatitudeDecimalDegrees;

            Assert.False(_aisMessage09.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestCourseOverGroundValid()
        {
            decimal courseOverGround = 45.0M;
            decimal expected = 45.0M;

            _aisMessage09.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage09.CourseOverGroundDegrees;

            Assert.True(_aisMessage09.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCourseOverGroundInvalid()
        {
            decimal courseOverGround = 720.0M;
            decimal expected = 360.0M;

            _aisMessage09.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage09.CourseOverGroundDegrees;

            Assert.False(_aisMessage09.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AIS09Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,91b77=h3h00nHt0Q3r@@07000<0b,0*69\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage09 aisMessage09 = aisMessage as AISMessage09;
            SOTDMACommunicationState communicationState = aisMessage09.CommunicationState as SOTDMACommunicationState;
            communicationState.GetReceivedStations(out UInt16 slotTimeout, out UInt16 receivedStations);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage09);
            Assert.Equal(9, aisMessage09.MessageId);
            Assert.Equal(0, aisMessage09.RepeatIndicator);
            Assert.Equal("111265591", aisMessage09.UserId);
            Assert.Equal(15, aisMessage09.Altitude);
            Assert.Equal(0, aisMessage09.SpeedOverGroundKnots);
            Assert.False(aisMessage09.PositionAccuracy);
            Assert.Equal(11.8816M, aisMessage09.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.Equal(57.778455M, aisMessage09.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.Equal(0, aisMessage09.CourseOverGroundDegrees);
            Assert.Equal(28, aisMessage09.Timestamp);
            Assert.True(aisMessage09.DTE);
            Assert.Equal(AISMessage09.AssignedModeEnum.AutonomousContinuousMode, aisMessage09.AssignedModeFlag);
            Assert.False(aisMessage09.CommunicationStateSelectorFlag);
            Assert.Equal(49194U, communicationState.CommunicationState);
            Assert.Equal(3, communicationState.SlotTimeout);
            Assert.Equal(3, slotTimeout);
            Assert.Equal(42, receivedStations);
        }

        [Fact]
        public void AIS09Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,91b55wi;hbOS@OdQAC062Ch2089h,0*30\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage09 aisMessage09 = aisMessage as AISMessage09;
            SOTDMACommunicationState communicationState = aisMessage09.CommunicationState as SOTDMACommunicationState;
            communicationState.GetSlotNumber(out UInt16 slotTimeout, out UInt16 slotNumber);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage09);
            Assert.Equal(9, aisMessage09.MessageId);
            Assert.Equal(0, aisMessage09.RepeatIndicator);
            Assert.Equal("111232511", aisMessage09.UserId);
            Assert.Equal(303, aisMessage09.Altitude);
            Assert.Equal(42M, aisMessage09.SpeedOverGroundKnots);
            Assert.False(aisMessage09.PositionAccuracy);
            Assert.Equal(-6.27884166666667M, aisMessage09.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.Equal(58.144M, aisMessage09.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.Equal(154.5M, aisMessage09.CourseOverGroundDegrees);
            Assert.Equal(15, aisMessage09.Timestamp);
            Assert.False(aisMessage09.DTE);
            Assert.Equal(AISMessage09.AssignedModeEnum.AutonomousContinuousMode, aisMessage09.AssignedModeFlag);
            Assert.False(aisMessage09.CommunicationStateSelectorFlag);
            Assert.Equal(33392U, communicationState.CommunicationState);
            Assert.Equal(2, communicationState.SlotTimeout);
            Assert.Equal(2, slotTimeout);
            Assert.Equal(624, slotNumber);
        }

        [Fact]
        public void AIS09Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,A,91b77=h3h00nHt0Q3r@@07000<0b,0*69\r\n"
            };

            _aisMessage09.MessageId = 9;
            _aisMessage09.RepeatIndicator = 0;
            _aisMessage09.UserId = "111265591";
            _aisMessage09.Altitude = 15;
            _aisMessage09.SpeedOverGroundKnots = 0M;
            _aisMessage09.PositionAccuracy = false;
            _aisMessage09.LongitudeDecimalDegrees = 11.8816M;
            _aisMessage09.LatitudeDecimalDegrees = 57.778455M;
            _aisMessage09.CourseOverGroundDegrees = 0M;
            _aisMessage09.Timestamp = 28;
            _aisMessage09.DTE = true;
            _aisMessage09.AssignedModeFlag = AISMessage09.AssignedModeEnum.AutonomousContinuousMode;
            _aisMessage09.CommunicationStateSelectorFlag = false;
            _aisMessage09.CommunicationState = new SOTDMACommunicationState()
            {
                CommunicationState = 49194U,
                SlotTimeout = 3,
            };

            IList<String> actual = _aisMessage09.EncodeSentences();

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
        // ~UnitTestAISMessage09()
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
