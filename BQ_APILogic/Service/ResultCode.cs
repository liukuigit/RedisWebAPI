using System;
using System.Collections.Generic;
using System.Text;

namespace BQ_APILogic.Service
{
    [Serializable]
    public enum ResultCode
    {
        Fail,
        Exception,
        OrderNotFound,
        Success,
        UserAuthenticationFail,
        EmpAuthenticationFail,
        obkUserInfoNotFound,
        OrderUserInfoNotFound,
        ObkUserAndOrderIDFail,
        AuthenticationIsNull,
        CompanyIdUidError,
        OBKUserAuthenticationFail,
        OrderStatusError,
        SelectionIsNull,
        StartTimeAndEndTimeError,
        StartTimeError,
        TypeInputError,
        UserIdIsEmpty,
        UserIdLengthError,
        RequestXMLWrong,
        NotFound
    }


}
