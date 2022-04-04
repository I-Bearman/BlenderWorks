using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] weapon;
    private int presentIndex, previousIndex;
    private string num;
    private Animator anim;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        previousIndex = -1;
        EquipNext(0);
    }
    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            if (presentIndex < weapon.Length-1)
            {
                EquipNext(presentIndex + 1);
            }
            else
            {
                EquipNext(0);
            }
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if (presentIndex > 0)
            {
                EquipNext(presentIndex - 1);
            }
            else
            {
                EquipNext(weapon.Length-1);
            }
        }

        #region SetAnimation

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("Strike");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("Upward Strike");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("Round Strike");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetTrigger("Combo");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            anim.SetTrigger("Kick");
        }
        #endregion


    }

    private void EquipNext(int index)
    {
        presentIndex = index;
        weapon[presentIndex].gameObject.SetActive(true);
        if (previousIndex > -1)
        {
            weapon[previousIndex].gameObject.SetActive(false);
        }
        previousIndex = presentIndex;
    }
}
