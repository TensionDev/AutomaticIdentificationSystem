﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.AIS
{
    /// <summary>
    /// Message 19: Extended class B equipment position report
    /// </summary>
    /// <remarks>For future equipment: this message is not needed and should not be used. All content is covered by Message 18, Message 24A and 24B.</remarks>
    [Obsolete("For future equipment: this message is not needed and should not be used. All content is covered by Message 18, Message 24A and 24B.")]
    public class AISMessage19 : AISMessage
    {
        private UInt64 _bitVector0_59;
        private UInt64 _bitVector60_119;
        private UInt64 _bitVector120_179;
        private UInt64 _bitVector180_239;
        private UInt64 _bitVector240_299;
        private UInt64 _bitVector300_311;

        protected UInt32 userId30;
        protected UInt16 spare8;
        protected UInt16 speedOverGround10;
        protected Boolean positionAccuracy1;
        protected Int32 longitude28;
        protected Int32 latitude27;
        protected UInt16 courseOverGround12;
        protected UInt16 trueHeading9;
        protected UInt16 timestamp6;
        protected UInt16 spare2_4;
        protected UInt64 name0_59;
        protected UInt64 name60_119;
        protected UInt16 shipAndCargoType8;
        protected UInt16 dimensionToBow9;
        protected UInt16 dimensionToStern9;
        protected UInt16 dimensionToPort6;
        protected UInt16 dimensionToStarboard6;
        protected UInt16 electronicPositionFixingDevice4;
        protected Boolean raim1;
        protected UInt16 dataTerminalEquipment1;
        protected UInt16 assignedModeFlag1;
        protected UInt16 spare3_4;

        /// <summary>
        /// Unique identifier such as MMSI number
        /// </summary>
        public String UserId { get => userId30.ToString("D9"); set => userId30 = UInt32.Parse(value); }

        /// <summary>
        /// Speed Over Ground in Knots
        /// </summary>
        public Decimal SpeedOverGroundKnots { get => speedOverGround10 < 1023 ? speedOverGround10 / 10.0M : 0; set => speedOverGround10 = (UInt16)Math.Min(1023, Math.Abs(value * 10)); }

        /// <summary>
        /// Is the Speed Over Ground Available?
        /// </summary>
        public Boolean SpeedOverGroundAvailable { get => speedOverGround10 < 1023; }

        /// <summary>
        /// The position accuracy (PA) flag should be determined in accordance with Table 50
        /// <para>True = high (Less Than or Equal to 10 m)</para>
        /// <para>False = low (Greater Than 10 m)</para>
        /// <para>False = default</para>
        /// </summary>
        public Boolean PositionAccuracy { get => positionAccuracy1; set => positionAccuracy1 = value; }

        /// <summary>
        /// <para>Longitude in Decimal Degrees</para>
        /// Longitude stored in 1/10 000 min (+-180°, East = positive (as per 2’s complement),
        /// West = negative(as per 2’s complement).
        /// 181 = (0x6791AC0) = not available = default)
        /// </summary>
        public Decimal LongitudeDecimalDegrees { get => (longitude28 / 10000.0M) / 60.0M; set => longitude28 = (Int32)((value * 60.0M) * 10000.0M); }

        /// <summary>
        /// Is the Longitude Available
        /// </summary>
        public Boolean LongitudeAvailable { get => longitude28 != 0x6791AC0; }

        /// <summary>
        /// <para>Latitude in Decimal Degrees</para>
        /// Latitude stored in 1/10 000 min (+-90°, North = positive (as per 2’s complement),
        /// South = negative(as per 2’s complement).
        /// 91 = (0x3412140) = not available = default)
        /// </summary>
        public Decimal LatitudeDecimalDegrees { get => (latitude27 / 10000.0M) / 60.0M; set => latitude27 = (Int32)((value * 60.0M) * 10000.0M); }

        /// <summary>
        /// Is the Latitude Available
        /// </summary>
        public Boolean LatitudeAvailable { get => latitude27 != 0x3412140; }

        /// <summary>
        /// Course Over Ground
        /// </summary>
        public Decimal CourseOverGroundDegrees { get => courseOverGround12 / 10.0M; set { if (Math.Abs(value) < 360.0M) { courseOverGround12 = (UInt16)Math.Abs(value * 10); } else { courseOverGround12 = 3600; } } }

        /// <summary>
        /// Is the Course Over Ground Available
        /// </summary>
        public Boolean CourseOverGroundAvailable { get => courseOverGround12 < 3600; }

        /// <summary>
        /// True Heading
        /// </summary>
        public UInt16 TrueHeadingDegrees { get => trueHeading9; set { if (value < 360) { trueHeading9 = value; } else { trueHeading9 = 511; } } }

        /// <summary>
        /// Is the True Heading Available
        /// </summary>
        public Boolean TrueHeadingAvailable { get => trueHeading9 < 360; }

        /// <summary>
        /// <para>UTC second when the report was generated by the electronic position system (EPFS)</para>
        /// (0-59, or 60 if time stamp is not available, which should also be the
        /// default value, or 61 if positioning system is in manual input mode, or 62 if
        /// electronic position fixing system operates in estimated(dead reckoning)
        /// mode, or 63 if the positioning system is inoperative)
        /// </summary>
        public UInt16 Timestamp { get => timestamp6; set => timestamp6 = value; }


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
        /// Receiver autonomous integrity monitoring (RAIM) flag of electronic
        /// position fixing device; 
        /// <para>False = RAIM not in use = default;</para>
        /// <para>True = RAIM in use.</para>
        /// </summary>
        public Boolean RAIMFlag { get => raim1; set => raim1 = value; }

        /// <summary>
        /// Data terminal equipment (DTE) ready (0 = available, 1 = not available = default) (see § 3.3.1)
        /// </summary>
        public Boolean DTE { get => dataTerminalEquipment1 == 0; set { if (value) { dataTerminalEquipment1 = 0; } else { dataTerminalEquipment1 = 1; } } }

        /// <summary>
        /// <para>0 = Station operating in autonomous and continuous mode = default</para>
        /// <para>1 = Station operating in assigned mode</para>
        /// </summary>
        public AssignedModeEnum AssignedModeFlag { get => (AssignedModeEnum)(assignedModeFlag1); set => assignedModeFlag1 = (UInt16)value; }

        public AISMessage19()
        {
            MessageId = 19;
            RepeatIndicator = 0;
            speedOverGround10 = 1023;
            positionAccuracy1 = false;
            longitude28 = 0x6791AC0;
            latitude27 = 0x3412140;
            courseOverGround12 = 3600;
            trueHeading9 = 511;
            timestamp6 = 60;
            name0_59 = 0;
            name60_119 = 0;
            shipAndCargoType8 = 0;
            dimensionToBow9 = 0;
            dimensionToStern9 = 0;
            dimensionToPort6 = 0;
            dimensionToStarboard6 = 0;
            electronicPositionFixingDevice4 = 0;
            raim1 = true;
            dataTerminalEquipment1 = 1;
            assignedModeFlag1 = 0;
        }

        /// <summary>
        /// Speed over ground in 1/10 knot steps (0-102.2 knots)
        /// 1 023 = not available, 1 022 = 102.2 knots or higher
        /// </summary>
        /// <param name="speedOverGround">Speed Over Ground at up to 102.2 knots or higher</param>
        /// <param name="SOGAvailable">Is the Speed Over Ground value available?</param>
        public void SetSpeedOverGround(Decimal speedOverGround, Boolean SOGAvailable = true)
        {
            if (SOGAvailable)
            {
                speedOverGround10 = Math.Min((UInt16)1022, (UInt16)Math.Abs(speedOverGround * 10.0M));
            }
            else
            {
                speedOverGround10 = 1023;
            }
        }

        /// <summary>
        /// Longitude in 1/10 000 min (+-180°, East = positive (as per 2’s complement),
        /// West = negative(as per 2’s complement).
        /// 181 = (0x6791AC0) = not available = default)
        /// </summary>
        /// <param name="longitudeDD">Logitude in Decimal Degrees</param>
        /// <param name="LongitudeAvailable">Is Longitude value available?</param>
        public void SetLongitude(Decimal longitudeDD, Boolean LongitudeAvailable = true)
        {
            if (LongitudeAvailable)
            {
                longitude28 = (Int32)(longitudeDD * 60.0M * 10000.0M);
            }
            else
            {
                longitude28 = 0x6791AC0;
            }
        }

        /// <summary>
        /// Latitude in 1/10 000 min (±90°, North = positive (as per 2’s complement),
        /// South = negative(as per 2’s complement).
        /// 91° (0x3412140) = not available = default)
        /// </summary>
        /// <param name="latitudeDD">Latitude in Decimal Degrees</param>
        /// <param name="LatitudeAvailable">Is Latitude value available?</param>
        public void SetLatitude(Decimal latitudeDD, Boolean LatitudeAvailable = true)
        {
            if (LatitudeAvailable)
            {
                latitude27 = (Int32)(latitudeDD * 60.0M * 10000.0M);
            }
            else
            {
                latitude27 = 0x3412140;
            }
        }

        /// <summary>
        /// Course over ground in 1/10 = (0-3 599). 3 600 (E10h) = not available =
        /// default. 3 601-4 095 should not be used
        /// </summary>
        /// <param name="courseOverGround">Course Over Ground</param>
        /// <param name="COGAvailable">Is the Course Over Ground value available?</param>
        public void SetCourseOverGround(Decimal courseOverGround, Boolean COGAvailable = true)
        {
            if (COGAvailable)
            {
                courseOverGround12 = Math.Min((UInt16)3599, (UInt16)Math.Abs(courseOverGround * 10.0M));
            }
            else
            {
                courseOverGround12 = 3600;
            }
        }

        /// <summary>
        /// Degrees (0-359) (511 indicates not available = default)
        /// </summary>
        /// <param name="trueHeading">True Heading</param>
        /// <param name="TrueHeadingAvailable">Is the True Heading Over Ground value available?</param>
        public void SetTrueHeading(UInt16 trueHeading, Boolean TrueHeadingAvailable = true)
        {
            if (TrueHeadingAvailable)
            {
                trueHeading9 = Math.Min((UInt16)359, (trueHeading));
            }
            else
            {
                trueHeading9 = 511;
            }
        }

        public override IList<String> EncodeSentences()
        {
            IList<String> sentences = new List<String>();

            StringBuilder stringBuilder = new StringBuilder();
            IList<String> payload = EncodePayloads();

            stringBuilder.AppendFormat("!AI{0},1,1,,B,{1},0", SentenceFormatter.ToString(), payload[0]);

            Byte checksum = CalculateChecksum(stringBuilder.ToString());

            stringBuilder.AppendFormat("*{0}\r\n", checksum.ToString("X2"));

            sentences.Add(stringBuilder.ToString());

            return sentences;
        }

        protected override void DecodePayloads(IList<String> payloads)
        {
            if (payloads.Count != 1)
                throw new ArgumentOutOfRangeException(nameof(payloads));

            String payload = payloads[0];

            _bitVector0_59 = DecodePayload(payload, 0, 10);
            _bitVector60_119 = DecodePayload(payload, 10, 10);
            _bitVector120_179 = DecodePayload(payload, 20, 10);
            _bitVector180_239 = DecodePayload(payload, 30, 10);
            _bitVector240_299 = DecodePayload(payload, 40, 10);

            _bitVector300_311 = DecodePayload(payload, 50, 2);

            SetBitVector0_59();
            SetBitVector60_119();
            SetBitVector120_179();
            SetBitVector180_239();
            SetBitVector240_299();
            SetBitVector300_311();
        }

        protected override IList<String> EncodePayloads()
        {
            IList<String> payloads = new List<String>();

            StringBuilder payload = new StringBuilder();

            GetBitVector0_59();
            GetBitVector60_119();
            GetBitVector120_179();
            GetBitVector180_239();
            GetBitVector240_299();
            GetBitVector300_311();

            payload.Append(EncodePayload(_bitVector0_59, 60));
            payload.Append(EncodePayload(_bitVector60_119, 60));
            payload.Append(EncodePayload(_bitVector120_179, 60));
            payload.Append(EncodePayload(_bitVector180_239, 60));
            payload.Append(EncodePayload(_bitVector240_299, 60));
            payload.Append(EncodePayload(_bitVector300_311, 12));

            payloads.Add(payload.ToString());

            return payloads;
        }

        private void GetBitVector0_59()
        {
            _bitVector0_59 = 0;

            _bitVector0_59 = messageId6;

            _bitVector0_59 <<= 2;
            _bitVector0_59 |= repeatIndicator2;

            _bitVector0_59 <<= 30;
            _bitVector0_59 |= userId30;

            _bitVector0_59 <<= 8;
            _bitVector0_59 |= spare8;

            _bitVector0_59 <<= 10;
            _bitVector0_59 |= speedOverGround10;

            _bitVector0_59 <<= 1;
            if (positionAccuracy1)
            {
                _bitVector0_59 |= 1;
            }

            if (longitude28 < 0)
            {
                UInt64 tempLongitude = (UInt64)(longitude28 + 0xFFFFFFF);

                _bitVector0_59 <<= 3;
                _bitVector0_59 |= GetBitVector(tempLongitude, 28, 25);
            }
            else
            {
                _bitVector0_59 <<= 3;
                _bitVector0_59 |= GetBitVector(longitude28, 28, 25);
            }
        }

        private void GetBitVector60_119()
        {
            _bitVector60_119 = 0;

            if (longitude28 < 0)
            {
                UInt64 tempLongitude = (UInt64)(longitude28 + 0xFFFFFFF);

                _bitVector60_119 = GetBitVector(tempLongitude, 25);
            }
            else
            {
                _bitVector60_119 = GetBitVector((UInt64)longitude28, 25);
            }

            if (latitude27 < 0)
            {
                UInt64 tempLatitude = (UInt64)(latitude27 + 0x7FFFFFF);

                _bitVector60_119 <<= 27;
                _bitVector60_119 |= tempLatitude;
            }
            else
            {
                _bitVector60_119 <<= 27;
                _bitVector60_119 |= (UInt32)latitude27;
            }

            _bitVector60_119 <<= 8;
            _bitVector60_119 |= GetBitVector((UInt64)courseOverGround12, 12, 4);
        }

        private void GetBitVector120_179()
        {
            _bitVector120_179 = 0;

            _bitVector120_179 = GetBitVector((UInt64)courseOverGround12, 4);

            _bitVector120_179 <<= 9;
            _bitVector120_179 |= trueHeading9;

            _bitVector120_179 <<= 6;
            _bitVector120_179 |= timestamp6;

            _bitVector120_179 <<= 4;
            _bitVector120_179 |= spare2_4;

            _bitVector120_179 <<= 37;
            _bitVector120_179 |= GetBitVector(name0_59, 60, 23);
        }

        private void GetBitVector180_239()
        {
            _bitVector180_239 = 0;

            _bitVector180_239 = GetBitVector(name0_59, 23);

            _bitVector180_239 <<= 37;
            _bitVector180_239 |= GetBitVector(name60_119, 60, 23);
        }

        private void GetBitVector240_299()
        {
            _bitVector240_299 = 0;

            _bitVector240_299 = GetBitVector(name60_119, 23);

            _bitVector240_299 <<= 8;
            _bitVector240_299 |= shipAndCargoType8;

            _bitVector240_299 <<= 9;
            _bitVector240_299 |= dimensionToBow9;

            _bitVector240_299 <<= 9;
            _bitVector240_299 |= dimensionToStern9;

            _bitVector240_299 <<= 6;
            _bitVector240_299 |= dimensionToPort6;

            _bitVector240_299 <<= 5;
            _bitVector240_299 |= GetBitVector((UInt64)dimensionToStarboard6, 6, 1);
        }

        private void GetBitVector300_311()
        {
            _bitVector300_311 = 0;

            _bitVector300_311 = GetBitVector((UInt64)dimensionToStarboard6, 1);

            _bitVector300_311 <<= 4;
            _bitVector300_311 |= electronicPositionFixingDevice4;

            _bitVector300_311 <<= 1;
            if (raim1)
            {
                _bitVector300_311 |= 1;
            }

            _bitVector300_311 <<= 1;
            _bitVector300_311 |= dataTerminalEquipment1;

            _bitVector300_311 <<= 1;
            _bitVector300_311 |= assignedModeFlag1;

            _bitVector300_311 <<= 4;
            _bitVector300_311 |= spare3_4;
        }

        private void SetBitVector0_59()
        {
            longitude28 = (Int32)(_bitVector0_59 & 0x7);
            longitude28 <<= 25;
            _bitVector0_59 >>= 3;

            positionAccuracy1 = ((_bitVector0_59 & 0x1) != 0);
            _bitVector0_59 >>= 1;

            speedOverGround10 = (UInt16)(_bitVector0_59 & 0x3FF);
            _bitVector0_59 >>= 10;

            spare8 = (UInt16)(_bitVector0_59 & 0xFF);
            _bitVector0_59 >>= 8;

            userId30 = (UInt32)(_bitVector0_59 & 0x3FFFFFFF);
            _bitVector0_59 >>= 30;

            repeatIndicator2 = (UInt16)(_bitVector0_59 & 0x3);
            _bitVector0_59 >>= 2;

            messageId6 = (UInt16)(_bitVector0_59 & 0x3F);
            _bitVector0_59 >>= 6;
        }

        private void SetBitVector60_119()
        {
            courseOverGround12 = (UInt16)(_bitVector60_119 & 0xFF);
            courseOverGround12 <<= 4;
            _bitVector60_119 >>= 8;

            latitude27 = (Int32)(_bitVector60_119 & 0x7FFFFFF);
            if (latitude27 > 0x3FFFFFF)
            {
                latitude27 -= 0x7FFFFFF;
            }
            _bitVector60_119 >>= 27;

            longitude28 |= (Int32)(_bitVector60_119 & 0x1FFFFFF);
            _bitVector60_119 >>= 25;
            if (longitude28 > 0x7FFFFFF)
            {
                longitude28 -= 0xFFFFFFF;
            }
        }

        private void SetBitVector120_179()
        {
            name0_59 = _bitVector120_179 & 0x1FFFFFFFFF;
            name0_59 <<= 23;
            _bitVector120_179 >>= 37;

            spare2_4 = (UInt16)(_bitVector120_179 & 0xF);
            _bitVector120_179 >>= 4;

            timestamp6 = (UInt16)(_bitVector120_179 & 0x3F);
            _bitVector120_179 >>= 6;

            trueHeading9 = (UInt16)(_bitVector120_179 & 0x1FF);
            _bitVector120_179 >>= 9;

            courseOverGround12 |= (UInt16)(_bitVector120_179 & 0xF);
        }

        private void SetBitVector180_239()
        {
            name60_119 = _bitVector180_239 & 0x1FFFFFFFFF;
            name60_119 <<= 23;
            _bitVector180_239 >>= 37;

            name0_59 |= _bitVector180_239 & 0x7FFFFF;
            _bitVector180_239 >>= 23;
        }

        private void SetBitVector240_299()
        {
            dimensionToStarboard6 = (UInt16)(_bitVector240_299 & 0x1F);
            dimensionToStarboard6 <<= 1;
            _bitVector240_299 >>= 5;

            dimensionToPort6 = (UInt16)(_bitVector240_299 & 0x3F);
            _bitVector240_299 >>= 6;

            dimensionToStern9 = (UInt16)(_bitVector240_299 & 0x1FF);
            _bitVector240_299 >>= 9;

            dimensionToBow9 = (UInt16)(_bitVector240_299 & 0x1FF);
            _bitVector240_299 >>= 9;

            shipAndCargoType8 = (UInt16)(_bitVector240_299 & 0xFF);
            _bitVector240_299 >>= 8;

            name60_119 |= _bitVector240_299 & 0x7FFFFF;
            _bitVector240_299 >>= 23;
        }

        private void SetBitVector300_311()
        {
            spare3_4 = (UInt16)(_bitVector300_311 & 0xF);
            _bitVector300_311 >>= 4;

            assignedModeFlag1 = (UInt16)(_bitVector300_311 & 0x1);
            _bitVector300_311 >>= 1;

            dataTerminalEquipment1 = (UInt16)(_bitVector300_311 & 0x1);
            _bitVector300_311 >>= 1;

            raim1 = ((_bitVector300_311 & 0x1) != 0);
            _bitVector300_311 >>= 1;

            electronicPositionFixingDevice4 = (UInt16)(_bitVector300_311 & 0xF);
            _bitVector300_311 >>= 4;

            dimensionToStarboard6 |= (UInt16)(_bitVector300_311 & 0x1);
            _bitVector300_311 >>= 1;
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

        public enum AssignedModeEnum
        {
            /// <summary>
            /// 0 = Station operating in autonomous and continuous mode
            /// </summary>
            AutonomousContinuousMode = 0,
            /// <summary>
            /// 1 = Station operating in assigned mode
            /// </summary>
            AssignedMode = 1,
        }
    }
}
