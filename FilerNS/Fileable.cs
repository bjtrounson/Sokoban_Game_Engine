using BaseNS;

namespace FilerNS
{
    public class Fileable : IFileable
    {
        private readonly Level _level;
        
        public Fileable(Level level)
        {
            _level = level;
        }
        
        public Part WhatsAt(int row, int column)
        {
            return _level.GetPartAtIndex(row, column);
        }

        public int GetColumnCount()
        {
            return _level.Width;
        }

        public int GetRowCount()
        {
            return _level.Height;
        }
    }
}