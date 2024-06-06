using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float hareketHizi = 1.75f;
    public Transform holdPoint;

    public float tasimaHizi = 1f; 

    //public Text keyCollectedText;

    public int toplananAnahtarSayisi = 0;

    private Rigidbody2D rb;
    private Vector2 hareket;
    private GameObject nesneTut = null;
    private Rigidbody2D nesneTutRb = null;

    private bool mesaleTasiyor = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hareket.x = Input.GetAxis("Horizontal");
        hareket.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E tusuna basildi");
            if (nesneTut == null)
            {
                TryPickup();
            }
            else
            {
                DropObject();
            }
        }

        if (mesaleTasiyor && Input.GetKeyDown(KeyCode.F))
    {
        TryLightCandle();
    }
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + hareket * hareketHizi * Time.fixedDeltaTime);

        if (nesneTut != null)
        {
            nesneTut.transform.position = holdPoint.position;
        }
    }

    void TryPickup()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Box"))
            {
                nesneTut = collider.gameObject;
                nesneTutRb = nesneTut.GetComponent<Rigidbody2D>();
                nesneTutRb.isKinematic = true;
                nesneTutRb.velocity = Vector2.zero;
                nesneTutRb.angularVelocity = 0f;
                nesneTut.transform.position = holdPoint.position;
                hareketHizi = tasimaHizi;
                break;
            }
            else if (collider.CompareTag("Torch"))
            {
                nesneTut = collider.gameObject;
            nesneTutRb = nesneTut.GetComponent<Rigidbody2D>();
            nesneTutRb.isKinematic = true;
            nesneTutRb.velocity = Vector2.zero;
            nesneTutRb.angularVelocity = 0f;
            nesneTut.transform.position = holdPoint.position;
            hareketHizi = tasimaHizi;
            mesaleTasiyor = true;
            break;
            }
        }
    }

    void DropObject()
    {
        if (nesneTut != null)
        {
            nesneTut.GetComponent<Rigidbody2D>().isKinematic = false;
            nesneTut = null;
            hareketHizi = 1.75f;
            mesaleTasiyor = false;
        }
    }

    void TryLightCandle()
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
    foreach (Collider2D collider in colliders)
    {
        if (collider.CompareTag("Candle"))
        {
            Candle candle = collider.GetComponent<Candle>();
            if (candle != null && !candle.isLit)
            {
                candle.LightCandle();
                break;
            }
        }
    }
}
    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Torch"))
    {
        TakeTorch(other.gameObject);
    }
}


void TakeTorch(GameObject torchObject)
{

    torchObject.SetActive(false);

 
    //ShowKeyCollectedUI();
}
/*void ShowKeyCollectedUI()
{

    toplananAnahtarSayisi++;
    keyCollectedText.text = "Toplanan Anahtar: " + toplananAnahtarSayisi.ToString();
}*/

}
