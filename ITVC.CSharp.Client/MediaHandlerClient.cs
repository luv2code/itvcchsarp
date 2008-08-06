using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ITVC.CSharp.Messages;

namespace ITVC.CSharp.Client
{
    public class MediaHandlerClient:IDisposable
    {

        private int _port;
        private Process MediaHandlerProc;
        private TcpClient _client;
        private NetworkStream _stream;

        public event EventHandler<ProgressReceivedEventArgs> ProgressReceived;

        public MediaHandlerClient(int port)
        {
            _port = port;

            Process MediaHandlerProc = new Process();
            MediaHandlerProc.StartInfo.FileName = ConfigurationManager.AppSettings["MediaHandlerEXEPath"];
            MediaHandlerProc.StartInfo.CreateNoWindow = true;
            MediaHandlerProc.StartInfo.Arguments = port.ToString();
            MediaHandlerProc.Start();
        }
        
        public FetchInfoDetails FetchInfo(FetchInfo fetchInfoRequest)
        {
            WriteToStream(fetchInfoRequest.ToXML());

            FetchInfoDetails fid = new FetchInfoDetails();
            MessageBase msg = MessageBase.GetMessageFromText(ReadFromStream());
            while (!msg is Result)
            {
                switch (msg.MsgType)
                {
                    case MessageType.AudioCodec:
                        AudioCodec ac = (AudioCodec)msg;
                        fid.AudioCodec = ac.Value;
                        break;
                    case MessageType.FileSize:
                        FileSize ac = (FileSize)msg;
                        fid.FileSize = ac.Value;
                        break;
                    case MessageType.FPS:
                        FPS ac = (FPS)msg;
                        fid.FPS = ac.Value;
                        break;
                    case MessageType.Height:
                        Height ac = (Height)msg;
                        fid.Height = ac.Value;
                        break;
                    case MessageType.Length:
                        Length ac = (Length)msg;
                        fid.Length = ac.Value;
                        break;
                    case MessageType.VideoBitRate:
                        VideoBitRate ac = (VideoBitRate)msg;
                        fid.VideoBitRate = ac.Value;
                        break;
                    case MessageType.VideoCodec:
                        VideoCodec ac = (VideoCodec)msg;
                        fid.VideoCodec = ac.Value;
                        break;
                    case MessageType.Width:
                        Width ac = (Width)msg;
                        fid.Width = ac.Value;
                        break;
                }
                msg = MessageBase.GetMessageFromText(ReadFromStream());
            }
            return fid;
        }

        public void Transcode(Transcode transcodeRequest)
        {
        }

        public void Quit(Quit quitRequest)
        {
        }

        public void ProgressReply(ProgressReply progressReplyRequest)
        {
        }

        public void Connect()
        {
            _client.Connect("localhost", _port);
            _stream = _client.GetStream();
        }

        public void Close()
        {
        }

        #region IDisposable Members

        public void Dispose()
        {
            MediaHandlerProc.Close();
        }


        private void WriteToStream(string input)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(input);
            _stream.Write(data, 0, data.Length);
            _stream.Flush();
        }

        private string ReadFromStream()
        {
        }
        #endregion
    }
}
