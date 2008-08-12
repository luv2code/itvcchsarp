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
        private string _path;
        private Process _mediaHandlerProc;
        private TcpClient _client;
        private NetworkStream _stream;

        public event EventHandler<ProgressReceivedEventArgs> ProgressReceived;

        public MediaHandlerClient(int mediaHandlerPort, string mediaHandlerPath)//, ProcessPriorityClass priority)
        {
            _port = mediaHandlerPort;
            _path = mediaHandlerPath;
            _mediaHandlerProc = new Process();
            _mediaHandlerProc.StartInfo.FileName = _path;
            _mediaHandlerProc.StartInfo.CreateNoWindow = true;
            _mediaHandlerProc.StartInfo.Arguments = _port.ToString();
            _mediaHandlerProc.Start();
            //_mediaHandlerProc.PriorityClass = priority;
            _client = new TcpClient();
        }
        
        public FetchInfoDetails FetchInfo(FetchInfo fetchInfoRequest)
        {
            WriteToStream(fetchInfoRequest.ToXML());

            FetchInfoDetails fid = new FetchInfoDetails();
            MessageBase msg = MessageBase.GetMessageFromText(ReadFromStream());
            while (!(msg is Result))
            {
                switch (msg.MsgType)
                {
                    case MessageType.AudioCodec:
                        AudioCodec ac = (AudioCodec)msg;
                        fid.AudioCodec = ac.Value;
                        break;
                    case MessageType.FileSize:
                        FileSize fs = (FileSize)msg;
                        fid.FileSize = int.Parse(fs.Value);
                        break;
                    case MessageType.FPS:
                        FPS fps = (FPS)msg;
                        fid.FPS = float.Parse(fps.Value);
                        break;
                    case MessageType.Height:
                        Height h = (Height)msg;
                        fid.Height = int.Parse(h.Value);
                        break;
                    case MessageType.Length:
                        Length l = (Length)msg;
                        fid.Length = float.Parse(l.Value);
                        break;
                    case MessageType.VideoBitRate:
                        VideoBitRate vbr = (VideoBitRate)msg;
                        fid.VideoBitRate = int.Parse(vbr.Value);
                        break;
                    case MessageType.VideoCodec:
                        VideoCodec vc = (VideoCodec)msg;
                        fid.VideoCodec = vc.Value;
                        break;
                    case MessageType.Width:
                        Width w = (Width)msg;
                        fid.Width = int.Parse(w.Value);
                        break;
                }
                msg = MessageBase.GetMessageFromText(ReadFromStream());
            }
            return fid;
        }

        public void Transcode(Transcode transcodeRequest)
        {
            WriteToStream(transcodeRequest.ToXML());
            MessageBase msg = MessageBase.GetMessageFromText(ReadFromStream());
            while (!(msg is Result))
            {
                if (msg is Progress && ProgressReceived != null)
                {
                    Progress prog = (Progress) msg;
                    ProgressReceivedEventArgs args = new ProgressReceivedEventArgs(prog.Number);
                    ProgressReceived(this, args);
                }
                msg = MessageBase.GetMessageFromText(ReadFromStream());
            }
        }

        public void Quit()
        {
            WriteToStream((new Quit()).ToXML());
        }

        public void ProgressReply(ProgressReply progressReplyRequest)
        {
            WriteToStream(progressReplyRequest.ToXML());
        }

        public void Connect()
        {
            _client.Connect("localhost", _port);
            _stream = _client.GetStream();
        }

        public void Close()
        {
            _client.Close();
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_client.Connected)
                _client.Close();
            _mediaHandlerProc.Close();
        }


        private void WriteToStream(string input)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(input);
            _stream.Write(data, 0, data.Length);
            _stream.Flush();
        }

        private string ReadFromStream()
        {
            int data = 0;
            List<byte> datas = new List<byte>();
            while (data != 10 && data != -1)
            {
                data = _stream.ReadByte();
                if (data != 10)
                    datas.Add((byte)data);
            }
            return ASCIIEncoding.ASCII.GetString(datas.ToArray());
        }
        #endregion
    }
}
