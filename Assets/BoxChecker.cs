using UnityEngine;

public class BoxChecker : MonoBehaviour
{
    public Transform correctPosition;
    private bool isCorrect = false;

    void Update()
    {
        if (Vector2.Distance(transform.position, correctPosition.position) < 0.1f)
        {
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
    }

    public bool GetIsCorrect()
    {
        return isCorrect;
    }
}
