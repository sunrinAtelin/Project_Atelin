using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ObserveBase : MonoBehaviour
{
    [SerializeField] protected GameObject ObserveParent;
    protected bool[] observed;
    //������ �͵�

    protected bool done;
    //�� �������� ��ü�� ������


    private void Start()
    {
        observed = ObserveParent.GetComponentsInChildren<ObservedObjectBase>().Select(oa => oa.areadone).ToArray();
        //���ô��ϴ¾ֵ� �θ� �����ͼ� �ֵ鰨���ϱ� 

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
            //��ü �� �����ߴ��� Ȯ���ϱ�
        }
        done = true;
        return;
    }
}
