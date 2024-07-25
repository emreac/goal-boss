using System.Collections;
using UnityEngine;

public class AreaManager : MonoBehaviour
{

    public CameraSwitcher cameraSwitcher;

    //Sorted Areas
    [SerializeField] private GameObject enegryArea;
    [SerializeField] private GameObject wingArea;
    //[SerializeField] private GameObject wings;
    [SerializeField] private GameObject ballArea;
    private bool isUserCompleteLevel;

    //Supporters
    public GameObject support1;
    public GameObject support2;

    public LockedUnitController lockedUnitController;
    // Start is called before the first frame update
    void Start()
    {
        LoadStateSupport1();
        LoadStateSupport2();
        LoadStateBall();
        LoadStateWing();
        LoadStateEnergy();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoalKeeperArea"))
        {

            if (lockedUnitController.isPurchased)
            {

                cameraSwitcher.PerformCameraAction();
                StartCoroutine(ActivateEneryArea());
                other.enabled = false;
            }
        }
        if (other.CompareTag("EnergyDrinkArea"))
        {
            StartCoroutine(ActivateWingArea());

        }
        if (other.CompareTag("WingArea"))
        {

            if (lockedUnitController.isPurchased)
            {
               //
               //wings.SetActive(true);
                cameraSwitcher.PerformCameraAction();
                support2.SetActive(true);
                PlayerPrefs.SetInt("Support2Active", 1);
                other.enabled = false;
                ballArea.SetActive(true);
                StartCoroutine(ActivateBallArea());
                cameraSwitcher.BallAreaCamera();
                TinySauce.OnGameFinished(isUserCompleteLevel, lockedUnitController.score, "HalfAreasCompleted");
            }
        }


    }
    IEnumerator ActivateEneryArea()
    {
        yield return new WaitForSeconds(2f);
        enegryArea.SetActive(true);
        support1.SetActive(true);
        PlayerPrefs.SetInt("Support1Active", 1);

        PlayerPrefs.SetInt("EnergyAreaActive", 1); // Save state as 1 (true)

        lockedUnitController.SaveUnit();
    }

    IEnumerator ActivateWingArea()
    {
        yield return new WaitForSeconds(0.5f);
        wingArea.SetActive(true);


        PlayerPrefs.SetInt("WingAreaActive", 1); // Save state as 1 (true)

        lockedUnitController.SaveUnit();
    }

    IEnumerator ActivateBallArea()
    {
        yield return new WaitForSeconds(0.5f);
        ballArea.SetActive(true);


        PlayerPrefs.SetInt("BallAreaActive", 1); // Save state as 1 (true)

        lockedUnitController.SaveUnit();
    }

    void LoadStateEnergy()
    {
        int energyAreaActive = PlayerPrefs.GetInt("EnergyAreaActive", 0); // Default to 0 (false)

        if (energyAreaActive == 1)
        {
            enegryArea.SetActive(true);

        }
        else
        {
            enegryArea.SetActive(false);

        }

    }
    void LoadStateWing()
    {
        int wingAreaActive = PlayerPrefs.GetInt("WingAreaActive", 0); // Default to 0 (false)

        if (wingAreaActive == 1)
        {
            wingArea.SetActive(true);

        }
        else
        {
            wingArea.SetActive(false);

        }

    }

    void LoadStateBall()
    {
        int ballAreaActive = PlayerPrefs.GetInt("BallAreaActive", 0); // Default to 0 (false)

        if (ballAreaActive == 1)
        {
            ballArea.SetActive(true);

        }
        else
        {
            ballArea.SetActive(false);

        }

    }

    void LoadStateSupport1()
    {
        int support1Active = PlayerPrefs.GetInt("Support1Active", 0); // Default to 0 (false)

        if (support1Active == 1)
        {
            support1.SetActive(true);

        }
        else
        {
            support1.SetActive(false);

        }
    }

    void LoadStateSupport2()
    {
        int support2Active = PlayerPrefs.GetInt("Support2Active", 0); // Default to 0 (false)

        if (support2Active == 1)
        {
            support2.SetActive(true);

        }
        else
        {
            support2.SetActive(false);

        }
    }



    public void PlayUnlockedSound()
    {
        AudioManager.instance.PlayAudio(AudioClipType.unlockedClip);
    }
}
