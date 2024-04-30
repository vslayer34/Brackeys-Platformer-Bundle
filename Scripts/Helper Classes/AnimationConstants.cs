using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scripts.Helper;

/// <summary>
/// Contains references to the animation clips names for each character/object
/// </summary>
public class AnimationConstants
{
    /// <summary>
    /// Contains references to animations names for the player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// References to the<c>Idle</c>animation clip
        /// </summary>
        public const string IDLE = "Idle";

        /// <summary>
        /// References to the<c>Run</c>animation clip
        /// </summary>
        public const string RUN = "Run";

        /// <summary>
        /// References to the<c>Jump</c>animation clip
        /// </summary>
        public const string JUMP = "Jump";
    }
}