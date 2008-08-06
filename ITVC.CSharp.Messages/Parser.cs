using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    internal class Parser
    {

        private static List<string> GetMessageList()
        {
            // The order that the constants are added to the list must match the message type enum
            List<string> ret = new List<string>();
            ret.Add(MessageConstants.FETCH_INFO_OPEN);
            ret.Add(MessageConstants.VIDEO_CODEC_OPEN);
            ret.Add(MessageConstants.AUDIO_CODEC_OPEN);
            ret.Add(MessageConstants.FPS_OPEN);
            ret.Add(MessageConstants.WIDTH_OPEN);
            ret.Add(MessageConstants.HEIGHT_OPEN);
            ret.Add(MessageConstants.LENGTH_OPEN);
            ret.Add(MessageConstants.FILE_SIZE_OPEN);
            ret.Add(MessageConstants.VIDEO_BIT_RATE_OPEN);
            ret.Add(MessageConstants.RESULT_OPEN);
            ret.Add(MessageConstants.TRANSCODE_OPEN);
            ret.Add(MessageConstants.PROGRESS_OPEN);
            ret.Add(MessageConstants.PROGRESS_REPLY_OPEN);
            ret.Add(MessageConstants.QUIT_OPEN);

            return ret;

        }

        public static Parsed GetTypeAndParameters(string input)
        {
            Parsed p = new Parsed();
            p.Parameters = new List<string>();

            p.Type = GetType(input);

            string paramtext = StripTags(input);

            string [] paramarr = paramtext.Split(new char[] { MessageConstants.PARAMETER_DELIMITER });
            p.Parameters.AddRange(paramarr);

            return p;
        }

        private static string StripTags(string input)
        {
            string retString = input.Substring(input.IndexOf('>') + 1);

            retString = retString.Substring(0, retString.IndexOf('<'));

            return retString;
        }

        private static MessageType GetType(string input)
        {
            List<string> list = GetMessageList();
            int x = 0;
            for (; x < list.Count; x++)
            {
                if (input.Contains(list[x]))
                    break;
            }
            return (MessageType)x;
        }
    }

    internal class Parsed
    {
        public MessageType Type {get; set;}
        public List<string> Parameters {get; set;}
    }
}
