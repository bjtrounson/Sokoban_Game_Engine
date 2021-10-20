namespace FilerNS
{
    public class Filer : IFiler
    {
        private Saver _saver;
        private Loader _loader;

        public Filer(Saver saver, Loader loader)
        {
            _saver = saver;
            _loader = loader;
        }

        public void Save(string filename, IFileable callMeBackforDetails)
        {
            _saver.Save(filename, callMeBackforDetails);
        }

        public string Load(string filename)
        {
            return _loader.Load(filename);
        }
    }
}