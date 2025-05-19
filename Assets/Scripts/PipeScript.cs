using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField]
    private Transform topPipe;

    [SerializeField]
    private Transform bottomPipe;
    public void SetGap(float gap)
    {
        topPipe.localPosition = new Vector3(0, gap, 0);
        bottomPipe.localPosition = new Vector3(0, -gap, 0);
    }

}
