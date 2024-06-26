using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class game : MonoBehaviour
{

    public GameObject leftArrow;
    public GameObject downArrow;
    public GameObject upArrow;
    public GameObject rightArrow;
    public GameObject miss;
    public GameObject perfect;
    public GameObject good;

    public bool gameOver = false;
    public double health = 100;
    public double score = 0;
    public List<GameObject> lefts = new List<GameObject>();
    public List<string> leftHits = new List<string>();
    public List<GameObject> downs = new List<GameObject>();
    public List<string> downHits = new List<string>();
    public List<GameObject> ups = new List<GameObject>();
    public List<string> upHits = new List<string>();
    public List<GameObject> rights = new List<GameObject>();
    public List<string> rightHits = new List<string>();
    public ScreenFlash screenFlash;
    // public endScript endscript;

    // score images
    public Image scoreImage;
    public static Sprite score0;
    public static Sprite score10;
    public static Sprite score20;
    public static Sprite score30;
    public static Sprite score40;
    public static Sprite score50;
    public static Sprite score60;
    public static Sprite score70;
    public static Sprite score80;
    public static Sprite score90;
    public static Sprite score100;

    // add to list
    public List<Sprite> scoreSprites = new List<Sprite> { score0, score10, score20, score30, score40, score50, score60, score70, score80, score90, score100 };

    // health images
    public Image healthImage;
    public static Sprite health0;
    public static Sprite health10;
    public static Sprite health20;
    public static Sprite health30;
    public static Sprite health40;
    public static Sprite health50;
    public static Sprite health60;
    public static Sprite health70;
    public static Sprite health80;
    public static Sprite health90;
    public static Sprite health100;

    // add to list
    public List<Sprite> healthSprites = new List<Sprite> { health0, health10, health20, health30, health40, health50, health60, health70, health80, health90, health100 };

    // indexes
    int scoreIndex = 0;
    int healthIndex = 0;

    public int missCount = 0;
    public int goodCount = 0;
    public int perfectCount = 0;
    public EndScript endscript;

    // Start is called before the first frame update    
    void Start()
    {
        if (endscript == null) Debug.LogError("endscript is null");

        // BUM BUM BUM BUM
        addUp(3.36f - (3.36f - (-14.5f) / 5f * 7f) + 2f);
        addRight(3.36f - (3.36f - (-15.2f) / 5f * 7f) + 2f);
        addUp(3.36f - (3.36f - (-16f) / 5f * 7f) + 2f);
        addRight(3.36f - (3.36f - (-16.8f) / 5f * 7f) + 2f);

        // baDaDaDa
        addRight(3.36f - (3.36f - (-27.5f) / 5f * 7f) - 3f);
        addLeft(3.36f - (3.36f - (-28f) / 5f * 7f) - 3f);
        addRight(3.36f - (3.36f - (-28.5f) / 5f * 7f) - 3f);
        addLeft(3.36f - (3.36f - (-29f) / 5f * 7f) - 3f);

        // badadada
        // badadada!!
        addLeft(3.36f - (3.36f - (-34.5f) / 5f * 7f) - 1f);
        addDown(3.36f - (3.36f - (-35f) / 5f * 7f) - 1f);
        addUp(3.36f - (3.36f - (-35.5f) / 5f * 7f) - 1f);
        addRight(3.36f - (3.36f - (-36f) / 5f * 7f) - 1f);

        // baDaDaDa
        addLeft(3.36f - (3.36f - (-41.5f) / 5f * 7f) - 1f);
        addRight(3.36f - (3.36f - (-42f) / 5f * 7f) - 1f);
        addLeft(3.36f - (3.36f - (-42.5f) / 5f * 7f) - 1f);
        addRight(3.36f - (3.36f - (-43f) / 5f * 7f) - 1f);

        // badadada
        // badadada!!
        addLeft(-64.5f - 1f);
        addDown(-65.2f - 1f);
        addUp(-65.9f - 1f);
        addRight(-66.6f - 1f);

        // dadadodum
        addUp(-71.5f - 1f);
        addRight(-72.2f - 1f);
        addUp(-72.9f - 1f);
        addRight(-73.6f - 1f);

        // TOOD: tune
        // adadadodumm
        addLeft(-78.5f);
        addUp(-79.2f);
        addLeft(-79.9f);
        addUp(-80.6f);
        addLeft(-81.3f);

        // adadadodummm
        addRight(-85.4f);
        addDown(-86.1f);
        addRight(-86.8f);
        addDown(-87.5f);
        addRight(-88.2f);

        // DA
        addLeft(-95.9f);

        // DUMMMM
        addRight(-100.5f);

        // badadadumm
        addLeft(-111.5f - 4f);
        addUp(-112.2f - 4f);
        addLeft(-112.9f - 4f);
        addUp(-113.6f - 4f);

        addDown(-125f - 15f);
        addDown(-126f - 15f);
        addDown(-127f - 15f);
        addRight(-128f - 15f);

        addUp(-140f - 15f);
        addUp(-141f - 15f);
        addUp(-142f - 15f);
        addLeft(-143f - 15f);

        addDown(-157f - 15f);
        addDown(-158f - 15f);
        addDown(-159f - 15f);
        addUp(-161f - 15f);
        addRight(-162f - 15f);

        addUp(-180f);
        addUp(-181f);
        addUp(-182f);
        addDown(-183f);
        addLeft(-184f);

        addUp(-190f);
        addRight(-190f);

        addLeft(-194.5f);
        addDown(-194.5f);

        addLeft(-199f);
        addRight(-199f);

        addUp(-203.5f);
        addDown(-203.5f);

        // addUp(-200.8f);
        // addRight(-200.8f);

        // addLeft(-203.5f);
        // addDown(-203.5f);

        addLeft(-208f);
        addRight(-208f);

        addUp(-212.5f);
        addDown(-212.5f);


        // addLeft(-202.4f);
        // addRight(-203.4f);
        // addLeft(-204.4f);
        // addRight(-205.4f);
        // addLeft(-206.4f);

        addLeft(-214f - 2f);
        addDown(-215f - 2f);

        addRight(-218 - 2f);
        addUp(-219f - 2f);

        addLeft(-222f - 2f);
        addDown(-223f - 2f);

        addRight(-226f - 2f);
        addUp(-227f - 2f);


        addLeft(-234);
        addDown(-235.5f);
        addUp(-237f);
        addRight(-238.5f);

        addLeft(-241);
        addDown(-242.5f);
        addUp(-244f);
        addRight(-245.5f);


        addLeft(-251f);
        addDown(-252f);

        addRight(-254f);
        addUp(-255f);

        addLeft(-257f);
        addDown(-258f);

        addRight(-260f);
        addUp(-261f);

        addUp(-265f);

        addLeft(-274);
        addDown(-274f);
        addUp(-274f);
        addRight(-274f);

        endSuccess();
    }

    private async void endSuccess()
    {
        StartCoroutine(EndSuccessCoroutine());
    }
    private async void endFail()
    {
        EndFailCoroutine();
    }


    private IEnumerator EndSuccessCoroutine()
    {
        yield return new WaitForSeconds(42);
        PlayerPrefs.SetInt("Score", (int)score);
        //PlayerPrefs.SetInt("Perfect", (int)perfectCount);
        //endscript.setEndScore((int)score);
        SceneManager.LoadScene("endSuccess");
    }
    private IEnumerator EndFailCoroutine()
    {
        yield return new WaitForSeconds(42);
        PlayerPrefs.SetInt("Score", (int)score);
        //endscript.setEndScore((int)score);
        SceneManager.LoadScene("endFail");
    }
    

    private async void displayPerfect()
    {
        SpriteRenderer pv = perfect.GetComponent<SpriteRenderer>();
        pv.enabled = true;
        SpriteRenderer gv = good.GetComponent<SpriteRenderer>();
        gv.enabled = false;
        SpriteRenderer mv = miss.GetComponent<SpriteRenderer>();
        mv.enabled = false;
        await Task.Delay(1000);
        pv = perfect.GetComponent<SpriteRenderer>();
        pv.enabled = false;
    }
    private async void displayGood()
    {
        SpriteRenderer pv = perfect.GetComponent<SpriteRenderer>();
        pv.enabled = false;
        SpriteRenderer gv = good.GetComponent<SpriteRenderer>();
        gv.enabled = true;
        SpriteRenderer mv = miss.GetComponent<SpriteRenderer>();
        mv.enabled = false;
        await Task.Delay(1000);
        gv = good.GetComponent<SpriteRenderer>();
        gv.enabled = false;
    }
    private async void displayMiss()
    {
        SpriteRenderer pv = perfect.GetComponent<SpriteRenderer>();
        pv.enabled = false;
        SpriteRenderer gv = good.GetComponent<SpriteRenderer>();
        gv.enabled = false;
        SpriteRenderer mv = miss.GetComponent<SpriteRenderer>();
        mv.enabled = true;
        await Task.Delay(1000);
        mv = miss.GetComponent<SpriteRenderer>();
        mv.enabled = false;
    }

    void ifPerfect()
    {
        // changed this for testing purposes for now
        changeScore(1.25);
        changeHealth(1.25);
        perfectCount++;
        Debug.Log("Perfect");
        displayPerfect();
    }

    void ifGood()
    {
        changeScore(0.5);
        goodCount++;
        Debug.Log("Good");
        displayGood();
    }

    void ifMiss()
    {
        changeHealth(-5);
        missCount++;
        Debug.Log("Missed");
        displayMiss();
    }

    void changeHealth(double points)
    {
        int changes = 0;
        Debug.Log("in changeHealth");
        double pastHealth = health;
        if (100 - health < points)
        {
            health = 100;
        }
        else if (health < points)
        {
            health = 0;
        }
        else
        {
            health += points;
        }
        Debug.Log("past health: " + pastHealth);
        Debug.Log("new health: " + health);
        changes = (Convert.ToInt32(pastHealth / 10)) - (Convert.ToInt32(health / 10));
        for (int i = 0; i < Mathf.Abs(changes); i++)
        {
            if (changes < 0)
            {
                healthIndex--;
                // if (healthIndex < 10) healthIndex = 0;
            }
            else
            {
                healthIndex++;
                // if (healthIndex > 10) healthIndex = 10;
            }
            healthImage.GetComponent<Image>().sprite = healthSprites[healthIndex];
            Debug.Log("new health index: " + healthIndex);
        }
    }

    void changeScore(double points)
    {
        Debug.Log("in changeScore");
        double pastScore = score; // 0
        if (100 - score < points)
        {
            score = 100;
        }
        else
        {
            score += points; // 15
        }
        int changes = (Convert.ToInt32(score / 10)) - (Convert.ToInt32(pastScore / 10)); // 1 - 0 == 1
        Debug.Log("past score: " + pastScore);
        Debug.Log("new score: " + score);
        for (int i = 0; i < changes; i++)
        {
            scoreIndex++;
            Debug.Log("new scoreIndex: " + scoreIndex);
            scoreImage.GetComponent<Image>().sprite = scoreSprites[scoreIndex];

        }
    }

    void addLeft(float y)
    {
        GameObject newLeft = Instantiate(leftArrow, new Vector3(-3.04f, y, 0f), Quaternion.identity);
        lefts.Add(newLeft);
    }

    void addDown(float y)
    {
        GameObject newDown = Instantiate(downArrow, new Vector3(-0.88f, y, 0f), Quaternion.identity);
        downs.Add(newDown);
    }

    void addUp(float y)
    {
        GameObject newUp = Instantiate(upArrow, new Vector3(1.05f, y, 0f), Quaternion.identity);
        ups.Add(newUp);
    }

    void addRight(float y)
    {
        GameObject newRight = Instantiate(rightArrow, new Vector3(3.18f, y, 0), Quaternion.identity);
        rights.Add(newRight);
    }

    void addMiss()
    {
        GameObject newMiss = Instantiate(miss, new Vector3(10.0f, 20.0f, 0), Quaternion.identity);
    }
    void addPerfect()
    {
        GameObject newPerfect = Instantiate(perfect, new Vector3(10.0f, 20.0f, 0), Quaternion.identity);
    }
    void addGood()
    {
        GameObject newGood = Instantiate(good, new Vector3(10.0f, 20.0f, 0), Quaternion.identity);
    }

    void CheckMissedArrows(List<GameObject> arrows, List<string> hits)
    {   
        for (int i = 0; i < arrows.Count; i++)
        {
            if (arrows[i] != null)
            {
                if (arrows[i].transform.position.y > 5.5f)
                {
                    hits.Add("missed");
                    ifMiss();
                    Destroy(arrows[i]);
                    arrows[i] = null;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (health <= 0)
        // {
        //     endFail();
        // }

        CheckMissedArrows(lefts, leftHits);
        CheckMissedArrows(downs, downHits);
        CheckMissedArrows(ups, upHits);
        CheckMissedArrows(rights, rightHits);

        GameObject targetArrowLeft = null;
        int targetArrowIndexLeft = -1;
        GameObject targetArrowRight = null;
        int targetArrowIndexRight = -1;
        GameObject targetArrowDown = null;
        int targetArrowIndexDown = -1;
        GameObject targetArrowUp = null;
        int targetArrowIndexUp = -1;


        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("left arrow pressed");

            // GameObject targetArrow = null;
            // int targetArrowIndex = -1;
            for (int i = 0; i < lefts.Count; i++)
            {

                if (lefts[i] != null)
                {
                    float arrowY = lefts[i].transform.position.y;
                    // if the arrow is in the valid hit area
                    if (arrowY > 2.8f && arrowY < 5.0f)
                    {
                        // if there's no current target arrow to compare it to make it the target arrow
                        if (targetArrowLeft == null)
                        {
                            targetArrowLeft = lefts[i];
                            targetArrowIndexLeft = i;
                        }
                        else
                        {
                            // if this arrow is closer than target arrow make this target arrow
                            if (Mathf.Abs(arrowY - 3.36f) < Mathf.Abs(targetArrowLeft.transform.position.y - 3.36f))
                            {
                                targetArrowLeft = lefts[i];
                                targetArrowIndexLeft = i;
                            }
                        }
                    }
                }
            }
            // so now we have our lil target arrow

            // for (int i = 0; i < lefts.Count; i++)
            // {
            //     if (lefts[i] != null)
            //     {
            //         if (lefts[i].transform.position.y > 55f && i > targetArrowIndexLeft)
            //         {
            //             leftHits.Add("miss");
            //             Debug.Log("added miss");
            //             ifMiss();
            //             Destroy(lefts[i]);
            //             lefts[i] = null;
            //         }
            //     }
            // }

            if (targetArrowLeft != null)
            {
                // if they missed any arrows
                // if (leftHits.Count + 1 < targetArrowIndexLeft)
                // {
                //     Debug.Log("in if for miss");
                //     for (int i = leftHits.Count + 1; i < targetArrowIndexLeft; i++)
                //     {
                //         leftHits.Add("missed");
                //         ifMiss();
                //         Debug.Log(leftHits[leftHits.Count-1]);
                //         //addMiss();
                //     }
                // }

                float targetArrowY = targetArrowLeft.transform.position.y;

                // perfect!
                if (Mathf.Abs(targetArrowY - 3.36f) < 0.40f)
                {
                    // screenFlash.Flash();
                    leftHits.Add("perfect");
                    Destroy(targetArrowLeft);
                    // screenFlash.Flash();
                    ifPerfect();
                    //addPerfect();
                }

                // good!
                else if (Mathf.Abs(targetArrowY - 3.36f) < 0.80f)
                {
                    // screenFlash.Flash();
                    leftHits.Add("good");
                    Destroy(targetArrowLeft);
                    // screenFlash.Flash();
                    ifGood();
                    // screenFlash.Flash();
                    //addGood();
                }

                lefts[targetArrowIndexLeft] = null;
            }

            // if (Conductor.Instance.CheckHit(ArrowType.UPARROW) == true) {
            //     Debug.Log("up arrow hit!!");
            //     screenFlash.Flash();

            //     score += 10;
            // }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("down arrow pressed");

            // GameObject targetArrow = null;
            // int  targetArrowIndex = -1;
            for (int i = 0; i < downs.Count; i++)
            {

                if (downs[i] != null)
                {
                    float arrowY = downs[i].transform.position.y;
                    // if the arrow is in the valid hit area
                    if (arrowY > 2.8f && arrowY < 5.0f)
                    {
                        // if there's no current target arrow to compare it to make it the target arrow
                        if (targetArrowDown == null)
                        {
                            targetArrowDown = downs[i];
                            targetArrowIndexDown = i;
                        }
                        else
                        {
                            // if this arrow is closer than target arrow make this target arrow
                            if (Mathf.Abs(arrowY - 3.36f) < Mathf.Abs(targetArrowDown.transform.position.y - 3.36f))
                            {
                                targetArrowDown = downs[i];
                                targetArrowIndexDown = i;
                            }
                        }
                    }
                }
            }
            // so now we have our lil target arrow

            if (targetArrowDown != null)
            {
                // if they missed any arrows
                // if (downHits.Count + 1 < targetArrowIndexDown)
                // {
                //     for (int i = downHits.Count + 1; i < targetArrowIndexDown; i++)
                //     {
                //         downHits.Add("missed");
                //         ifMiss();
                //         //addMiss();
                //     }
                // }

                float targetArrowY = targetArrowDown.transform.position.y;

                // perfect!
                if (Mathf.Abs(targetArrowY - 3.36f) < 0.40f)
                {
                    downHits.Add("perfect");
                    Destroy(targetArrowDown);
                    // screenFlash.Flash();
                    ifPerfect();
                    //addPerfect();
                }

                // good!
                else if (Mathf.Abs(targetArrowY - 3.36f) < 0.80f)
                {
                    downHits.Add("good");
                    Destroy(targetArrowDown);
                    // screenFlash.Flash();
                    ifGood();
                    // screenFlash.Flash();
                    //addGood();
                }

                downs[targetArrowIndexDown] = null;
            }

            // if (Conductor.Instance.CheckHit(ArrowType.UPARROW) == true) {
            //     Debug.Log("up arrow hit!!");
            //     screenFlash.Flash();

            //     score += 10;
            // }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("up arrow pressed");

            // GameObject targetArrow = null;
            // int  targetArrowIndex = -1;
            for (int i = 0; i < ups.Count; i++)
            {

                if (ups[i] != null)
                {
                    float arrowY = ups[i].transform.position.y;
                    // if the arrow is in the valid hit area
                    if (arrowY > 2.8f && arrowY < 5.0f)
                    {
                        // if there's no current target arrow to compare it to make it the target arrow
                        if (targetArrowUp == null)
                        {
                            targetArrowUp = ups[i];
                            targetArrowIndexUp = i;
                        }
                        else
                        {
                            // if this arrow is closer than target arrow make this target arrow
                            if (Mathf.Abs(arrowY - 3.36f) < Mathf.Abs(targetArrowUp.transform.position.y - 3.36f))
                            {
                                targetArrowUp = ups[i];
                                targetArrowIndexUp = i;
                            }
                        }
                    }
                }
            }
            // so now we have our lil target arrow

            if (targetArrowUp != null)
            {
                // if they missed any arrows
                // if (upHits.Count + 1 < targetArrowIndexUp)
                // {
                //     for (int i = upHits.Count + 1; i < targetArrowIndexUp; i++)
                //     {
                //         upHits.Add("missed");
                //         ifMiss();
                //         //addMiss();
                //     }
                // }

                float targetArrowY = targetArrowUp.transform.position.y;

                // perfect!
                if (Mathf.Abs(targetArrowY - 3.36f) < 0.40f)
                {
                    upHits.Add("perfect");
                    Destroy(targetArrowUp);
                    // screenFlash.Flash();
                    ifPerfect();
                    //addPerfect();
                }

                // good!
                else if (Mathf.Abs(targetArrowY - 3.36f) < 0.80f)
                {
                    upHits.Add("good");
                    Destroy(targetArrowUp);
                    // screenFlash.Flash();
                    ifGood();
                    // screenFlash.Flash();
                    //addGood();
                }

                ups[targetArrowIndexUp] = null;
            }

            // if (Conductor.Instance.CheckHit(ArrowType.UPARROW) == true) {
            //     Debug.Log("up arrow hit!!");
            //     screenFlash.Flash();

            //     score += 10;
            // }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("right arrow pressed");

            // GameObject targetArrow = null;
            // int targetArrowIndex = -1;
            for (int i = 0; i < rights.Count; i++)
            {

                if (rights[i] != null)
                {
                    float arrowY = rights[i].transform.position.y;
                    // if the arrow is in the valid hit area
                    if (arrowY > 2.8f && arrowY < 5.0f)
                    {
                        // if there's no current target arrow to compare it to make it the target arrow
                        if (targetArrowRight == null)
                        {
                            targetArrowRight = rights[i];
                            targetArrowIndexRight = i;
                        }
                        else
                        {
                            // if this arrow is closer than target arrow make this target arrow
                            if (Mathf.Abs(arrowY - 3.36f) < Mathf.Abs(targetArrowRight.transform.position.y - 3.36f))
                            {
                                targetArrowRight = rights[i];
                                targetArrowIndexRight = i;
                            }
                        }
                    }
                }
            }
            // so now we have our lil target arrow

            if (targetArrowRight != null)
            {
                // if they missed any arrows
                // if (rightHits.Count + 1 < targetArrowIndexRight)
                // {
                //     for (int i = rightHits.Count + 1; i < targetArrowIndexRight; i++)
                //     {
                //         rightHits.Add("missed");
                //         ifMiss();
                //         //addMiss();
                //     }
                // }

                float targetArrowY = targetArrowRight.transform.position.y;

                // perfect!
                if (Mathf.Abs(targetArrowY - 3.36f) < 0.40f)
                {
                    rightHits.Add("perfect");
                    Destroy(targetArrowRight);
                    // screenFlash.Flash();
                    ifPerfect();
                    //addPerfect();
                }

                // good!
                else if (Mathf.Abs(targetArrowY - 3.36f) < 0.80f)
                {
                    rightHits.Add("good");
                    Destroy(targetArrowRight);
                    // screenFlash.Flash();
                    ifGood();
                    // screenFlash.Flash();
                    //addGood();
                }

                rights[targetArrowIndexRight] = null;
            }

            // if (Conductor.Instance.CheckHit(ArrowType.UPARROW) == true) {
            //     Debug.Log("up arrow hit!!");
            //     screenFlash.Flash();

            //     score += 10;
            // }
        }

    }
}
