using UnityEngine;
using UnityEngine.UI;

public class Bonfire : MonoBehaviour
{
    public static float BurningLevel { get; private set; }
    public bool isBurning;
    [SerializeField] private float fadingSpeed; 
    [SerializeField] private Image burningLevelScale;
    [SerializeField] private GameObject putOnLogsBtn;

    private void Start()
    {
        BurningLevel = 1;
        isBurning = true;
    }

    private void Update()
    {
        if (BurningLevel > 0)
        {
            isBurning = true;
            BurningLevel -= fadingSpeed * Time.deltaTime;
            burningLevelScale.fillAmount = BurningLevel;
        }
        else
        {
            isBurning = false;
            Destroy(putOnLogsBtn);
            //When binfire went out
        }
    }

    public static void SetBurningLevel(float value)
    {
        if (value > 1) value = 1;
        if (value < 0) value = 0;
        BurningLevel = value;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            putOnLogsBtn.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            putOnLogsBtn.SetActive(false);
        }
    }

    public void PutOnLogs()
    {
        try
        {
            LogsHandler.ChangeLogsCount(LogsHandler.LogsCount - 1);
        }
        catch
        {
            return;
        }
        SetBurningLevel(BurningLevel + 0.2f);
    }
}
