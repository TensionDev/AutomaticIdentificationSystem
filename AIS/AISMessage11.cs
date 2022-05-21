using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.AIS
{
    /// <summary>
    /// Message 11: Coordinated universal time/date response
    /// </summary>
    public class AISMessage11 : AISMessage
    {
        private UInt64 _bitVector0_59;
        private UInt64 _bitVector60_119;
        private UInt64 _bitVector120_167;

        protected UInt32 userId30;
        protected UInt16 utcYear14;
        protected UInt16 utcMonth4;
        protected UInt16 utcDay5;
        protected UInt16 utcHour5;
        protected UInt16 utcMinute6;
        protected UInt16 utcSecond6;
        protected Boolean positionAccuracy1;
        protected Int32 longitude28;
        protected Int32 latitude27;
        protected UInt16 electronicPositionFixingDevice4;
        protected Boolean transmissionControlLongRangeBroadcast1;
        protected UInt16 spare9;
        protected Boolean raim1;

        /// <summary>
        /// Unique identifier such as MMSI number
        /// </summary>
        public String UserId { get => userId30.ToString("D9"); set => userId30 = UInt32.Parse(value); }

        /// <summary>
        /// UTC Year, 1-9999; 0 = UTC year not available = default
        /// </summary>
        public UInt16 UTCYear { get => utcYear14; set => utcYear14 = Math.Min((UInt16)9999, value); }

        /// <summary>
        /// UTC Month, 1-12; 0 = UTC month not available = default; 13-15 not used
        /// </summary>
        public UInt16 UTCMonth { get => utcMonth4; set => utcMonth4 = Math.Min((UInt16)12, value); }

        /// <summary>
        /// UTC Day, 1-31; 0 = UTC day not available = default
        /// </summary>
        public UInt16 UTCDay { get => utcDay5; set => utcDay5 = Math.Min((UInt16)31, value); }

        /// <summary>
        /// UTC Hour, 0-23; 24 = UTC hour not available = default; 25-31 not used
        /// </summary>
        public UInt16 UTCHour { get => utcHour5; set => utcHour5 = Math.Min((UInt16)24, value); }

        /// <summary>
        /// UTC Minute, 0-59; 60 = UTC minute not available = default; 61-63 not used
        /// </summary>
        public UInt16 UTCMinute { get => utcMinute6; set => utcMinute6 = Math.Min((UInt16)60, value); }

        /// <summary>
        /// UTC Second, 0-59; 60 = UTC second not available = default; 61-63 not used
        /// </summary>
        public UInt16 UTCSecond { get => utcSecond6; set => utcSecond6 = Math.Min((UInt16)60, value); }

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
        /// <para>False = default – Class-A AIS station stops transmission of Message 27 within an AIS base station coverage area.</para>
        /// <para>True = Request Class-A station to transmit Message 27 within an AIS base station coverage area.</para>
        /// <para></para>
        /// </summary>
        public Boolean TransmissionControlForLongRangeBroadcastMessage { get => transmissionControlLongRangeBroadcast1; set => transmissionControlLongRangeBroadcast1 = value; }

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

        public AISMessage11()
        {
            MessageId = 11;
            RepeatIndicator = 0;
            utcYear14 = 0;
            utcMonth4 = 0;
            utcDay5 = 0;
            utcHour5 = 24;
            utcMinute6 = 60;
            utcSecond6 = 60;
            positionAccuracy1 = false;
            longitude28 = 0x6791AC0;
            latitude27 = 0x3412140;
            electronicPositionFixingDevice4 = 0;
            transmissionControlLongRangeBroadcast1 = false;
            spare9 = 0;
            raim1 = false;
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

            _bitVector0_59 <<= 14;
            _bitVector0_59 |= utcYear14;

            _bitVector0_59 <<= 4;
            _bitVector0_59 |= utcMonth4;

            _bitVector0_59 <<= 4;
            _bitVector0_59 |= GetBitVector((UInt64)utcDay5, 5, 1);
        }

        private void GetBitVector60_119()
        {
            _bitVector60_119 = 0;

            _bitVector60_119 = GetBitVector((UInt64)utcDay5, 1);

            _bitVector60_119 <<= 5;
            _bitVector60_119 |= utcHour5;

            _bitVector60_119 <<= 6;
            _bitVector60_119 |= utcMinute6;

            _bitVector60_119 <<= 6;
            _bitVector60_119 |= utcSecond6;

            _bitVector60_119 <<= 1;
            if (positionAccuracy1)
            {
                _bitVector60_119 |= 1;
            }

            if (longitude28 < 0)
            {
                UInt64 tempLongitude = (UInt64)(longitude28 + (Int32)0xFFFFFFF);

                _bitVector60_119 <<= 28;
                _bitVector60_119 |= tempLongitude;
            }
            else
            {
                _bitVector60_119 <<= 28;
                _bitVector60_119 |= (UInt64)((UInt32)longitude28);
            }

            if (latitude27 < 0)
            {
                UInt64 tempLatitude = (UInt64)(latitude27 + (Int32)0x7FFFFFF);

                _bitVector60_119 <<= 13;
                _bitVector60_119 |= GetBitVector((UInt64)tempLatitude, 27, 14);
            }
            else
            {
                _bitVector60_119 <<= 13;
                _bitVector60_119 |= GetBitVector((UInt64)latitude27, 27, 14);
            }
        }

        private void GetBitVector120_167()
        {
            _bitVector120_167 = 0;

            if (latitude27 < 0)
            {
                UInt64 tempLatitude = (UInt64)(latitude27 + (Int32)0x7FFFFFF);

                _bitVector120_167 <<= 14;
                _bitVector120_167 |= GetBitVector((UInt64)tempLatitude, 14);
            }
            else
            {
                _bitVector120_167 <<= 14;
                _bitVector120_167 |= GetBitVector((UInt64)latitude27, 14);
            }

            _bitVector120_167 <<= 4;
            _bitVector120_167 |= electronicPositionFixingDevice4;

            _bitVector120_167 <<= 1;
            if (transmissionControlLongRangeBroadcast1)
            {
                _bitVector120_167 |= 1;
            }

            _bitVector120_167 <<= 9;
            _bitVector120_167 |= spare9;

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
            utcDay5 = (UInt16)(_bitVector0_59 & 0xF);
            utcDay5 <<= 1;
            _bitVector0_59 >>= 4;

            utcMonth4 = (UInt16)(_bitVector0_59 & 0xF);
            _bitVector0_59 >>= 4;

            utcYear14 = (UInt16)(_bitVector0_59 & 0x3FFF);
            _bitVector0_59 >>= 14;

            userId30 = (UInt32)(_bitVector0_59 & 0x3FFFFFFF);
            _bitVector0_59 >>= 30;

            repeatIndicator2 = (UInt16)(_bitVector0_59 & 0x3);
            _bitVector0_59 >>= 2;

            messageId6 = (UInt16)(_bitVector0_59 & 0x3F);
            _bitVector0_59 >>= 6;
        }

        private void SetBitVector60_119()
        {
            latitude27 = (UInt16)(_bitVector60_119 & 0x1FFF);
            latitude27 <<= 14;
            _bitVector60_119 >>= 13;

            longitude28 = (Int32)(_bitVector60_119 & 0xFFFFFFF);
            if (longitude28 > 0x7FFFFFF)
            {
                longitude28 -= 0xFFFFFFF;
            }
            _bitVector60_119 >>= 28;

            positionAccuracy1 = ((_bitVector60_119 & 0x1) != 0);
            _bitVector60_119 >>= 1;

            utcSecond6 = (UInt16)(_bitVector60_119 & 0x3F);
            _bitVector60_119 >>= 6;

            utcMinute6 = (UInt16)(_bitVector60_119 & 0x3F);
            _bitVector60_119 >>= 6;

            utcHour5 = (UInt16)(_bitVector60_119 & 0x1F);
            _bitVector60_119 >>= 5;

            utcDay5 |= (UInt16)(_bitVector60_119 & 0x1);
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

            spare9 = (UInt16)(_bitVector120_167 & 0x1FF);
            _bitVector120_167 >>= 9;

            transmissionControlLongRangeBroadcast1 = ((_bitVector120_167 & 0x1) != 0);
            _bitVector120_167 >>= 1;

            electronicPositionFixingDevice4 = (UInt16)(_bitVector120_167 & 0xF);
            _bitVector120_167 >>= 4;

            latitude27 |= (UInt16)(_bitVector120_167 & 0x3FFF);
            if (latitude27 > 0x3FFFFFF)
            {
                latitude27 -= 0x7FFFFFF;
            }
            _bitVector120_167 >>= 14;
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
