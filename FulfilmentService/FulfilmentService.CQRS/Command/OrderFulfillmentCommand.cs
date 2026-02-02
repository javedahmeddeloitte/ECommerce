using System;
using System.Collections.Generic;
using System.Text;

namespace FulfilmentService.CQRS.Command
{
    public record OrderFulfillmentCommand(Guid orderId);

}
