using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.DTO
{
    public record AccountResponseDTO
    (
        int Id, 
        string Owner, 
        decimal Balance
    );
}
