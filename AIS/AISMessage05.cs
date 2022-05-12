using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.AIS
{
    /// <summary>
    /// Messages 5: Static and voyage related data
    /// </summary>
    public class AISMessage05 : AISMessage
    {
        private UInt64 _bitVector0_59;
        private UInt64 _bitVector60_119;
        private UInt64 _bitVector120_179;
        private UInt64 _bitVector180_239;
        private UInt64 _bitVector240_299;
        private UInt64 _bitVector300_359;
        private UInt64 _bitVector360_419;
        private UInt64 _bitVector420_423;

        protected UInt32 userId30;
        protected UInt16 aisVersion2;
        protected UInt32 imoNumber30;
        protected UInt64 callSign42;
        protected UInt64 name0_59;
        protected UInt64 name60_119;
        protected UInt16 shipAndCargoType8;
        protected UInt16 dimensionToBow9;
        protected UInt16 dimensionToStern9;
        protected UInt16 dimensionToPort6;
        protected UInt16 dimensionToStarboard6;
        protected UInt16 electronicPositionFixingDevice4;
        protected UInt16 etaMonth4;
        protected UInt16 etaDay5;
        protected UInt16 etaHour5;
        protected UInt16 etaMinute6;
        protected UInt16 maxPresentStaticDraught8;
        protected UInt64 destination0_59;
        protected UInt64 destination60_119;
        protected UInt16 dataTerminalEquipment1;
        protected UInt16 spare1;

        /// <summary>
        /// Unique identifier such as MMSI number
        /// </summary>
        public String UserId { get => userId30.ToString("D9"); set => userId30 = UInt32.Parse(value); }

        /// <summary>
        /// <para>0 = station compliant with Recommendation ITU-R M.1371-1</para>
        /// <para>1 = station compliant with Recommendation ITU-R M.1371-3 (or later)</para>
        /// <para>2 = station compliant with Recommendation ITU-R M.1371-5 (or later)</para>
        /// <para>3 = station compliant with future editions</para>
        /// </summary>
        public AISVersionEnum AISVersion { get => (AISVersionEnum)(aisVersion2); set => aisVersion2 = (UInt16)value; }

        /// <summary>
        /// <para>0 = not available = default – Not applicable to SAR aircraft;</para>
        /// <para>0000000001-0000999999 not used;</para>
        /// <para>0001000000-0009999999 = valid IMO number;</para>
        /// <para>0010000000-1073741823 = official flag state number.</para>
        /// </summary>
        public String IMONumber { get => imoNumber30.ToString("D9"); set => imoNumber30 = UInt32.Parse(value); }

        /// <summary>
        /// <para>7 x 6 bit ASCII characters, @@@@@@@ = not available = default.</para>
        /// <para>Craft associated with a parent vessel, should use “A” followed by the last 6 digits of the MMSI of the parent vessel.</para>
        /// Examples of these craft include towed vessels, rescue boats, tenders, lifeboats and liferafts.
        /// </summary>
        public String CallSign
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                UInt64 temp = callSign42;

                for (Int32 i = 0; i < 7; ++i)
                {
                    UInt64 vs = temp & 0x3F;
                    temp >>= 6;

                    if (vs < 32)
                    {
                        vs += 64;
                    }

                    stringBuilder.Insert(0, Convert.ToChar(vs));
                }

                return stringBuilder.ToString();
            }
            set
            {
                callSign42 = 0;
                for (Int32 i = 0; i < 7; ++i)
                {
                    callSign42 <<= 6;
                    if (i < value.Length)
                    {
                        if (Convert.ToUInt64(value[i]) >= 64L)
                        {
                            callSign42 += Convert.ToUInt64(value[i]) - 64L;
                        }
                        else
                        {
                            callSign42 += Convert.ToUInt64(value[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// <para>Maximum 20 characters 6 bit ASCII, as defined in Table 47 “@@@@@@@@@@@@@@@@@@@@” = not available = default.</para>
        /// <para>The Name should be as shown on the station radio license.</para>
        /// <para>For SAR aircraft, it should be set to “SAR AIRCRAFT NNNNNNN” where NNNNNNN equals the aircraft registration number.</para>
        /// </summary>
        public String Name
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                UInt64 temp = name60_119;

                for (Int32 i = 0; i < 10; ++i)
                {
                    UInt64 vs = temp & 0x3F;
                    temp >>= 6;

                    if (vs < 32)
                    {
                        vs += 64;
                    }

                    stringBuilder.Insert(0, Convert.ToChar(vs));
                }

                temp = name0_59;
                for (Int32 i = 0; i < 10; ++i)
                {
                    UInt64 vs = temp & 0x3F;
                    temp >>= 6;

                    if (vs < 32)
                    {
                        vs += 64;
                    }

                    stringBuilder.Insert(0, Convert.ToChar(vs));
                }

                return stringBuilder.ToString();
            }
            set
            {
                name0_59 = 0;
                name60_119 = 0;
                for (Int32 i = 0; i < 10; ++i)
                {
                    name0_59 <<= 6;
                    if (i < value.Length)
                    {
                        if (Convert.ToUInt64(value[i]) >= 64L)
                        {
                            name0_59 += Convert.ToUInt64(value[i]) - 64L;
                        }
                        else
                        {
                            name0_59 += Convert.ToUInt64(value[i]);
                        }
                    }
                }
                for (Int32 i = 10; i < 20; ++i)
                {
                    name60_119 <<= 6;
                    if (i < value.Length)
                    {
                        if (Convert.ToUInt64(value[i]) >= 64L)
                        {
                            name60_119 += Convert.ToUInt64(value[i]) - 64L;
                        }
                        else
                        {
                            name60_119 += Convert.ToUInt64(value[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Type of Ship and Cargo Type
        /// <para>0 = not available or no ship = default</para>
        /// <para>1-99 = as defined in § 3.3.2</para>
        /// <para>100-199 = reserved, for regional use</para>
        /// <para>200-255 = reserved, for future use</para>
        /// <para>Not applicable to SAR aircraft</para>
        /// </summary>
        public UInt16 TypeOfShipAndCargoType { get => shipAndCargoType8; set => shipAndCargoType8 = Math.Min((UInt16)255, value); }

        /// <summary>
        /// 0-511; 511 = 511 m or greater
        /// </summary>
        public UInt16 DimensionToBow { get => dimensionToBow9; set => dimensionToBow9 = Math.Min((UInt16)511, value); }

        /// <summary>
        /// 0-511; 511 = 511 m or greater
        /// </summary>
        public UInt16 DimensionToStern { get => dimensionToStern9; set => dimensionToStern9 = Math.Min((UInt16)511, value); }

        /// <summary>
        /// 0-63; 63 = 63 m or greater
        /// </summary>
        public UInt16 DimensionToPort { get => dimensionToPort6; set => dimensionToPort6 = Math.Min((UInt16)63, value); }

        /// <summary>
        /// 0-63; 63 = 63 m or greater
        /// </summary>
        public UInt16 DimensionToStarboard { get => dimensionToStarboard6; set => dimensionToStarboard6 = Math.Min((UInt16)63, value); }

        /// <summary>
        /// <para>The maximum length of the ship between the ships extreme points important for berthing purposes.</para>
        /// <para>NOTE: Setting this will reset the <see cref="DimensionToBow"/> to 0 and <see cref="DimensionToStern"/> to the value, capped at 511.</para>
        /// <para>0-511; 511 = 511 m or greater</para>
        /// </summary>
        public UInt16 LengthOverall { get { return (UInt16)(DimensionToBow + DimensionToStern); } set { DimensionToBow = 0; DimensionToStern = Math.Min((UInt16)511, value); } }

        /// <summary>
        /// The overall width of the ship measured at the widest point of the nominal waterline.
        /// <para>NOTE: Setting this will reset the <see cref="DimensionToPort"/> to 0 and <see cref="DimensionToStarboard"/> to the value, capped at 63.</para>
        /// <para>0-63; 63 = 63 m or greater</para>
        /// </summary>
        public UInt16 BeamOverall { get { return (UInt16)(DimensionToPort + DimensionToStarboard); } set { DimensionToPort = 0; DimensionToStarboard = Math.Min((UInt16)63, value); } }

        /// <summary>
        /// Type of electronic position fixing device
        /// <para>0 = undefined (default)</para>
        /// <para>1 = GPS</para>
        /// <para>2 = GLONASS</para>
        /// <para>3 = combined GPS/GLONASS</para>
        /// <para>4 = Loran-C</para>
        /// <para>5 = Chayka</para>
        /// <para>6 = integrated navigation system</para>
        /// <para>7 = surveyed</para>
        /// <para>8 = Galileo,</para>
        /// <para>9-14 = not used</para>
        /// <para>15 = internal GNSS</para>
        /// </summary>
        public ElectronicPositionFixingDeviceEnum TypeOfElectronicPositionFixingDevice { get => (ElectronicPositionFixingDeviceEnum)electronicPositionFixingDevice4; set => electronicPositionFixingDevice4 = (UInt16)value; }

        /// <summary>
        /// Estimated time of arrival in UTC, Month; 1-12; 0 = not available = default
        /// </summary>
        public UInt16 ETAMonthUTC { get => etaMonth4; set => etaMonth4 = Math.Min((UInt16)12, value); }

        /// <summary>
        /// Estimated time of arrival in UTC, Day; 1-31; 0 = not available = default
        /// </summary>
        public UInt16 ETADayUTC { get => etaDay5; set => etaDay5 = Math.Min((UInt16)31, value); }

        /// <summary>
        /// Estimated time of arrival in UTC, Hour; 0-23; 24 = not available = default
        /// </summary>
        public UInt16 ETAHourUTC { get => etaHour5; set => etaHour5 = Math.Min((UInt16)24, value); }

        /// <summary>
        /// Estimated time of arrival in UTC, Minute; 0-59; 60 = not available = default
        /// </summary>
        public UInt16 ETAMinuteUTC { get => etaMinute6; set => etaMinute6 = Math.Min((UInt16)60, value); }

        /// <summary>
        /// In 1/10 m steps, 25.5 = draught 25.5 m or greater, 0 = not available = default;
        /// in accordance with IMO Resolution A.851
        /// Not applicable to SAR aircraft, should be set to 0
        /// </summary>
        public Decimal MaximumPresentStaticDraught { get => maxPresentStaticDraught8 / 10.0M; set => maxPresentStaticDraught8 = (UInt16)Math.Min((Math.Abs(value) * 10.0M), 255); }

        /// <summary>
        /// <para>Maximum 20 characters 6 bit ASCII, as defined in Table 47 “@@@@@@@@@@@@@@@@@@@@” = not available = default.</para>
        /// <para>For SAR aircraft, the use of this field may be decided by the responsible administration.</para>
        /// </summary>
        public String Destination
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                UInt64 temp = destination60_119;

                for (Int32 i = 0; i < 10; ++i)
                {
                    UInt64 vs = temp & 0x3F;
                    temp >>= 6;

                    if (vs < 32)
                    {
                        vs += 64;
                    }

                    stringBuilder.Insert(0, Convert.ToChar(vs));
                }

                temp = destination0_59;
                for (Int32 i = 0; i < 10; ++i)
                {
                    UInt64 vs = temp & 0x3F;
                    temp >>= 6;

                    if (vs < 32)
                    {
                        vs += 64;
                    }

                    stringBuilder.Insert(0, Convert.ToChar(vs));
                }

                return stringBuilder.ToString();
            }
            set
            {
                destination0_59 = 0;
                destination60_119 = 0;
                for (Int32 i = 0; i < 10; ++i)
                {
                    destination0_59 <<= 6;
                    if (i < value.Length)
                    {
                        if (Convert.ToUInt64(value[i]) >= 64L)
                        {
                            destination0_59 += Convert.ToUInt64(value[i]) - 64L;
                        }
                        else
                        {
                            destination0_59 += Convert.ToUInt64(value[i]);
                        }
                    }
                }
                for (Int32 i = 10; i < 20; ++i)
                {
                    destination60_119 <<= 6;
                    if (i < value.Length)
                    {
                        if (Convert.ToUInt64(value[i]) >= 64L)
                        {
                            destination60_119 += Convert.ToUInt64(value[i]) - 64L;
                        }
                        else
                        {
                            destination60_119 += Convert.ToUInt64(value[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Data terminal equipment (DTE) ready (0 = available, 1 = not available = default) (see § 3.3.1)
        /// </summary>
        public Boolean DTE { get => dataTerminalEquipment1 == 0; set { if (value) { dataTerminalEquipment1 = 0; } else { dataTerminalEquipment1 = 1; } } }

        public AISMessage05()
        {
            MessageId = 5;
            RepeatIndicator = 0;
            aisVersion2 = 0;
            imoNumber30 = 0;
            callSign42 = 0;
            name0_59 = 0;
            name60_119 = 0;
            shipAndCargoType8 = 0;
            dimensionToBow9 = 0;
            dimensionToStern9 = 0;
            dimensionToPort6 = 0;
            dimensionToStarboard6 = 0;
            electronicPositionFixingDevice4 = 0;
            etaMonth4 = 0;
            etaDay5 = 0;
            etaHour5 = 24;
            etaMinute6 = 60;
            maxPresentStaticDraught8 = 0;
            destination0_59 = 0;
            destination60_119 = 0;
            dataTerminalEquipment1 = 1;
            spare1 = 0;
        }

        public override IList<String> EncodeSentences()
        {
            IList<String> sentences = new List<String>();

            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            IList<String> payload = EncodePayloads();

            stringBuilder.AppendFormat("!AI{0},2,1,{1},A,{2},0", SentenceFormatter.ToString(), s_groupId, payload[0]);
            stringBuilder2.AppendFormat("!AI{0},2,2,{1},A,{2},0", SentenceFormatter.ToString(), s_groupId, payload[1]);

            Byte checksum = CalculateChecksum(stringBuilder.ToString());
            Byte checksum2 = CalculateChecksum(stringBuilder2.ToString());

            stringBuilder.AppendFormat("*{0}\r\n", checksum.ToString("X2"));
            stringBuilder2.AppendFormat("*{0}\r\n", checksum2.ToString("X2"));

            sentences.Add(stringBuilder.ToString());
            sentences.Add(stringBuilder2.ToString());

            ++s_groupId;
            if (s_groupId > 9)
                s_groupId = 0;

            return sentences;
        }

        protected override void DecodePayloads(IList<String> payloads)
        {
            if (payloads.Count != 2)
                throw new ArgumentOutOfRangeException(nameof(payloads));

            String payload = payloads[0] + payloads[1];

            _bitVector0_59 = DecodePayload(payload, 0, 10);
            _bitVector60_119 = DecodePayload(payload, 10, 10);
            _bitVector120_179 = DecodePayload(payload, 20, 10);
            _bitVector180_239 = DecodePayload(payload, 30, 10);
            _bitVector240_299 = DecodePayload(payload, 40, 10);

            _bitVector300_359 = DecodePayload(payload, 50, 10);
            _bitVector360_419 = DecodePayload(payload, 60, 10);
            _bitVector420_423 = DecodePayload(payload, 70, 1);

            SetBitVector0_59();
            SetBitVector60_119();
            SetBitVector120_179();
            SetBitVector180_239();
            SetBitVector240_299();
            SetBitVector300_359();
            SetBitVector360_419();
            SetBitVector420_423();
        }

        protected override IList<String> EncodePayloads()
        {
            IList<String> payloads = new List<String>();

            StringBuilder payload = new StringBuilder();
            StringBuilder payload2 = new StringBuilder();

            GetBitVector0_59();
            GetBitVector60_119();
            GetBitVector120_179();
            GetBitVector180_239();
            GetBitVector240_299();
            GetBitVector300_359();
            GetBitVector360_419();
            GetBitVector420_423();

            payload.Append(EncodePayload(_bitVector0_59, 60));
            payload.Append(EncodePayload(_bitVector60_119, 60));
            payload.Append(EncodePayload(_bitVector120_179, 60));
            payload.Append(EncodePayload(_bitVector180_239, 60));
            payload.Append(EncodePayload(_bitVector240_299, 60));

            payload2.Append(EncodePayload(_bitVector300_359, 60));
            payload2.Append(EncodePayload(_bitVector360_419, 60));
            payload2.Append(EncodePayload(_bitVector420_423, 6));

            payloads.Add(payload.ToString());
            payloads.Add(payload2.ToString());

            return payloads;
        }

        private void GetBitVector0_59()
        {
            _bitVector0_59 = messageId6;

            _bitVector0_59 <<= 2;
            _bitVector0_59 |= repeatIndicator2;

            _bitVector0_59 <<= 30;
            _bitVector0_59 |= userId30;

            _bitVector0_59 <<= 2;
            _bitVector0_59 |= aisVersion2;

            _bitVector0_59 <<= 20;
            _bitVector0_59 |= GetBitVector((UInt64)imoNumber30, 30, 10);
        }

        private void GetBitVector60_119()
        {
            _bitVector60_119 = GetBitVector((UInt64)imoNumber30, 10);

            _bitVector60_119 <<= 42;
            _bitVector60_119 |= callSign42;

            _bitVector60_119 <<= 8;
            _bitVector60_119 |= GetBitVector((UInt64)name0_59, 60, 52);
        }

        private void GetBitVector120_179()
        {
            _bitVector120_179 = GetBitVector((UInt64)name0_59, 52);

            _bitVector120_179 <<= 8;
            _bitVector120_179 |= GetBitVector((UInt64)name60_119, 60, 52);
        }

        private void GetBitVector180_239()
        {
            _bitVector180_239 = GetBitVector((UInt64)name60_119, 52);

            _bitVector180_239 <<= 8;
            _bitVector180_239 |= shipAndCargoType8;
        }

        private void GetBitVector240_299()
        {
            _bitVector240_299 = dimensionToBow9;

            _bitVector240_299 <<= 9;
            _bitVector240_299 |= dimensionToStern9;

            _bitVector240_299 <<= 6;
            _bitVector240_299 |= dimensionToPort6;

            _bitVector240_299 <<= 6;
            _bitVector240_299 |= dimensionToStarboard6;

            _bitVector240_299 <<= 4;
            _bitVector240_299 |= electronicPositionFixingDevice4;

            _bitVector240_299 <<= 4;
            _bitVector240_299 |= etaMonth4;

            _bitVector240_299 <<= 5;
            _bitVector240_299 |= etaDay5;

            _bitVector240_299 <<= 5;
            _bitVector240_299 |= etaHour5;

            _bitVector240_299 <<= 6;
            _bitVector240_299 |= etaMinute6;

            _bitVector240_299 <<= 6;
            _bitVector240_299 |= GetBitVector((UInt64)maxPresentStaticDraught8, 8, 2);
        }

        private void GetBitVector300_359()
        {
            _bitVector300_359 = GetBitVector((UInt64)maxPresentStaticDraught8, 2);

            _bitVector300_359 <<= 58;
            _bitVector300_359 |= GetBitVector((UInt64)destination0_59, 60, 2);
        }

        private void GetBitVector360_419()
        {
            _bitVector360_419 = GetBitVector((UInt64)destination0_59, 2);

            _bitVector360_419 <<= 58;
            _bitVector360_419 |= GetBitVector((UInt64)destination60_119, 60, 2);
        }

        private void GetBitVector420_423()
        {
            _bitVector420_423 = GetBitVector((UInt64)destination60_119, 2);

            _bitVector420_423 <<= 1;
            _bitVector420_423 |= dataTerminalEquipment1;

            _bitVector420_423 <<= 1;
            _bitVector420_423 |= spare1;

            _bitVector420_423 <<= 2;
        }

        private void SetBitVector0_59()
        {
            imoNumber30 = (UInt32)(_bitVector0_59 & 0xFFFFF);
            imoNumber30 <<= 10;
            _bitVector0_59 >>= 20;

            aisVersion2 = (UInt16)(_bitVector0_59 & 0x3);
            _bitVector0_59 >>= 2;

            userId30 = (UInt32)(_bitVector0_59 & 0x3FFFFFFF);
            _bitVector0_59 >>= 30;

            repeatIndicator2 = (UInt16)(_bitVector0_59 & 0x3);
            _bitVector0_59 >>= 2;

            messageId6 = (UInt16)(_bitVector0_59 & 0x3F);
            _bitVector0_59 >>= 6;
        }

        private void SetBitVector60_119()
        {
            name0_59 = (UInt64)(_bitVector60_119 & 0xFF);
            name0_59 <<= 52;
            _bitVector60_119 >>= 8;

            callSign42 = (UInt64)(_bitVector60_119 & 0x3FFFFFFFFFF);
            _bitVector60_119 >>= 42;

            imoNumber30 |= (UInt32)(_bitVector60_119 & 0x3FF);
            _bitVector60_119 >>= 10;
        }

        private void SetBitVector120_179()
        {
            name60_119 = (UInt64)(_bitVector120_179 & 0xFF);
            name60_119 <<= 52;
            _bitVector120_179 >>= 8;

            name0_59 |= (UInt64)(_bitVector120_179 & 0xFFFFFFFFFFFFF);
            _bitVector120_179 >>= 52;
        }

        private void SetBitVector180_239()
        {
            shipAndCargoType8 = (UInt16)(_bitVector180_239 & 0xFF);
            _bitVector180_239 >>= 8;

            name60_119 |= (UInt64)(_bitVector180_239 & 0xFFFFFFFFFFFFF);
            _bitVector180_239 >>= 52;
        }

        private void SetBitVector240_299()
        {
            maxPresentStaticDraught8 = (UInt16)(_bitVector240_299 & 0x3F);
            maxPresentStaticDraught8 <<= 2;
            _bitVector240_299 >>= 6;

            etaMinute6 = (UInt16)(_bitVector240_299 & 0x3F);
            _bitVector240_299 >>= 6;

            etaHour5 = (UInt16)(_bitVector240_299 & 0x1F);
            _bitVector240_299 >>= 5;

            etaDay5 = (UInt16)(_bitVector240_299 & 0x1F);
            _bitVector240_299 >>= 5;

            etaMonth4 = (UInt16)(_bitVector240_299 & 0xF);
            _bitVector240_299 >>= 4;

            electronicPositionFixingDevice4 = (UInt16)(_bitVector240_299 & 0xF);
            _bitVector240_299 >>= 4;

            dimensionToStarboard6 = (UInt16)(_bitVector240_299 & 0x3F);
            _bitVector240_299 >>= 6;

            dimensionToPort6 = (UInt16)(_bitVector240_299 & 0x3F);
            _bitVector240_299 >>= 6;

            dimensionToStern9 = (UInt16)(_bitVector240_299 & 0x1FF);
            _bitVector240_299 >>= 9;

            dimensionToBow9 = (UInt16)(_bitVector240_299 & 0x1FF);
            _bitVector240_299 >>= 9;
        }

        private void SetBitVector300_359()
        {
            destination0_59 = (UInt64)(_bitVector300_359 & 0x3FFFFFFFFFFFFFF);
            destination0_59 <<= 2;
            _bitVector300_359 >>= 58;

            maxPresentStaticDraught8 |= (UInt16)(_bitVector300_359 & 0x3);
            _bitVector300_359 >>= 2;
        }

        private void SetBitVector360_419()
        {
            destination60_119 = (UInt64)(_bitVector360_419 & 0x3FFFFFFFFFFFFFF);
            destination60_119 <<= 2;
            _bitVector360_419 >>= 58;

            destination0_59 |= (UInt64)(_bitVector360_419 & 0x3);
            _bitVector360_419 >>= 2;
        }

        private void SetBitVector420_423()
        {
            _bitVector420_423 >>= 2;

            spare1 = (UInt16)(_bitVector420_423 & 0x1);
            _bitVector420_423 >>= 1;

            dataTerminalEquipment1 = (UInt16)(_bitVector420_423 & 0x1);
            _bitVector420_423 >>= 1;

            destination60_119 |= (UInt64)(_bitVector420_423 & 0x3);
            _bitVector420_423 >>= 2;
        }

        public enum AISVersionEnum
        {
            /// <summary>
            /// 0 = station compliant with Recommendation ITU-R M.1371-1
            /// </summary>
            CompliantWithRecommendationITU_R_M_1371_1 = 0,
            /// <summary>
            /// 1 = station compliant with Recommendation ITU-R M.1371-3 (or later)
            /// </summary>
            CompliantWithRecommendationITU_R_M_1371_3 = 1,
            /// <summary>
            /// 2 = station compliant with Recommendation ITU-R M.1371-5 (or later)
            /// </summary>
            CompliantWithRecommendationITU_R_M_1371_5 = 2,
            /// <summary>
            /// 3 = station compliant with future editions
            /// </summary>
            CompliantWithFutureVersion = 3,
        }

        public enum ElectronicPositionFixingDeviceEnum
        {
            /// <summary>
            /// 0 = undefined (default)
            /// </summary>
            Undefined = 0,
            /// <summary>
            /// 1 = GPS
            /// </summary>
            GPS = 1,
            /// <summary>
            /// 2 = GLONASS
            /// </summary>
            GLONASS = 2,
            /// <summary>
            /// 3 = combined GPS/GLONASS
            /// </summary>
            CombinedGPSGLONASS = 3,
            /// <summary>
            /// 4 = Loran-C
            /// </summary>
            LoranC = 4,
            /// <summary>
            /// 5 = Chakya
            /// </summary>
            Chayka = 5,
            /// <summary>
            /// 6 = integrated navigation system
            /// </summary>
            IntegratedNavigationSystem = 6,
            /// <summary>
            /// 7 = surveyed
            /// </summary>
            Surveyed = 7,
            /// <summary>
            /// 8 = Galileo
            /// </summary>
            Galileo = 8,
            /// <summary>
            /// 15 = internal GNSS
            /// </summary>
            InternalGNSS = 15
        }
    }
}
