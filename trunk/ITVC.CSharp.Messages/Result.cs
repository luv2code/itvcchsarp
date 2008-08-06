using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class Result : MessageBase
    {
        public const string RESULT_OK = "ok";
        public const string RESULT_ABORTED = "aborted";

        public string Value { get; set; }

        public Result()
        {
            MsgType = MessageType.Result;
        }
        public static Result CreateFromXML(string XmlText)
        {
            return (Result)MessageBase.GetMessageFromText(XmlText);
        }


        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.RESULT_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.RESULT_CLOSE);
            return xml.ToString();
        }
    }
}
