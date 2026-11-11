using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.MobileApp
{
  public  class MobDeviceData
    {
        public string DeviceId { get; set; }
        public string DeviceModel { get; set; }
        public string AppVersion { get; set; }
        public string FcmId { get; set; }
    }
}
