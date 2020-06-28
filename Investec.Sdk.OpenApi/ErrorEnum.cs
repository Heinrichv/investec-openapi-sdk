using System;
using System.Collections.Generic;
using System.Text;

namespace Investec.Sdk.OpenApi
{
    public enum ErrorEnum
    {
        OperationFailed = 100,
        OperationRefused,
        OperationCancelled,
        UnknownErrorOccurred
    }
}
