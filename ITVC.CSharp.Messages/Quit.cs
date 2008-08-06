using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class Quit : MessageBase
    {
        public Quit()
        {
            MsgType = MessageType.Quit;
        }
        public static Quit CreateFromXML(string XmlText)
        {
            return (Quit)MessageBase.GetMessageFromText(XmlText);
        }
        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.QUIT_OPEN);
            xml.Append(MessageConstants.QUIT_CLOSE);
            return xml.ToString();
        }
    }
}
