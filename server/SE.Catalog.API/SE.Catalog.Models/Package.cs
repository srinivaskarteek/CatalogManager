using System;
using System.Collections.Generic;

namespace SE.Catalog.Models
{
    public class Package : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public string HWVersion { get; set; }
        public DeviceFamily DeviceFamily { get; set; }
        public ProductFamily ProductFamily { get; set; }
        public Vendor Vendor { get; set; }
        public string ProfileType { get; set; }
        public WorkFlowStatus Status { get; set; }
        public int OwnerId { get; set; }
        public DateTime UploadDate { get; set; }
        public string ProductId { get; set; }
        public string SWVersion { get; set; }
        public string FileName { get; set; }
        public string BlobURL { get; set; }
        public List<PackageComment> Comments { get; set; }
    }
    public enum WorkFlowStatus
    {
        Approved,
        Pending,
        Rejected
    }
}
