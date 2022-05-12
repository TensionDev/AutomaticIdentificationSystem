using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage04
    {
        private const Int32 POSITIONAL_PRECISION = 5;

        [Fact]
        public void AIS04Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,400TcdiuiT7VDR>3nIfr6>i00000,0*78"
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
            Assert.Equal(-29.870832M, aisMessage04.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
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
                "!AIVDM,1,1,,A,403OviQuMGCqWrRO9>E6fE700@GO,0*4D"
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
    }
}
