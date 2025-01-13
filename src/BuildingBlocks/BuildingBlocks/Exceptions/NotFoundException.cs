namespace BuildingBlocks.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string name, object id) : base($"The entity {name} with an ID: {id} is not found")
    {
    }
}
