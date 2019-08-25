using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance;
    public GameObject NormalWorld;
    public GameObject InsideWorld;
    public GameObject SpawnPoint;
    public float changeDuration = 3f;
    public Vector3 spawnPoint;
    public GameObject BloodParticle;
    public TransferToAnother TransferToAnother;///add by Haru

    public string NowLevel;
    public GameObject LoadingObj;
    public GameObject PlayerPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        LoadingObj.SetActive(false);
        NowLevel = SceneManager.GetActiveScene().name;

        SetWrold();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadScene("Tutorial1", true);
        }

        //player
        if (Player.instence == null) return;
        if (Player.instence.isDead)
        {
            Debug.Log("Dead");
            Player.instence.isDead = false;

            if (InsideWorld)
                InsideWorld.SetActive(false);
            NormalWorld.SetActive(true);
            StopAllCoroutines();
            Player.instence.TransferToAnother.ZoomInToNormalEffect();
            //player.gameObject.SetActive(false);
            //player.transform.position = Vector3.Lerp(player.transform.position, spawnPoint, 0.5f);
            BloodParticle.transform.position = Player.instence.transform.position;
            BloodParticle.SetActive(true);
            BloodParticle.GetComponent<ParticleSystem>().Play();

            Player.instence.transform.DOMove(spawnPoint, 0.3f).OnStart(() => onPlayerDeadStart()).OnComplete(() => onPlayerDeadEnd());
            Player.instence.gameObject.SetActive(true);

            if (Player.instence.gameObject.transform.position.x >= spawnPoint.x && Player.instence.gameObject.transform.position.x <= spawnPoint.x + 1)
            {

            }
        }
    }
    void onPlayerDeadStart()
    {
        Player.instence.movement.canMove = false;
        Player.instence.GetComponent<Collider2D>().enabled = false;
        Player.instence.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player.instence.GetComponent<Rigidbody2D>().simulated = false;
    }
    void onPlayerDeadEnd()
    {
        Player.instence.movement.canMove = true;
        Player.instence.GetComponent<Collider2D>().enabled = true;
        Player.instence.GetComponent<Rigidbody2D>().simulated = true;
    }

    public void ChangeWorld()
    {
        // Animation
        if (NormalWorld.active)
        {
            Player.instence.TransferToAnother.ZoomOutEffect();///add by Haru
            InsideWorld.SetActive(true);
            NormalWorld.SetActive(false);
            StartCoroutine(counter(changeDuration));
        }
    }

    IEnumerator counter(float d)
    {
        yield return new WaitForSecondsRealtime(d);
        InsideWorld.SetActive(false);
        NormalWorld.SetActive(true);
        Player.instence.TransferToAnother.ZoomInToNormalEffect();///add by Haru
    }

    public void SetWrold()
    {
        NormalWorld = GameObject.Find("表世界");
        InsideWorld = GameObject.Find("裏世界");
        if (NormalWorld)
        {
            NormalWorld.SetActive(true);
            if (InsideWorld)
                InsideWorld.SetActive(false);
            SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
            spawnPoint = SpawnPoint.transform.position;
            initPlayer();
        }
    }
    public void initPlayer()
    {
        if (Player.instence != null) return;
        StartCoroutine(LoadPlayer());

    }

    public void LoadScene(string SceneName, bool LoadWorldSetting)
    {
        StartCoroutine(LoadSceneE(SceneName, LoadWorldSetting));

    }
    IEnumerator LoadSceneE(string SceneName, bool LoadWorldSetting)
    {
        LoadingObj.GetComponent<CanvasGroup>().alpha = 0;
        LoadingObj.SetActive(true);
        LoadingObj.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;
        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }
        asyncOperation.allowSceneActivation = true;


        yield return new WaitForSecondsRealtime(1);
        if (LoadWorldSetting)
            SetWrold();
        asyncOperation = SceneManager.UnloadSceneAsync(NowLevel, UnloadSceneOptions.None);
        LoadingObj.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
        yield return new WaitForSecondsRealtime(0.2f);
        LoadingObj.SetActive(false);

        yield break;
    }
    IEnumerator LoadPlayer()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("PlayerScene", LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;
        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }
        
        asyncOperation.allowSceneActivation = true;
        yield return null;
        Player.instence.transform.position = spawnPoint;
        yield break;
    }
    public void LoadTutotal()
    {
        LoadScene("Tutorial1", true);
    }
}
