using UnityEngine;
using UnityEngine.Playables;
public class Timeline : MonoBehaviour
{
    public PlayableDirector playableDirector;
    [SerializeField] private int VidSkipSec;


    // Call this function to jump to a specific time in the timeline
    private void JumpToTime(float timeInSeconds)
    {
        playableDirector.time = timeInSeconds;
        playableDirector.Evaluate(); // Forces the timeline to update to the new time
    }

    public void Jumpto()
    {
        JumpToTime(VidSkipSec);
    }
       
}
