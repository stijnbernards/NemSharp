using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace NemSharp.Request.Responses.Namespace
{
    public class Namespace : IEquatable<Namespace>
    {
        [DeserializeAs(Name = "fqn")]
        public string NamespaceID { get; set; }
        [DeserializeAs(Name = "owner")]
        public string Owner { get; set; }
        [DeserializeAs(Name = "height")]
        public int Height { get; set; }

        #region EqualsOverrides
        public bool Equals(Namespace ns1)
        {
            return ns1 != null &&
                   ns1.Height == Height &&
                   ns1.NamespaceID == NamespaceID &&
                   ns1.Owner == Owner;
        }

        public new bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Namespace))
            {
                return obj.Equals(this);
            }

            Namespace ns1 = obj as Namespace;

            return ns1 != null &&
                   ns1.Height == Height &&
                   ns1.NamespaceID == NamespaceID &&
                   ns1.Owner == Owner;
        }

        public new int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + Height.GetHashCode();
                hash = hash * 23 + Owner.GetHashCode();
                hash = hash * 23 + NamespaceID.GetHashCode();

                return hash;
            }
        }
        #endregion
    }
}
