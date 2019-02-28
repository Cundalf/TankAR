using UnityEngine;
using UnityEngine.UI;

public class ShotController : MonoBehaviour
{
    public GameObject ProgressBarGO;
    public Game gameScript;
    public int iMinPower = 5;
    public int iMaxPower = 10;
    public int iSeconds = 2;

    private Image pbImage;
    private bool bTouchScreen;
    private bool bCounting;
    private float fTimer;
    private float fPower;

    void Start()
    {
        pbImage = ProgressBarGO.transform.Find("Image").gameObject.GetComponent<Image>();
    }

    void Update()
    {
        updateTouchState();

        if (bTouchScreen)
        {
            if(bCounting)
            {
                ProgressBarGO.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y + 150f);
                pbImage.fillAmount = ((fTimer * 100) / iSeconds) / 100;

                // 33=33% de 360 = 120 aprox.
                pbImage.color = Color.HSVToRGB((33 - (33 * pbImage.fillAmount)) / 100, 1, 1);

                if (fTimer < iSeconds)
                {
                    fTimer += Time.deltaTime;
                }
            }
            else
            {
                ProgressBarGO.SetActive(true);
                bCounting = true;
                fTimer = 0;
            }
            
        }
        else
        {
            if(bCounting)
            {
                ProgressBarGO.SetActive(false);
                fPower = (((iMaxPower - iMinPower) * pbImage.fillAmount) + iMinPower) / 10;
                gameScript.activeTank.GetComponent<TankController>().Fire(fPower);
                bCounting = false;
            }
        }
    }

    private void updateTouchState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > 150f && Input.mousePosition.y > 200f)
            {
                bTouchScreen = true;
            }
            else
            {
                bTouchScreen = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            bTouchScreen = false;
        }
    }
}