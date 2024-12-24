using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage19 : IDisposable
    {
        private bool disposedValue;

        private const Int32 POSITIONAL_PRECISION = 5;

        private readonly AISMessage19 _aisMessage19;

        public UnitTestAISMessage19()
        {
            _aisMessage19 = new AISMessage19();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage19.UserId = userId;
            string actual = _aisMessage19.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundValid()
        {
            decimal speedOverGround = 10.0M;
            decimal expected = 10.0M;

            _aisMessage19.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage19.SpeedOverGroundKnots;

            Assert.True(_aisMessage19.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSpeedOverGroundInvalid()
        {
            decimal speedOverGround = 1024.0M;
            decimal expected = 0.0M;

            _aisMessage19.SpeedOverGroundKnots = speedOverGround;
            decimal actual = _aisMessage19.SpeedOverGroundKnots;

            Assert.False(_aisMessage19.SpeedOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLongitudeValid()
        {
            decimal longitude = 103.833333M;
            decimal expected = 103.833333M;

            _aisMessage19.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage19.LongitudeDecimalDegrees;

            Assert.True(_aisMessage19.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLongitudeInvalid()
        {
            decimal longitude = 181.0M;
            decimal expected = 181.0M;

            _aisMessage19.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage19.LongitudeDecimalDegrees;

            Assert.False(_aisMessage19.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeValid()
        {
            decimal latitude = 1.283333M;
            decimal expected = 1.283333M;

            _aisMessage19.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage19.LatitudeDecimalDegrees;

            Assert.True(_aisMessage19.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeInvalid()
        {
            decimal latitude = 91.0M;
            decimal expected = 91.0M;

            _aisMessage19.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage19.LatitudeDecimalDegrees;

            Assert.False(_aisMessage19.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestCourseOverGroundValid()
        {
            decimal courseOverGround = 45.0M;
            decimal expected = 45.0M;

            _aisMessage19.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage19.CourseOverGroundDegrees;

            Assert.True(_aisMessage19.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCourseOverGroundInvalid()
        {
            decimal courseOverGround = 720.0M;
            decimal expected = 360.0M;

            _aisMessage19.CourseOverGroundDegrees = courseOverGround;
            decimal actual = _aisMessage19.CourseOverGroundDegrees;

            Assert.False(_aisMessage19.CourseOverGroundAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingValid()
        {
            ushort trueHeading = 270;
            ushort expected = 270;

            _aisMessage19.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage19.TrueHeadingDegrees;

            Assert.True(_aisMessage19.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTrueHeadingInvalid()
        {
            ushort trueHeading = 720;
            ushort expected = 511;

            _aisMessage19.TrueHeadingDegrees = trueHeading;
            ushort actual = _aisMessage19.TrueHeadingDegrees;

            Assert.False(_aisMessage19.TrueHeadingAvailable);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNameValid()
        {
            string name = "SAR AIRCRAFT NNNNNNN";
            string expected = "SAR AIRCRAFT NNNNNNN";

            _aisMessage19.Name = name;
            string actual = _aisMessage19.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNameInvalid()
        {
            string name = string.Empty;
            string expected = "@@@@@@@@@@@@@@@@@@@@";

            _aisMessage19.Name = name;
            string actual = _aisMessage19.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTypeOfShipAndCargoTypeValid()
        {
            ushort typeOfShipAndCargoType = 99;
            ushort expected = 99;

            _aisMessage19.TypeOfShipAndCargoType = typeOfShipAndCargoType;
            ushort actual = _aisMessage19.TypeOfShipAndCargoType;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTypeOfShipAndCargoTypeInvalid()
        {
            ushort typeOfShipAndCargoType = ushort.MaxValue;
            ushort expected = 255;

            _aisMessage19.TypeOfShipAndCargoType = typeOfShipAndCargoType;
            ushort actual = _aisMessage19.TypeOfShipAndCargoType;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToBowValid()
        {
            ushort dimeToBow = 200;
            ushort expected = 200;

            _aisMessage19.DimensionToBow = dimeToBow;
            ushort actual = _aisMessage19.DimensionToBow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToBowInvalid()
        {
            ushort dimeToBow = ushort.MaxValue;
            ushort expected = 511;

            _aisMessage19.DimensionToBow = dimeToBow;
            ushort actual = _aisMessage19.DimensionToBow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToSternValid()
        {
            ushort dimeToStern = 200;
            ushort expected = 200;

            _aisMessage19.DimensionToStern = dimeToStern;
            ushort actual = _aisMessage19.DimensionToStern;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToSternInvalid()
        {
            ushort dimeToStern = ushort.MaxValue;
            ushort expected = 511;

            _aisMessage19.DimensionToStern = dimeToStern;
            ushort actual = _aisMessage19.DimensionToStern;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToPortValid()
        {
            ushort dimeToPort = 52;
            ushort expected = 52;

            _aisMessage19.DimensionToPort = dimeToPort;
            ushort actual = _aisMessage19.DimensionToPort;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToPortInvalid()
        {
            ushort dimeToPort = ushort.MaxValue;
            ushort expected = 63;

            _aisMessage19.DimensionToPort = dimeToPort;
            ushort actual = _aisMessage19.DimensionToPort;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToStarboardValid()
        {
            ushort dimeToStarboard = 47;
            ushort expected = 47;

            _aisMessage19.DimensionToStarboard = dimeToStarboard;
            ushort actual = _aisMessage19.DimensionToStarboard;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToStarboardInvalid()
        {
            ushort dimeToStarboard = ushort.MaxValue;
            ushort expected = 63;

            _aisMessage19.DimensionToStarboard = dimeToStarboard;
            ushort actual = _aisMessage19.DimensionToStarboard;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLengthOverallValid()
        {
            ushort dimeToBow = 47;
            ushort dimeToStern = 47;
            ushort expected = (ushort)(dimeToBow + dimeToStern);

            _aisMessage19.DimensionToBow = dimeToBow;
            _aisMessage19.DimensionToStern = dimeToStern;
            ushort actual = _aisMessage19.LengthOverall;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLengthOverallInvalid()
        {
            ushort dimeToBow = 512;
            ushort dimeToStern = 512;
            ushort expected = 511;

            _aisMessage19.LengthOverall = (ushort)(dimeToBow + dimeToStern);
            ushort actual = _aisMessage19.LengthOverall;

            Assert.Equal(expected, actual);
            Assert.Equal(0, _aisMessage19.DimensionToBow);
            Assert.Equal(expected, _aisMessage19.DimensionToStern);
        }

        [Fact]
        public void TestBeamOverallValid()
        {
            ushort dimeToPort = 23;
            ushort dimeToStarboard = 23;
            ushort expected = (ushort)(dimeToPort + dimeToStarboard);

            _aisMessage19.DimensionToPort = dimeToPort;
            _aisMessage19.DimensionToStarboard = dimeToStarboard;
            ushort actual = _aisMessage19.BeamOverall;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBeamOverallInvalid()
        {
            ushort dimeToPort = 64;
            ushort dimeToStarboard = 64;
            ushort expected = 63;

            _aisMessage19.BeamOverall = (ushort)(dimeToPort + dimeToStarboard);
            ushort actual = _aisMessage19.BeamOverall;

            Assert.Equal(expected, actual);
            Assert.Equal(0, _aisMessage19.DimensionToPort);
            Assert.Equal(expected, _aisMessage19.DimensionToStarboard);
        }

        [Fact]
        public void TestAIS19Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,C5N3SRP0EnJGEBT>NhWAwwo062PaLELTBJ:V00000000S0D:R220,0*54\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage19 aisMessage19 = aisMessage as AISMessage19;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage19);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage19.SentenceFormatter);
            Assert.Equal(19, aisMessage19.MessageId);
            Assert.Equal(0, aisMessage19.RepeatIndicator);
            Assert.Equal("367059850", aisMessage19.UserId);
            Assert.Equal(8.7M, aisMessage19.SpeedOverGroundKnots);
            Assert.True(aisMessage19.SpeedOverGroundAvailable);
            Assert.False(aisMessage19.PositionAccuracy);
            Assert.Equal(-88.810391M, aisMessage19.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage19.LongitudeAvailable);
            Assert.Equal(29.543695M, aisMessage19.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage19.LatitudeAvailable);
            Assert.Equal(335.9M, aisMessage19.CourseOverGroundDegrees);
            Assert.True(aisMessage19.CourseOverGroundAvailable);
            Assert.Equal(511, aisMessage19.TrueHeadingDegrees);
            Assert.False(aisMessage19.TrueHeadingAvailable);
            Assert.Equal(46, aisMessage19.Timestamp);
            Assert.Equal("CAPT.J.RIMES@@@@@@@@", aisMessage19.Name);
            Assert.Equal(70, aisMessage19.TypeOfShipAndCargoType);
            Assert.Equal(5, aisMessage19.DimensionToBow);
            Assert.Equal(21, aisMessage19.DimensionToStern);
            Assert.Equal(4, aisMessage19.DimensionToPort);
            Assert.Equal(4, aisMessage19.DimensionToStarboard);
            Assert.Equal(AISMessage19.ElectronicPositionFixingDeviceEnum.GPS, aisMessage19.TypeOfElectronicPositionFixingDevice);
            Assert.False(aisMessage19.RAIMFlag);
            Assert.True(aisMessage19.DTE);
            Assert.Equal(AISMessage19.AssignedModeEnum.AutonomousContinuousMode, aisMessage19.AssignedModeFlag);
        }

        [Fact]
        public void TestAIS19Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,B,C5N3SRP0EnJGEBT>NhWAwwo062PaLELTBJ:V00000000S0D:R220,0*54\r\n"
            };

            _aisMessage19.MessageId = 19;
            _aisMessage19.RepeatIndicator = 0;
            _aisMessage19.UserId = "367059850";
            _aisMessage19.SpeedOverGroundKnots = 8.7M;
            _aisMessage19.PositionAccuracy = false;
            _aisMessage19.LongitudeDecimalDegrees = -88.810391M;
            _aisMessage19.LatitudeDecimalDegrees = 29.543695M;
            _aisMessage19.CourseOverGroundDegrees = 335.9M;
            _aisMessage19.TrueHeadingDegrees = 511;
            _aisMessage19.Timestamp = 46;
            _aisMessage19.Name = "CAPT.J.RIMES";
            _aisMessage19.TypeOfShipAndCargoType = 70;
            _aisMessage19.DimensionToBow = 5;
            _aisMessage19.DimensionToStern = 21;
            _aisMessage19.DimensionToPort = 4;
            _aisMessage19.DimensionToStarboard = 4;
            _aisMessage19.TypeOfElectronicPositionFixingDevice = AISMessage19.ElectronicPositionFixingDeviceEnum.GPS;
            _aisMessage19.RAIMFlag = false;
            _aisMessage19.DTE = true;
            _aisMessage19.AssignedModeFlag = AISMessage19.AssignedModeEnum.AutonomousContinuousMode;

            IList<String> actual = _aisMessage19.EncodeSentences();

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
        // ~UnitTestAISMessage19()
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
