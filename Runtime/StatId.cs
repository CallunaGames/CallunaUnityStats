using System;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "StatId", menuName = "Calluna Games/Stats/Id")]
    public class StatId : ScriptableObjectId, IEquatable<StatId>
    {
        public bool Equals(StatId other)
        {
            return ReferenceEquals(other, this);
        }
    }
}
