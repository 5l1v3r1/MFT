﻿using System;
using System.Text;

namespace MFT.Attributes
{
    public class LoggedUtilityStream : Attribute
    {
        public LoggedUtilityStream(byte[] rawBytes) : base(rawBytes)
        {
            var content = new byte[AttributeContentLength];

            Buffer.BlockCopy(rawBytes, ContentOffset, content, 0, AttributeContentLength);

            ResidentData = new ResidentData(content);
        }

        public ResidentData ResidentData { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("**** " + GetType().Name.ToUpperInvariant() + " ****");

            sb.AppendLine(base.ToString());

            sb.AppendLine();

            sb.AppendLine(
                $"ResidentData: {ResidentData}");

            return sb.ToString();
        }
    }
}