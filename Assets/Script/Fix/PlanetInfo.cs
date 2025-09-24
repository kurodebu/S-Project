using UnityEngine;

public class PlanetInfo : MonoBehaviour
{
    public string namaPlanet;
    public string materiPlanet;
    public MateriTampil mt;

    /// <summary>
    /// Call this method to update materiurutan when clicked.
    /// </summary>
    public void UpdateMateriurutan()
    {
        mt.materiPlanetUsed = materiPlanet;
        mt.namaText.text = namaPlanet;
        mt.TampilkanMateriurutan();
    }
}
