using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record BookDTtoForUpdate(int Id, String Title, decimal Price);
}
