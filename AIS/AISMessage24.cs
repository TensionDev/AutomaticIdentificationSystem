using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.AIS
{
    /// <summary>
    /// Message 24: Static data report
    /// </summary>
    public class AISMessage24 : AISMessage
    {
        private UInt64 _bitVector0_59;
        private UInt64 _bitVector60_119;
        private UInt64 _bitVector120_167;

        protected UInt32 userId30;
        protected UInt16 partNumber2;
        protected UInt64 name0_59;
        protected UInt64 name60_119;
        protected UInt16 shipAndCargoType8;
        protected UInt64 vendorId42;
        protected UInt64 callSign42;
        protected UInt16 dimensionToBow9;
        protected UInt16 dimensionToStern9;
        protected UInt16 dimensionToPort6;
        protected UInt16 dimensionToStarboard6;
        protected UInt16 electronicPositionFixingDevice4;
        protected UInt16 spare2;

        /// <summary>
        /// Unique identifier such as MMSI number
        /// </summary>
        public String UserId { get => userId30.ToString("D9"); set => userId30 = UInt32.Parse(value); }

        /// <summary>
        /// <para>Identifier for the message part number;</para>
        /// <para>Always 0 for Part A</para>
        /// <para>Always 1 for Part B</para>
        /// </summary>
        public PartNumberEnum PartNumber { get => (PartNumberEnum)(partNumber2); set => partNumber2 = (UInt16)value; }

        /// <summary>
        /// <para>Message 24 part A</para>
        /// <para>Name of the MMSI-registered vessel. Maximum 20 characters 6-bit ASCII, @@@@@@@@@@@@@@@@@@@@ = not available = default. </para>
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
                    for (Int32 j = 10; j < 20; ++j)
                    {
                        name60_119 <<= 6;
                        if (j < value.Length)
                        {
                            if (Convert.ToUInt64(value[j]) >= 64L)
                            {
                                name60_119 += Convert.ToUInt64(value[j]) - 64L;
                            }
                            else
                            {
                                name60_119 += Convert.ToUInt64(value[j]);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// <para>Type of Ship and Cargo Type</para>
        /// <para>0 = not available or no ship = default</para>
        /// <para>1-99 = as defined in § 3.3.2</para>
        /// <para>100-199 = reserved, for regional use</para>
        /// <para>200-255 = reserved, for future use</para>
        /// <para>Not applicable to SAR aircraft</para>
        /// </summary>
        public UInt16 TypeOfShipAndCargoType { get => shipAndCargoType8; set => shipAndCargoType8 = Math.Min((UInt16)255, value); }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// <para>Unique identification of the Unit by a number as defined by the manufacturer</para>
        /// <para>(option; “@@@@@@@” = not available = default)</para>
        /// </summary>
        public String VendorId
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                UInt64 temp = vendorId42;

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
        }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// <para>The Manufacturer’s ID bits indicate the manufacture’s mnemonic code consisting of three 6 bit ASCII characters(1)</para>
        /// </summary>
        public String ManufacturerId
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                UInt64 temp = vendorId42 & 0x3FFFF000000;
                temp >>= 24;

                for (Int32 i = 0; i < 3; ++i)
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
                UInt64 temp = 0;
                for (Int32 i = 0; i < 3; ++i)
                {
                    temp <<= 6;
                    if (i < value.Length)
                    {
                        if (Convert.ToUInt64(value[i]) >= 64L)
                        {
                            temp += Convert.ToUInt64(value[i]) - 64L;
                        }
                        else
                        {
                            temp += Convert.ToUInt64(value[i]);
                        }
                    }
                }

                temp <<= 24;
                vendorId42 &= 0xFFFFFF;
                vendorId42 |= temp;
            }
        }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// <para>The Unit Model Code bits indicate the binary coded series number of the model.
        /// The first model of the manufacture uses “1” and the number is incremented at the release of a new model.
        /// The code reverts to “1” after reaching to “15”. The “0” is not used</para>
        /// </summary>
        public UInt16 UnitModelCode
        {
            get
            {
                UInt64 temp = vendorId42 & 0xF00000;
                temp >>= 20;

                return (UInt16)temp;
            }
            set
            {
                UInt64 temp = value;

                temp <<= 20;
                vendorId42 &= 0x3FFFF0FFFFF;
                vendorId42 |= temp;
            }
        }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// <para>The Unit Serial Number bits indicate the manufacture traceable serial number.
        /// When the serial number is composed of numeric only, the binary coding should be used.
        /// If it includes figure(s), the manufacture can define the coding method.
        /// The coding method should be mentioned in the manual</para>
        /// </summary>
        public UInt32 UnitSerialNumber
        {
            get
            {
                UInt64 temp = vendorId42 & 0xFFFFF;

                return (UInt32)temp;
            }
            set
            {
                UInt64 temp = value;

                vendorId42 &= 0x3FFFFF00000;
                vendorId42 |= temp;
            }
        }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// <para>Call sign of the MMSI-registered vessel. 7 x 6 bit ASCII characters, “@@@@@@@” = not available = default.</para>
        /// <para>Craft associated with a parent vessel should use “A” followed by the last 6 digits of the MMSI of the parent vessel.</para>
        /// <para>Examples of these craft include towed vessels, rescue boats, tenders, lifeboats and life rafts.</para>
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
        /// <para>Message 24 part B</para>
        /// 0-511; 511 = 511 m or greater
        /// </summary>
        public UInt16 DimensionToBow { get => dimensionToBow9; set => dimensionToBow9 = Math.Min((UInt16)511, value); }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// 0-511; 511 = 511 m or greater
        /// </summary>
        public UInt16 DimensionToStern { get => dimensionToStern9; set => dimensionToStern9 = Math.Min((UInt16)511, value); }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// 0-63; 63 = 63 m or greater
        /// </summary>
        public UInt16 DimensionToPort { get => dimensionToPort6; set => dimensionToPort6 = Math.Min((UInt16)63, value); }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// 0-63; 63 = 63 m or greater
        /// </summary>
        public UInt16 DimensionToStarboard { get => dimensionToStarboard6; set => dimensionToStarboard6 = Math.Min((UInt16)63, value); }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// <para>The maximum length of the ship between the ships extreme points important for berthing purposes.</para>
        /// <para>NOTE: Setting this will reset the <see cref="DimensionToBow"/> to 0 and <see cref="DimensionToStern"/> to the value, capped at 511.</para>
        /// <para>0-511; 511 = 511 m or greater</para>
        /// </summary>
        public UInt16 LengthOverall { get { return (UInt16)(DimensionToBow + DimensionToStern); } set { DimensionToBow = 0; DimensionToStern = Math.Min((UInt16)511, value); } }

        /// <summary>
        /// <para>Message 24 part B</para>
        /// The overall width of the ship measured at the widest point of the nominal waterline.
        /// <para>NOTE: Setting this will reset the <see cref="DimensionToPort"/> to 0 and <see cref="DimensionToStarboard"/> to the value, capped at 63.</para>
        /// <para>0-63; 63 = 63 m or greater</para>
        /// </summary>
        public UInt16 BeamOverall { get { return (UInt16)(DimensionToPort + DimensionToStarboard); } set { DimensionToPort = 0; DimensionToStarboard = Math.Min((UInt16)63, value); } }

        /// <summary>
        /// <para>Message 24 part B</para>
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

        public AISMessage24()
        {
            MessageId = 24;
            RepeatIndicator = 0;
            partNumber2 = 0;
            name0_59 = 0;
            name60_119 = 0;
            shipAndCargoType8 = 0;
            vendorId42 = 0;
            callSign42 = 0;
            dimensionToBow9 = 0;
            dimensionToStern9 = 0;
            dimensionToPort6 = 0;
            dimensionToStarboard6 = 0;
            electronicPositionFixingDevice4 = 0;
            spare2 = 0;
        }

        public override IList<string> EncodeSentences()
        {
            IList<String> sentences = new List<String>();

            StringBuilder stringBuilder = new StringBuilder();
            IList<String> payload = EncodePayloads();

            if (PartNumber == PartNumberEnum.PartA)
            {
                stringBuilder.AppendFormat("!AIVDM,1,1,,B,{0},2", payload[0]);
            }
            else
            {
                stringBuilder.AppendFormat("!AIVDM,1,1,,B,{0},0", payload[0]);
            }

            Byte checksum = CalculateChecksum(stringBuilder.ToString());

            stringBuilder.AppendFormat("*{0}\r\n", checksum.ToString("X2"));

            sentences.Add(stringBuilder.ToString());

            return sentences;
        }

        protected override void DecodePayloads(IList<string> payloads)
        {
            if (payloads.Count != 1)
                throw new ArgumentOutOfRangeException(nameof(payloads));

            String payload = payloads[0];

            _bitVector0_59 = DecodePayload(payload, 0, 10);
            _bitVector60_119 = DecodePayload(payload, 10, 10);

            SetBitVector0_59();
            SetBitVector60_119();

            if (PartNumber == PartNumberEnum.PartA)
            {
                _bitVector120_167 = DecodePayload(payload, 20, 7);
            }
            else
            {
                _bitVector120_167 = DecodePayload(payload, 20, 8);
            }

            SetBitVector120_167();
        }

        protected override IList<string> EncodePayloads()
        {
            IList<String> payloads = new List<String>();

            StringBuilder payload = new StringBuilder();

            GetBitVector0_59();
            GetBitVector60_119();
            GetBitVector120_167();

            payload.Append(EncodePayload(_bitVector0_59, 60));
            payload.Append(EncodePayload(_bitVector60_119, 60));

            if (PartNumber == PartNumberEnum.PartA)
            {
                payload.Append(EncodePayload(_bitVector120_167, 42));
            }
            else
            {
                payload.Append(EncodePayload(_bitVector120_167, 48));
            }

            payloads.Add(payload.ToString());

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
            _bitVector0_59 |= partNumber2;

            if (partNumber2 == 0)
            {
                _bitVector0_59 <<= 20;
                _bitVector0_59 |= GetBitVector((UInt64)name0_59, 60, 40);
            }
            else
            {
                _bitVector0_59 <<= 8;
                _bitVector0_59 |= shipAndCargoType8;

                _bitVector0_59 <<= 12;
                _bitVector0_59 |= GetBitVector((UInt64)vendorId42, 42, 30);
            }
        }

        private void GetBitVector60_119()
        {
            if (partNumber2 == 0)
            {
                _bitVector60_119 <<= 40;
                _bitVector60_119 |= GetBitVector((UInt64)name0_59, 40);

                _bitVector60_119 <<= 20;
                _bitVector60_119 |= GetBitVector((UInt64)name60_119, 60, 40);
            }
            else
            {
                _bitVector60_119 <<= 30;
                _bitVector60_119 |= GetBitVector((UInt64)vendorId42, 30);

                _bitVector60_119 <<= 30;
                _bitVector60_119 |= GetBitVector((UInt64)callSign42, 42, 12);
            }
        }

        private void GetBitVector120_167()
        {
            if (partNumber2 == 0)
            {
                _bitVector120_167 <<= 40;
                _bitVector120_167 |= GetBitVector((UInt64)name60_119, 40);

                _bitVector120_167 <<= 2;
            }
            else
            {
                _bitVector120_167 <<= 12;
                _bitVector120_167 |= GetBitVector((UInt64)callSign42, 12);

                _bitVector120_167 <<= 9;
                _bitVector120_167 |= dimensionToBow9;

                _bitVector120_167 <<= 9;
                _bitVector120_167 |= dimensionToStern9;

                _bitVector120_167 <<= 6;
                _bitVector120_167 |= dimensionToPort6;

                _bitVector120_167 <<= 6;
                _bitVector120_167 |= dimensionToStarboard6;

                _bitVector120_167 <<= 4;
                _bitVector120_167 |= electronicPositionFixingDevice4;

                _bitVector120_167 <<= 2;
                _bitVector120_167 |= spare2;
            }
        }

        private void SetBitVector0_59()
        {
            UInt64 temp = (UInt64)(_bitVector0_59 & 0xFFFFF);
            _bitVector0_59 >>= 20;

            partNumber2 = (UInt16)(_bitVector0_59 & 0x3);
            _bitVector0_59 >>= 2;

            userId30 = (UInt32)(_bitVector0_59 & 0x7FFFFFFF);
            _bitVector0_59 >>= 30;

            repeatIndicator2 = (UInt16)(_bitVector0_59 & 0x3);
            _bitVector0_59 >>= 2;

            messageId6 = (UInt16)(_bitVector0_59 & 0x3F);
            _bitVector0_59 >>= 6;

            if (partNumber2 == 0)
            {
                name0_59 = temp;
                name0_59 <<= 40;
            }
            else
            {
                vendorId42 = (UInt32)(temp & 0xFFF);
                vendorId42 <<= 30;
                temp >>= 12;

                shipAndCargoType8 = (UInt16)(temp & 0xFF);
            }
        }

        private void SetBitVector60_119()
        {
            if (partNumber2 == 0)
            {
                name60_119 = (UInt64)(_bitVector60_119 & 0xFFFFF);
                name60_119 <<= 40;
                _bitVector60_119 >>= 20;

                name0_59 |= (UInt64)(_bitVector60_119 & 0xFFFFFFFFFF);
                _bitVector60_119 >>= 20;
            }
            else
            {
                callSign42 = (UInt64)(_bitVector60_119 & 0x3FFFFFFF);
                callSign42 <<= 12;
                _bitVector60_119 >>= 30;

                vendorId42 |= (UInt64)(_bitVector60_119 & 0x3FFFFFFF);
                _bitVector60_119 >>= 30;
            }
        }

        private void SetBitVector120_167()
        {
            if (partNumber2 == 0)
            {
                _bitVector120_167 >>= 2;

                name60_119 |= (UInt64)(_bitVector120_167 & 0xFFFFFFFFFF);
                _bitVector120_167 >>= 40;
            }
            else
            {
                spare2 = (UInt16)(_bitVector120_167 & 0x3);
                _bitVector120_167 >>= 2;

                electronicPositionFixingDevice4 = (UInt16)(_bitVector120_167 & 0xF);
                _bitVector120_167 >>= 4;

                dimensionToStarboard6 = (UInt16)(_bitVector120_167 & 0x3F);
                _bitVector120_167 >>= 6;

                dimensionToPort6 = (UInt16)(_bitVector120_167 & 0x3F);
                _bitVector120_167 >>= 6;

                dimensionToStern9 = (UInt16)(_bitVector120_167 & 0x1FF);
                _bitVector120_167 >>= 9;

                dimensionToBow9 = (UInt16)(_bitVector120_167 & 0x1FF);
                _bitVector120_167 >>= 9;

                callSign42 |= (UInt64)(_bitVector120_167 & 0xFFF);
                _bitVector120_167 >>= 12;
            }
        }

        public enum PartNumberEnum
        {
            /// <summary>
            /// 0 = Message 24 part A
            /// </summary>
            PartA = 0,
            /// <summary>
            /// 1 = Message 24 part B
            /// </summary>
            PartB = 1,
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
