﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MiniTwitter.Net.Twitter
{
    [Serializable]
    [XmlRoot("direct-messages")]
    public class DirectMessages : ITimeTaged
    {
        [XmlElement("direct_message")]
        public DirectMessage[] DirectMessage { get; set; }

        public static readonly DirectMessage[] Empty = new DirectMessage[0];

        [XmlIgnore()]
        public DateTime LastModified { get; set; }

        void ITimeTaged.UpdateChild()
        {
            foreach (var item in DirectMessage)
            {
                item.LastModified = this.LastModified;
            }
        }
    }
}