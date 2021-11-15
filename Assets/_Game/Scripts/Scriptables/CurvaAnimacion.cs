using UnityEngine;
[CreateAssetMenu(fileName = "Curva", menuName = "Morion/Curva", order = 1)]
public class CurvaAnimacion : ScriptableObject
{
    public AnimationCurve curva;
    public float GetPunto(float t)
	{
		return curva.Evaluate(t);
	}
}
