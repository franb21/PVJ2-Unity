using UnityEngine;
public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public AudioSource gameMusic;
    public AudioSource selectMejora;
    public AudioSource selectStat;
    public AudioSource zonaElectricaDamage;
    public AudioSource pinchosDamage;
    public AudioSource damageEnemigo;
    public AudioSource misil;
    public AudioSource pinchos;
    public AudioSource pistola;
    public AudioSource gameOver;
    public AudioSource win;
    public AudioSource playerDamage;
    public AudioSource enemigoDisparo;
    public AudioSource bossShoot;
    public AudioSource bossInvocacion;
    public AudioSource bossEmbestida;
    public AudioSource bossDisparo;
    public AudioSource levelUp;
    public AudioSource button;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(AudioSource sound)
    {
        sound.Stop();
        sound.Play();
    }
}
