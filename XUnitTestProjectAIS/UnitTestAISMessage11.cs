using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage11
    {
        private const Int32 POSITIONAL_PRECISION = 5;

        [Fact]
        public void AIS11Decoding()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,;4R33:1uUK2F`q?mOt@@GoQ00000,0*5D"
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
    }
}
