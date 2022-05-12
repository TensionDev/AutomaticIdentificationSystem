using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage09
    {
        private const Int32 POSITIONAL_PRECISION = 5;

        [Fact]
        public void AIS09Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,91b77=h3h00nHt0Q3r@@07000<0b,0*69"
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
                "!AIVDM,1,1,,B,91b55wi;hbOS@OdQAC062Ch2089h,0*30"
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
    }
}
