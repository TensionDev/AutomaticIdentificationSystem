using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.AIS
{
    /// <summary>
    /// Message 2: Position report (Assigned)
    /// </summary>
    public class AISMessage02 : AISMessage
    {
        private const double RATE_OF_TURN_COEFFICIENT = 4.733;
        private UInt64 _bitVector0_59;
        private UInt64 _bitVector60_119;
        private UInt64 _bitVector120_167;

        protected UInt32 userId30;
        protected UInt16 navigationalStatus4;
        protected Int16 rateOfTurn8;
        protected UInt16 speedOverGround10;
        protected Boolean positionAccuracy1;
        protected Int32 longitude28;
        protected Int32 latitude27;
        protected UInt16 courseOverGround12;
        protected UInt16 trueHeading9;
        protected UInt16 timestamp6;
        protected UInt16 specialManoeuvreIndicator2;
        protected UInt16 spare3;
        protected Boolean raim1;

        /// <summary>
        /// Unique identifier such as MMSI number
        /// </summary>
        public String UserId { get => userId30.ToString("D9"); set => userId30 = UInt32.Parse(value); }

        /// <summary>
        /// Navigation Status
        /// </summary>
        public NavigationalStatusEnum NavigationalStatus { get => (NavigationalStatusEnum)(navigationalStatus4); set => navigationalStatus4 = (UInt16)value; }

        /// <summary>
        /// Rate of Turn in degrees per minute
        /// </summary>
        public Double RateOfTurnDegreesPerMinute
        {
            get
            {
                if (rateOfTurn8 == -128)
                {
                    return 0;
                }
                else if (rateOfTurn8 == -127 || rateOfTurn8 == 127)
                {
                    if (rateOfTurn8 == -127)
                    {
                        return -10;
                    }
                    else
                    {
                        return 10;
                    }
                }
                else
                {
                    Double rot = Math.Pow(rateOfTurn8 / RATE_OF_TURN_COEFFICIENT, 2);
                    if (rateOfTurn8 < 0)
                    {
                        rot *= -1;
                    }

                    return rot;
                }
            }
        }

        /// <summary>
        /// Is the Turn Indicator Available?
        /// </summary>
        public Boolean TurnIndicatorAvailable { get => Math.Abs(rateOfTurn8) < 127; }

        /// <summary>
        /// Is the Turn Information Available?
        /// </summary>
        public Boolean TurnInformationAvailable { get => Math.Abs(rateOfTurn8) < 128; }

        /// <summary>
        /// Speed Over Ground in Knots
        /// </summary>
        public Decimal SpeedOverGroundKnots { get => speedOverGround10 / 10.0M; set => speedOverGround10 = (UInt16)Math.Min(1023, Math.Abs(value * 10)); }

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
        /// <para>0 = not available = default</para>
        /// <para>1 = not engaged in special manoeuvre</para>
        /// <para>2 = engaged in special manoeuvre</para>
        /// <para>(i.e.regional passing arrangement on Inland Waterway)</para>
        /// </summary>
        public SpecialManoeuvreIndicatorEnum SpecialManoeuvreIndicator { get => (SpecialManoeuvreIndicatorEnum)(specialManoeuvreIndicator2); set => specialManoeuvreIndicator2 = (UInt16)value; }

        /// <summary>
        /// Receiver autonomous integrity monitoring (RAIM) flag of electronic
        /// position fixing device; 
        /// <para>False = RAIM not in use = default;</para>
        /// <para>True = RAIM in use.</para>
        /// </summary>
        public Boolean RAIMFlag { get => raim1; set => raim1 = value; }

        /// <summary>
        /// SOTDMA communication state as described in § 3.3.7.2.2, Annex 2
        /// </summary>
        public SOTDMACommunicationState CommunicationState { get; set; }

        public AISMessage02()
        {
            MessageId = 2;
            RepeatIndicator = 0;
            NavigationalStatus = NavigationalStatusEnum.Undefined;
            rateOfTurn8 = -128;
            speedOverGround10 = 1023;
            positionAccuracy1 = false;
            longitude28 = 0x6791AC0;
            latitude27 = 0x3412140;
            courseOverGround12 = 3600;
            trueHeading9 = 511;
            timestamp6 = 60;
            specialManoeuvreIndicator2 = 0;
            raim1 = false;
        }

        /// <summary>
        /// <para>0 to +126 = turning right at up to 708° per min or higher</para>
        /// <para>0 to –126 = turning left at up to 708° per min or higher</para>
        /// <para>Values between 0 and 708° per min coded by</para>
        /// <para>ROTAIS = 4.733 SQRT(ROTsensor) degrees per min</para>
        /// <para>where ROTsensor is the Rate of Turn as input by an external Rate of Turn</para>
        /// <para>Indicator(TI). ROTAIS is rounded to the nearest integer value.</para>
        /// <para>+127 = turning right at more than 5° per 30 s (No TI available)</para>
        /// <para>–127 = turning left at more than 5° per 30 s(No TI available)</para>
        /// </summary>
        /// <param name="rateOfTurn">
        /// <para>Rate of turn at up to 708° per min or higher.</para>
        /// <para>Positive is turning right, Negative is turning left.</para>
        /// </param>
        /// <param name="TurnIndicatorAvailable">Is the Turn Indicator available?</param>
        public void SetRateOfTurn(Double rateOfTurn, Boolean TurnIndicatorAvailable = true)
        {
            if (TurnIndicatorAvailable)
            {
                if (rateOfTurn < 0)
                {
                    var raw = (RATE_OF_TURN_COEFFICIENT * Math.Sqrt(Math.Abs(rateOfTurn)));
                    raw = Math.Floor(raw + 0.5);
                    var value = Math.Min((UInt16)raw,
                        (UInt16)126);
                    rateOfTurn8 = (Int16)((-1) * value);
                }
                else
                {
                    var raw = (RATE_OF_TURN_COEFFICIENT * Math.Sqrt(Math.Abs(rateOfTurn)));
                    raw = Math.Floor(raw + 0.5);
                    var value = Math.Min((UInt16)raw,
                        (UInt16)126);
                    rateOfTurn8 = (Int16)value;
                }
            }
            else
            {
                // turning left at more than 5° per 30 s (No TI available)
                // turning left at more than 10° per minute
                if (rateOfTurn < -10)
                {
                    rateOfTurn8 = -127;
                }
                // turning right at more than 5° per 30 s (No TI available)
                // turning right at more than 10° per minute
                else if (rateOfTurn > 10)
                {
                    rateOfTurn8 = 127;
                }
                else
                {
                    rateOfTurn8 = 0;
                }
            }
        }

        /// <summary>
        /// –128 (80 hex) indicates no turn information available (default)
        /// </summary>
        public void SetNoTurnInformation()
        {
            rateOfTurn8 = -128;
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

            stringBuilder.AppendFormat("!AI{0},1,1,,A,{1},0", SentenceFormatter.ToString(), payload[0]);

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
            _bitVector120_167 = DecodePayload(payload, 20, 8);

            SetBitVector0_59();
            SetBitVector60_119();
            SetBitVector120_167();
        }

        protected override IList<String> EncodePayloads()
        {
            IList<String> payloads = new List<String>();

            StringBuilder payload = new StringBuilder();

            GetBitVector0_59();
            GetBitVector60_119();
            GetBitVector120_167();

            payload.Append(EncodePayload(_bitVector0_59, 60));
            payload.Append(EncodePayload(_bitVector60_119, 60));
            payload.Append(EncodePayload(_bitVector120_167, 48));

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

            _bitVector0_59 <<= 4;
            _bitVector0_59 |= navigationalStatus4;

            if (rateOfTurn8 < 0)
            {
                UInt64 tempRateOfTurn = (UInt64)(rateOfTurn8 + 0xFF);

                _bitVector0_59 <<= 8;
                _bitVector0_59 |= tempRateOfTurn;
            }
            else
            {
                _bitVector0_59 <<= 8;
                _bitVector0_59 |= (UInt16)rateOfTurn8;
            }

            _bitVector0_59 <<= 10;
            _bitVector0_59 |= speedOverGround10;
        }

        private void GetBitVector60_119()
        {
            _bitVector60_119 = 0;

            if (positionAccuracy1)
            {
                _bitVector60_119 |= 1;
            }

            if (longitude28 < 0)
            {
                UInt64 tempLongitude = (UInt64)(longitude28 + 0xFFFFFFF);

                _bitVector60_119 <<= 28;
                _bitVector60_119 |= tempLongitude;
            }
            else
            {
                _bitVector60_119 <<= 28;
                _bitVector60_119 |= (UInt32)longitude28;
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

            _bitVector60_119 <<= 4;
            _bitVector60_119 |= GetBitVector((UInt64)courseOverGround12, 12, 8);
        }

        private void GetBitVector120_167()
        {
            _bitVector120_167 = 0;

            _bitVector120_167 = GetBitVector((UInt64)courseOverGround12, 8);

            _bitVector120_167 <<= 9;
            _bitVector120_167 |= trueHeading9;

            _bitVector120_167 <<= 6;
            _bitVector120_167 |= timestamp6;

            _bitVector120_167 <<= 2;
            _bitVector120_167 |= specialManoeuvreIndicator2;

            _bitVector120_167 <<= 3;
            _bitVector120_167 |= spare3;

            _bitVector120_167 <<= 1;
            if (raim1)
            {
                _bitVector120_167 |= 1;
            }

            _bitVector120_167 <<= 19;
            _bitVector120_167 |= CommunicationState.CommunicationState;
        }

        private void SetBitVector0_59()
        {
            speedOverGround10 = (UInt16)(_bitVector0_59 & 0x3FF);
            _bitVector0_59 >>= 10;

            rateOfTurn8 = (Int16)(_bitVector0_59 & 0xFF);
            if (rateOfTurn8 > 0x7F)
            {
                rateOfTurn8 -= 0x100;
            }
            _bitVector0_59 >>= 8;

            navigationalStatus4 = (UInt16)(_bitVector0_59 & 0xF);
            _bitVector0_59 >>= 4;

            userId30 = (UInt32)(_bitVector0_59 & 0x3FFFFFFF);
            _bitVector0_59 >>= 30;

            repeatIndicator2 = (UInt16)(_bitVector0_59 & 0x3);
            _bitVector0_59 >>= 2;

            messageId6 = (UInt16)(_bitVector0_59 & 0x3F);
            _bitVector0_59 >>= 6;
        }

        private void SetBitVector60_119()
        {
            courseOverGround12 = (UInt16)(_bitVector60_119 & 0xF);
            courseOverGround12 <<= 8;
            _bitVector60_119 >>= 4;

            latitude27 = (Int32)(_bitVector60_119 & 0x7FFFFFF);
            if (latitude27 > 0x3FFFFFF)
            {
                latitude27 -= 0x7FFFFFF;
            }
            _bitVector60_119 >>= 27;

            longitude28 = (Int32)(_bitVector60_119 & 0xFFFFFFF);
            if (longitude28 > 0x7FFFFFF)
            {
                longitude28 -= 0xFFFFFFF;
            }
            _bitVector60_119 >>= 28;

            positionAccuracy1 = ((_bitVector60_119 & 0x1) != 0);
            _bitVector60_119 >>= 1;
        }

        private void SetBitVector120_167()
        {
            UInt32 communicationState = (UInt32)(_bitVector120_167 & 0x7FFFF);
            _bitVector120_167 >>= 19;
            CommunicationState = new SOTDMACommunicationState()
            {
                CommunicationState = communicationState
            };

            raim1 = ((_bitVector120_167 & 0x1) != 0);
            _bitVector120_167 >>= 1;

            spare3 = (UInt16)(_bitVector120_167 & 0x7);
            _bitVector120_167 >>= 3;

            specialManoeuvreIndicator2 = (UInt16)(_bitVector120_167 & 0x3);
            _bitVector120_167 >>= 2;

            timestamp6 = (UInt16)(_bitVector120_167 & 0x3F);
            _bitVector120_167 >>= 6;

            trueHeading9 = (UInt16)(_bitVector120_167 & 0x1FF);
            _bitVector120_167 >>= 9;

            courseOverGround12 |= (UInt16)(_bitVector120_167 & 0xFF);
            _bitVector120_167 >>= 8;
        }

        public enum NavigationalStatusEnum
        {
            /// <summary>
            /// 0 = under way using engine
            /// </summary>
            UnderWayUsingEngine = 0,
            /// <summary>
            /// 1 = at anchor
            /// </summary>
            AtAnchor = 1,
            /// <summary>
            /// 2 = not under command
            /// </summary>
            NotUnderCommand = 2,
            /// <summary>
            /// 3 = restricted maneuverability
            /// </summary>
            RestrictedManeuverability = 3,
            /// <summary>
            /// 4 = constrained by her draught
            /// </summary>
            ConstrainedByHerDraught = 4,
            /// <summary>
            /// 5 = moored
            /// </summary>
            Moored = 5,
            /// <summary>
            /// 6 = aground
            /// </summary>
            Aground = 6,
            /// <summary>
            /// 7 = engaged in fishing
            /// </summary>
            EnagagedInFishing = 7,
            /// <summary>
            /// 8 = under way sailing
            /// </summary>
            UnderWaySailing = 8,
            /// <summary>
            /// 9 = reserved for
            /// future amendment of navigational status for ships carrying DG, HS, or MP,
            /// or IMO hazard or pollutant category C, high speed craft (HSC)
            /// </summary>
            ReservedForFutureAmendmentForHighSpeedCraft = 9,
            /// <summary>
            /// 10 = reserved for future amendment of navigational status for ships carrying
            /// dangerous goods (DG), harmful substances(HS) or marine pollutants(MP),
            /// or IMO hazard or pollutant category A, wing in ground(WIG)
            /// </summary>
            ReservedForFutureAmendmentForWingInGround = 10,
            /// <summary>
            /// 11 = powerdriven vessel towing astern (regional use)
            /// </summary>
            PowerDrivenVesselTowingAstern = 11,
            /// <summary>
            /// 12 = power-driven vessel pushing ahead or towing alongside (regional use)
            /// </summary>
            PowerDrivenVesselPushingAheadOrTowingAlongside = 12,
            /// <summary>
            /// 13 = reserved for future use,
            /// </summary>
            ReservedForFutureUse = 13,
            /// <summary>
            /// 14 = AIS-SART (active), MOB-AIS, EPIRB-AIS
            /// </summary>
            AISSART = 14,
            /// <summary>
            /// 15 = undefined = default (also used by AIS-SART, MOB-AIS and EPIRB-AIS under test)
            /// </summary>
            Undefined = 15,
        }

        public enum SpecialManoeuvreIndicatorEnum
        {
            /// <summary>
            /// 0 = not available = default
            /// </summary>
            NotAvailable = 0,
            /// <summary>
            /// 1 = not engaged in special manoeuvre
            /// </summary>
            NotEngagedInSpecialManoeuvre = 1,
            /// <summary>
            /// <para>2 = engaged in special manoeuvre</para>
            /// <para>(i.e.regional passing arrangement on Inland Waterway)</para>
            /// </summary>
            EngagedInSpecialManoeuvre = 2,
        }

        public enum SyncStateEnum
        {
            /// <summary>
            /// 0 = UTC direct 
            /// </summary>
            UTCDirect = 0,
            /// <summary>
            /// 1 = UTC indirect 
            /// </summary>
            UTCIndirect = 1,
            /// <summary>
            /// 2 = Station is synchronized to a base station
            /// </summary>
            SyncToBaseStation = 2,
            /// <summary>
            /// 3 = Station is synchronized to another station based on the highest number of received stations
            /// </summary>
            SyncToAnotherStation = 3,
        }
    }
}
