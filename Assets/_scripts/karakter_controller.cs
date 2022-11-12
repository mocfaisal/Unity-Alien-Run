using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class karakter_controller : MonoBehaviour
{
    HalamanManager halamanManager;
    private Animator anim;
    public bool is_starGame = false;
    public bool is_jump = false;
    public bool is_GameOver = false;
    public float jumpForce = 5f;
    public int maxScore = 0;
    public int levelGame = 1;

    Rigidbody2D rb;
    GameObject player;
    public GameObject obstacleSpawner;
    GameObject panelSelesai;
    GameObject btnPanelSolo;
    GameObject btnPanelDuo;

    Text HighScoreUI;
    Text CurrScoreUI;
    int HighScoreInt;
    int CurrScoreInt;
    string indexHighscore = "highscore";

    Text txtPanelSelesai_Title;
    Text txtPanelSelesai_Subitle;
    Button btn_panelSelesai;
    Button btn_panelRetry;

    AudioSource audio;
    public AudioClip scoreSound;
    public AudioClip gameCompleteSound;
    public AudioClip gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        is_jump = false;
        anim.SetTrigger("Idle");
        player = GameObject.FindGameObjectWithTag("Player");

        // Score
        HighScoreUI = GameObject.Find("High_Score_count").GetComponent<Text>();
        CurrScoreUI = GameObject.Find("Curr_Score_count").GetComponent<Text>();

        HighScoreInt = PlayerPrefs.GetInt(indexHighscore, 0);
        CurrScoreInt = 0;


        HighScoreUI.text = HighScoreInt.ToString();
        CurrScoreUI.text = CurrScoreInt.ToString();

        audio = GetComponent<AudioSource>();

        panelSelesai = GameObject.Find("PanelSelesai");
        btnPanelSolo = GameObject.Find("btn_solo_finish");
        btnPanelDuo = GameObject.Find("btn_duo_finish");

        txtPanelSelesai_Title = GameObject.Find("title_finish").GetComponent<Text>();
        txtPanelSelesai_Subitle = GameObject.Find("subItle_finish").GetComponent<Text>();
        btn_panelSelesai = GameObject.Find("btn_next_finish").GetComponent<Button>();
        btn_panelRetry = GameObject.Find("btn_retry_finish").GetComponent<Button>();


        panelSelesai.SetActive(false);
        btnPanelSolo.SetActive(true);
        btnPanelDuo.SetActive(false);

        is_GameOver = false;

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        //// Keyboard A untuk Idle
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    anim.SetTrigger("Idle");
        //}

        //// Keyboard S untuk Walk
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    anim.SetTrigger("Walk");
        //}

        //// Keyboard D untuk Jump
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    anim.SetTrigger("Jump");
        //}

        obstacleSpawner.GetComponent<obstacle_spawner>().StartSpawning();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (is_starGame == false)
            //{
            //    is_starGame = true;

            //}

            anim.SetTrigger("Jump");

            if (!is_jump)
            {
                //Debug.Log("Lompat");
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 13, 0);
                is_jump = true;
            }

        }

        //else
        //{
        //    anim.SetTrigger("Walk");
        //}
        //if (Input.GetKey(KeyCode.Space) && is_GameOver)
        //{
        //    //SceneManager.LoadScene("SceneLevel1");
        //    Time.timeScale = 1;
        //    return;
        //}
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            is_jump = false;
            Debug.Log("ground");
            //anim.SetTrigger("Idle");
            //if (is_starGame == false)
            //{
            //    anim.SetTrigger("Idle");
            //}
            //else
            //{
            anim.SetTrigger("Walk");

            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //Application.LoadLevel("SceneLevel1");
            is_GameOver = true;
            showScorePanel(false, CurrScoreInt);
            Time.timeScale = 0;
        }

        if (collision.name == "PointObj")
        {
            // obstacle berhasil dilewati


            //anim.SetTrigger("Fall");

            //Debug.Log("Kena");
            //    Destroy(gameObject);
            AddPoint();
            showScorePanel(true, CurrScoreInt);
            //    //Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), PointObstacle.GetComponent<Collider2D>());
        }
    }

    public void AddPoint()
    {
        CurrScoreInt += 1;
        CurrScoreUI.text = CurrScoreInt + "";
        audio.PlayOneShot(scoreSound);
        Debug.Log(CurrScoreInt + "");
        if (HighScoreInt <= CurrScoreInt)
        {
            PlayerPrefs.SetInt(indexHighscore, CurrScoreInt);
        }

    }

    void showScorePanel(bool isFinish = false, int LastScore = 0)
    {

        string txtTItle = "";
        string txtSubtitle = "";

        if (isFinish)
        {
            if (LastScore == maxScore)
            {
                panelSelesai.SetActive(true);

                btnPanelSolo.SetActive(true);
                btnPanelDuo.SetActive(false);

                // Game Finish
                txtTItle = "Permainan Selesai";
                txtSubtitle = "Level " + levelGame + " Complete";
                txtPanelSelesai_Subitle.text = txtSubtitle;
                txtPanelSelesai_Title.text = txtTItle;
                audio.PlayOneShot(gameCompleteSound);
                Time.timeScale = 0;

            }
        }
        else
        {
            // Game Over
            panelSelesai.SetActive(true);

            btnPanelSolo.SetActive(false);
            btnPanelDuo.SetActive(true);

            txtTItle = "Game Over";
            txtSubtitle = "Level " + levelGame + " Failed!";

            txtPanelSelesai_Subitle.text = txtSubtitle;
            txtPanelSelesai_Title.text = txtTItle;
            audio.PlayOneShot(gameOverSound);

            Time.timeScale = 0;
        }

        return;
    }

}
