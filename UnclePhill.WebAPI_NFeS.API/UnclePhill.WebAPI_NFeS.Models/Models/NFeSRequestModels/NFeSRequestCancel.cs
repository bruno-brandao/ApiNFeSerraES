﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnclePhill.WebAPI_NFeS.Models.Models.NFeSRequestModels
{
    public class NFeSRequestCancel
    {
        public NFeSRequestCancel()
        {

        }

        public NFeSRequestCancel(long CompanyId, string NFNumber)
        {
            this.CompanyId = CompanyId;
            this.NFNumber = NFNumber;
        }

        public long CompanyId { get; set; }
        public string NFNumber { get; set; }
    }
}
