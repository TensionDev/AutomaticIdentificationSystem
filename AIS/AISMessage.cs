using System;
using System.Collections.Generic;
using System.Text;

namespace TensionDev.Maritime.AIS
{
    public abstract class AISMessage
    {
        private protected static UInt16 s_groupId = 0;

        protected UInt16 messageId6;
        protected UInt16 repeatIndicator2;

        /// <summary>
        /// Identifier for this Message
        /// </summary>
        public UInt16 MessageId { get => messageId6; set => messageId6 = value; }

        /// <summary>
        /// Used by the repeater to indicate how many times a message has been
        /// repeated.See § 4.6.1, Annex 2; 0-3; 0 = default; 3 = do not repeat any more
        /// </summary>
        public UInt16 RepeatIndicator { get => repeatIndicator2; set => repeatIndicator2 = value; }

        protected AISMessage()
        {
        }

        /// <summary>
        /// Decodes the AIS Messages and returns the appropriate AIS object.
        /// </summary>
        /// <param name="sentences">The AIS messages</param>
        /// <returns>The AIS object</returns>
        public static AISMessage DecodeSentences(IList<String> sentences)
        {
            if (sentences == null || sentences.Count == 0)
                throw new ArgumentNullException(nameof(sentences));

            IList<String> payloads = new List<String>();
            String messageId = "@";
            String sequenceId = String.Empty;

            foreach (String sentence in sentences)
            {
                String sentenceIdentifier = sentence.Substring(3, 3);
                if (sentenceIdentifier != "VDM" && sentenceIdentifier != "VDO")
                {
                    throw new NotImplementedException("Sentence Identifier not recognised.");
                }

                String[] vs = sentence.Split(new char[] { ',', '*' });

                // Ensure sentences count is equal to sentence fragment count.
                if (vs[1] != sentences.Count.ToString())
                {
                    throw new InvalidOperationException("Fragment Count does not correspond to number of sentences given.");
                }

                if (String.IsNullOrEmpty(sequenceId))
                {
                    sequenceId = vs[3];
                }
                else
                {
                    if (sequenceId != vs[3])
                        throw new InvalidOperationException("Sentences do not belong to the same sequence.");
                }

                // Taking first message for Message ID.
                if (vs[2] == "1")
                {
                    messageId = vs[5][0].ToString();
                }

                payloads.Add(vs[5]);
            }

            AISMessage aisMessage;

            switch (messageId)
            {
                case "1":
                    aisMessage = new AISMessage01();
                    break;

                default:
                    throw new NotImplementedException("Message Identifier not recognised.");
            }

            aisMessage.DecodePayloads(payloads);

            return aisMessage;
        }

        /// <summary>
        /// Gets the bitvector of a value based on number of bits.
        /// </summary>
        /// <param name="value">The Value to get the bitvector from</param>
        /// <param name="bitcount">The end index of the bits required</param>
        /// <returns>The bitvector containing the required number of bits</returns>
        public UInt64 GetBitVector(Int64 value, Int32 bitcount)
        {
            UInt64 bv = 0;
            Int64 mask;

            for (Int32 i = 0; i < bitcount; i++)
            {
                mask = (Int64)Math.Pow(2, i);
                bv = (UInt64)(mask & value) | bv;
            }

            return bv;
        }

        /// <summary>
        /// Gets the bitvector of a value based on number of bits with the 
        /// LSB having the bit value of the start index.
        /// </summary>
        /// <param name="value">The Value to get the bitvector from</param>
        /// <param name="bitcount">The end index of the bits required</param>
        /// <param name="startindex">The start index of the bits required</param>
        /// <returns>The bitvector containing the required number of bits</returns>
        public UInt64 GetBitVector(Int64 value, Int32 bitcount, Int32 startindex)
        {
            UInt64 bv = 0;
            Int64 mask;

            for (Int32 i = startindex; i < bitcount; i++)
            {
                mask = (Int64)Math.Pow(2, i);
                bv = (UInt64)(mask & value) | bv;
            }
            bv >>= startindex;
            return bv;
        }

        /// <summary>
        /// Gets the bitvector of a value based on number of bits.
        /// </summary>
        /// <param name="value">The Value to get the bitvector from</param>
        /// <param name="bitcount">The end index of the bits required</param>
        /// <returns>The bitvector containing the required number of bits</returns>
        public UInt64 GetBitVector(UInt64 value, Int32 bitcount)
        {
            UInt64 bv = 0;
            UInt64 mask;

            for (Int32 i = 0; i < bitcount; i++)
            {
                mask = (UInt64)Math.Pow(2, i);
                bv = (UInt64)(mask & value) | bv;
            }

            return bv;
        }

