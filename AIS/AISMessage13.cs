using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.AIS
{
    /// <summary>
    /// Message 13: Safety related acknowledge
    /// </summary>
    public class AISMessage13 : AISMessage
    {
        private UInt64 _bitVector0_59;
        private UInt64 _bitVector60_119;
        private UInt64 _bitVector120_167;

        protected UInt32 sourceId30;
        protected UInt16 spare2;
        protected UInt32 destinationId1_30;
        protected UInt16 sequenceNumber1_2;
        protected Nullable<UInt32> destinationId2_30;
        protected Nullable<UInt16> sequenceNumber2_2;
        protected Nullable<UInt32> destinationId3_30;
        protected Nullable<UInt16> sequenceNumber3_2;
        protected Nullable<UInt32> destinationId4_30;
        protected Nullable<UInt16> sequenceNumber4_2;

        /// <summary>
        /// MMSI number of source of this acknowledge (ACK)
        /// </summary>
        public String SourceId { get => sourceId30.ToString("D9"); set => sourceId30 = UInt32.Parse(value); }

        /// <summary>
        /// MMSI number of first destination of this ACK
        /// </summary>
        public String DestinationId1 { get => destinationId1_30.ToString("D9"); set => destinationId1_30 = UInt32.Parse(value); }

        /// <summary>
        /// MMSI number of first destination of this ACK
        /// </summary>
        public UInt16 SequenceNumber1 { get => sequenceNumber1_2; set => sequenceNumber1_2 = Math.Min((UInt16)3, value); }

        /// <summary>
        /// MMSI number of second destination of this ACK; should be omitted if no destination ID2
        /// </summary>
        public String DestinationId2 { get => destinationId2_30.HasValue ? destinationId2_30.Value.ToString("D9") : String.Empty; }

        /// <summary>
        /// Sequence number of message to be acknowledged; 0-3; should be omitted if no destination ID2
        /// </summary>
        public UInt16 SequenceNumber2 { get => sequenceNumber2_2.HasValue ? sequenceNumber2_2.Value : UInt16.MinValue; }

        /// <summary>
        /// MMSI number of third destination of this ACK; should be omitted if no destination ID3
        /// </summary>
        public String DestinationId3 { get => destinationId3_30.HasValue ? destinationId3_30.Value.ToString("D9") : String.Empty; }

        /// <summary>
        /// Sequence number of message to be acknowledged; 0-3; should be omitted if no destination ID3
        /// </summary>
        public UInt16 SequenceNumber3 { get => sequenceNumber3_2.HasValue ? sequenceNumber3_2.Value : UInt16.MinValue; }

        /// <summary>
        /// MMSI number of fourth destination of this ACK; should be omitted if no destination ID4
        /// </summary>
        public String DestinationId4 { get => destinationId4_30.HasValue ? destinationId4_30.Value.ToString("D9") : String.Empty; }

        /// <summary>
        /// Sequence number of message to be acknowledged; 0-3; should be omitted if no destination ID4
        /// </summary>
        public UInt16 SequenceNumber4 { get => sequenceNumber4_2.HasValue ? sequenceNumber4_2.Value : UInt16.MinValue; }

        public AISMessage13()
        {
            MessageId = 13;
            RepeatIndicator = 0;
            destinationId2_30 = null;
            sequenceNumber2_2 = null;
            destinationId3_30 = null;
            sequenceNumber3_2 = null;
            destinationId4_30 = null;
            sequenceNumber4_2 = null;
        }

        /// <summary>
        /// Sets the Destination ID 2 with the Sequence Number for ID 2
        /// </summary>
        /// <param name="destinationId">Destination ID 2</param>
        /// <param name="sequenceNumber">Sequence number of message to be acknowledged; 0-3</param>
        /// <exception cref="ArgumentNullException">destinationId is Null.</exception>
        /// <exception cref="FormatException">destinationId is not in the correct format.</exception>
        /// <exception cref="OverflowException">destinationId is not in the correct format.</exception>
        public void SetDestination2(String destinationId, UInt16 sequenceNumber)
        {
            destinationId2_30 = UInt32.Parse(destinationId);
            sequenceNumber2_2 = Math.Min((UInt16)3, sequenceNumber);
        }

        /// <summary>
        /// Clears the Destination ID 2 and the Sequence Number for ID 2
        /// </summary>
        public void ClearDestination2()
        {
            destinationId2_30 = null;
            sequenceNumber2_2 = null;
        }

        /// <summary>
        /// Gets the Destination ID 2 with the Sequence Number for ID 2
        /// </summary>
        /// <param name="destinationId">Destination ID 2</param>
        /// <param name="sequenceNumber">Sequence number of message to be acknowledged; 0-3</param>
        /// <returns>Returns true if both are valid. Else, false.</returns>
        public Boolean GetDestination2(out String destinationId, out UInt16 sequenceNumber)
        {
            if (destinationId2_30.HasValue && 
                sequenceNumber2_2.HasValue)
            {
                destinationId = destinationId2_30.Value.ToString("D9");
                sequenceNumber = sequenceNumber2_2.Value;

                return true;
            }
            else
            {
                destinationId = UInt32.MinValue.ToString("D9");
                sequenceNumber = UInt16.MinValue;

                return false;
            }
        }

        /// <summary>
        /// Sets the Destination ID 3 with the Sequence Number for ID 3
        /// </summary>
        /// <param name="destinationId">Destination ID 3</param>
        /// <param name="sequenceNumber">Sequence number of message to be acknowledged; 0-3</param>
        /// <exception cref="ArgumentNullException">destinationId is Null.</exception>
        /// <exception cref="FormatException">destinationId is not in the correct format.</exception>
        /// <exception cref="OverflowException">destinationId is not in the correct format.</exception>
        public void SetDestination3(String destinationId, UInt16 sequenceNumber)
        {
            destinationId3_30 = UInt32.Parse(destinationId);
            sequenceNumber3_2 = Math.Min((UInt16)3, sequenceNumber);
        }

        /// <summary>
        /// Clears the Destination ID 3 and the Sequence Number for ID 3
        /// </summary>
        public void ClearDestination3()
        {
            destinationId3_30 = null;
            sequenceNumber3_2 = null;
        }

        /// <summary>
        /// Gets the Destination ID 3 with the Sequence Number for ID 3
        /// </summary>
        /// <param name="destinationId">Destination ID 3</param>
        /// <param name="sequenceNumber">Sequence number of message to be acknowledged; 0-3</param>
        /// <returns>Returns true if both are valid. Else, false.</returns>
        public Boolean GetDestination3(out String destinationId, out UInt16 sequenceNumber)
        {
            if (destinationId3_30.HasValue &&
                sequenceNumber3_2.HasValue)
            {
                destinationId = destinationId3_30.Value.ToString("D9");
                sequenceNumber = sequenceNumber3_2.Value;

                return true;
            }
            else
            {
                destinationId = UInt32.MinValue.ToString("D9");
                sequenceNumber = UInt16.MinValue;

                return false;
            }
        }

        /// <summary>
        /// Sets the Destination ID 4 with the Sequence Number for ID 4
        /// </summary>
        /// <param name="destinationId">Destination ID 4</param>
        /// <param name="sequenceNumber">Sequence number of message to be acknowledged; 0-3</param>
        /// <exception cref="ArgumentNullException">destinationId is Null.</exception>
        /// <exception cref="FormatException">destinationId is not in the correct format.</exception>
        /// <exception cref="OverflowException">destinationId is not in the correct format.</exception>
        public void SetDestination4(String destinationId, UInt16 sequenceNumber)
        {
            destinationId4_30 = UInt32.Parse(destinationId);
            sequenceNumber4_2 = Math.Min((UInt16)3, sequenceNumber);
        }

        /// <summary>
        /// Clears the Destination ID 4 and the Sequence Number for ID 4
        /// </summary>
        public void ClearDestination4()
        {
            destinationId4_30 = null;
            sequenceNumber4_2 = null;
        }

        /// <summary>
        /// Gets the Destination ID 4 with the Sequence Number for ID 4
        /// </summary>
        /// <param name="destinationId">Destination ID 4</param>
        /// <param name="sequenceNumber">Sequence number of message to be acknowledged; 0-3</param>
        /// <returns>Returns true if both are valid. Else, false.</returns>
        public Boolean GetDestination4(out String destinationId, out UInt16 sequenceNumber)
        {
            if (destinationId4_30.HasValue &&
                sequenceNumber4_2.HasValue)
            {
                destinationId = destinationId4_30.Value.ToString("D9");
                sequenceNumber = sequenceNumber4_2.Value;

                return true;
            }
            else
            {
                destinationId = UInt32.MinValue.ToString("D9");
                sequenceNumber = UInt16.MinValue;

                return false;
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

            SetBitVector0_59();

            if (payload.Length > 23)
            {
                _bitVector60_119 = DecodePayload(payload, 10, 10);
                _bitVector120_167 = DecodePayload(payload, 20, 8);

                SetBitVector60_119();
                SetBitVector120_167();
            }
            else if (payload.Length > 18)
            {
                _bitVector60_119 = DecodePayload(payload, 10, 10);
                _bitVector120_167 = DecodePayload(payload, 20, 3);

                SetBitVector60_119();
                SetBitVector120_137();
            }
            else if (payload.Length > 12)
            {
                _bitVector60_119 = DecodePayload(payload, 10, 8);

                SetBitVector60_107();
            }
            else
            {
                _bitVector60_119 = DecodePayload(payload, 10, 2);

                SetBitVector60_71();
            }
        }

        protected override IList<String> EncodePayloads()
        {
            IList<String> payloads = new List<String>();

            StringBuilder payload = new StringBuilder();

            GetBitVector0_59();

            payload.Append(EncodePayload(_bitVector0_59, 60));

            if (destinationId4_30.HasValue)
            {
                GetBitVector60_119();
                GetBitVector120_167();

                payload.Append(EncodePayload(_bitVector60_119, 60));
                payload.Append(EncodePayload(_bitVector120_167, 48));
            }
            else if(destinationId3_30.HasValue)
            {
                GetBitVector60_119();
                GetBitVector120_137();

                payload.Append(EncodePayload(_bitVector60_119, 60));
                payload.Append(EncodePayload(_bitVector120_167, 18));
            }
            else if (destinationId2_30.HasValue)
            {
                GetBitVector60_107();

                payload.Append(EncodePayload(_bitVector60_119, 48));
            }
            else 
            {
                GetBitVector60_71();

                payload.Append(EncodePayload(_bitVector60_119, 12));
            }

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
            _bitVector0_59 |= sourceId30;

            _bitVector0_59 <<= 2;
            _bitVector0_59 |= spare2;

            _bitVector0_59 <<= 20;
            _bitVector0_59 |= GetBitVector((UInt64)destinationId1_30, 30, 10);
        }

        private void GetBitVector60_71()
        {
            _bitVector60_119 = 0;

            _bitVector60_119 = GetBitVector((UInt64)destinationId1_30, 10);

            _bitVector60_119 <<= 2;
            _bitVector60_119 |= sequenceNumber1_2;
        }

        private void GetBitVector60_107()
        {
            _bitVector60_119 = 0;

            _bitVector60_119 = GetBitVector((UInt64)destinationId1_30, 10);

            _bitVector60_119 <<= 2;
            _bitVector60_119 |= sequenceNumber1_2;

            _bitVector60_119 <<= 30;
            _bitVector60_119 |= destinationId2_30.Value;

            _bitVector60_119 <<= 2;
            _bitVector60_119 |= sequenceNumber2_2.Value;

            _bitVector60_119 <<= 4;
        }

        private void GetBitVector60_119()
        {
            _bitVector60_119 = 0;

            _bitVector60_119 = GetBitVector((UInt64)destinationId1_30, 10);

            _bitVector60_119 <<= 2;
            _bitVector60_119 |= sequenceNumber1_2;

            _bitVector60_119 <<= 30;
            _bitVector60_119 |= destinationId2_30.Value;

            _bitVector60_119 <<= 2;
            _bitVector60_119 |= sequenceNumber2_2.Value;

            _bitVector60_119 <<= 16;
            _bitVector60_119 |= GetBitVector((UInt64)destinationId3_30.Value, 30, 14);
        }

        private void GetBitVector120_137()
        {
            _bitVector120_167 = 0;

            _bitVector120_167 = GetBitVector((UInt64)destinationId3_30.Value, 14);

            _bitVector120_167 <<= 2;
            _bitVector120_167 |= sequenceNumber3_2.Value;
            
            _bitVector120_167 <<= 2;
        }

        private void GetBitVector120_167()
        {
            _bitVector120_167 = 0;

            _bitVector120_167 = GetBitVector((UInt64)destinationId3_30.Value, 14);

            _bitVector120_167 <<= 2;
            _bitVector120_167 |= sequenceNumber3_2.Value;

            _bitVector120_167 <<= 30;
            _bitVector120_167 |= destinationId4_30.Value;

            _bitVector120_167 <<= 2;
            _bitVector120_167 |= sequenceNumber4_2.Value;
        }

        private void SetBitVector0_59()
        {
            destinationId1_30 = (UInt32)(_bitVector0_59 & 0xFFFFF);
            destinationId1_30 <<= 10;
            _bitVector0_59 >>= 20;

            spare2 = (UInt16)(_bitVector0_59 & 0x3);
            _bitVector0_59 >>= 2;

            sourceId30 = (UInt32)(_bitVector0_59 & 0x3FFFFFFF);
            _bitVector0_59 >>= 30;

            repeatIndicator2 = (UInt16)(_bitVector0_59 & 0x3);
            _bitVector0_59 >>= 2;

            messageId6 = (UInt16)(_bitVector0_59 & 0x3F);
            _bitVector0_59 >>= 6;
        }

        private void SetBitVector60_71()
        {
            sequenceNumber1_2 = (UInt16)(_bitVector60_119 & 0x3);
            _bitVector60_119 >>= 2;

            destinationId1_30 |= (UInt32)(_bitVector60_119 & 0x3FF);
            _bitVector60_119 >>= 10;
        }

        private void SetBitVector60_107()
        {
            _bitVector60_119 >>= 4;

            sequenceNumber2_2 = (UInt16)(_bitVector60_119 & 0x3);
            _bitVector60_119 >>= 2;

            destinationId2_30 = (UInt32)(_bitVector60_119 & 0x3FFFFFFF);
            _bitVector60_119 >>= 30;

            sequenceNumber1_2 = (UInt16)(_bitVector60_119 & 0x3);
            _bitVector60_119 >>= 2;

            destinationId1_30 |= (UInt32)(_bitVector60_119 & 0x3FF);
            _bitVector60_119 >>= 10;
        }

        private void SetBitVector60_119()
        {
            destinationId3_30 = (UInt32)(_bitVector60_119 & 0xFFFF);
            destinationId3_30 <<= 14;
            _bitVector60_119 >>= 16;

            sequenceNumber2_2 = (UInt16)(_bitVector60_119 & 0x3);
            _bitVector60_119 >>= 2;

            destinationId2_30 = (UInt32)(_bitVector60_119 & 0x3FFFFFFF);
            _bitVector60_119 >>= 30;

            sequenceNumber1_2 = (UInt16)(_bitVector60_119 & 0x3);
            _bitVector60_119 >>= 2;

            destinationId1_30 |= (UInt32)(_bitVector60_119 & 0x3FF);
            _bitVector60_119 >>= 10;
        }

        private void SetBitVector120_137()
        {
            _bitVector120_167 >>= 2;

            sequenceNumber3_2 = (UInt16)(_bitVector120_167 & 0x3);
            _bitVector120_167 >>= 2;

            destinationId3_30 |= (UInt32)(_bitVector120_167 & 0x3FFF);
            _bitVector120_167 >>= 14;
        }

        private void SetBitVector120_167()
        {
            sequenceNumber4_2 = (UInt16)(_bitVector120_167 & 0x3);
            _bitVector120_167 >>= 2;

            destinationId4_30 = (UInt32)(_bitVector120_167 & 0x3FFFFFFF);
            _bitVector120_167 >>= 14;

            sequenceNumber3_2 = (UInt16)(_bitVector120_167 & 0x3);
            _bitVector120_167 >>= 2;

            destinationId3_30 |= (UInt32)(_bitVector120_167 & 0x3FFF);
            _bitVector120_167 >>= 14;
        }
    }
}
