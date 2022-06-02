public interface IPullObjects<TObject> where TObject : IResetable
{
    public  TObject Create();
    public void Destroy(TObject obj);
}
