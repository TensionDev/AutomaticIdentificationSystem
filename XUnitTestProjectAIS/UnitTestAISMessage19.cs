using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage19
    {
        private const Int32 POSITIONAL_PRECISION = 5;

        [Fact]
        public void AIS19Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,2,1,0,B,C5N3SRgPEnJGEBT>NhWAwwo862PaLELTBJ:V00000000S0D:R2,0*3A",
                "!AIVDM,2,2,0,B,20,0*17"
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
            Assert.Equal(-88.810394M, aisMessage19.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
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
    }
}
