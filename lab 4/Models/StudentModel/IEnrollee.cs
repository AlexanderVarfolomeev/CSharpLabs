namespace StudentModel;

public interface IEnrollee
{
    public string Name { get; set; }
    public void ToStudy();
    public void ToReadBook();
}