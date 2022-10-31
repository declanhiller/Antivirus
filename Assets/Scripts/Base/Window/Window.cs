using UnityEngine;


public class Window : MonoBehaviour
{
    public WindowContent content { get; set; }

    

    public void Maximize()
    {
        
    }

    public void Minimize()
    {
        
    }

    public void Close()
    {
        Destroy(gameObject);
    }
    
}