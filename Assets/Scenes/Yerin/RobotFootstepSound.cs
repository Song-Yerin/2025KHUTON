using UnityEngine;

public class RobotFootstepSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepClip;

    public void PlayFootstep()
    {
        audioSource.PlayOneShot(footstepClip);
    }
}
