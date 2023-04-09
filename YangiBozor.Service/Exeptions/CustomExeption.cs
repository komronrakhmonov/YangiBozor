using System;

namespace YangiBozor.Service.Exeptions;

public class CustomExeption : Exception
{
    public int Code { get; set; }
	public CustomExeption(int code, string messeage) : base(messeage)
	{
		this.Code = code;
	}
}
