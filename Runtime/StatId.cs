using System;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "StatId", menuName = "Settings/Stat/Id")]
    public class StatId : ScriptableObjectId, IEquatable<StatId>
    {
        public bool Equals(StatId other)
        {
            return ReferenceEquals(other, this);
        }
    }
}
