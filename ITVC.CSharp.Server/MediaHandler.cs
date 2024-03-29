﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ITVC.CSharp.Messages;

namespace ITVC.CSharp.Server
{
    
    public class MediaHandler
    {
        public event EventHandler<MediaHandlerEventArgs> FetchInfoReceived;
        public event EventHandler<MediaHandlerEventArgs> TranscodeReceived;
        public event EventHandler<MediaHandlerEventArgs> ProgressReplyReceived;
        public event EventHandler<MediaHandlerEventArgs> QuitReceived;

        private int _port;
        private TcpListener _listener;
        private bool _continue = true;
        private TcpClient _client;
        private NetworkStream _stream;

        public MediaHandler(int port)
        {
            _port = port;
            _listener = new TcpListener(IPAddress.Any, _port);
        }

        public void Start()
        {
            _listener.Start();
            _client = _listener.AcceptTcpClient();
            _stream = _client.GetStream();

            //string msg = new BinaryReader(_stream).ReadString();
            while (_continue)
            {
                string rawText = ReadFromStream();
                MessageBase msg = MessageBase.GetMessageFromText(rawText);
                MediaHandlerEventArgs args = new MediaHandlerEventArgs(msg.MsgType, rawText, msg);
                switch (msg.MsgType)
                {
                    case MessageType.FetchInfo:
                        if (FetchInfoReceived != null)
                            FetchInfoReceived(this, args);
                        break;
                    case MessageType.Transcode:
                        if (TranscodeReceived != null)
                            TranscodeReceived(this, args);
                        break;
                    case MessageType.ProgressReply:
                        if (ProgressReplyReceived != null)
                            ProgressReplyReceived(this, args);
                        break;
                    case MessageType.Quit:
                        if (QuitReceived != null)
                            QuitReceived(this, args);
                        break;
                }
            }
            _listener.Stop();
        }

        public void Stop()
        {
            _continue = false;
        }

        public void Send(MessageBase msg)
        {
            byte[] data = ASCIIEncoding.ASCII.GetBytes(msg.ToXML());
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
    }
}
