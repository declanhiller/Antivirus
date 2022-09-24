using UnityEngine;


public class Window : MonoBehaviour
{
    private WindowContent content { get; set; }


    public void Maximize()
    {
        Destroy(content.gameObject);
    }

    public void Minimize()
    {
        
    }

    public void Close()
    {
        
    }
    
}