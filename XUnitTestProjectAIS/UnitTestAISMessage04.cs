using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage04 : IDisposable
    {
        private bool disposedValue;

        private const Int32 POSITIONAL_PRECISION = 5;

        private readonly AISMessage04 _aisMessage04;

        public UnitTestAISMessage04()
        {
            _aisMessage04 = new AISMessage04();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage04.UserId = userId;
            string actual = _aisMessage04.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCYear()
        {
            ushort utcYear = 2020;
            ushort expected = 2020;

            _aisMessage04.UTCYear = utcYear;
            ushort actual = _aisMessage04.UTCYear;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCMonth()
        {
            ushort utcMonth = 12;
            ushort expected = 12;

            _aisMessage04.UTCMonth = utcMonth;
            ushort actual = _aisMessage04.UTCMonth;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCDay()
        {
            ushort utcDay = 31;
            ushort expected = 31;

            _aisMessage04.UTCDay = utcDay;
            ushort actual = _aisMessage04.UTCDay;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCHour()
        {
            ushort utcHour = 23;
            ushort expected = 23;

            _aisMessage04.UTCHour = utcHour;
            ushort actual = _aisMessage04.UTCHour;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCMinute()
        {
            ushort utcMinute = 59;
            ushort expected = 59;

            _aisMessage04.UTCMinute = utcMinute;
            ushort actual = _aisMessage04.UTCMinute;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCSecond()
        {
            ushort utcSecond = 58;
            ushort expected = 58;

            _aisMessage04.UTCSecond = utcSecond;
            ushort actual = _aisMessage04.UTCSecond;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLongitudeValid()
        {
            decimal longitude = 103.833333M;
            decimal expected = 103.833333M;

            _aisMessage04.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage04.LongitudeDecimalDegrees;

            Assert.True(_aisMessage04.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLongitudeInvalid()
        {
            decimal longitude = 181.0M;
            decimal expected = 181.0M;

            _aisMessage04.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage04.LongitudeDecimalDegrees;

            Assert.False(_aisMessage04.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeValid()
        {
            decimal latitude = 1.283333M;
            decimal expected = 1.283333M;

            _aisMessage04.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage04.LatitudeDecimalDegrees;

            Assert.True(_aisMessage04.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeInvalid()
        {
            decimal latitude = 91.0M;
            decimal expected = 91.0M;

            _aisMessage04.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage04.LatitudeDecimalDegrees;

            Assert.False(_aisMessage04.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void AIS04Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,400TcdiuiT7VDR>3nIfr6>Q00000,0*40\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage04 aisMessage04 = aisMessage as AISMessage04;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage04);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage04.SentenceFormatter);
            Assert.Equal(4, aisMessage04.MessageId);
            Assert.Equal(0, aisMessage04.RepeatIndicator);
            Assert.Equal("000601011", aisMessage04.UserId);
            Assert.Equal(2012, aisMessage04.UTCYear);
            Assert.Equal(6, aisMessage04.UTCMonth);
            Assert.Equal(8, aisMessage04.UTCDay);
            Assert.Equal(7, aisMessage04.UTCHour);
            Assert.Equal(38, aisMessage04.UTCMinute);
            Assert.Equal(20, aisMessage04.UTCSecond);
            Assert.True(aisMessage04.PositionAccuracy);
            Assert.Equal(31.033514M, aisMessage04.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage04.LongitudeAvailable);
            Assert.Equal(-29.870835M, aisMessage04.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage04.LatitudeAvailable);
            Assert.Equal(AISMessage04.ElectronicPositionFixingDeviceEnum.GPS, aisMessage04.TypeOfElectronicPositionFixingDevice);
            Assert.False(aisMessage04.TransmissionControlForLongRangeBroadcastMessage);
            Assert.False(aisMessage04.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage04.CommunicationState.SyncState);
            Assert.Equal(0, aisMessage04.CommunicationState.SlotTimeout);
        }

        [Fact]
        public void AIS04Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,403OviQuMGCqWrRO9>E6fE700@GO,0*4D\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage04 aisMessage04 = aisMessage as AISMessage04;
            SOTDMACommunicationState communicationState = aisMessage04.CommunicationState;
            communicationState.GetSlotNumber(out UInt16 slotTimeout, out UInt16 slotNumber);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage04);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage04.SentenceFormatter);
            Assert.Equal(4, aisMessage04.MessageId);
            Assert.Equal(0, aisMessage04.RepeatIndicator);
            Assert.Equal("003669702", aisMessage04.UserId);
            Assert.Equal(2007, aisMessage04.UTCYear);
            Assert.Equal(5, aisMessage04.UTCMonth);
            Assert.Equal(14, aisMessage04.UTCDay);
            Assert.Equal(19, aisMessage04.UTCHour);
            Assert.Equal(57, aisMessage04.UTCMinute);
            Assert.Equal(39, aisMessage04.UTCSecond);
            Assert.True(aisMessage04.PositionAccuracy);
            Assert.Equal(-76.35236M, aisMessage04.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage04.LongitudeAvailable);
            Assert.Equal(36.883766M, aisMessage04.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage04.LatitudeAvailable);
            Assert.Equal(AISMessage04.ElectronicPositionFixingDeviceEnum.Surveyed, aisMessage04.TypeOfElectronicPositionFixingDevice);
            Assert.False(aisMessage04.TransmissionControlForLongRangeBroadcastMessage);
            Assert.False(aisMessage04.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, communicationState.SyncState);
            Assert.Equal(4, communicationState.SlotTimeout);
            Assert.Equal(4, slotTimeout);
            Assert.Equal(1503, slotNumber);
        }

        [Fact]
        public void AIS04Encoding01()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,A,400TcdiuiT7VDR>3nIfr6>Q00000,0*40\r\n"
            };

            _aisMessage04.MessageId = 4;
            _aisMessage04.RepeatIndicator = 0;
            _aisMessage04.UserId = "000601011";
            _aisMessage04.UTCYear = 2012;
            _aisMessage04.UTCMonth = 6;
            _aisMessage04.UTCDay = 8;
            _aisMessage04.UTCHour = 7;
            _aisMessage04.UTCMinute = 38;
            _aisMessage04.UTCSecond = 20;
            _aisMessage04.PositionAccuracy = true;
            _aisMessage04.LongitudeDecimalDegrees = 31.033514M;
            _aisMessage04.LatitudeDecimalDegrees = -29.870835M;
            _aisMessage04.TypeOfElectronicPositionFixingDevice = AISMessage04.ElectronicPositionFixingDeviceEnum.GPS;
            _aisMessage04.TransmissionControlForLongRangeBroadcastMessage = false;
            _aisMessage04.RAIMFlag = false;
            _aisMessage04.CommunicationState = new SOTDMACommunicationState()
            {
                SyncState = AISCommunicationState.SyncStateEnum.UTCDirect,
                SlotTimeout = 0,
            };

            IList<String> actual = _aisMessage04.EncodeSentences();

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
        // ~UnitTestAISMessage04()
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
