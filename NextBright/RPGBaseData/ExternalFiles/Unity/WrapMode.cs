using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGLogicBase
{
    //
    // Summary:
    //     Determines how time is treated outside of the keyframed range of an AnimationClip
    //     or AnimationCurve.
    public enum AnimWrapMode
    {
        //
        // Summary:
        //     When time reaches the end of the animation clip, the clip will automatically
        //     stop playing and time will be reset to beginning of the clip.
        Once = 1,
        //
        // Summary:
        //     When time reaches the end of the animation clip, time will continue at the beginning.
        Loop = 2,
        //
        // Summary:
        //     When time reaches the end of the animation clip, time will ping pong back between
        //     beginning and end.
        PingPong = 4,
        //
        // Summary:
        //     Plays back the animation. When it reaches the end, it will keep playing the last
        //     frame and never stop playing.
        OnceAndStopAtEnd = 8
    }
}
