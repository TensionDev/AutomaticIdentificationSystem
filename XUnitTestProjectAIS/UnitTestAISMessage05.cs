﻿using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage05
    {
        [Fact]
        public void AIS05Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,2,1,0,A,58wt8Ui`g??r21`7S=:22058<v05Htp000000015>8OA;0sk,0*7B",
                "!AIVDM,2,2,0,A,eQ8823mDm3kP00000000000,2*5D"
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
                "!AIVDM,2,1,1,A,55?MbV02;H;s<HtKR20EHE:0@T4@Dn2222222216L961O5Gf0NSQEp6ClRp8,0*1C",
                "!AIVDM,2,2,1,A,88888888880,2*25"
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
    }
}
