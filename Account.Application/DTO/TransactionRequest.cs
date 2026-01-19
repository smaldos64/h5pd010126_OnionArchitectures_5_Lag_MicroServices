using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.DTO
{
    public record TransactionRequest
    (
        int AccountId, 
        float Amount
    );
}
