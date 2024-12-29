using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage11 : IDisposable
    {
        private bool disposedValue;

        private const Int32 POSITIONAL_PRECISION = 5;

        private readonly AISMessage11 _aisMessage11;

        public UnitTestAISMessage11()
        {
            _aisMessage11 = new AISMessage11();
        }

        [Fact]
        public void TestUserId()
        {
            string userId = "123456789";
            string expected = "123456789";

            _aisMessage11.UserId = userId;
            string actual = _aisMessage11.UserId;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCYear()
        {
            ushort utcYear = 2020;
            ushort expected = 2020;

            _aisMessage11.UTCYear = utcYear;
            ushort actual = _aisMessage11.UTCYear;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCMonth()
        {
            ushort utcMonth = 12;
            ushort expected = 12;

            _aisMessage11.UTCMonth = utcMonth;
            ushort actual = _aisMessage11.UTCMonth;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCDay()
        {
            ushort utcDay = 31;
            ushort expected = 31;

            _aisMessage11.UTCDay = utcDay;
            ushort actual = _aisMessage11.UTCDay;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCHour()
        {
            ushort utcHour = 23;
            ushort expected = 23;

            _aisMessage11.UTCHour = utcHour;
            ushort actual = _aisMessage11.UTCHour;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCMinute()
        {
            ushort utcMinute = 59;
            ushort expected = 59;

            _aisMessage11.UTCMinute = utcMinute;
            ushort actual = _aisMessage11.UTCMinute;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestUTCSecond()
        {
            ushort utcSecond = 58;
            ushort expected = 58;

            _aisMessage11.UTCSecond = utcSecond;
            ushort actual = _aisMessage11.UTCSecond;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestLongitudeValid()
        {
            decimal longitude = 103.833333M;
            decimal expected = 103.833333M;

            _aisMessage11.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage11.LongitudeDecimalDegrees;

            Assert.True(_aisMessage11.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLongitudeInvalid()
        {
            decimal longitude = 181.0M;
            decimal expected = 181.0M;

            _aisMessage11.LongitudeDecimalDegrees = longitude;
            decimal actual = _aisMessage11.LongitudeDecimalDegrees;

            Assert.False(_aisMessage11.LongitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeValid()
        {
            decimal latitude = 1.283333M;
            decimal expected = 1.283333M;

            _aisMessage11.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage11.LatitudeDecimalDegrees;

            Assert.True(_aisMessage11.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void TestLatitudeInvalid()
        {
            decimal latitude = 91.0M;
            decimal expected = 91.0M;

            _aisMessage11.LatitudeDecimalDegrees = latitude;
            decimal actual = _aisMessage11.LatitudeDecimalDegrees;

            Assert.False(_aisMessage11.LatitudeAvailable);
            Assert.Equal(expected, actual, POSITIONAL_PRECISION);
        }

        [Fact]
        public void AIS11Decoding()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,;4R33:1uUK2F`q?mOt@@GoQ00000,0*5D\r\n"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage11 aisMessage11 = aisMessage as AISMessage11;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage11);
            Assert.Equal(11, aisMessage11.MessageId);
            Assert.Equal(0, aisMessage11.RepeatIndicator);
            Assert.Equal("304137000", aisMessage11.UserId);
            Assert.Equal(2009, aisMessage11.UTCYear);
            Assert.Equal(5, aisMessage11.UTCMonth);
            Assert.Equal(22, aisMessage11.UTCDay);
            Assert.Equal(2, aisMessage11.UTCHour);
            Assert.Equal(22, aisMessage11.UTCMinute);
            Assert.Equal(40, aisMessage11.UTCSecond);
            Assert.True(aisMessage11.PositionAccuracy);
            Assert.Equal(-94.40768333333333333333333333M, aisMessage11.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage11.LongitudeAvailable);
            Assert.Equal(28.40911666666666666666666667M, aisMessage11.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage11.LatitudeAvailable);
            Assert.Equal(AISMessage11.ElectronicPositionFixingDeviceEnum.GPS, aisMessage11.TypeOfElectronicPositionFixingDevice);
            Assert.False(aisMessage11.TransmissionControlForLongRangeBroadcastMessage);
            Assert.False(aisMessage11.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage11.CommunicationState.SyncState);
            Assert.Equal(0, aisMessage11.CommunicationState.SlotTimeout);
        }

        [Fact]
        public void AIS11Encoding()
        {
            IList<String> expected = new List<String>()
            {
                "!AIVDM,1,1,,A,;4R33:1uUK2F`q?mOt@@GoQ00000,0*5E\r\n"
            };

            _aisMessage11.MessageId = 11;
            _aisMessage11.RepeatIndicator = 0;
            _aisMessage11.UserId = "304137000";
            _aisMessage11.UTCYear = 2009;
            _aisMessage11.UTCMonth = 5;
            _aisMessage11.UTCDay = 22;
            _aisMessage11.UTCHour = 2;
            _aisMessage11.UTCMinute = 22;
            _aisMessage11.UTCSecond = 40;
            _aisMessage11.PositionAccuracy = true;
            _aisMessage11.LongitudeDecimalDegrees = -94.40768333333333333333333333M;
            _aisMessage11.LatitudeDecimalDegrees = 28.40911666666666666666666667M;
            _aisMessage11.TypeOfElectronicPositionFixingDevice = AISMessage11.ElectronicPositionFixingDeviceEnum.GPS;
            _aisMessage11.TransmissionControlForLongRangeBroadcastMessage = false;
            _aisMessage11.RAIMFlag = false;
            _aisMessage11.CommunicationState = new SOTDMACommunicationState()
            {
                SyncState = AISCommunicationState.SyncStateEnum.UTCDirect,
                SlotTimeout = 0,
            };

            IList<String> actual = _aisMessage11.EncodeSentences();

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
        // ~UnitTestAISMessage11()
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
