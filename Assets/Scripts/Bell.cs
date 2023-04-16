using UnityEngine;

public class Bell : MonoBehaviour
{

    [SerializeField] private AudioClip bellSound;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (bellSound != null)
        {
            AudioSource.PlayClipAtPoint(bellSound, transform.position);
        }
    }
}
