using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage05 : IDisposable
    {
        private bool disposedValue;

        private const Int32 POSITIONAL_PRECISION = 5;

        private readonly AISMessage05 _aisMessage05;

        public UnitTestAISMessage05()
        {
            _aisMessage05 = new AISMessage05();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage05.UserId = userId;
            string actual = _aisMessage05.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAISVersion()
        {
            AISMessage05.AISVersionEnum version = AISMessage05.AISVersionEnum.CompliantWithFutureVersion;
            AISMessage05.AISVersionEnum expected = AISMessage05.AISVersionEnum.CompliantWithFutureVersion;

            _aisMessage05.AISVersion = version;
            AISMessage05.AISVersionEnum actual = _aisMessage05.AISVersion;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestIMONumber()
        {
            string imoNumber = "1073741823";
            string expected = "1073741823";

            _aisMessage05.IMONumber = imoNumber;
            string actual = _aisMessage05.IMONumber;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCallSign()
        {
            string callsign = "FIRENZE";
            string expected = "FIRENZE";

            _aisMessage05.CallSign = callsign;
            string actual = _aisMessage05.CallSign;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNameValid()
        {
            string name = "SAR AIRCRAFT NNNNNNN";
            string expected = "SAR AIRCRAFT NNNNNNN";

            _aisMessage05.Name = name;
            string actual = _aisMessage05.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNameInvalid()
        {
            string name = string.Empty;
            string expected = "@@@@@@@@@@@@@@@@@@@@";

            _aisMessage05.Name = name;
            string actual = _aisMessage05.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTypeOfShipAndCargoTypeValid()
        {
            ushort typeOfShipAndCargoType = 99;
            ushort expected = 99;

            _aisMessage05.TypeOfShipAndCargoType = typeOfShipAndCargoType;
            ushort actual = _aisMessage05.TypeOfShipAndCargoType;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTypeOfShipAndCargoTypeInvalid()
        {
            ushort typeOfShipAndCargoType = ushort.MaxValue;
            ushort expected = 255;

            _aisMessage05.TypeOfShipAndCargoType = typeOfShipAndCargoType;
            ushort actual = _aisMessage05.TypeOfShipAndCargoType;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToBowValid()
        {
            ushort dimeToBow = 200;
            ushort expected = 200;

            _aisMessage05.DimensionToBow = dimeToBow;
            ushort actual = _aisMessage05.DimensionToBow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToBowInvalid()
        {
            ushort dimeToBow = ushort.MaxValue;
            ushort expected = 511;

            _aisMessage05.DimensionToBow = dimeToBow;
            ushort actual = _aisMessage05.DimensionToBow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToSternValid()
        {
            ushort dimeToStern = 200;
            ushort expected = 200;

            _aisMessage05.DimensionToStern = dimeToStern;
            ushort actual = _aisMessage05.DimensionToStern;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToSternInvalid()
        {
            ushort dimeToStern = ushort.MaxValue;
            ushort expected = 511;

            _aisMessage05.DimensionToStern = dimeToStern;
            ushort actual = _aisMessage05.DimensionToStern;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToPortValid()
        {
            ushort dimeToPort = 52;
            ushort expected = 52;

            _aisMessage05.DimensionToPort = dimeToPort;
            ushort actual = _aisMessage05.DimensionToPort;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToPortInvalid()
        {
            ushort dimeToPort = ushort.MaxValue;
            ushort expected = 63;

            _aisMessage05.DimensionToPort = dimeToPort;
            ushort actual = _aisMessage05.DimensionToPort;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToStarboardValid()
        {
            ushort dimeToStarboard = 47;
            ushort expected = 47;

            _aisMessage05.DimensionToStarboard = dimeToStarboard;
            ushort actual = _aisMessage05.DimensionToStarboard;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToStarboardInvalid()
        {
            ushort dimeToStarboard = ushort.MaxValue;
            ushort expected = 63;

            _aisMessage05.DimensionToStarboard = dimeToStarboard;
            ushort actual = _aisMessage05.DimensionToStarboard;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLengthOverallValid()
        {
            ushort dimeToBow = 47;
            ushort dimeToStern = 47;
            ushort expected = (ushort)(dimeToBow + dimeToStern);

            _aisMessage05.DimensionToBow = dimeToBow;
            _aisMessage05.DimensionToStern = dimeToStern;
            ushort actual = _aisMessage05.LengthOverall;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLengthOverallInvalid()
        {
            ushort dimeToBow = 512;
            ushort dimeToStern = 512;
            ushort expected = 511;

            _aisMessage05.LengthOverall = (ushort)(dimeToBow + dimeToStern);
            ushort actual = _aisMessage05.LengthOverall;

            Assert.Equal(expected, actual);
            Assert.Equal(0, _aisMessage05.DimensionToBow);
            Assert.Equal(expected, _aisMessage05.DimensionToStern);
        }

        [Fact]
        public void TestBeamOverallValid()
        {
            ushort dimeToPort = 23;
            ushort dimeToStarboard = 23;
            ushort expected = (ushort)(dimeToPort + dimeToStarboard);

            _aisMessage05.DimensionToPort = dimeToPort;
            _aisMessage05.DimensionToStarboard = dimeToStarboard;
            ushort actual = _aisMessage05.BeamOverall;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBeamOverallInvalid()
        {
            ushort dimeToPort = 64;
            ushort dimeToStarboard = 64;
            ushort expected = 63;

            _aisMessage05.BeamOverall = (ushort)(dimeToPort + dimeToStarboard);
            ushort actual = _aisMessage05.BeamOverall;

            Assert.Equal(expected, actual);
            Assert.Equal(0, _aisMessage05.DimensionToPort);
            Assert.Equal(expected, _aisMessage05.DimensionToStarboard);
        }

        [Fact]
        public void TestDestinationValid()
        {
            string destination = "SCHAFFHAUSERRHEINWEG";
            string expected = "SCHAFFHAUSERRHEINWEG";

            _aisMessage05.Destination = destination;
            string actual = _aisMessage05.Destination;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDestinationInvalid()
        {
            string destination = string.Empty;
            string expected = "@@@@@@@@@@@@@@@@@@@@";

            _aisMessage05.Destination = destination;
            string actual = _aisMessage05.Destination;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AIS05Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,2,1,0,A,58wt8Ui`g??r21`7S=:22058<v05Htp000000015>8OA;0sk,0*7B\r\n",
                "!AIVDM,2,2,0,A,eQ8823mDm3kP00000000000,2*5D\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage05 aisMessage05 = aisMessage as AISMessage05;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage05);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage05.SentenceFormatter);
            Assert.Equal(5, aisMessage05.MessageId);
            Assert.Equal(0, aisMessage05.RepeatIndicator);
            Assert.Equal("603916439", aisMessage05.UserId);
            Assert.Equal(AISMessage05.AISVersionEnum.CompliantWithRecommendationITU_R_M_1371_1, aisMessage05.AISVersion);
            Assert.Equal("439303422", aisMessage05.IMONumber);
            Assert.Equal("  ZA83R", aisMessage05.CallSign);
            Assert.Equal("   ARCO AVON@@@@@@@@", aisMessage05.Name);
            Assert.Equal(69, aisMessage05.TypeOfShipAndCargoType);
            Assert.Equal(113, aisMessage05.DimensionToBow);
            Assert.Equal(31, aisMessage05.DimensionToStern);
            Assert.Equal(17, aisMessage05.DimensionToPort);
            Assert.Equal(11, aisMessage05.DimensionToStarboard);
            Assert.Equal(AISMessage05.ElectronicPositionFixingDeviceEnum.Undefined, aisMessage05.TypeOfElectronicPositionFixingDevice);
            Assert.Equal(3, aisMessage05.ETAMonthUTC);
            Assert.Equal(23, aisMessage05.ETADayUTC);
            Assert.Equal(19, aisMessage05.ETAHourUTC);
            Assert.Equal(45, aisMessage05.ETAMinuteUTC);
            Assert.Equal(13.2M, aisMessage05.MaximumPresentStaticDraught);
            Assert.Equal("  HOUSTON@@@@@@@@@@@", aisMessage05.Destination);
            Assert.True(aisMessage05.DTE);
        }

        [Fact]
        public void AIS05Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,2,1,1,A,55?MbV02;H;s<HtKR20EHE:0@T4@Dn2222222216L961O5Gf0NSQEp6ClRp8,0*1C\r\n",
                "!AIVDM,2,2,1,A,88888888880,2*25\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage05 aisMessage05 = aisMessage as AISMessage05;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage05);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage05.SentenceFormatter);
            Assert.Equal(5, aisMessage05.MessageId);
            Assert.Equal(0, aisMessage05.RepeatIndicator);
            Assert.Equal("351759000", aisMessage05.UserId);
            Assert.Equal(AISMessage05.AISVersionEnum.CompliantWithRecommendationITU_R_M_1371_1, aisMessage05.AISVersion);
            Assert.Equal("009134270", aisMessage05.IMONumber);
            Assert.Equal("3FOF8  ", aisMessage05.CallSign);
            Assert.Equal("EVER DIADEM         ", aisMessage05.Name);
            Assert.Equal(70, aisMessage05.TypeOfShipAndCargoType);
            Assert.Equal(225, aisMessage05.DimensionToBow);
            Assert.Equal(70, aisMessage05.DimensionToStern);
            Assert.Equal(1, aisMessage05.DimensionToPort);
            Assert.Equal(31, aisMessage05.DimensionToStarboard);
            Assert.Equal(AISMessage05.ElectronicPositionFixingDeviceEnum.GPS, aisMessage05.TypeOfElectronicPositionFixingDevice);
            Assert.Equal(5, aisMessage05.ETAMonthUTC);
            Assert.Equal(15, aisMessage05.ETADayUTC);
            Assert.Equal(14, aisMessage05.ETAHourUTC);
            Assert.Equal(0, aisMessage05.ETAMinuteUTC);
            Assert.Equal(12.2M, aisMessage05.MaximumPresentStaticDraught);
            Assert.Equal("NEW YORK            ", aisMessage05.Destination);
            Assert.True(aisMessage05.DTE);
        }

        [Fact]
        public void AIS05Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,2,1,0,A,58wt8Ui`g??r21`7S=:22058<v05Htp000000015>8OA;0skeQ,0*4F\r\n",
                "!AIVDM,2,2,0,A,8823mDm3kP00000000000,2*69\r\n"
            };

            _aisMessage05.MessageId = 5;
            _aisMessage05.RepeatIndicator = 0;
            _aisMessage05.UserId = "603916439";
            _aisMessage05.AISVersion = AISMessage05.AISVersionEnum.CompliantWithRecommendationITU_R_M_1371_1;
            _aisMessage05.IMONumber = "439303422";
            _aisMessage05.CallSign = "  ZA83R";
            _aisMessage05.Name = "   ARCO AVON@@@@@@@@";
            _aisMessage05.TypeOfShipAndCargoType = 69;
            _aisMessage05.DimensionToBow = 113;
            _aisMessage05.DimensionToStern = 31;
            _aisMessage05.DimensionToPort = 17;
            _aisMessage05.DimensionToStarboard = 11;
            _aisMessage05.TypeOfElectronicPositionFixingDevice = AISMessage05.ElectronicPositionFixingDeviceEnum.Undefined;
            _aisMessage05.ETAMonthUTC = 3;
            _aisMessage05.ETADayUTC = 23;
            _aisMessage05.ETAHourUTC = 19;
            _aisMessage05.ETAMinuteUTC = 45;
            _aisMessage05.MaximumPresentStaticDraught = 13.2M;
            _aisMessage05.Destination = "  HOUSTON@@@@@@@@@@@";
            _aisMessage05.DTE = true;

            IList<String> actual = _aisMessage05.EncodeSentences();

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
        // ~UnitTestAISMessage05()
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
