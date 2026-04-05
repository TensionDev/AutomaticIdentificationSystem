using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.AIS
{
    /// <summary>
    /// Message 10: Coordinated universal time and date inquiry
    /// </summary>
    public class AISMessage10 : AISMessage
    {
        private UInt64 _bitVector0_59;
        private UInt64 _bitVector60_71;

        protected UInt32 sourceId30;
        protected UInt16 spare2;
        protected UInt32 destinationId30;
        protected UInt16 spare2_2;

        /// <summary>
        /// MMSI number of station which inquires UTC
        /// </summary>
        public String SourceId { get => sourceId30.ToString("D9"); set => sourceId30 = UInt32.Parse(value); }

        /// <summary>
        /// MMSI number of station which is inquired
        /// </summary>
        public String DestinationId { get => destinationId30.ToString("D9"); set => destinationId30 = UInt32.Parse(value); }

        public AISMessage10()
        {
            MessageId = 10;
            RepeatIndicator = 0;
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
            _bitVector60_71 = DecodePayload(payload, 10, 2);

            SetBitVector0_59();
            SetBitVector60_71();
        }

        protected override IList<String> EncodePayloads()
        {
            IList<String> payloads = new List<String>();

            StringBuilder payload = new StringBuilder();

            GetBitVector0_59();
            GetBitVector60_71();

            payload.Append(EncodePayload(_bitVector0_59, 60));
            payload.Append(EncodePayload(_bitVector60_71, 12));

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
            _bitVector0_59 |= GetBitVector((UInt64)destinationId30, 30, 10);
        }

        private void GetBitVector60_71()
        {
            _bitVector60_71 = 0;

            _bitVector60_71 = GetBitVector((UInt64)destinationId30, 10);

            _bitVector60_71 <<= 2;
            _bitVector60_71 |= spare2_2;
        }

        private void SetBitVector0_59()
        {
            destinationId30 = (UInt32)(_bitVector0_59 & 0xFFFFF);
            destinationId30 <<= 10;
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
            spare2_2 = (UInt16)(_bitVector60_71 & 0x3);
            _bitVector60_71 >>= 2;

            destinationId30 |= (UInt32)(_bitVector60_71 & 0x3FF);
            _bitVector60_71 >>= 10;
        }
    }
}
