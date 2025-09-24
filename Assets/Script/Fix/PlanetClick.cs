using UnityEngine;

public class PlanetClick : MonoBehaviour
{
    public int planetIndexClick;
    public MateriSelection matSel;
    public void IndexReplace()
    {
        matSel.currentPlanetIndex = planetIndexClick;
        matSel.MateriTampilClick();
    }
}
