using UnityEngine;

namespace Unit.Interfaces
{
    /// <summary>
    /// Whatever unit implements this interface, is a unit which can move.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// This method will move the AI to a selected position / target.
        /// </summary>
        /// <param name="moveTowards">This is the point towards which the AI will move</param>
        public void Move(Vector3 moveTowards);
    }
}