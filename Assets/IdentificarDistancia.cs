using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private CharacterTypeEnum _characterOne = default;
    [SerializeField] private CharacterTypeEnum _characterTwo = default;
    public Player PlayerOne { get; private set; }
    public Player PlayerTwo { get; private set; }

    [Header("Audio Settings")]
    [SerializeField] private AudioClip audioClip;
    private AudioSource audioSource;
    
    public float minDistance = 0f;
    public float maxDistance = 1000f;

    public float GetNormalizedDistance()
    {
        if (PlayerOne == null || PlayerTwo == null)
        {
            Debug.LogWarning("algum dos players não foi inserido");
            return 0;
        }

        float distance = Vector3.Distance(PlayerOne.transform.position, PlayerTwo.transform.position);
        float normalizedDistance = Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));

        return normalizedDistance;
    }

    void Awake()
    {
        SceneSettings.PlayerOne = (int)_characterOne;
        SceneSettings.PlayerTwo = (int)_characterTwo;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true; 
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; 
        audioSource.volume = 0f;

        if (audioClip != null)
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        float normalizedDistance = GetNormalizedDistance();
        audioSource.volume = Mathf.Lerp(1f, 0f, normalizedDistance); 
}
