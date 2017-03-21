using System;
using System.Collections.Generic;

namespace Graphene.Core
{
    public class TransactionDto
    {
        public List<string> Extensions { get; set; }

        public List<string> Signatures { get; set; }

        public List<string> Operations { get; set; }

        public List<string> Expiration { get; set; }

        public UInt16 RefBlockNum { get; set; }

        public UInt32 RefBlockPrefix { get; set; }
    }
}