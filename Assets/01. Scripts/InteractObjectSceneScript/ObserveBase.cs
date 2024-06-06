using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ObserveBase : MonoBehaviour
{
    [SerializeField] protected GameObject ObserveParent;
    protected bool[] observed;
    //감시할 것들

    protected bool done;
    //이 옵저버의 전체가 끝나면


    private void Start()
    {
        observed = ObserveParent.GetComponentsInChildren<ObservedObjectBase>().Select(oa => oa.areadone).ToArray();
        //감시당하는애들 부모 가져와서 애들감시하기 

        for (int i = 0; i < observed.Length; i++)
        {
            print(observed[i]);
        }
    }


    public void IsAllOccupied()
    {

        for (int i = 0; i < observed.Length; i++)
        {

            if (observed[i] == false)
            {
                done = false;
                return;
            }
            //전체 다 점령했는지 확인하기
        }
        done = true;
        return;
    }
}
