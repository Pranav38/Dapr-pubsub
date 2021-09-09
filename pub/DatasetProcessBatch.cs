using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pub
{
   public   class DatasetProcessBatch
    {
        public   int BatchId { get; set; }
        public   int DatasetId { get; set; }
        public   string UserId { get; set; }
        public   string Status { get; set; }
        public   string CreatedOn { get; set; }
        public   string ModifiedOn { get; set; }
    }
}
