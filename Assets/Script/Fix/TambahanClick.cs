using UnityEngine;

public class TambahanClick : MonoBehaviour
{
    public int faktaIndexClick;
    public MateriTambahan matTam;
    public void IndexReplace()
    {
        matTam.currentFaktaIndex = faktaIndexClick;
        matTam.MateriTampilClick();
    }
}
