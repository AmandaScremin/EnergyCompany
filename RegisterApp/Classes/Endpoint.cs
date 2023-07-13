using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterApp
{
    public class Endpoint
    {
        // Attributes
        public int SerialNumber { get; set; }
        public MeterModelId MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string MeterFirmwareVersion { get; set; }
        public SwitchState SwitchState { get; set; }

        private bool Excluded { get; set; }

        //Methods

        public Endpoint(int serialNumber, MeterModelId meterModelId, int meterNumber, string meterFirmwareVersion, SwitchState switchState)
        {
            this.SerialNumber = serialNumber;
            this.MeterModelId = meterModelId;
            this.MeterNumber = meterNumber;
            this.MeterFirmwareVersion = meterFirmwareVersion;
            this.SwitchState = switchState;
            this.Excluded = false;
        }
        public Endpoint(SwitchState switchState)
        {
            this.SwitchState = switchState;
        }

        //Encapsulation 

        public int returnSerialNumber()
        {
            return this.SerialNumber;
        }
        public MeterModelId returnMeterModelId()
        {
            return this.MeterModelId;
        }
        public int returnMeterNumber()
        {
            return this.MeterNumber;
        }
        public string returnMeterFirmwareVersion()
        {
            return this.MeterFirmwareVersion;
        }
        public SwitchState returnSwitchState()
        {
            return this.SwitchState;
        }
        internal bool returnExcluded()
        {
            return this.Excluded;
        }
        public void Exclude()
        {
            this.Excluded = true;
        }
    }
}
