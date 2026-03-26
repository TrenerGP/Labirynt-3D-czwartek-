using UnityEngine;

public class Lock : MonoBehaviour
{
    public Door[] doors;
    public KeyColor doorColor;
    bool canOpen;
    bool opened;
    Animator key;

    private void Start()
    {
        key = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
            Debug.Log("You can use the key");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
            Debug.Log("You can't use the key");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && !opened && CheckKey())
        {
            key.SetBool("useKey", true);
        }
    }

    public void UseKey()
    {
        foreach(Door d in doors)
        {
            d.OpenDoor();
        }
    }

    public bool CheckKey()
    {
        if (doorColor==KeyColor.Red && GameManager.instance.RedKey>0)
        {
            GameManager.instance.RedKey--;
            opened = true;
            return true;
        }
        if (doorColor == KeyColor.Blue && GameManager.instance.BlueKey > 0)
        {
            GameManager.instance.BlueKey--;
            opened = true;
            return true;
        }
        if (doorColor == KeyColor.Green && GameManager.instance.GreenKey > 0)
        {
            GameManager.instance.GreenKey--;
            opened = true;
            return true;
        }
        Debug.Log("You don't have a key");
        return false;
    }
}
