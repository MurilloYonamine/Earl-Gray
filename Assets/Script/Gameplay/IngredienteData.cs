using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient_", menuName = "Combination/Ingredient")]
public class IngredienteData : ScriptableObject
{
    [SerializeField] private string ingredientName;
    [SerializeField] private string ingredientDescription;
    [SerializeField] private Sprite ingredientSprite;

    public string IngredientName  => ingredientName; 
    public string IngredientDescription { get => ingredientDescription; set => ingredientDescription = value; }
    public Sprite IngredientSprite { get => ingredientSprite; set => ingredientSprite = value; }
}
