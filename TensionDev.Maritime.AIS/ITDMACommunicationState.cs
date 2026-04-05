using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace TensionDev.Maritime.AIS
{
    public class ITDMACommunicationState : AISCommunicationState
    {
        private BitVector32.Section _slotIncrement13;
        private BitVector32.Section _numberOfSlots3;
        private BitVector32.Section _keepFlag1;

        /// <summary>
        /// Offset to next slot to be used, or zero (0) if no more transmissions
        /// </summary>
        public Int16 SlotIncrement { get => (Int16)communicationState19[_slotIncrement13]; set => communicationState19[_slotIncrement13] = value; }

        /// <summary>
        /// Number of consecutive slots to allocate.
        /// <para>0 = 1 slot,</para>
        /// <para>1 = 2 slots,</para>
        /// <para>2 = 3 slots,</para>
        /// <para>3 = 4 slots,</para>
        /// <para>4 = 5 slots,</para>
        /// <para>5 = 1 slot; offset = slot increment + 8 192,</para>
        /// <para>6 = 2 slots; offset = slot increment + 8 192,</para>
        /// <para>7 = 3 slots; offset = slot increment + 8 192.</para>
        /// <para>Use of 5 to 7 removes the need for RATDMA broadcast for scheduled transmissions up to 6 min intervals</para>
        /// </summary>
        public UInt16 NumberOfSlots { get => (UInt16)communicationState19[_numberOfSlots3]; set => communicationState19[_numberOfSlots3] = Math.Min((UInt16)7, value); }

        public Boolean KeepFlag { get => communicationState19[_keepFlag1] != 0; set => communicationState19[_keepFlag1] = value ? 1 : 0; }

        public ITDMACommunicationState() : base()
        {
            _keepFlag1 = BitVector32.CreateSection(0x1);
            _numberOfSlots3 = BitVector32.CreateSection(0x7, _keepFlag1);
            _slotIncrement13 = BitVector32.CreateSection(0x1FFF, _numberOfSlots3);
        }
    }
}
