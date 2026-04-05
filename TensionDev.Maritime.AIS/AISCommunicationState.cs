using System;
using System.Collections.Specialized;

namespace TensionDev.Maritime.AIS
{
    public abstract class AISCommunicationState
    {
        protected BitVector32 communicationState19;

        private BitVector32.Section _stateSpecific8;
        private BitVector32.Section _stateSpecific9;
        private BitVector32.Section _syncState2;

        /// <summary>
        /// <para>0 = UTC direct (see ß 3.1.1.1)</para>
        /// <para>1 = UTC indirect(see ß 3.1.1.2)</para>
        /// <para>2 = Station is synchronized to a base station(see ß 3.1.1.3)</para>
        /// <para>3 = Station is synchronized to another station based on the highest number of received stations (see ß 3.1.1.4)</para>
        /// </summary>
        public SyncStateEnum SyncState { get => (SyncStateEnum)(communicationState19[_syncState2]); set => communicationState19[_syncState2] = (UInt16)value; }

        protected AISCommunicationState()
        {
            _stateSpecific8 = BitVector32.CreateSection(0xFF);
            _stateSpecific9 = BitVector32.CreateSection(0x1FF, _stateSpecific8);
            _syncState2 = BitVector32.CreateSection(0x3, _stateSpecific9);
        }

        public UInt32 CommunicationState { get => (UInt32)communicationState19.Data; set => communicationState19 = new BitVector32((Int32)value); }

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
