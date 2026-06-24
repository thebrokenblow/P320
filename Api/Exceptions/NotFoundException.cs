namespace Api.Exceptions;

public class NotFoundException(string error) : Exception(error)
{
}