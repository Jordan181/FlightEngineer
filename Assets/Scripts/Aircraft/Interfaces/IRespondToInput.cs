namespace Aircraft.Interfaces
{
    public interface IRespondToInput
    {
        InputKey InputKey { get; }

        void Respond(float inputValue);
    }
}
