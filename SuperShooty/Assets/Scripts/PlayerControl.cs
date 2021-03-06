using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/*
"My momma always said life is like a box of chocolates; You never know what you're gonna get."
 -Forrest Gump
*/
public class PlayerControl : MonoBehaviour
{
    [Tooltip("Use usfxr to generate this string.")]
    public string ShootingSound;
    UnityEvent m_MyEvent = new UnityEvent();
    //public Button fireButton;
    SfxrSynth synth = new SfxrSynth();
    public float Speed = 500;
    public float RotationSpeed = 10;
    public GameObject musicPlayer;
    AudioSource audioref;
    Rigidbody2D myRb;
    // Laser spawner
    [Tooltip("Object to use as bullet.")]
    public GameObject Bullet;
    public float Cooldown = 0.2f;
    float Timer = 0;
    public float BulletSpeed = 15;
    // Bullet spawn positions.
    public Vector3 Offset1 = new Vector3(0.35f, 0.4f, 0);
    public Vector3 Offset2 = new Vector3(-0.35f, 0.4f, 0);

    public float FireError = 1f;
    // Screen shake
    CameraFollow FC;
    public float FireShakeTime = 0.1f;
    public float FireShakeMagnitude = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        FC = FindObjectOfType<CameraFollow>();
        synth.parameters.SetSettingsString(ShootingSound);
        audioref = musicPlayer.GetComponent<AudioSource>();
    }

    // FixedUpdate is called 30 times/second
    void FixedUpdate()
    {
        // I say, give me the input, good sir!
        float ySpeed = Input.GetAxisRaw("Vertical") * Speed;
        float rotSpeed = Input.GetAxisRaw("Horizontal") * RotationSpeed;

        // Forces & Torque exist.
        audioref.pitch = myRb.velocity.magnitude / 12;
        myRb.AddForce(transform.up * ySpeed * Time.fixedDeltaTime);
        myRb.AddTorque(rotSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Increase timer based on time passed.
        Timer += Time.deltaTime;
        if (Timer > Cooldown && (Input.GetAxisRaw("Jump") == 1))
        {
            // Reset the timer.
            Timer = 0;
            // FIRE!!!
            Fire(Offset1);
            Fire(Offset2);
        }
    }
    // Spawns one object with offset.
    void Fire(Vector3 offset)
    {
        // Create the object with a position offset and affected by rotation.
        Vector3 spawnPos = transform.position + transform.rotation * offset;
        GameObject clone = Instantiate(Bullet, spawnPos, transform.rotation);
        // Set the speed of the clone.
        Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
        cloneRb.velocity = transform.up * BulletSpeed;
        // Pew!
        FC.TriggerShake(FireShakeTime, FireShakeMagnitude);
        synth.Play();
    }
}
