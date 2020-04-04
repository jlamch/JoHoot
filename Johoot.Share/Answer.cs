namespace Johoot.Data
{
  public class Answer
  {
    public Question ParentQuestion { get; set; }

    public string Text { get; set; }
    public bool? IsCorrect { get; set; }
    public long Id { get; set; }
  }
}