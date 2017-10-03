using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Common.ViewModel
{
    public class ImportExportMV
    {
        public OptionImport OptionImport { get; set; }
        public IFormFile Attachment { get; set; }

        public ImportExportMV()
        {
            this.OptionImport = OptionImport.IsAddUpdate;
        }
    }
}
