using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage04
    {
        [Fact]
        public void AIS02Decoding()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,400TcdiuiT7VDR>3nIfr6>i00000,0*78"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage04 aisMessage04 = aisMessage as AISMessage04;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage04);
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
            Assert.Equal(31.033514M, aisMessage04.LongitudeDecimalDegrees, 5);
            Assert.True(aisMessage04.LongitudeAvailable);
            Assert.Equal(-29.870832M, aisMessage04.LatitudeDecimalDegrees, 5);
            Assert.True(aisMessage04.LatitudeAvailable);
            Assert.Equal(AISMessage04.ElectronicPositionFixingDeviceEnum.GPS, aisMessage04.TypeOfElectronicPositionFixingDevice);
            Assert.False(aisMessage04.TransmissionControlForLongRangeBroadcastMessage);
            Assert.False(aisMessage04.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage04.CommunicationState.SyncState);
            Assert.Equal(0, aisMessage04.CommunicationState.SlotTimeout);
        }
    }
}
