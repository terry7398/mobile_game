using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonManager<CharacterManager>
{
    private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float jump_speed;
    public Vector3 CurrPos = new();
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.1f);
        if (Mathf.Round(CurrPos.x * 10f) == Mathf.Round(transform.position.x * 10f) &&
    Mathf.Round(CurrPos.y * 10f) == Mathf.Round(transform.position.y * 10f) &&
    Mathf.Round(CurrPos.z * 10f) == Mathf.Round(transform.position.z * 10f))
        {
            for (int i = 0; i < 50; i++)
            {
                    transform.Translate(Vector3.up * Time.deltaTime * jump_speed);
                    yield return new WaitForSeconds(0.001f);
            }
        }
    }
    public void Move(string Direction)
    {
        switch (Direction)
        {
            case "Forward":
                
                animator.SetFloat("RunState", 0.5f);
                transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
                break;

            case "Back":
                animator.SetFloat("RunState", 0.5f);
                transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
                break;

            case "Jump":
                CurrPos = transform.position;
                StartCoroutine(Jump());
                break;

            case "None":
                animator.SetFloat("RunState", 0);
                break;
        }
    }
}


