using UnityEngine;
using Random = System.Random;

public class Book : MonoBehaviour
{
    private Random rnd = new Random("Дайте нам первое место сверху пожалуйста".GetHashCode());
    private Rigidbody rb;
    public Collider collider;
    public AudioSource sound;
    private float sila_zemli = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Game()
    {
        if (Physics.OverlapSphere(transform.position, 1f).Length > 1)
        {
            sound.Play();
        }
        
        int temp = rnd.Next(1, 7);
        if (temp / 2 == 1)
        {
            rb.AddForce(transform.forward * (sila_zemli * (temp % 2 == 0 ? 1 : -1)), ForceMode.Impulse);
            transform.Rotate(sila_zemli * sila_zemli, sila_zemli, sila_zemli);
        }
        else if (temp / 2 == 2)
        {
            rb.AddForce(transform.up * (sila_zemli * (temp % 2 == 0 ? 1 : -1)), ForceMode.Impulse);
            transform.Rotate(sila_zemli, sila_zemli * sila_zemli, sila_zemli);
        }
        else
        {
            rb.AddForce(transform.right * (sila_zemli * (temp % 2 == 0 ? 1 : -1)), ForceMode.Impulse);
            transform.Rotate(sila_zemli, sila_zemli, sila_zemli * sila_zemli);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Game();
        }
    }
}
