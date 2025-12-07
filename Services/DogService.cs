using HappyPawsKennel.Data;
using HappyPawsKennel.Models;
using Microsoft.EntityFrameworkCore;

public class DogService : IDogService
{
    private readonly HappyPawsContext _context;

    public DogService(HappyPawsContext context)
    {
        _context = context;
    }

    public async Task<List<Dog>> GetDogsByBreedAsync(string breed)
    {
        return await _context.Dogs
            .FromSqlInterpolated($"EXEC GetDogsByBreed {breed}")
            .ToListAsync();
    }
}
