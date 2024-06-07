using UnityEngine;

[CreateAssetMenu(fileName = "Result_", menuName = "Combination/Result")]
public class ResultData : ScriptableObject
{
    [SerializeField] private string resultName;
    [SerializeField] private string resultDescription;
    [SerializeField] private Sprite resultSprite;

    public string ResultName { get => resultName; set => resultName = value; }
    public string ResultDescription { get => resultDescription; set => resultDescription = value; }
    public Sprite ResultSprite { get => resultSprite; set => resultSprite = value; }
}
