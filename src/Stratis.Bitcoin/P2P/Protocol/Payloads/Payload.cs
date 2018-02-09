﻿using System.Linq;
using System.Reflection;
using NBitcoin;

namespace Stratis.Bitcoin.P2P.Protocol.Payloads
{
    public abstract class Payload : IBitcoinSerializable
    {
        public virtual string Command
        {
            get
            {
                return this.GetType().CustomAttributes.OfType<PayloadAttribute>().First().Name;
            }
        }

        public void ReadWrite(BitcoinStream stream)
        {
            using (stream.SerializationTypeScope(SerializationType.Network))
            {
                this.ReadWriteCore(stream);
            }
        }

        public virtual void ReadWriteCore(BitcoinStream stream)
        {
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
