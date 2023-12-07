using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadEmoji : MonoBehaviour {

    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public float releaseTime = .15f;
    public float maxDragDistance = 2f;

    public GameObject nextRedEmoji;
    
    private bool isPressed = false;

    void Update()
    {
        if (isPressed)
        {
            Vector2 mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePOS,hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePOS - hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePOS; 
        }
    }
    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release ()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        if (nextRedEmoji != null)
        {
            nextRedEmoji.SetActive(true);
        }
        else
        {
            BlueEmoji.BlueEmojisAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

}