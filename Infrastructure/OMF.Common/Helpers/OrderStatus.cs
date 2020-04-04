using System;
using System.Collections.Generic;
using System.Text;

namespace OMF.Common.Helpers
{
    public enum OrderStatus
    {
        PaymentPending,
        PaymentSuccessful,
        PaymentFailed,
        Cancelled,
        OrderPlaced,
        Delivered,
        EnRoute

    }
}
