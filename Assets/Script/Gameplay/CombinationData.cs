using UnityEngine;

[CreateAssetMenu(fileName = "Combination_", menuName = "Combination/Combination")]
public class CombinationData : ScriptableObject
{
    [SerializeField] private IngredienteData[] ingredients;
    [SerializeField] private ResultData result;

    public IngredienteData[] Ingredients { get => ingredients; set => ingredients = value; }
    public ResultData Result { get => result; set => result = value; }
}
