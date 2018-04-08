using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public partial class InverterData
    {
        public short OrganizationId { get; set; }
        public short SiteId { get; set; }
        public short InverterId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        [Column("PV3 Current/PV3")]
        public double? Pv3CurrentPv3 { get; set; }
        [Column("PV4 Voltage/PV4")]
        public double? Pv4VoltagePv4 { get; set; }
        [Column("PV5 Current/PV5")]
        public double? Pv5CurrentPv5 { get; set; }
        [Column("PV1 Current/PV1")]
        public double? Pv1CurrentPv1 { get; set; }
        [Column("PV3 Voltage/PV3")]
        public double? Pv3VoltagePv3 { get; set; }
        [Column("Output active power")]
        public double? OutputActivePower { get; set; }
        [Column("PV2 Voltage/PV2")]
        public double? Pv2VoltagePv2 { get; set; }
        [Column("Inverter Status")]
        public double? InverterStatus { get; set; }
        [Column("MPPT1 DC Power")]
        public double? Mppt1DcPower { get; set; }
        [Column("Grid A Line Current")]
        public double? GridALineCurrent { get; set; }
        [Column("Grid AB Line Voltage")]
        public double? GridAbLineVoltage { get; set; }
        [Column("MPPT2 DC Power")]
        public double? Mppt2DcPower { get; set; }
        [Column("PV1 Voltage/PV1")]
        public double? Pv1VoltagePv1 { get; set; }
        [Column("Grid C Line Current")]
        public double? GridCLineCurrent { get; set; }
        [Column("Frequency of grid")]
        public double? FrequencyOfGrid { get; set; }
        [Column("PV6 Current/PV6")]
        public double? Pv6CurrentPv6 { get; set; }
        [Column("E-day")]
        public double? EDay { get; set; }
        [Column("Output power factor")]
        public double? OutputPowerFactor { get; set; }
        [Column("PV5 Voltage/PV5")]
        public double? Pv5VoltagePv5 { get; set; }
        [Column("Total energy")]
        public double? TotalEnergy { get; set; }
        [Column("PV2 Current/PV2")]
        public double? Pv2CurrentPv2 { get; set; }
        [Column("Grid BC Line Voltage")]
        public double? GridBcLineVoltage { get; set; }
        [Column("Output reactive power")]
        public double? OutputReactivePower { get; set; }
        [Column("Grid B Line Current")]
        public double? GridBLineCurrent { get; set; }
        [Column("Cabinet temperature")]
        public double? CabinetTemperature { get; set; }
        [Column("PV6 Voltage/PV6")]
        public double? Pv6VoltagePv6 { get; set; }
        [Column("MPPT3 DC Power")]
        public double? Mppt3DcPower { get; set; }
        [Column("PV4 Current/PV4")]
        public double? Pv4CurrentPv4 { get; set; }
        [Column("Grid CA Line Voltage")]
        public double? GridCaLineVoltage { get; set; }

        [ForeignKey("OrganizationId,SiteId,InverterId")]
        [InverseProperty("InverterData")]
        public InverterMaster InverterMaster { get; set; }
        [ForeignKey("OrganizationId")]
        [InverseProperty("InverterData")]
        public OrganizationMaster Organization { get; set; }
        [ForeignKey("OrganizationId,SiteId")]
        [InverseProperty("InverterData")]
        public SiteMaster SiteMaster { get; set; }
    }
}
