using System;
using System.Collections.Specialized;

namespace TensionDev.Maritime.AIS
{
    public class SOTDMACommunicationState : AISCommunicationState
    {
        private BitVector32.Section _slotTimeout3;
        private BitVector32.Section _subMessage14;

        /// <summary>
        /// <para>Specifies frames remaining until a new slot is selected</para>
        /// <para>0 means that this was the last transmission in this slot</para>
        /// <para>1-7 means that 1 to 7 frames respectively are left until slot change</para>
        /// </summary>
        public UInt16 SlotTimeout { get => (UInt16)communicationState19[_slotTimeout3]; set => communicationState19[_slotTimeout3] = Math.Min((UInt16)7, value); }

        public SOTDMACommunicationState() : base()
        {
            _subMessage14 = BitVector32.CreateSection(0x3FFF);
            _slotTimeout3 = BitVector32.CreateSection(0x7, _subMessage14);
        }

        /// <summary>
        /// For Slot time-out 3, 5, 7 only
        /// Number of other stations (not own station) which the station currently is receiving(between 0 and 16 383)
        /// </summary>
        /// <param name="slotTimeout">Slot time-out</param>
        /// <param name="receivedStations">Number of other stations (not own station) which the station currently is receiving</param>
        /// <exception cref="InvalidOperationException">Slot Timeout is not 3, 5 or 7</exception>
        public void SetReceivedStations(UInt16 slotTimeout, UInt16 receivedStations)
        {
            if (slotTimeout != 3 &&
                slotTimeout != 5 &&
                slotTimeout != 7)
            {
                throw new InvalidOperationException("Slot Timeout is not 3, 5 or 7");
            }

            communicationState19[_slotTimeout3] = slotTimeout;
            communicationState19[_subMessage14] = Math.Min((UInt16)16383, receivedStations);
        }

        /// <summary>
        /// For Slot time-out 3, 5, 7 only
        /// Number of other stations (not own station) which the station currently is receiving(between 0 and 16 383)
        /// </summary>
        /// <param name="slotTimeout">Slot time-out</param>
        /// <param name="receivedStations">Number of other stations (not own station) which the station currently is receiving</param>
        /// <exception cref="InvalidOperationException">Slot Timeout is not 3, 5 or 7</exception>
        public void GetReceivedStations(out UInt16 slotTimeout, out UInt16 receivedStations)
        {
            if (communicationState19[_slotTimeout3] != 3 &&
                communicationState19[_slotTimeout3] != 5 &&
                communicationState19[_slotTimeout3] != 7)
            {
                throw new InvalidOperationException("Slot Timeout is not 3, 5 or 7");
            }

            slotTimeout = (UInt16)communicationState19[_slotTimeout3];
            receivedStations = Math.Min((UInt16)16383, (UInt16)communicationState19[_subMessage14]);
        }

        /// <summary>
        /// For Slot time-out 2, 4, 6 only
        /// Slot number used for this transmission (between 0 and 2 249) 
        /// </summary>
        /// <param name="slotTimeout">Slot time-out</param>
        /// <param name="slotNumber">Slot number used for this transmission</param>
        /// <exception cref="InvalidOperationException">Slot Timeout is not 2, 4 or 6</exception>
        public void SetSlotNumber(UInt16 slotTimeout, UInt16 slotNumber)
        {
            if (slotTimeout != 2 &&
                slotTimeout != 4 &&
                slotTimeout != 6)
            {
                throw new InvalidOperationException("Slot Timeout is not 2, 4 or 6");
            }

            communicationState19[_slotTimeout3] = slotTimeout;
            communicationState19[_subMessage14] = Math.Min((UInt16)2249, slotNumber);
        }

        /// <summary>
        /// For Slot time-out 2, 4, 6 only
        /// Slot number used for this transmission (between 0 and 2 249) 
        /// </summary>
        /// <param name="slotTimeout">Slot time-out</param>
        /// <param name="slotNumber">Slot number used for this transmission</param>
        /// <exception cref="InvalidOperationException">Slot Timeout is not 2, 4 or 6</exception>
        public void GetSlotNumber(out UInt16 slotTimeout, out UInt16 slotNumber)
        {
            if (communicationState19[_slotTimeout3] != 2 &&
                communicationState19[_slotTimeout3] != 4 &&
                communicationState19[_slotTimeout3] != 6)
            {
                throw new InvalidOperationException("Slot Timeout is not 2, 4 or 6");
            }

            slotTimeout = (UInt16)communicationState19[_slotTimeout3];
            slotNumber = Math.Min((UInt16)2249, (UInt16)communicationState19[_subMessage14]);
        }

        /// <summary>
        /// For Slot time-out 1 only
        /// <para>If the station has access to UTC, the hour and minute should be indicated in this sub message.</para>
        /// Hour(0-23) should be coded in bits
        /// 13 to 9 of the sub message(bit 13 is MSB). Minute(0-59) should be
        /// coded in bit 8 to 2 (bit 8 is MSB)
        /// </summary>
        /// <param name="slotTimeout">Slot time-out</param>
        /// <param name="utcTime">UTC hour and minute</param>
        /// <exception cref="InvalidOperationException">Slot Timeout is not 1</exception>
        public void SetUTCHourAndMinute(UInt16 slotTimeout, TimeSpan utcTime)
        {
            if (slotTimeout != 1)
            {
                throw new InvalidOperationException("Slot Timeout is not 1");
            }

            communicationState19[_slotTimeout3] = slotTimeout;
            communicationState19[_subMessage14] = 0;

            communicationState19[_subMessage14] |= (UInt16)utcTime.Hours;

            communicationState19[_subMessage14] <<= 7;
            communicationState19[_subMessage14] |= (UInt16)utcTime.Minutes;

            communicationState19[_subMessage14] <<= 2;
        }

        /// <summary>
        /// For Slot time-out 1 only
        /// <para>If the station has access to UTC, the hour and minute should be indicated in this sub message.</para>
        /// Hour(0-23) should be coded in bits
        /// 13 to 9 of the sub message(bit 13 is MSB). Minute(0-59) should be
        /// coded in bit 8 to 2 (bit 8 is MSB)
        /// </summary>
        /// <param name="slotTimeout">Slot time-out</param>
        /// <param name="utcTime">UTC hour and minute</param>
        /// <exception cref="InvalidOperationException">Slot Timeout is not 1</exception>
        public void GetUTCHourAndMinute(out UInt16 slotTimeout, out TimeSpan utcTime)
        {
            if (communicationState19[_slotTimeout3] != 1)
            {
                throw new InvalidOperationException("Slot Timeout is not 1");
            }

            slotTimeout = (UInt16)communicationState19[_slotTimeout3];

            UInt16 temp = (UInt16)communicationState19[_subMessage14];
            temp >>= 2;

            Int32 minutes = temp & 0x7F;
            temp >>= 7;

            Int32 hours = temp & 0x1F;

            utcTime = new TimeSpan(hours, minutes, 0);
        }
    }
}
