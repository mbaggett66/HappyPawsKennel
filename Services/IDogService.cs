using HappyPawsKennel.Models;

public interface IDogService
{
    Task<List<Dog>> GetDogsByBreedAsync(string breed);
}