        /// <summary>
        /// Gets the bitvector of a value based on number of bits with the 
        /// LSB having the bit value of the start index.
        /// </summary>
        /// <param name="value">The Value to get the bitvector from</param>
        /// <param name="bitcount">The end index of the bits required</param>
        /// <param name="startindex">The start index of the bits required</param>
        /// <returns>The bitvector containing the required number of bits</returns>
        public UInt64 GetBitVector(UInt64 value, Int32 bitcount, Int32 startindex)
        {
            UInt64 bv = 0;
            UInt64 mask;

            for (Int32 i = startindex; i < bitcount; i++)
            {
                mask = (UInt64)Math.Pow(2, i);
                bv = (UInt64)(mask & value) | bv;
            }

            bv >>= startindex;

            return bv;
        }

        /// <summary>
        /// Encoding the bitvector payload to its Message paylod values.
        /// </summary>
        /// <param name="bitvector">The bitvector payload</param>
        /// <param name="bitsleft">The number of bits to encode</param>
        /// <exception cref="ArgumentException">bitsleft value is not a multiple of 6.</exception>
        /// <returns>The Message payload</returns>
        public String EncodePayload(UInt64 bitvector, Int32 bitsleft)
        {
            if ((bitsleft % 6) != 0)
            {
                throw new ArgumentException("bitsleft is not a multiple of 6.", nameof(bitsleft));
            }
            String symbol;
            if (bitsleft <= 0)
            {
                return String.Empty;
            }

            UInt64 encod = bitvector % 64L;

            if (encod >= 40)
                encod += 8L;

            encod += 48L;

            symbol = Convert.ToChar(encod).ToString();

            return EncodePayload(bitvector / 64, bitsleft - 6) + symbol;
        }

        public UInt64 DecodePayload(String payload, Int32 startIndex, Int32 length)
        {
            if (length > 10)
            {
                throw new ArgumentException("length is longer than 10, which is 60 bits.", nameof(length));
            }

            String segment = payload.Substring(startIndex, length);

            UInt64 decod = 0;

            for (Int32 i = 0; i < segment.Length; ++i)
            {
                UInt64 vs = Convert.ToUInt64(segment[i]);
                vs -= 48L;

                if (vs >= 48L)
                    vs -= 8L;

                decod *= 64L;
                decod += vs;
            }

            return decod;
        }

        /// <summary>
        /// Calculate the checksum value for the NMEA 0183 sentence
        /// </summary>
        /// <param name="sentence">The NMEA 0183 sentence to be computed, inclusive of the start delimiter "!" and just before the checksum delimiter "*"</param>
        /// <returns>The 8-bit XOR value.</returns>
        protected Byte CalculateChecksum(String sentence)
        {
            Byte checksum = 0b0;
            Byte[] data = Encoding.ASCII.GetBytes(sentence.Substring(1));

            checksum = CalculateChecksum(checksum, data);

            return checksum;
        }

        /// <summary>
        /// Calculate NMEA 0183 checksum given a series of bytes. Consist of one round of XOR operation for each byte.
        /// </summary>
        /// <param name="initial">Initial byte value used.</param>
        /// <param name="data">Series of bytes to calculate the checksum for.</param>
        /// <returns>NMEA 0183 checksum</returns>
        protected static Byte CalculateChecksum(Byte initial, Byte[] data)
        {
            Byte checksum = initial;

            for (int i = 0; i < data.Length; ++i)
            {
                checksum = CalculateChecksum(checksum, data[i]);
            }

            return checksum;
        }

        /// <summary>
        /// Calculate NMEA 0183 checksum given a series of bytes. Consist of one round of XOR operation.
        /// </summary>
        /// <param name="initial">Initial byte value used.</param>
        /// <param name="data">Byte to calculate checksum for.</param>
        /// <returns>NMEA 0183 checksum</returns>
        protected static Byte CalculateChecksum(Byte initial, Byte data)
        {
            Byte checksum = initial;

            checksum = (Byte)(checksum ^ data);

            return checksum;
        }

        /// <summary>
        /// Encodes the AIS object and returns the appropriate AIS sentence.
        /// </summary>
        /// <returns>The AIS sentence</returns>
        public abstract IList<String> EncodeSentences();

        /// <summary>
        /// Returns the AIS Payload.
        /// </summary>
        /// <returns>AIS Payloads</returns>
        protected abstract IList<String> EncodePayloads();

        /// <summary>
        /// Decodes given AIS Payload.
        /// </summary>
        /// <param name="payloads">AIS Payloads</param>
        protected abstract void DecodePayloads(IList<String> payloads);
    }
}
