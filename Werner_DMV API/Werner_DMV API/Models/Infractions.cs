﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Werner_DMV_API.Models
{
    public partial class Infractions
    {
        public string InfractionID { get; set; }
        public string IInfoID { get; set; }
        public string LicenseID { get; set; }
        public string LawEnID { get; set; }

        public virtual InfractionInfo IInfo { get; set; }
        public virtual LawEnforcement LawEn { get; set; }
        public virtual Licenses License { get; set; }
    }
}