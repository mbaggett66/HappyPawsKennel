using HappyPawsKennel.Data;

namespace HappyPawsKennel.Services
{
    public class KennelService : IKennelService
    {
        private readonly HappyPawsContext _context;

        public KennelService(HappyPawsContext context)
        {
            _context = context;
        }

        public int GetAvailableKennelCount()
        {
            // Return a placeholder number until kennel data is added
            return 5;
        }
    }
}
