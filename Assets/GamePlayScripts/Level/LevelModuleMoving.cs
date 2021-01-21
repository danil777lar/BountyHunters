using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelModuleMoving : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text speedWidget;

    public bool isMoving = true;
    public float speed;
    public float oldSpeed;
    public int generateChance;
    public int minSpace;

    public int level = 1;

    private int[] moduleId = new int[2];
    private GameObject[] modules = new GameObject[2];
    private Rigidbody2D[] rb = new Rigidbody2D[2];
    private BackGroundMove background;

    public bool isMotionStoped = false;
    private  bool isEndingScene = false;
    private bool isCatched = false;
    public bool isGameOver = false;
    private bool win;

    
    void Start()
    {
        background = GetComponentInChildren<BackGroundMove>();
        moduleId[0] = 0;
        moduleId[1] = 0;

        modules[0] = Instantiate(Resources.Load<GameObject>("Prefabs/Map/"+moduleId[0]+"/LevelModule"));
        modules[0].transform.parent = transform;
        modules[0].transform.position = new Vector3(28f, -11f, 0f);
        rb[0] = modules[0].GetComponent<Rigidbody2D>();
        modules[0].GetComponent<LevelModule>().Generate(moduleId[0], generateChance, minSpace, true);

       MakeNextModule();
       Invoke("UpLevel", 15f);
    }

    void UpLevel(){
        if (isMoving){
            level++;
            speed ++;
            Invoke("UpLevel", 15f);
        }
    }

    
    void Update()
    {
        background.speed = speed * .1f;
        rb[0].velocity = new Vector2(speed*-1, 0);
        rb[1].velocity = new Vector2(speed*-1, 0); 
        
        if(modules[1].transform.position.x <= 18){
            if (isEndingScene) EndingScene();
            else {
                Destroy(modules[0]);
                modules[0] = modules[1];
                moduleId[0] = moduleId[1];
                rb[0] = rb[1];

                moduleId[1] = 0;
                MakeNextModule();
            } 
        }

        if (!isGameOver) speedWidget.text = ""+speed+Assets.SimpleLocalization.LocalizationManager.Localize("Global.Speed");
    }

    private void EndingScene(){
        if (!isGameOver){
            isMotionStoped = true;
            StopMotion();
            Invoke("GameOverInvoke", 1f);
        }
    }
    
    private void MakeNextModule(){
        modules[1] = Instantiate(Resources.Load<GameObject>("Prefabs/Map/"+moduleId[1]+"/LevelModule"));
        if (!isCatched) modules[1].GetComponent<LevelModule>().Generate(moduleId[1], generateChance, minSpace, false);
        else{
            modules[1].GetComponent<LevelModule>().Generate();
            isEndingScene = true;
        }
        modules[1].transform.parent = transform;
        float[] sides = GetSides();
        modules[1].transform.position = new Vector3(sides[1]+(sides[3]-sides[2])/2, -11f, 0f);
        rb[1] = modules[1].GetComponent<Rigidbody2D>();
    }

    private float[] GetSides(){
        float[] sides = new float[4];
        sides[0] = modules[0].GetComponent<LevelModule>().LeftSide.position.x;
        sides[1] = modules[0].GetComponent<LevelModule>().RightSide.position.x;
        sides[2] = modules[1].GetComponent<LevelModule>().LeftSide.position.x;
        sides[3] = modules[1].GetComponent<LevelModule>().RightSide.position.x;
        return sides;
    }

    public void GameOver(bool win){
        if (!isGameOver){
            this.win = win;
            if (win) isCatched = true;
            else{
                StopMotion();
                Invoke("GameOverInvoke", 1f);
            }
        }
    }

    private void StopMotion(){
        oldSpeed = speed;
        speed = 0f;
        isMoving = false;
        isGameOver = true;
    }

    private void GameOverInvoke(){
        gameOverPanel.SetActive(true);
        if (LevelConstructor.isFreeMode || win) gameOverPanel.GetComponent<GameOverMenu>().GameWin();
        else if (!win) gameOverPanel.GetComponent<GameOverMenu>().GameLose();
    }
}