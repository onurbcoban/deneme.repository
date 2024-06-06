using UnityEngine;

public class CandleController : MonoBehaviour
{
    public CandleChecker[] candles; 
    public GameObject door; 

    private bool isOpen = false;

    void Update()
    {

        if (!isOpen && CheckAllCandles())
        {
            OpenDoor();
        }
    }

    bool CheckAllCandles()
    {
        foreach (CandleChecker candle in candles)
        {
            if (!candle.GetIsCorrect())
            {
                return false;
            }
        }
        return true;
    }

    void OpenDoor()
    {
        isOpen = true;
        Debug.Log("Kapı acildi");

        
            door.SetActive(true);

    }


}


