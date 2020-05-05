namespace LiquidGenerator.Cli.Usecase
{
    public interface IUsecase<T>
    {
        T Execute();
    }
}