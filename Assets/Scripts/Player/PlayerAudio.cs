using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [Header("Audio Parameters")]
    [SerializeField] private AudioSource footstepAudioSource = default;
    [SerializeField] private P_movement playerScript;
    [SerializeField] private float baseStepSpeed = 0.5f;
    [SerializeField] private float crouchStepMultiplier = 1.5f;
    [Header("Audio Clips")]
    [SerializeField] AudioClip[] carpetClips = default;
    [SerializeField] AudioClip[] grassClips = default;
    [SerializeField] AudioClip[] metalClips = default;
    [SerializeField] AudioClip[] stoneClips = default;
    [SerializeField] AudioClip[] tileClips = default;
    [SerializeField] AudioClip[] woodClips = default;
    [SerializeField] AudioClip[] waterClips = default;

    private float footstepTimer = 0f;
    private float GetCurrentOffset => playerScript.IsCrouching || playerScript.IsSilentWalking ? baseStepSpeed * crouchStepMultiplier
                                      : baseStepSpeed;
    private void Awake()
    {
        playerScript = FindObjectOfType<P_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleFootsteps();    
    }
    //CURRENT BUG, on slopes the footstep audio won't cut. IsWalking can be transferred into Vector2 that is being sent out 
    //by the AbilityManager to check if there is input.
    private void HandleFootsteps()
    {
        if (!playerScript.IsGrounded) return;
        if (!playerScript.IsWalking) return;

        footstepTimer -= Time.deltaTime;

        if(footstepTimer <= 0)
        {
            //Perhaps we can create a single raycast function that everything that requires it access it.
            //After this is working, I will see to that.
            if (Physics.Raycast(playerScript.orientation.position, Vector3.down,out RaycastHit hit,3))//AVOID MAGIC NUMBER.
            {
                switch(hit.collider.tag)
                {
                    case "Footsteps/WOOD":
                        footstepAudioSource.PlayOneShot(woodClips[Random.Range(0,woodClips.Length -1)]);
                        break;
                    case "Footsteps/GRASS":
                        footstepAudioSource.PlayOneShot(grassClips[Random.Range(0, grassClips.Length - 1)]);
                        break;
                    case "Footsteps/STONE":
                        footstepAudioSource.PlayOneShot(stoneClips[Random.Range(0, stoneClips.Length - 1)]);
                        break;
                    case "Footsteps/METAL":
                        footstepAudioSource.PlayOneShot(metalClips[Random.Range(0, metalClips.Length - 1)]);
                        break;
                    case "Footsteps/TILE":
                        footstepAudioSource.PlayOneShot(tileClips[Random.Range(0, tileClips.Length - 1)]);
                        break;
                    case "Footsteps/CARPET":
                        footstepAudioSource.PlayOneShot(carpetClips[Random.Range(0, carpetClips.Length - 1)]);
                        break;
                    case "Footsteps/WATER":
                        footstepAudioSource.PlayOneShot(waterClips[Random.Range(0, waterClips.Length - 1)]);
                        break;
                    default:
                        Debug.Log("Warning, no tag has been added to this object.");
                        footstepAudioSource.PlayOneShot(stoneClips[Random.Range(0, stoneClips.Length - 1)]);
                        break;
                }
            }
            footstepTimer = GetCurrentOffset;
        }
    }
}
