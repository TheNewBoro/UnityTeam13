using UnityEngine;

public class Weapons : MonoBehaviour
{
    public int id;
    public int prefabID;
    public float damage;
    public float speed;
    public int count;

    float timer;

    private void Start()
    {
        Init();
    }

    private void Update()
    {

    }

    public void Init()
    {
        switch (id)
        {
            case 0:

                break;
            default:
                break;
        }
    }
}
