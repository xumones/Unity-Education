using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionAction : MonoBehaviour
{
    [SerializeField] float crashDelay = 0.5f; 
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] AudioClip SFX_crash; 
    [SerializeField] AudioClip SFX_pass; 

    [SerializeField] ParticleSystem PTC_crash; 
    [SerializeField] ParticleSystem PTC_pass; 

    AudioSource audioSource;

    bool isTransitioning = false; //anything happen? if not then = false
    bool collisionDisabled = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CheckDebug();
    }

    private void OnCollisionEnter(Collision other) 
    {
        //if variable "isTransitioning" is true (something happen before) then quit this execute
        if (isTransitioning || collisionDisabled) { return; }
        //but if variable "isTransitioning" is false (anything don't happen) then execute this
        switch(other.gameObject.tag)
        {
            case "Finish":
                StartNextSequence();
                break;
            case "Respawn":
                Debug.Log("Again?");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        PTC_crash.Play();
        isTransitioning = true; //change state and everything that happen after this can't execute
        audioSource.Stop();
        audioSource.PlayOneShot(SFX_crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", crashDelay);
    }
    void StartNextSequence()
    {
        PTC_pass.Play();
        isTransitioning = true; //change state and everything that happen after this can't execute
        audioSource.Stop();
        audioSource.PlayOneShot(SFX_pass);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        GetComponent<Movement>().enabled = true;
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void CheckDebug()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // toggle bool state to true or false by C BUTTON
        }
    }

}
