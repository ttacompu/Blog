using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDataModel
{
   public interface IAuditInfo
    {
      DateTime ModifiedOn { get; set; }
      DateTime CreatedOn { get; set; }
    }
}
