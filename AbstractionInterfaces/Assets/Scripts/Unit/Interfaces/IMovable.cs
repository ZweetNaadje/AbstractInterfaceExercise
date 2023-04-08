using UnityEngine;

namespace Unit.Interfaces
{
    /// <summary>
    /// Whatever unit implements this interface, is a unit which can move.
    /// </summary>
    public interface IMovable
    {
        public void Move(Vector3 moveTowards);
    }
}