using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [Header("Audio Parameters")]
    [SerializeField] private AudioSource FootstepAudioSource = default;
    [SerializeField] private P_movement PlayerScript;
    [SerializeField] private float BaseStepSpeed = 0.5f;
    [SerializeField] private float CrouchStepMultiplier = 1.5f;
    [Header("Audio Clips")]
    [SerializeField] AudioClip[] CarpetClips = default;
    [SerializeField] AudioClip[] GrassClips = default;
    [SerializeField] AudioClip[] MetalClips = default;
    [SerializeField] AudioClip[] StoneClips = default;
    [SerializeField] AudioClip[] TileClips = default;
    [SerializeField] AudioClip[] WoodClips = default;
    [SerializeField] AudioClip[] WaterClips = default;

    public bool FootstepsEnabled { get; set; }
    private float FootstepTimer = 0f;
    private float GetCurrentOffset => PlayerScript.IsCrouching || PlayerScript.IsSilentWalking ? BaseStepSpeed * CrouchStepMultiplier
                                      : BaseStepSpeed;
    private int CurrentAudioQuene = 0;
    private void Awake()
    {
        PlayerScript = FindObjectOfType<P_movement>();
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
        if (!PlayerScript.IsGrounded) return;
        if (!PlayerScript.IsWalking) return;

        FootstepTimer -= Time.deltaTime;

        if(FootstepTimer <= 0)
        {
            //Perhaps we can create a single raycast function that everything that requires it access it.
            //After this is working, I will see to that.
            if (Physics.Raycast(PlayerScript.Orientation.position, Vector3.down,out RaycastHit hit,3))//AVOID MAGIC NUMBER.
            {
                switch(hit.collider.tag)
                {
                    case "Footsteps/WOOD":
                        FootstepAudioSource.PlayOneShot(WoodClips[Random.Range(0,WoodClips.Length -1)]);
                        break;
                    case "Footsteps/GRASS":
                        FootstepAudioSource.PlayOneShot(GrassClips[Random.Range(0, GrassClips.Length - 1)]);
                        break;
                    case "Footsteps/STONE":
                        FootstepAudioSource.PlayOneShot(StoneClips[Random.Range(0, StoneClips.Length - 1)]);
                        break;
                    case "Footsteps/METAL":
                        FootstepAudioSource.PlayOneShot(MetalClips[Random.Range(0, MetalClips.Length - 1)]);
                        break;
                    case "Footsteps/TILE":
                        FootstepAudioSource.PlayOneShot(TileClips[Random.Range(0, TileClips.Length - 1)]);
                        break;
                    case "Footsteps/CARPET":
                        FootstepAudioSource.PlayOneShot(CarpetClips[Random.Range(0, CarpetClips.Length - 1)]);
                        break;
                    case "Footsteps/WATER":
                        FootstepAudioSource.PlayOneShot(WaterClips[Random.Range(0, WaterClips.Length - 1)]);
                        break;
                    default:
                        Debug.LogWarning("Warning, no tag has been added to this object.");
                        //FootstepAudioSource.PlayOneShot(StoneClips[Random.Range(0, StoneClips.Length - 1)]);
                        FootstepAudioSource.PlayOneShot(GetAudioFromArray(StoneClips));
                        break;
                }
            }
            FootstepTimer = GetCurrentOffset;
        }
    }
    //I am trying to get away from Random becuase random sometimes sends the same item twice.
    public AudioClip GetAudioFromArray(AudioClip[] audio) 
    {
        if(audio.Length <= CurrentAudioQuene)
        {
            CurrentAudioQuene = 0;
        }
        CurrentAudioQuene++;
        Debug.Log(audio[CurrentAudioQuene - 1].name);
        return audio[CurrentAudioQuene - 1];
    }
}
