﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Werner_DMV_API.Models
{
    public partial class DMV
    {
        public DMV()
        {
            License = new HashSet<Licenses>();
        }

        public string DMVID { get; set; }
        public string DMVUserName { get; set; }
        public string DMVPassword { get; set; }

        public virtual ICollection<Licenses> License { get; set; }
    }
}