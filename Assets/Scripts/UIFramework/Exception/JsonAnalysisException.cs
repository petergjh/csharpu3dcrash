using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Json路径或格式错误引发的异常
/// </summary>
public class JsonAnalysisException :Exception
{

    public JsonAnalysisException() : base() { }
    public JsonAnalysisException(string exceptionMessage): base(exceptionMessage) { }
}
