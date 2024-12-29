using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage24 : IDisposable
    {
        private bool disposedValue;

        private readonly AISMessage24 _aisMessage24;

        public UnitTestAISMessage24()
        {
            _aisMessage24 = new AISMessage24();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage24.UserId = userId;
            string actual = _aisMessage24.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNameValid()
        {
            string name = "SAR AIRCRAFT NNNNNNN";
            string expected = "SAR AIRCRAFT NNNNNNN";

            _aisMessage24.Name = name;
            string actual = _aisMessage24.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNameInvalid()
        {
            string name = string.Empty;
            string expected = "@@@@@@@@@@@@@@@@@@@@";

            _aisMessage24.Name = name;
            string actual = _aisMessage24.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTypeOfShipAndCargoTypeValid()
        {
            ushort typeOfShipAndCargoType = 99;
            ushort expected = 99;

            _aisMessage24.TypeOfShipAndCargoType = typeOfShipAndCargoType;
            ushort actual = _aisMessage24.TypeOfShipAndCargoType;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTypeOfShipAndCargoTypeInvalid()
        {
            ushort typeOfShipAndCargoType = ushort.MaxValue;
            ushort expected = 255;

            _aisMessage24.TypeOfShipAndCargoType = typeOfShipAndCargoType;
            ushort actual = _aisMessage24.TypeOfShipAndCargoType;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestManufacturerId()
        {
            string manufacturerId = "UWU";
            string expected = "UWU";

            _aisMessage24.ManufacturerId = manufacturerId;
            string actual = _aisMessage24.ManufacturerId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUnitModelCode()
        {
            ushort unitModelCode = 11;
            ushort expected = 11;

            _aisMessage24.UnitModelCode = unitModelCode;
            ushort actual = _aisMessage24.UnitModelCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUnitSerialNumber()
        {
            uint unitSerialNumber = 524287;
            uint expected = 524287;

            _aisMessage24.UnitSerialNumber = unitSerialNumber;
            uint actual = _aisMessage24.UnitSerialNumber;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCallSign()
        {
            string callsign = "FIRENZE";
            string expected = "FIRENZE";

            _aisMessage24.CallSign = callsign;
            string actual = _aisMessage24.CallSign;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToBowValid()
        {
            ushort dimeToBow = 200;
            ushort expected = 200;

            _aisMessage24.DimensionToBow = dimeToBow;
            ushort actual = _aisMessage24.DimensionToBow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToBowInvalid()
        {
            ushort dimeToBow = ushort.MaxValue;
            ushort expected = 511;

            _aisMessage24.DimensionToBow = dimeToBow;
            ushort actual = _aisMessage24.DimensionToBow;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToSternValid()
        {
            ushort dimeToStern = 200;
            ushort expected = 200;

            _aisMessage24.DimensionToStern = dimeToStern;
            ushort actual = _aisMessage24.DimensionToStern;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToSternInvalid()
        {
            ushort dimeToStern = ushort.MaxValue;
            ushort expected = 511;

            _aisMessage24.DimensionToStern = dimeToStern;
            ushort actual = _aisMessage24.DimensionToStern;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToPortValid()
        {
            ushort dimeToPort = 52;
            ushort expected = 52;

            _aisMessage24.DimensionToPort = dimeToPort;
            ushort actual = _aisMessage24.DimensionToPort;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToPortInvalid()
        {
            ushort dimeToPort = ushort.MaxValue;
            ushort expected = 63;

            _aisMessage24.DimensionToPort = dimeToPort;
            ushort actual = _aisMessage24.DimensionToPort;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToStarboardValid()
        {
            ushort dimeToStarboard = 47;
            ushort expected = 47;

            _aisMessage24.DimensionToStarboard = dimeToStarboard;
            ushort actual = _aisMessage24.DimensionToStarboard;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDimensionToStarboardInvalid()
        {
            ushort dimeToStarboard = ushort.MaxValue;
            ushort expected = 63;

            _aisMessage24.DimensionToStarboard = dimeToStarboard;
            ushort actual = _aisMessage24.DimensionToStarboard;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLengthOverallValid()
        {
            ushort dimeToBow = 47;
            ushort dimeToStern = 47;
            ushort expected = (ushort)(dimeToBow + dimeToStern);

            _aisMessage24.DimensionToBow = dimeToBow;
            _aisMessage24.DimensionToStern = dimeToStern;
            ushort actual = _aisMessage24.LengthOverall;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLengthOverallInvalid()
        {
            ushort dimeToBow = 512;
            ushort dimeToStern = 512;
            ushort expected = 511;

            _aisMessage24.LengthOverall = (ushort)(dimeToBow + dimeToStern);
            ushort actual = _aisMessage24.LengthOverall;

            Assert.Equal(expected, actual);
            Assert.Equal(0, _aisMessage24.DimensionToBow);
            Assert.Equal(expected, _aisMessage24.DimensionToStern);
        }

        [Fact]
        public void TestBeamOverallValid()
        {
            ushort dimeToPort = 23;
            ushort dimeToStarboard = 23;
            ushort expected = (ushort)(dimeToPort + dimeToStarboard);

            _aisMessage24.DimensionToPort = dimeToPort;
            _aisMessage24.DimensionToStarboard = dimeToStarboard;
            ushort actual = _aisMessage24.BeamOverall;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestBeamOverallInvalid()
        {
            ushort dimeToPort = 64;
            ushort dimeToStarboard = 64;
            ushort expected = 63;

            _aisMessage24.BeamOverall = (ushort)(dimeToPort + dimeToStarboard);
            ushort actual = _aisMessage24.BeamOverall;

            Assert.Equal(expected, actual);
            Assert.Equal(0, _aisMessage24.DimensionToPort);
            Assert.Equal(expected, _aisMessage24.DimensionToStarboard);
        }

        [Fact]
        public void AIS24ADecoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDO,1,1,,B,H1c2;qA@PU>0U>060<h5=>0:1Dp,2*7D\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDO, aisMessage24.SentenceFormatter);
            Assert.Equal(24, aisMessage24.MessageId);
            Assert.Equal(0, aisMessage24.RepeatIndicator);
            Assert.Equal("112233445", aisMessage24.UserId);
            Assert.Equal(AISMessage24.PartNumberEnum.PartA, aisMessage24.PartNumber);
            Assert.Equal("THIS IS A CLASS B UN", aisMessage24.Name);
        }

        [Fact]
        public void AIS24ADecoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,H42O55i18tMET00000000000000,2*6D\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage24.SentenceFormatter);
            Assert.Equal(24, aisMessage24.MessageId);
            Assert.Equal(0, aisMessage24.RepeatIndicator);
            Assert.Equal("271041815", aisMessage24.UserId);
            Assert.Equal(AISMessage24.PartNumberEnum.PartA, aisMessage24.PartNumber);
            Assert.Equal("PROGUY@@@@@@@@@@@@@@", aisMessage24.Name);
        }

        [Fact]
        public void AIS24AEncoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDO,1,1,,B,H1c2;qA@PU>0U>060<h5=>0:1Dp,2*7D\r\n"
            };

            _aisMessage24.SentenceFormatter = AISMessage.SentenceFormatterEnum.VDO;
            _aisMessage24.MessageId = 24;
            _aisMessage24.RepeatIndicator = 0;
            _aisMessage24.UserId = "112233445";
            _aisMessage24.PartNumber = AISMessage24.PartNumberEnum.PartA;
            _aisMessage24.Name = "THIS IS A CLASS B UN";

            IList<String> actual = _aisMessage24.EncodeSentences();

            Assert.Equivalent(expected, actual);
        }

        [Fact]
        public void AIS24BDecoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDO,1,1,,B,H1c2;qDTijklmno31<<C970`43<1,0*28\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDO, aisMessage24.SentenceFormatter);
            Assert.Equal(24, aisMessage24.MessageId);
            Assert.Equal(0, aisMessage24.RepeatIndicator);
            Assert.Equal("112233445", aisMessage24.UserId);
            Assert.Equal(AISMessage24.PartNumberEnum.PartB, aisMessage24.PartNumber);
            Assert.Equal(36, aisMessage24.TypeOfShipAndCargoType);
            Assert.Equal("1234567", aisMessage24.VendorId);
            Assert.Equal("CALLSIG", aisMessage24.CallSign);
            Assert.Equal(5, aisMessage24.DimensionToBow);
            Assert.Equal(4, aisMessage24.DimensionToStern);
            Assert.Equal(3, aisMessage24.DimensionToPort);
            Assert.Equal(12, aisMessage24.DimensionToStarboard);
        }

        [Fact]
        public void AIS24BDecoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,H42O55lti4hhhilD3nink000?050,0*40\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage24.SentenceFormatter);
            Assert.Equal(24, aisMessage24.MessageId);
            Assert.Equal(0, aisMessage24.RepeatIndicator);
            Assert.Equal("271041815", aisMessage24.UserId);
            Assert.Equal(AISMessage24.PartNumberEnum.PartB, aisMessage24.PartNumber);
            Assert.Equal(60, aisMessage24.TypeOfShipAndCargoType);
            Assert.Equal("1D00014", aisMessage24.VendorId);
            Assert.Equal("TC6163@", aisMessage24.CallSign);
            Assert.Equal(0, aisMessage24.DimensionToBow);
            Assert.Equal(15, aisMessage24.DimensionToStern);
            Assert.Equal(0, aisMessage24.DimensionToPort);
            Assert.Equal(5, aisMessage24.DimensionToStarboard);
        }

        [Fact]
        public void AIS24BEncoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDO,1,1,,B,H1c2;qDTijklmno31<<C970`43<0,0*29\r\n"
            };

            _aisMessage24.SentenceFormatter = AISMessage.SentenceFormatterEnum.VDO;
            _aisMessage24.MessageId = 24;
            _aisMessage24.RepeatIndicator = 0;
            _aisMessage24.UserId = "112233445";
            _aisMessage24.PartNumber = AISMessage24.PartNumberEnum.PartB;
            _aisMessage24.TypeOfShipAndCargoType = 36;
            _aisMessage24.ManufacturerId = "123";
            _aisMessage24.UnitModelCode = 13;
            _aisMessage24.UnitSerialNumber = 220599;
            _aisMessage24.CallSign = "CALLSIG";
            _aisMessage24.DimensionToBow = 5;
            _aisMessage24.DimensionToStern = 4;
            _aisMessage24.DimensionToPort = 3;
            _aisMessage24.DimensionToStarboard = 12;

            IList<String> actual = _aisMessage24.EncodeSentences();

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
        // ~UnitTestAISMessage24()
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
